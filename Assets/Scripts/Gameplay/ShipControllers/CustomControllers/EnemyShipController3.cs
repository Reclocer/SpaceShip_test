using System.Collections;
using System.Collections.Generic;
using Gameplay.Helpers;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class EnemyShipController3 : ShipController
    {       
        [SerializeField]
        private Vector2 _fireDelay;

        private Camera _camera;

        private bool _fire = true;

        [SerializeField] private SpriteRenderer _representation;
        private Bounds _bounds;
        private float _rightBound;        
        private float _leftBound;  
        private bool _rightScreenBoundFlag = false;

        private void Start()
        {
            _camera = Camera.main;
            Vector2 screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width,
                                                                          Screen.height,
                                                                          _camera.transform.position.z));

            _bounds = _representation.bounds;
            _rightBound = screenBounds.x - _bounds.size.x / 2;
            _leftBound = -screenBounds.x + _bounds.size.x / 2;            
        }  

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            Vector3 transformPosition = transform.position;
            float positionX = 0;
            
            if (_rightBound > transformPosition.x && !_rightScreenBoundFlag)
            {
                positionX = Time.deltaTime * -1;
                float bound = _rightBound - 2;                

                if (bound < transformPosition.x)
                {
                    _rightScreenBoundFlag = true;
                }
            }
            else if (_leftBound < transformPosition.x && _rightScreenBoundFlag)
            {
                positionX = Time.deltaTime ;
                float bound = _leftBound + 2;
                
                if (bound > transformPosition.x)
                {
                    _rightScreenBoundFlag = false;
                }
            }

            if (GameAreaHelper.RestrictLateralMovement(ref transformPosition, positionX, _bounds , _camera))
            {
                movementSystem.LateralMovement(positionX);
            }
            else
            {
                transform.position = transformPosition;
            }
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (!_fire)
                return;

            fireSystem.TriggerFire();
            StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
        }

        private IEnumerator FireDelay(float delay)
        {
            _fire = false;
            yield return new WaitForSeconds(delay);
            _fire = true;
        }
    }
}

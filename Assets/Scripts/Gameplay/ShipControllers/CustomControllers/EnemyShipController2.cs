using Gameplay.ShipSystems;
using Gameplay.Helpers;
using UnityEngine;
using System.Collections;

namespace Gameplay.ShipControllers.CustomControllers
{    
    public class EnemyShipController2 : ShipController
    {
        private Transform _playerShipTransform;        
        private float _playerPositionX = 0;        
        [SerializeField] private float _findPositionTimeDelay = 1;
        private bool _find = true;

        [SerializeField]
        private Vector2 _fireDelay;

        private bool _fire = true;

        [SerializeField] private SpriteRenderer _representation;

        private void Start()
        {
            _playerShipTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            Vector3 transformPosition = transform.position;
            float positionX = 0;

            if(_playerPositionX < transformPosition.x)
            {
                positionX = Time.deltaTime;                
            }
            else
            {
                positionX = Time.deltaTime * -1;                
            }

            if (GameAreaHelper.RestrictLateralMovement(ref transformPosition, positionX, _representation.bounds, Camera.main))
            {
                movementSystem.LateralMovement(positionX);
            }
            else
            {
                transform.position = transformPosition;
            }

            if (!_find)
                return;

            StartCoroutine(FindPlayerPosition());
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

        private IEnumerator FindPlayerPosition()
        {
            _find = false;
            yield return new WaitForSeconds(_findPositionTimeDelay);
            _find = true;

            if (_playerShipTransform)
            {
                _playerPositionX = _playerShipTransform.position.x;
            }
        }
    }
}

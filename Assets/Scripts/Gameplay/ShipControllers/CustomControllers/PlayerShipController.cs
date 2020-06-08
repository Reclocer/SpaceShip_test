using Gameplay.Spaceships;
using Gameplay.ShipSystems;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{    
    public class PlayerShipController : ShipController
    {
        [SerializeField] private SpriteRenderer _representation;

        private IUserControl _userControl;

        public override void Init(ISpaceship spaceship)
        {
            base.Init(spaceship);
            _userControl = GetComponent<IUserControl>();
        }

        /// <summary>
        /// Set control system
        /// </summary>
        /// <param name="userControl"></param>
        public void SetControl(IUserControl userControl)
        {
            if (_userControl != null)
            {
                Destroy(_userControl.Object);
            }

            _userControl = userControl;
        }

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            if (_userControl == null)
                return;
            
            float positionX = _userControl.X * Time.deltaTime;            
            Vector3 transformPosition = transform.position;

            if (GameAreaHelper.RestrictLateralMovement(ref transformPosition, positionX, _representation.bounds, Camera.main))
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
            if (_userControl == null)
                return;

            if (_userControl.Key)
            {
                fireSystem.TriggerFire();
            }
        }
    }
}

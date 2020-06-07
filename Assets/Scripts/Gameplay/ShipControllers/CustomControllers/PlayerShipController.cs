using Gameplay.Spaceships;
using Gameplay.ShipSystems;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    [RequireComponent(typeof(Spaceship))]
    public class PlayerShipController : ShipController
    {
        [SerializeField] private SpriteRenderer _representation;

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            float positionX = Input.GetAxis("Horizontal") * Time.deltaTime;
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
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }
    }
}

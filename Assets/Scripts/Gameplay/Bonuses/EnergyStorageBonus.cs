using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class EnergyStorageBonus : BonusBase, IEnergyDealer
    {
        [SerializeField] private float _energy = 1;
        /// <summary>
        /// Energy Value
        /// </summary>
        public float Energy => _energy;

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            var weaponSystem = other.gameObject.GetComponent<IWeaponSystem>();

            if (weaponSystem != null
                && weaponSystem.BattleIdentity == ForBattleIdentity)
            {
                weaponSystem.ReductionWeaponCoolDownTime(this);
                Destroy(gameObject);
            }
        }

        protected override void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
    }
}

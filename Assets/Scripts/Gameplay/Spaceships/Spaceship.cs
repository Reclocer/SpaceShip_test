using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public abstract class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        protected ShipController _shipController;

        [SerializeField]
        protected MovementSystem _movementSystem;

        [SerializeField]
        protected WeaponSystem _weaponSystem;

        [SerializeField]
        protected UnitBattleIdentity _battleIdentity;


        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        [SerializeField] protected float _health = 1;
        /// <summary>
        /// Health
        /// </summary>
        public float Health => _health;

        [SerializeField] protected float _maxHealth = 1;
        /// <summary>
        /// Max health points
        /// </summary>
        public float MaxHealth => _health;

        protected void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public virtual void ApplyDamage(IDamageDealer damageDealer)
        {
            _health -= damageDealer.Damage;

            if (_health <= 0)
            {
                DestroyShip();
            }
        }

        protected virtual void DestroyShip()
        {
            Destroy(gameObject);
        }
    }
}

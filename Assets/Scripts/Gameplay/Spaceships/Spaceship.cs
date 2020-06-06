using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using Gameplay.Core;
using UnityEngine;
using System;

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
        
        [SerializeField] protected NextFloat _health = new NextFloat();
        /// <summary>
        /// Health
        /// </summary>
        public float Health => _health.Value;

        [SerializeField] protected float _maxHealth = 1;
        /// <summary>
        /// Max health points
        /// </summary>
        public float MaxHealth => _maxHealth;
                
        protected Action _shipDestroyed = () => { ShipDestroyed(); };
        /// <summary>
        /// Action after destroy this ship 
        /// </summary>
        public static event Action ShipDestroyed = () => { };

        protected virtual void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);

            //Health value normalize
            if(_health.Value > _maxHealth)
            {
                _health.Value = _maxHealth;
            }
        }        

        public virtual void ApplyDamage(IDamageDealer damageDealer)
        {
            _health.Value -= damageDealer.Damage;

            if (_health.Value <= 0)
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

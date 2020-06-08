using System;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {
        [SerializeField]
        protected float _speed;

        [SerializeField] 
        protected float _damage;
        
        protected UnitBattleIdentity _battleIdentity;
        /// <summary>
        /// Which side
        /// </summary>
        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        public float Damage => _damage;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }        

        protected void Update()
        {
            Move(_speed);
        }
        
        protected void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();
            
            if (damagableObject != null 
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ApplyDamage(this);
            }
        }

        protected abstract void Move(float speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Weapons;

namespace Gameplay.Bonuses
{
    public abstract class BonusBase : MonoBehaviour
    {
        [SerializeField]
        protected float _speed;

        [SerializeField] protected UnitBattleIdentity _forBattleIdentity;
        /// <summary>
        /// Which side
        /// </summary>
        public UnitBattleIdentity ForBattleIdentity => _forBattleIdentity;
        
        protected void Update()
        {
            Move(_speed);
        }

        protected abstract void Move(float speed);

        protected abstract void OnCollisionEnter2D(Collision2D other);
    }
}

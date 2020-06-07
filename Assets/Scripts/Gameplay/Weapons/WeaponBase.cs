using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {        
        [SerializeField]
        protected Transform _barrel;

        [SerializeField]
        protected float _cooldown;

        protected bool _readyToFire = true;
        protected UnitBattleIdentity _battleIdentity;
               
        public virtual void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }

        public abstract void TriggerFire();
        
        protected IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }
    }
}

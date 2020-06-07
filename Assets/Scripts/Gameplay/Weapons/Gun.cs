using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Gun : WeaponBase
    {
        [SerializeField]
        protected Projectile _projectile;

        public override void Init(UnitBattleIdentity battleIdentity)
        {
            base.Init(battleIdentity);
        }

        public override void TriggerFire()
        {
            if (!_readyToFire)
                return;

            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            StartCoroutine(Reload(_cooldown));
        }
    }
}

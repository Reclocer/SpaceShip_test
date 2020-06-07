using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class MissileLauncher : WeaponBase
    {
        [SerializeField]
        private Missile _projectile;

        [SerializeField]
        private MissileSO _missile;
                
        public override void TriggerFire()
        {
            if (!_readyToFire)
                return;

            Missile proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            proj.SetML(_missile);
            StartCoroutine(Reload(_cooldown));
        }
    }
}

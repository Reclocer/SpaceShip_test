using System.Collections.Generic;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    [RequireComponent(typeof(Spaceship))]
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Gun> _guns;

        [SerializeField]
        private List<MissileLauncher> _missileLauncher;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _guns.ForEach(w => w.Init(battleIdentity));
            _missileLauncher.ForEach(w => w.Init(battleIdentity));
        }        
        
        public void TriggerFire()
        {
            _guns.ForEach(w => w.TriggerFire());
            _missileLauncher.ForEach(w => w.TriggerFire());
        }

    }
}

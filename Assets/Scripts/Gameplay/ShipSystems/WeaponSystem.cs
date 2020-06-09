using System.Collections.Generic;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using Gameplay.Bonuses;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    [RequireComponent(typeof(Spaceship))]
    public class WeaponSystem : MonoBehaviour, IWeaponSystem
    {
        [SerializeField] private UnitBattleIdentity _battleIdentity;
        /// <summary>
        /// Which side
        /// </summary>
        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        [SerializeField]
        private List<Gun> _guns;

        [SerializeField]
        private List<MissileLauncher> _missileLauncher;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
            _guns.ForEach(w => w.Init(battleIdentity));
            _missileLauncher.ForEach(w => w.Init(battleIdentity));
        }        
        
        public void TriggerFire()
        {
            _guns.ForEach(gun => gun.TriggerFire());
            _missileLauncher.ForEach(ml => ml.TriggerFire());
        }

        public void ReductionWeaponCoolDownTime(IEnergyDealer energyDealer)
        {
            _guns.ForEach(gun => gun.ReductionCooldownTime(energyDealer.Energy));            
        }
    }
}

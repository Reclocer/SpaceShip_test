using Gameplay.Bonuses;

namespace Gameplay.ShipSystems
{
    public interface IWeaponSystem 
    {
        UnitBattleIdentity BattleIdentity { get; }

        void ReductionWeaponCoolDownTime(IEnergyDealer energyDealer);
    }
}

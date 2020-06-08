namespace Gameplay.Bonuses
{
    public interface IEnergyDealer
    {
        UnitBattleIdentity ForBattleIdentity { get; }

        float Energy { get; }
    }
}

namespace Gameplay.Bonuses
{
    public interface IHealthDealer
    {
        UnitBattleIdentity ForBattleIdentity { get; }

        float Health { get; }
    }
}
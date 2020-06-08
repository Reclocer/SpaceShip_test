namespace Gameplay.Bonuses
{
    public interface IRecoverable
    {
        float Health { get; }
        float MaxHealth { get; }

        UnitBattleIdentity BattleIdentity { get; }

        void ApplyHealth(IHealthDealer healthDealer);
    }
}

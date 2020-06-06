using Gameplay.Weapons;

namespace Gameplay.Bonuses
{
    public interface IHealthDealer : IWithHealth
    {
        UnitBattleIdentity BattleIdentity { get; }
    }
}
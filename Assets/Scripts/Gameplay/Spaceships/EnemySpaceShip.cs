using UnityEngine;

namespace Gameplay.Spaceships
{
    public class EnemySpaceShip : Spaceship
    {
        [SerializeField] private int _scoreValueCost = 1;

        protected override void DestroyShip()
        {
            if (_battleIdentity == UnitBattleIdentity.Enemy)
            {                
                _scoreManager.AddScorePoints(_scoreValueCost);
            }

            base.DestroyShip();
        }
    }
}

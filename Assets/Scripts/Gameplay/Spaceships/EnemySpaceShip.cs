using UnityEngine;
using Gameplay.Managers;

namespace Gameplay.Spaceships
{
    public class EnemySpaceShip : Spaceship
    {
        [SerializeField] private int _scoreValueCost = 1;

        protected ScoreManager _scoreManager;

        protected override void Start()
        {
            base.Start();

            _scoreManager = FindObjectOfType<ScoreManager>();
        }

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

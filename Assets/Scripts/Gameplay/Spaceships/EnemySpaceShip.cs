using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gameplay.Weapons;
using Gameplay.Managers;

namespace Gameplay.Spaceships
{
    public class EnemySpaceShip : Spaceship
    {
        [SerializeField] private int _scoreValueCost = 1;

        protected override void DestroyShip()
        {
            if (_battleIdentity == UnitBattleIdentity.Enemy)
            {
                ScoreManager.Instance.AddScore(_scoreValueCost);
            }

            base.DestroyShip();
        }
    }
}

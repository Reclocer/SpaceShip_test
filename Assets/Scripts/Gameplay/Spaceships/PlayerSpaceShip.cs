using System;
using Gameplay.Bonuses;

namespace Gameplay.Spaceships
{
    public class PlayerSpaceShip : Spaceship
    {
        /// <summary>
        /// On change health value
        /// </summary>
        public event Action<float> RefreshHealth = (health) => { };
        
        protected override void Start()
        {
            base.Start();

            _health.AddAction((f) => { RefreshHealth(f); });
        }

        /// <summary>
        /// Apply health
        /// </summary>
        /// <param name="healthDealer">Object HealthDealer</param>
        public void ApplyHealth(IHealthDealer healthDealer)
        {
            _health.Value += healthDealer.Health;

            if (_health > _maxHealth)
            {
                _health.Value = _maxHealth;
            }
        }

        protected override void DestroyShip()
        {
            base.DestroyShip();

            _shipDestroyed();
        }
    }
}

using UnityEngine;

namespace Gameplay.Bonuses
{
    public class HealthBonus : BonusBase, IHealthDealer
    {  
        [SerializeField] private float _health = 1;
        /// <summary>
        /// Health value 
        /// </summary>
        public float Health => _health;
           
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            var recoverable = other.gameObject.GetComponent<IRecoverable>();

            if (recoverable != null
                && recoverable.BattleIdentity == ForBattleIdentity)
            {
                if (recoverable.Health < recoverable.MaxHealth)
                {
                    recoverable.ApplyHealth(this);
                    Destroy(gameObject);
                }
            }
        }

        protected override void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
    }
}

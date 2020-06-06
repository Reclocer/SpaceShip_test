using Gameplay.Core;
using Gameplay.Spaceships;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Managers
{
    public class HealthManager : SingletonBase<HealthManager>
    {
        [SerializeField] private Text _healthValueText;
        [SerializeField] private PlayerSpaceShip _spaceShip;

        private float _maxHealthPlayerShip = 1; 

        private void Start()
        {
            _maxHealthPlayerShip = _spaceShip.MaxHealth; //подразумевается что максимальное здоровье игрока меняться не будет
            OnRefreshHealth(_spaceShip.Health);

            _spaceShip.RefreshHealth += OnRefreshHealth; //объект "HealthManager" не разрушаем, отписка не требуется             
        }

        protected override HealthManager GetInstance()
        {
            return this;
        }

        //Refresh health text
        private void OnRefreshHealth(float health)
        {
            string newHealth = health.ToString();
            _healthValueText.text = $"{newHealth} / {_maxHealthPlayerShip} ";
        }
    }
}

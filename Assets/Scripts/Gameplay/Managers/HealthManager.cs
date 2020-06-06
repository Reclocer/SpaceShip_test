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

        private void Start()
        {
            OnRefreshHealth(_spaceShip.Health);
            _spaceShip.RefreshHealth += OnRefreshHealth; //объект не разрушаем, отписка не требуется         
        }

        protected override HealthManager GetInstance()
        {
            return this;
        }

        //Refresh health text
        private void OnRefreshHealth(float health)
        {
            _healthValueText.text = health.ToString();
        }
    }
}

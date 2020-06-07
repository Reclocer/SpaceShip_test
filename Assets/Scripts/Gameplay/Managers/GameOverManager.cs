using Gameplay.Core;
using Gameplay.Spaceships;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Gameplay.Managers
{
    public class GameOverManager : SingletonBase<GameOverManager>
    {
        [SerializeField] private UnityEvent _unityEvent;
        [SerializeField] private Text _totalScore;        
        [SerializeField] private PlayerSpaceShip _playerSpaceShip;

        [SerializeField] private ScoreManager _scoreManager;

        private void OnEnable()
        {
            _playerSpaceShip.ShipDestroyed += _unityEvent.Invoke;
        }

        private void Start()
        {
            //_scoreManager = ScoreManager.Instance;      
            
        }

        private void OnDisable()
        {
            _playerSpaceShip.ShipDestroyed -= _unityEvent.Invoke;
        }

        protected override GameOverManager GetInstance()
        {
            return this;
        } 
        
        /// <summary>
        /// Print total score
        /// </summary>
        public void PrintScore()
        {
            string score = _scoreManager.Score.ToString();
            _totalScore.text = $"Score: {score}";
        }

        /// <summary>
        /// Restart scene/game
        /// </summary>
        public void OnClickRestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}

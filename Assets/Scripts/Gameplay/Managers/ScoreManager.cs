using UnityEngine;
using Gameplay.Core;
using UnityEngine.UI;

namespace Gameplay.Managers
{
    public class ScoreManager : MonoBehaviour 
    {
        [SerializeField] private Text _scoreValueText;

        /// <summary>
        /// The game score
        /// </summary>
        public int Score => _score;
        private int _score = 0;                     

        /// <summary>
        /// Add score value
        /// </summary>
        /// <param name="score">Score value</param>
        public void AddScorePoints(int score)
        {
            _score += score;
            _scoreValueText.text = _score.ToString();
        }

        /// <summary>
        /// Reset score
        /// </summary>
        public void ResetScore()
        {
            _score = 0;
        }        
    }
}

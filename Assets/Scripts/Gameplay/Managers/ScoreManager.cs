using UnityEngine;
using Gameplay.Core;
using UnityEngine.UI;

namespace Gameplay.Managers
{
    public class ScoreManager : SingletonBase<ScoreManager>
    {
        [SerializeField] private Text _scoreValueText;

        private int _score = 0;
        /// <summary>
        /// The game score
        /// </summary>
        public int Score => _score;

        /// <summary>
        /// Add score value
        /// </summary>
        /// <param name="score">Score value</param>
        public void AddScore(int score)
        {
            _score += score;
            _scoreValueText.text = _score.ToString();
        }

        protected override ScoreManager GetInstance()
        {
            return this;
        }
    }
}

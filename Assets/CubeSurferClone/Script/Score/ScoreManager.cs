using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubeSurferClone.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        [SerializeField] private Text _scoreText;
        [SerializeField] private int _scoreCounter;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        public void ScoreUpdate(int score)
        {
            _scoreCounter += score;
            _scoreText.text = _scoreCounter.ToString();
        }
    }
}
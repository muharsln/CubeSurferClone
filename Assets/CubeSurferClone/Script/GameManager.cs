using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurferClone
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
        }
        public enum GameStat
        {
            Start,
            Play,
            Failed,
            Finish
        }
        public GameStat gameStat;

        public void SetGamePlayStat()
        {
            gameStat = GameStat.Play;
        }
    }
}
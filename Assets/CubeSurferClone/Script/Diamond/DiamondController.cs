using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurferClone.Diamond
{
    public class DiamondController : MonoBehaviour
    {
        public static DiamondController Instance { get; private set; }

        [SerializeField] private ParticleSystem _particleSystem;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayFX()
        {
            _particleSystem.Play();
            gameObject.SetActive(false);
        }
    }
}
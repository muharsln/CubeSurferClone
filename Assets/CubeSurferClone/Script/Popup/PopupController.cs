using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurferClone.Popup
{
    public class PopupController : MonoBehaviour
    {
        public static PopupController Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void GameObjectActive()
        {
            gameObject.SetActive(false);
        }
    }
}
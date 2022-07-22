using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurferClone.Anim
{
    public class AnimManager : MonoBehaviour
    {
        public static AnimManager Instance { get; private set; }

        [SerializeField] private Animator _chickenAnim;

        private void Awake()
        {
            Instance = this;
        }

        public void SetAnim(string animName,bool anim)
        {
            _chickenAnim.SetBool(animName, anim);
        }
    }
}
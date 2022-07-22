using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeSurferClone.Cubes
{
    public class CubeController : MonoBehaviour
    {
        public static CubeController Instance;

        public List<GameObject> cubeList = new List<GameObject>();

        public int index;

        private void Awake()
        {
            index = 0;
            Instance = this;
        }

    }

}
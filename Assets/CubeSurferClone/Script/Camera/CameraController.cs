using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace CubeSurferClone.Camera
{
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance { get; private set; }

        public GameObject target;
        public float rotateSpeed;

        Vector3 deneme = Vector3.zero;
        private void Awake()
        {
            Instance = this;
        }

        public void LateUpdate()
        {
            transform.DOLocalMoveY(5.5f + deneme.y, 1f);
            if (GameManager.Instance.gameStat == GameManager.GameStat.Finish)
            {
                CamRotate();
            }
        }

        public void CamUp()
        {
            deneme += Vector3.up / 1.75f;
        }
        //public void CamDown()
        //{
        //    deneme -= Vector3.up / 2;
        //}

        private void CamRotate()
        {
            transform.RotateAround(target.transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
    }
}
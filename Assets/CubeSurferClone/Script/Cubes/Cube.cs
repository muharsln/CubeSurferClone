using System.Collections;
using UnityEngine;
using DG.Tweening;
using CubeSurferClone.Player;

namespace CubeSurferClone.Cubes
{
    public class Cube : MonoBehaviour
    {
        private Transform _cubeParent;

        private bool _isTrigger = false;

        private void Start()
        {
            DOTween.Init(this);
            _cubeParent = transform.parent;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("NoStacked"))
            {
                Vector3 pos = CubeController.Instance.cubeList[CubeController.Instance.cubeList.Count - 1].transform.localPosition;
                other.transform.parent = _cubeParent;
                other.tag = "Stacked";
                other.transform.localPosition = pos - Vector3.up;
                other.gameObject.AddComponent<Cube>();
                other.gameObject.GetComponent<Cube>().transform.GetChild(0).gameObject.SetActive(true);
                _cubeParent.transform.localPosition += Vector3.up;
                CubeController.Instance.cubeList.Add(other.gameObject);
            }

            if (!_isTrigger && other.CompareTag("Obstacle"))
            {
                Anim.AnimManager.Instance.SetAnim("Run", true);
                _isTrigger = true;
                transform.parent = null;
                CubeController.Instance.cubeList.Remove(gameObject);
                CubeController.Instance.index++;
                if (CubeController.Instance.cubeList.Count == 0)
                {
                    GameManager.Instance.gameStat = GameManager.GameStat.Failed;
                    Anim.AnimManager.Instance.SetAnim("Run", false);
                    Anim.AnimManager.Instance.SetAnim("Dead", true);
                    StartCoroutine(PanelActive());
                }
                StartCoroutine(DeActive());
                StartCoroutine(Delay());
            }

            if (other.CompareTag("Diamond"))
            {
                other.gameObject.GetComponent<Diamond.DiamondController>().PlayFX();
                Score.ScoreManager.Instance.ScoreUpdate(10);
                UI.UIManager.Instance.DiamondScale();
            }

            if (other.CompareTag("Ground"))
            {
                Anim.AnimManager.Instance.SetAnim("Run", false);
                CubeController.Instance.index = 0;
            }

            if (other.CompareTag("Finish"))
            {
                transform.parent = null;
                Camera.CameraController.Instance.CamUp();
                CubeController.Instance.cubeList.Remove(gameObject);
                if (CubeController.Instance.cubeList.Count == 0)
                {
                    GameManager.Instance.gameStat = GameManager.GameStat.Finish;
                    StartCoroutine(PanelActive());
                }
                else
                {
                    StartCoroutine(DeActive());
                }
            }
        }

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.3f);
            _cubeParent.transform.DOLocalMoveY(_cubeParent.transform.localPosition.y - CubeController.Instance.index, .3f);
        }

        IEnumerator DeActive()
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }

        IEnumerator PanelActive()
        {
            yield return new WaitForSeconds(2f);
            switch (GameManager.Instance.gameStat)
            {
                case GameManager.GameStat.Failed:
                    UI.UIManager.Instance.ActiveGameFailed();
                    break;
                case GameManager.GameStat.Finish:
                    UI.UIManager.Instance.ActiveGameSuccess();
                    break;
                default:
                    break;
            }
        }
    }

}
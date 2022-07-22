using UnityEngine;

namespace CubeSurferClone.Player
{
    public class PlayerController : MonoBehaviour
    {
        #region Singleton
        public static PlayerController Instance { get; private set; }
        #endregion

        #region Private Serialize Field
        [Header("Move Referance")]
        [SerializeField] private bool _localMovement;
        [SerializeField] private Transform _transToMove;
        [SerializeField] private float _playerMoveSpeed;
        [SerializeField] private float _minX, _maxX;

        [Header("Path Creator")]
        [SerializeField] private PathCreation.PathCreator _pathCreator;
        [SerializeField] private PathCreation.EndOfPathInstruction _endOfPathInstruction;
        [SerializeField] private float _speed = 5;
        #endregion

        #region Private Field
        // Move Referance
        private Touch _touch;
        private Vector3 _newPos;

        // Path Creator
        private float _distanceTravelled;
        #endregion

        #region Awake
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
        #endregion

        #region Update
        private void Update()
        {
            if (GameManager.Instance.gameStat == GameManager.GameStat.Play)
            {
                PlayerMove();
            }
        }
        #endregion

        #region Player Movement
        private void PlayerForwardMove()
        {
            if (_pathCreator != null)
            {
                _distanceTravelled += _speed * Time.deltaTime;
                transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
                transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
            }
        }
        private void PlayerMove()
        {
            PlayerForwardMove();

            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Moved)
                {
                    float newX = _touch.deltaPosition.x * _playerMoveSpeed * Time.deltaTime;
                    _newPos = _localMovement ? _transToMove.localPosition : _transToMove.position;
                    _newPos.x += newX;
                    _newPos.x = Mathf.Clamp(_newPos.x, _minX, _maxX);

                    if (_localMovement)
                        _transToMove.localPosition = _newPos;
                    else
                        _transToMove.position = _newPos;
                }
            }
        }
        #endregion
    }
}
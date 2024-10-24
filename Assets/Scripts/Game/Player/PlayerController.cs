using System.Collections;
using Game.Level;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IPlayerPosition
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Joystick _joystick;
        private GameEntryPoint _gameEntryPoint;
        private float _moveSpeed;
        private Vector3 _rotation;
        public Vector3 Position { get; private set; }
        
        private void Start()
        {
            _moveSpeed = _gameEntryPoint.PlayerConfiguration.MoveSpeed;
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (true)
            {
                Vector3 direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical) * (_moveSpeed * Time.deltaTime);
                if (direction != Vector3.zero)
                {
                    _rotation = direction;
                    transform.forward = _rotation;
                    _characterController.Move(direction);
                }
                Position = transform.position;
                yield return null;
            }
        }

        [Inject] private void Construct(GameEntryPoint gameEntryPoint) => _gameEntryPoint = gameEntryPoint;
        
    }
}

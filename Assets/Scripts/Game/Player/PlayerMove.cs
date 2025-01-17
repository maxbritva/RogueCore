using Game.CameraLogic;
using Services.Input;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _moveSpeed;
        private IInputService _inputService;
        private Camera _camera;
        
        private void Awake() => _inputService = Infrastructure.Game.InputService;

        private void Start()
        {
            _camera = Camera.main;
            _camera.GetComponent<CameraFollow>().SetFollow(transform);
        }

        private void Update()
        {
            var movementVector = Vector3.zero;
            if (_inputService.Axis.sqrMagnitude > 0.001f)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0f;
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;
            _characterController.Move(movementVector * (_moveSpeed * Time.deltaTime));
        }
        
        
    }
}

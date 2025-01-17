using System;
using UnityEngine;

namespace Game.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _followTransform;
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;

        private void LateUpdate()
        {
            if(_followTransform == null)
                return;
            var rotation = Quaternion.Euler(_rotationAngleX, 0f, 0f);
            transform.position = rotation * new Vector3(0, 0, -_distance) + FollowingPosition();
            transform.rotation = rotation;
        }

        public void SetFollow(Transform target) => _followTransform = target;

        private Vector3 FollowingPosition() => 
            new Vector3(_followTransform.position.x, 0f,
                _followTransform.position.z);
    }
}
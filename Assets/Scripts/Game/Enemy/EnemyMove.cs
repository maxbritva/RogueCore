using System;
using System.Collections;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        private IPlayerPosition _playerPosition;
        private Vector3 _direction;
        private float _moveSpeed = 3f;

        private void OnEnable() => StartCoroutine(Move());

        private IEnumerator Move()
        {
            while (true)
            {
                _direction = (_playerPosition.Position - transform.position).normalized;
                transform.position += _direction * (_moveSpeed * Time.deltaTime);
                transform.forward = _direction;
                yield return null;
            }
        }


        [Inject] private void Construct(IPlayerPosition playerPosition) => _playerPosition = playerPosition;
    }
}
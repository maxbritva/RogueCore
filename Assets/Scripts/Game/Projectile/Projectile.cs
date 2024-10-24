using System.Collections;
using Game.Enemy;
using Game.Level;
using UnityEngine;
using Zenject;

namespace Game.Projectile
{
    public class Projectile : MonoBehaviour
    {
        private int _damage;
        private float _projectileSpeed;
        private GameEntryPoint _gameEntryPoint;


        private void OnEnable()
        {
            _damage = _gameEntryPoint.PlayerConfiguration.Damage;
            _projectileSpeed = _gameEntryPoint.PlayerConfiguration.Damage;
            StartCoroutine(Move());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemy))
            {
                enemy.TakeDamage(Mathf.RoundToInt(randomDamage()));
                gameObject.SetActive(false);
            }
        }

        private IEnumerator Move()
        {
            while (true)
            {
                transform.position += transform.forward * (_projectileSpeed * Time.deltaTime);
                yield return null;
            }
          
        }


        private float randomDamage() => Random.Range(_damage / 2f, _damage * 2f);

        [Inject] private void Construct(GameEntryPoint gameEntryPoint) => _gameEntryPoint = gameEntryPoint;
    }
}
using Game.Player;
using UnityEngine;

namespace Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfiguration _enemyConfiguration;
        private int _damage;
        public EnemyConfiguration EnemyConfiguration => _enemyConfiguration;

        private void OnEnable() => _damage = _enemyConfiguration.Damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerHealth player))
            {
                player.TakeDamage(_damage);
                //player.OnHealthChanged?.Invoke();
                gameObject.SetActive(false);
            }
        }

        private void SetupView()
        {
            
        }
    }
    }

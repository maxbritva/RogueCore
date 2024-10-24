using System.Collections;
using Game.FX;
using Game.Health;
using Game.UI;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemyHealth : ObjectHealth
    {
        [SerializeField] private Enemy _enemy;
        private Camera _camera;
        private DamageTextSpawner _damageTextSpawner;
        private DestroyEffectSpawner _destroyEffectSpawner;

        private void Start() => _camera = Camera.main;

        private void OnEnable()
        {
            _maxHealth = _enemy.EnemyConfiguration.MaxHealth;
            _currentHealth = _maxHealth;
            UpdateHealthBar();
            StartCoroutine(RotateBar());
        }
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            _damageTextSpawner.Activate(transform, damage);
            if (CurrentHealth <= 0)
            {
                _destroyEffectSpawner.Spawn(transform);
                gameObject.SetActive(false);
            }
        }

        private IEnumerator RotateBar()
        {
            while (gameObject.activeInHierarchy)
            {
                if(_camera)
                    _healthBar.transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
                yield return null;
            }
        }
        
        [Inject] private void Construct(DamageTextSpawner damageTextSpawner, DestroyEffectSpawner destroyEffectSpawner)
        {
            _damageTextSpawner = damageTextSpawner;
            _destroyEffectSpawner = destroyEffectSpawner;
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Health
{
    public abstract class ObjectHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] protected Image _healthBar;
        protected float _maxHealth;
        protected float _currentHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;

        private void Start() => _healthBar.transform.localScale = Vector3.one;

        public virtual void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            _currentHealth -= damage;
            UpdateHealthBar();
        }
        protected void UpdateHealthBar() => _healthBar.transform.localScale = new Vector3(_currentHealth / _maxHealth,1f,1f);
    }
}
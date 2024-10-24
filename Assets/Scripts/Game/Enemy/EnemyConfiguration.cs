using UnityEngine;

namespace Game.Enemy
{
    
    [CreateAssetMenu(fileName = "EnemyConfiguration", menuName = "Configurations/EnemyConfiguration")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _damage;
        public float MoveSpeed => _moveSpeed;
        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
    }
}
using UnityEngine;

namespace Game.Configurations
{
    [CreateAssetMenu(fileName = "PlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _moveSpeed;
        
        [Header("Gun")]
        [SerializeField] private int _damage;
        [SerializeField] private float _shootRate;
        [SerializeField] private float _aimRadius;
        [SerializeField] private float _projectileSpeed;
        
        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
        public float MoveSpeed => _moveSpeed;
        public float ShootRate => _shootRate;
        public float AimRadius => _aimRadius;
    }
}
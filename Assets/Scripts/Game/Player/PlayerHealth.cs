using System;
using Game.FX;
using Game.Health;
using Game.Level;
using Zenject;

namespace Game.Player
{
    public class PlayerHealth : ObjectHealth
    {
        private GameEntryPoint _gameEntryPoint;
        private ShakeCamera _shakeCamera;
        
        private void OnEnable()
        {
            _maxHealth = _gameEntryPoint.PlayerConfiguration.MaxHealth;
            _currentHealth = _maxHealth;
            UpdateHealthBar();
        }
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            _shakeCamera.CameraShake();
            if(_currentHealth <=0)
                _gameEntryPoint.EndGame();
                
        }
        
        [Inject] private void Construct(GameEntryPoint gameEntryPoint, ShakeCamera shakeCamera)
        {
            _gameEntryPoint = gameEntryPoint;
            _shakeCamera = shakeCamera;
        }
    }
}
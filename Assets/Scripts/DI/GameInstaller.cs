using Game.FX;
using Game.Level;
using Game.Player;
using Game.UI;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameInstaller: MonoInstaller
    {
        [SerializeField] private GameEntryPoint _gameEntryPoint;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private LevelSystem _levelSystem;
        [SerializeField] private DamageTextSpawner _damageTextSpawner;
        [SerializeField] private DestroyEffectSpawner _destroyEffectSpawner;
        [SerializeField] private ShakeCamera _shakeCamera;
        public override void InstallBindings()
        {
            Container.Bind<GameEntryPoint>().FromInstance(_gameEntryPoint).AsSingle().NonLazy();
            Container.Bind<GameTimer>().FromInstance(_gameTimer).AsSingle().NonLazy();
            Container.Bind<LevelSystem>().FromInstance(_levelSystem).AsSingle().NonLazy();
            Container.Bind<ShakeCamera>().FromInstance(_shakeCamera).AsSingle().NonLazy();
            Container.Bind<DamageTextSpawner>().FromInstance(_damageTextSpawner).AsSingle().NonLazy();
            Container.Bind<DestroyEffectSpawner>().FromInstance(_destroyEffectSpawner).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
        }
    }
}
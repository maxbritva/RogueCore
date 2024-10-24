using System.Collections;
using Game.Level;
using Game.Pool;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerGun : MonoBehaviour
    {
        [SerializeField] private GameObject _playerTurret;
        [SerializeField] private ObjectPool _objectPool;
        [SerializeField] private LayerMask _enemyMask;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private ParticleSystem _muzzleFlash;
        private GameEntryPoint _gameEntryPoint;
        private float _aimRadius = 15f;
        private Vector3 _direction;
        private WaitForSeconds _shootRate;
        private bool _isAimed;

        private void Start()
        {
            _aimRadius = _gameEntryPoint.PlayerConfiguration.AimRadius;
            _shootRate = new WaitForSeconds(_gameEntryPoint.PlayerConfiguration.ShootRate);
            StartCoroutine(Aim());
            StartCoroutine(Shoot());
        }

        private IEnumerator Aim()
        {
            while (true)
            {
                Collider[] enemyColliders = Physics.OverlapSphere(transform.position, _aimRadius, _enemyMask);
             
                if (enemyColliders.Length > 0)
                {
                    _isAimed = true;
                    Vector3 nearEnemy = enemyColliders[0].transform.position;
                    for (int i = 0; i < enemyColliders.Length ; i++)
                    {
                        if (Vector3.Distance(transform.position, enemyColliders[i].transform.position) <
                            Vector3.Distance(transform.position, nearEnemy))
                            nearEnemy = enemyColliders[i].transform.position;
                    }
                    _direction = (nearEnemy - transform.position).normalized;
                    _playerTurret.transform.forward = _direction;
                }
                else
                {
                    _isAimed = false;
                    _playerTurret.transform.forward = transform.forward;
                }
                yield return null;
            } }

        private IEnumerator Shoot()
        {
            while (true)
            {
                if (_isAimed)
                {
                    _muzzleFlash.Play();
                    var projectile = _objectPool.GetFromPool();
                    projectile.transform.SetParent(_gameEntryPoint.transform);
                    projectile.transform.forward = _direction;
                    projectile.transform.position = _shootPoint.position;
                    projectile.SetActive(true);
                    yield return _shootRate;
                }
                else
                    yield return _shootRate;
            }
        }

        [Inject]
        private void Construct(GameEntryPoint gameEntryPoint) => _gameEntryPoint = gameEntryPoint;
    }
}
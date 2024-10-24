using System.Collections;
using Game.Pool;
using Interfaces;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemySpawner : MonoBehaviour, IActivatable
    {
        [SerializeField] private float _spawnInterval;
        [SerializeField] private ObjectPool _enemyPool;
        
        private WaitForSeconds _spawnIntervalWait;
        private Coroutine _spawnCoroutine;

        private void Start() => _spawnIntervalWait = new WaitForSeconds(_spawnInterval);
        
        public void Activate() => _spawnCoroutine = StartCoroutine(Spawn());

        public void Deactivate()
        {
            if(_spawnCoroutine != null)
                StopCoroutine(_spawnCoroutine);
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                GameObject enemy = _enemyPool.GetFromPool();
                enemy.transform.SetParent(transform);
                var position = Random.insideUnitCircle;
                enemy.transform.position = new Vector3(position.x,0f, position.y)  * 35f;
                enemy.SetActive(true);
                yield return _spawnIntervalWait;
            } }
        
    }
}
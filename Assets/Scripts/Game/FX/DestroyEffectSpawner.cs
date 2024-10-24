using Game.Pool;
using UnityEngine;

namespace Game.FX
{
    public class DestroyEffectSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool _gameObjectPool;

        public void Spawn(Transform target) 
        {
            GameObject effect = _gameObjectPool.GetFromPool();
            effect.transform.position = target.position;
            effect.transform.SetParent(transform);
            effect.SetActive(true);
            if (effect.TryGetComponent(out ParticleSystem particle))
                particle.Play();
        }
    }
}
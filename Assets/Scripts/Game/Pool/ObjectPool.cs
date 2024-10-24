using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Pool
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private List<GameObject> _objectPool = new List<GameObject>();
        private DiContainer _diContainer;

        public GameObject GetFromPool()
        {
            for (int i = 0; i < _objectPool.Count; i++)
            {
                if(_objectPool[i].activeInHierarchy) continue;
                _objectPool[i].SetActive(true);
                return _objectPool[i];
            }
            GameObject newObject = Create();
            return newObject;
        }

        public GameObject Create()
        {
            GameObject newObject = _diContainer.InstantiatePrefab(_prefab);
            newObject.SetActive(false);
            _objectPool.Add(newObject);
            return newObject;
        }
       
        [Inject] private void Construct(DiContainer diContainer) => 
            _diContainer = diContainer;
    }
}
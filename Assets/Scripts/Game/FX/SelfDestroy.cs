using System.Collections;
using UnityEngine;

namespace Game.FX
{
    public class SelfDestroy : MonoBehaviour
    {
        [SerializeField] private float _destroyTimer;
        
        private WaitForSeconds _destroyTimerWait;
        
        private void Start() => _destroyTimerWait = new WaitForSeconds(_destroyTimer);

        private void OnEnable() => StartCoroutine(WaitForDestroy());

        private IEnumerator WaitForDestroy()
        {
            yield return _destroyTimerWait;
            gameObject.SetActive(false);
        }
    }
}
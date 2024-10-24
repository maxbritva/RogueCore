using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Player;
using Unity.Cinemachine;
using UnityEngine;

namespace Game.FX
{
    public class ShakeCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _camera;
        private CinemachineBasicMultiChannelPerlin _channelPerlin;
        private CancellationTokenSource _cancellationToken;
        private readonly float _shakeIntensity = 4f;
        private PlayerHealth _playerHealth;
       

        private void OnEnable()
        {
            _channelPerlin = _camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
            _cancellationToken = new CancellationTokenSource();
        }

        public async void CameraShake() => await Shake();

        private async UniTask Shake()
        {
            SetAmplitude(_shakeIntensity);
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f), _cancellationToken.IsCancellationRequested);
            SetAmplitude(0f);
            _cancellationToken.Cancel();
        }

        private void SetAmplitude(float value) => _channelPerlin.AmplitudeGain = value;
    }
}
using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts.CollectSystem
{
    public class CoinVisualizer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private FloatingText _floatingTextPrefab;

        private Vector3 _endTextPosition;
        private Vector3 _startTextPosition;

        public void Initialize()
        {
            _startTextPosition = transform.position;
            var mainCamera = Camera.main;
            _endTextPosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, mainCamera.nearClipPlane));;
        }

        public void VisualizeCollection(float collectedAmount)
        {
            _particleSystem.Emit((int)collectedAmount);
            var floatingText = Instantiate(_floatingTextPrefab);
            floatingText.Initialize(collectedAmount, _startTextPosition, _endTextPosition);
        }
    }
}
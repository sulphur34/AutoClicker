using System;
using UnityEngine;

namespace Scripts.CollectSystem
{
    public class CollectorView : MonoBehaviour
    {
        [SerializeField] private CoinVisualizer _coinVisualizer;

        private ICollect[] _collectSources;

        public void Initialize(ICollect[] collectSources)
        {
            _collectSources = collectSources;
            _coinVisualizer.Initialize();

            foreach (var source in _collectSources)
            {
                source.Collected += OnCollect;
            }
        }

        private void OnDisable()
        {
            foreach (var source in _collectSources)
            {
                source.Collected -= OnCollect;
            }
        }

        private void OnCollect(float value)
        {
            _coinVisualizer.VisualizeCollection(value);
        }
    }
}
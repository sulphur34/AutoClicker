using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts.CollectSystem
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinValueText;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _minDistance = 1f;

        private Transform _transform;
        private Vector3 _endPosition;
        private Coroutine _coroutine;

        public void Initialize(float textValue, Vector3 startPosition, Vector3 endPosition)
        {
            _coinValueText.text = textValue.ToString();
            _transform = _coinValueText.transform;
            _transform.position = startPosition;
            _endPosition = endPosition;
            _coroutine = StartCoroutine(FloatingRoutine());
        }

        private void OnDisable()
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator FloatingRoutine()
        {
            while (!IsDestinationReached())
            {
                _transform.position = Vector3.MoveTowards(
                    _transform.position,
                    _endPosition,
                    _speed * Time.deltaTime);
                yield return null;
            }

            Destroy(gameObject);
        }

        private bool IsDestinationReached()
        {
            return Vector3.Distance(_transform.position, _endPosition) <= _minDistance;
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.CollectSystem
{
    public class ClickerView : MonoBehaviour
    {
        [SerializeField] private Button _clickButton;

        public event Action Clicked;

        public void Initialize()
        {
            _clickButton.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _clickButton.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke();
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace IncomeSystem
{
    public class IncomeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;
        private IIncome _income;

        public void Initialize(IIncome income)
        {
            _income = income;
            _income.IncomeChanged += OnIncome;
        }

        private void OnDisable()
        {
            _income.IncomeChanged -= OnIncome;
        }

        private void OnIncome(float value)
        {
            _label.text = value.ToString();
        }
    }
}
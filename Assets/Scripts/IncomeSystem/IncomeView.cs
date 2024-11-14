using TMPro;
using UnityEngine;

public class IncomeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lable;
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
        _lable.text = value.ToString();
    }
}
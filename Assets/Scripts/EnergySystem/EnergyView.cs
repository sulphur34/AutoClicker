using TMPro;
using UnityEngine;

namespace EnergySystem
{
    public class EnergyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _lable;

        private IEnergyInfo _energyInfo;

        public void Initialize(IEnergyInfo energyInfo)
        {
            _energyInfo = energyInfo;
            _energyInfo.EnergyChanged += OnEnergyChanged;
        }

        private void OnEnergyChanged(int value)
        {
            _lable.text = value.ToString();
        }

        private void OnDisable()
        {
            _energyInfo.EnergyChanged += OnEnergyChanged;
        }
    }
}
using UnityEngine;

namespace Scripts.EnergySystem
{
    public class EnergyConfig : ScriptableObject
    {
        [Tooltip("Стартовое количество энергии")]
        [field: SerializeField] public int BaseEnergy { get; private set; } = 100;

        [Tooltip("Минимальное количество энергии")]
        [field: SerializeField] public int MinEnergy { get; private set; } = 100;

        [Tooltip("Максимальное количество энергии")]
        [field: SerializeField] public int MaxEnergy { get; private set; } = 100;

        [Tooltip("Количество энергии затрачиваемое на один тап")]
        [field: SerializeField] public int TapEnergy { get; private set; } = 1;

        [Tooltip("Интервал между восстановлением энергии")]
        [field: SerializeField] public float EnergyRefillInterval { get; private set; } = 1f;

        [Tooltip("Количество восстанавливаемой энергии")]
        [field: SerializeField] public int EnergyRefillValue { get; private set; } = 1;
    }
}
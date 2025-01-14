using UnityEngine;

namespace CollectSystem
{
    [CreateAssetMenu(fileName = "CurrencyConfig", menuName = "GameSettings/CurrencyConfig")]
    public class CurrencyConfig : ScriptableObject
    {
        [Tooltip("Базовое количество софт валюты, получаемое за один тап")]
        [field: SerializeField] public float BaseTapCurrency { get; private set; } = 10f;

        [Tooltip("Модификатор тапа, который влияет на доход от каждого нажатия")]
        [field: SerializeField] public float TapModifier { get; private set; } = 1f;

        [Tooltip("Интервал автосбора в секундах")]
        [field: SerializeField] public float AutoCollectInterval { get; private set; } = 5f;

        [Tooltip("Количество софт валюты, начисляемое за каждый автосбор")]
        [field: SerializeField] public float AutoCollectAmount { get; private set; } = 100f;

        [Tooltip("Бонусный процент от автосбора, который добавляется к доходу за каждый тап")]
        [field: SerializeField, Range(0f, 1f)] public float AutoCollectBonusMultiplier { get; private set; } = 0.1f;
    }
}

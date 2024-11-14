using CollectSystem;
using EnergySystem;
using IncomeSystem;
using ModifierSliderSystem;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private CurrencyConfig _currencyConfig;
    [SerializeField] private EnergyConfig _energyConfig;
    [SerializeField] private ClickerView _clickerView;
    [SerializeField] private CollectorView _collectorView;
    [SerializeField] private EnergyView _energyView;
    [SerializeField] private IncomeView _incomeView;
    [SerializeField] private ModifierSlider _modifierSlider;
    [SerializeField] private SliderValueTracker _sliderValueTracker;

    private EnergyModel _energyModel;
    private IncomeModel _incomeModel;
    private CollectorModel _collectorModel;
    private AutoCollectorModel _autoCollectorModel;
    private ICollect[] _collectSources;

    private void Awake()
    {
        _energyModel = new EnergyModel(_energyConfig, this, _clickerView);
        _autoCollectorModel = new AutoCollectorModel(_currencyConfig, this, _modifierSlider);
        _collectorModel = new CollectorModel(_energyModel, _autoCollectorModel, _currencyConfig.BaseTapCurrency);
        _collectSources = new ICollect[] { _collectorModel, _autoCollectorModel };
        _incomeModel = new IncomeModel(_collectSources);
        _clickerView.Initialize();
    }

    private void Start()
    {
        _clickerView.Initialize();
        _collectorView.Initialize(_collectSources);
        _energyView.Initialize(_energyModel);
        _incomeView.Initialize(_incomeModel);
        _sliderValueTracker.Initialize();
        _modifierSlider.Initialize(_currencyConfig.AutoCollectBonusMultiplier);
        _energyModel.Activate();
        _incomeModel.Activate();
        _autoCollectorModel.Activate();
    }

    private void OnDisable()
    {
        _energyModel.Dispose();
        _incomeModel.Dispose();
        _collectorModel.Dispose();
        _autoCollectorModel.Dispose();
    }
}
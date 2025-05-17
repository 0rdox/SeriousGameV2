using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TrainingSettings : MonoBehaviour
{
    [Header("Training Type")]
    public Dropdown imtOrEmtDropdown; // 0 = IMT, 1 = EMT
    
    [Header("Training Level")]
    public Slider trainingLevelSlider;
    public Text trainingLevelValue;

    [Header("Tolerance")]
    public Slider toleranceSlider;
    public Text toleranceValue;

    [Header("Time settings")]
    public InputField durationAboveToleranceInput; // In seconden
    public InputField valveOpenTimeInput; // In seconden

    [Header("Service Config")]
    public ServiceLocator serviceLocator;
    private DataStorageManager _storage;

    private const string TypeKey = "training_type";
    private const string LevelKey = "training_level";
    private const string ToleranceKey = "training_tolerance";
    private const string DurationKey = "training_duration_above";
    private const string ValveKey = "training_valve_trigger";

    void Start()
    {
        if (serviceLocator == null)
        {
            Debug.LogError("ServiceLocator is not assigned.");
            return;
        }
        _storage = serviceLocator.GetDataStorageManager();

        imtOrEmtDropdown.value = _storage.LoadInt(TypeKey, 0);

        trainingLevelSlider.value = _storage.LoadFloat(LevelKey, 1f);
        trainingLevelValue.text = $"{trainingLevelSlider.value:F0}";

        float savedTolerance = _storage.LoadFloat(ToleranceKey, 0.5f);
        toleranceSlider.value = Mathf.RoundToInt(savedTolerance * 10f);
        toleranceValue.text = $"{toleranceSlider.value:F1}";

        durationAboveToleranceInput.text = _storage.LoadFloat(DurationKey, 2f).ToString("F1");

        valveOpenTimeInput.text = _storage.LoadFloat(ValveKey, 1f).ToString("F1");

        imtOrEmtDropdown.onValueChanged.AddListener(OnTrainingTypeChanged);
        trainingLevelSlider.onValueChanged.AddListener(UpdateTrainingLevel);
        toleranceSlider.onValueChanged.AddListener(UpdateTolerance);
        durationAboveToleranceInput.onEndEdit.AddListener(UpdateDurationAboveTolerance);
        valveOpenTimeInput.onEndEdit.AddListener(UpdateValveOpenTime);
    }

    void OnTrainingTypeChanged(int index)
    {
        _storage.SaveInt(TypeKey, index);
    }

    void UpdateTrainingLevel(float level)
    {
        trainingLevelValue.text = $"{level:F0}";
        _storage.SaveFloat(LevelKey, level);
    }

    void UpdateTolerance(float value)
    {
        int intValue = Mathf.RoundToInt(value);
        float tolerance = intValue / 10f;

        toleranceValue.text = $"{tolerance:F1}";
        _storage.SaveFloat(ToleranceKey, tolerance);
    }

    void UpdateDurationAboveTolerance(string input)
    {
        if (float.TryParse(input, out float duration))
        {
            _storage.SaveFloat(DurationKey, duration);
        }
        else
        {
            Debug.LogWarning("Invalid value for duration above tolerance.");
        }
    }

    void UpdateValveOpenTime(string input)
    {
        if (float.TryParse(input, out float valveTime))
        {
            _storage.SaveFloat(ValveKey, valveTime);
        }
        else
        {
            Debug.LogWarning("Invalid value for valve time.");
        }
    }

    public void ResetSettings()
    {
        imtOrEmtDropdown.value = 0;
        
        trainingLevelSlider.value = 1f;
        trainingLevelValue.text = "1";

        toleranceSlider.value = 5;
        toleranceValue.text = "0.5";

        durationAboveToleranceInput.text = "2.0";
        valveOpenTimeInput.text = "1.0";

        _storage.SaveInt(TypeKey, 0);
        _storage.SaveFloat(LevelKey, 1f);
        _storage.SaveFloat(ToleranceKey, 0.5f);
        _storage.SaveFloat(DurationKey, 2f);
        _storage.SaveFloat(ValveKey, 1f);
    }
}

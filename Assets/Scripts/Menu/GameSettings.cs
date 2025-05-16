using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Slider volumeSlider;
    //public AudioSource audioSource;

    public InputField ageInputField;
    public Text ageDisplayText;

    public ServiceLocator serviceLocator;
    private DataStorageManager _storage;

    private const string VolumeKey = "game_volume";
    private const string AgeKey = "player_age";

    void Start()
    {
        if (serviceLocator == null)
        {
            Debug.LogError("ServiceLocator is not assigned.");
            return;
        }
        _storage = serviceLocator.GetDataStorageManager();

        float savedVolume = _storage.LoadFloat(VolumeKey, 1f);
        volumeSlider.value = savedVolume;
        //audioSource.volume = savedVolume;

        int savedAge = _storage.LoadInt(AgeKey, 18);
        ageInputField.text = savedAge.ToString();
        ageDisplayText.text = savedAge.ToString();

        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        ageInputField.onEndEdit.AddListener(UpdateAge);
    }

    public void UpdateVolume(float newVolume)
    {
        //audioSource.volume = newVolume;
        PlayerPrefs.SetFloat(VolumeKey, newVolume);
        PlayerPrefs.Save();
    }

    public void UpdateAge(string input)
    {
        if (int.TryParse(input, out int newAge))
        {
            ageDisplayText.text = newAge.ToString();
            PlayerPrefs.SetInt(AgeKey, newAge);
            PlayerPrefs.Save();
        }
    }

    public void ResetSettings()
    {
        volumeSlider.value = 1f;
        //audioSource.volume = 1f;
        _storage.SaveFloat(VolumeKey, 1f);

        ageInputField.text = "18";
        ageDisplayText.text = "Leeftijd: 18";
        _storage.SaveInt(AgeKey, 18);
    }
}

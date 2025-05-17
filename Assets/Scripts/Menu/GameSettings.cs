using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [Header("Volume")]
    public Slider volumeSlider;
    //public AudioSource audioSource;

    [Header("Age")]
    public InputField ageInputField;
    public Text ageDisplayText;

    [Header("Service Config")]
    public ServiceLocator serviceLocator;
    private DataStorageManager _storage;

    private const string VolumeKey = "game_volume";
    private const string AgeKey = "player_age";

    public int minAge = 5;
    public int maxAge = 18;

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
        _storage.SaveFloat(VolumeKey, newVolume);
    }

    public void UpdateAge(string input)
    {

        if (int.TryParse(input, out int newAge))
        {
            if (newAge < this.minAge || newAge > this.maxAge)
            {
                Debug.LogWarning($"Ongeldige leeftijd: {newAge}. Moet tussen {this.minAge} en {this.maxAge} liggen.");
                // fouttekst tonen
                return;
            }

            ageDisplayText.text = newAge.ToString();
            _storage.SaveInt(AgeKey, newAge);
        }
        else
        {
            Debug.LogWarning($"Kon invoer niet omzetten naar een getal: \"{input}\"");
            // fouttekst tonen
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

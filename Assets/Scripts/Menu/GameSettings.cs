using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Slider volumeSlider;
    //public AudioSource audioSource;

    public InputField ageInputField;
    public Text ageDisplayText;

    private const string VolumeKey = "game_volume";
    private const string AgeKey = "player_age";

    void Start()
    {
        Debug.Log("GameSettings script started.");
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        volumeSlider.value = savedVolume;
        Debug.Log("Volume slider value set to: " + savedVolume);
        //audioSource.volume = savedVolume;
        //Debug.Log("Audio source volume set to: " + savedVolume);

        int savedAge = PlayerPrefs.GetInt(AgeKey, 18);
        Debug.Log("Saved age from PlayerPrefs: " + savedAge);
        ageInputField.text = savedAge.ToString();
        ageDisplayText.text = savedAge.ToString();
        Debug.Log("Age input field and display text set to: " + savedAge);

        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        ageInputField.onEndEdit.AddListener(UpdateAge);
        Debug.Log("Listeners added to volume slider and age input field.");
    }

    public void UpdateVolume(float newVolume)
    {
        Debug.Log("Volume updated to: " + newVolume);
        //audioSource.volume = newVolume;
        PlayerPrefs.SetFloat(VolumeKey, newVolume);
        PlayerPrefs.Save();
        Debug.Log("Volume saved to PlayerPrefs: " + newVolume);
    }

    public void UpdateAge(string input)
    {
        Debug.Log("Age input received: " + input);
        if (int.TryParse(input, out int newAge))
        {
            Debug.Log("Parsed age: " + newAge);
            ageDisplayText.text = newAge.ToString();
            PlayerPrefs.SetInt(AgeKey, newAge);
            PlayerPrefs.Save();
            Debug.Log("Age saved to PlayerPrefs: " + newAge);
        }
    }

}

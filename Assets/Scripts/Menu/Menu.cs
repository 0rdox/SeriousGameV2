using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public string gameScene;
    public string settingsScene;
    public string logbookScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void StartSettings()
    {
        SceneManager.LoadScene(settingsScene);
    }

    public void StartLogbook()
    {
        SceneManager.LoadScene(logbookScene);
    }

}

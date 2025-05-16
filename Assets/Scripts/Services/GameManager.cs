using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/GameManager", order = 1)]
public class GameManager : ScriptableObject
{
    public float collectedEnergy;
    public bool isPlayingGame;

    public void SubtractEnergy(float amount)
    {
        if (collectedEnergy < 0)
        {
            collectedEnergy = 0;
            GameOver();
        }
        collectedEnergy -= amount;
    }

    private void GameOver()
    {
        isPlayingGame = false;
        SceneManager.LoadScene("MenuScene");
    }
}

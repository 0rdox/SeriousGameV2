using UnityEngine;

[CreateAssetMenu(fileName = "ServiceLocatorConfig", menuName = "ScriptableObjects/ServiceLocator", order = 1)]
public class ServiceLocator : ScriptableObject
{
    public GameManager gameManager;
    public ScoreManager scoreManager;

    public GameManager GetGameManager()
    {
        return gameManager;
    }

    public ScoreManager GetScoreManager()
    {
        return scoreManager;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardController : MonoBehaviour
{
    [Header("Entry References")]
    public GameObject entryTemplate;
    public Transform entryContainer;

    [Header("Service Locator")]
    public ServiceLocator serviceLocator;
    private ScoreManager scoreManager;

    void Start()
    {
        if (serviceLocator == null)
        {
            Debug.LogError("ScoreboardController: ServiceLocator not assigned.");
            return;
        }
        scoreManager = serviceLocator.GetScoreManager();
        scoreManager.Init();

        entryTemplate.SetActive(false);

        List<ScoreEntry> highScores = scoreManager.GetHighScores();

        for (int i = 0; i < highScores.Count; i++)
        {
            CreateScoreEntry(i + 1, highScores[i].score);
        }
    }

    private void CreateScoreEntry(int rank, int score)
    {
        GameObject entry = Instantiate(entryTemplate, entryContainer);
        entry.SetActive(true);

        Text rankText = entry.transform.Find("Rank text").GetComponent<Text>();
        Text scoreText = entry.transform.Find("Score text").GetComponent<Text>();

        rankText.text = $"#{rank}";
        scoreText.text = score.ToString();
    }
}

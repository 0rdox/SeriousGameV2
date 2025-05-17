using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScoreManager", menuName = "ScriptableObjects/ScoreManager")]
public class ScoreManager : ScriptableObject
{

    private const string HighScoresKey = "game_high_scores";
    public const int MaxScores = 10;

    private List<ScoreEntry> highScores = new List<ScoreEntry>();

    [Header("Service Config")]
    public ServiceLocator serviceLocator;
    //private DataStorageManager _storage;

    private bool _isInitialized = false;

    public void Init()
    {
        if (_isInitialized) return;

        if (serviceLocator == null)
        {
            Debug.LogError("ScoreManager: ServiceLocator not assigned.");
            return;
        }

        //_storage = serviceLocator.GetDataStorageManager();
        LoadScores();

        _isInitialized = true;
    }

    public void AddScore(int newScore)
    {
        highScores.Add(new ScoreEntry(newScore));
        highScores.Sort((a, b) => b.score.CompareTo(a.score));
        if (highScores.Count > MaxScores)
            highScores.RemoveRange(MaxScores, highScores.Count - MaxScores);

        SaveScores();
    }

    public List<ScoreEntry> GetHighScores() => new List<ScoreEntry>(highScores);


    private void SaveScores()
    {
        var scoreData = new ScoreListWrapper { scores = highScores };
        string json = JsonUtility.ToJson(scoreData);
        //_storage.SaveString(HighScoresKey, json);
    }

    private void LoadScores()
    {
        //string json = _storage.LoadString(HighScoresKey, "");
        //if (!string.IsNullOrEmpty(json))
        //{
        //    var scoreData = JsonUtility.FromJson<ScoreListWrapper>(json);
        //    highScores = scoreData?.scores ?? new List<ScoreEntry>();
        //}
    }

    [System.Serializable]
    private class ScoreListWrapper
    {
        public List<ScoreEntry> scores;
    }

#if UNITY_EDITOR
    [ContextMenu("Add Test Scores")]
    public void AddTestScores()
    {
        highScores.Clear();

        // Add 10 fake scores
        AddScore(9200);
        AddScore(8600);
        AddScore(7900);
        AddScore(7400);
        AddScore(6800);
        AddScore(6200);
        AddScore(5700);
        AddScore(5100);
        AddScore(4700);
        AddScore(4300);

        Debug.Log("Test scores added.");
    }
#endif

}

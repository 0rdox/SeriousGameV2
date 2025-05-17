using System;

[Serializable]
public class ScoreEntry
{
    public int score;
    public string timestamp;

    public ScoreEntry(int score)
    {
        this.score = score;
        this.timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}

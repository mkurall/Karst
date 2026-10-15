using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverText;

    private void Start()
    {
        GameOverText.SetActive(false);
    }
    public void AddSkor(int value)
    {
        score += value;

        if(ScoreText!=null)
        {
            ScoreText.text = $"Skor: {score}";
        }

    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverText.SetActive(true);
    }


}

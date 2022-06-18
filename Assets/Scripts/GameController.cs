using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score;
    public int highscore;
    public Text ScoreText;
    public Text GameOverText;
    public Text HighscoreText;
    public Player player;
    public Text WelcomeText;

    public void Awake()
    {
        HighscoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        Pause();
    }
    public void Play()
    {
        score = 0;
        ScoreText.text = "Score: " + score;
        GameOverText.gameObject.SetActive(false);
        WelcomeText.gameObject.SetActive(false);
        MoveObstacles[] obstacles = FindObjectsOfType<MoveObstacles>();
        foreach(MoveObstacles o in obstacles)
        {
            Destroy(o.gameObject);
        }
        player.transform.position = new Vector3(-7, 0, 0);
        player.direction.y = 0;
        Time.timeScale = 1f;
        player.enabled = true;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }
    public void GameOver()
    {
        
        GameOverText.gameObject.SetActive(true);
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            HighscoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
        }

        Pause();
    }
    public void ScoreUp()
    {
        score++;
        ScoreText.text = "Score: " + score;
    }
    private void Update()
    {
        if((GameOverText.gameObject.activeSelf || WelcomeText.gameObject.activeSelf) && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
            {
                Play();
            }
    }
}

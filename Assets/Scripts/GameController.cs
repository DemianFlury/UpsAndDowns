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
    public Canvas SaveScreenCanvas;
    public InputField Slot1Name;
    public InputField Slot2Name;
    public InputField Slot3Name;
    public Text Slot1Score;
    public Text Slot2Score;
    public Text Slot3Score;
    public Text PauseText;
    public float TimeScale;

    public void Awake()
    {
        HighscoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        Pause();
    }
    /// <summary>
    /// Deletes all the pipes on screen. Hides any Text and sets the score to 0. 
    /// Resets player Momentum and Position.
    /// </summary>
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
    }
    /// <summary>
    /// Sets the timescale to 0 and disables the player.
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }
    
    /// <summary>
    /// Updates the Highscore and displays the GameOverText
    /// </summary>
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
        if (GameOverText.gameObject.activeSelf  && Input.GetKeyDown(KeyCode.S))
        {
            OpenSaveScreen();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    private void OpenSaveScreen()
    {
        GameOverText.gameObject.SetActive(false);
        SaveScreenCanvas.gameObject.SetActive(true);

        Slot1Name.text = PlayerPrefs.GetString("Slot1Name", "Slot 1 empty");
        Slot1Score.text = PlayerPrefs.GetInt("Slot1Score", 0).ToString();

        Slot2Name.text = PlayerPrefs.GetString("Slot2Name", "Slot 2 empty");
        Slot2Score.text = PlayerPrefs.GetInt("Slot2Score", 0).ToString();
        
        Slot3Name.text = PlayerPrefs.GetString("Slot3Name", "Slot 3 empty");
        Slot3Score.text = PlayerPrefs.GetInt("Slot3Score", 0).ToString();
    }
    public void ExitSaveScreen()
    {
        SaveScreenCanvas.gameObject.SetActive(false);
        WelcomeText.gameObject.SetActive(true);
    }
    public void SaveSlot1()
    {
        PlayerPrefs.SetString("Slot1Name", Slot1Name.text);
        PlayerPrefs.SetInt("Slot1Score", score);
    }
    public void SaveSlot2()
    {
        PlayerPrefs.SetString("Slot2Name", Slot2Name.text);
        PlayerPrefs.SetInt("Slot2Score", score);
    }
    public void SaveSlot3()
    {
        PlayerPrefs.SetString("Slot3Name", Slot3Name.text);
        PlayerPrefs.SetInt("Slot3Score", score);
    }
    public void TogglePause()
    {
        if(PauseText.gameObject.activeSelf)
        {
            PauseText.gameObject.SetActive(false);
            Time.timeScale = TimeScale;
            player.enabled = true;
        }
        else
        {
            TimeScale = Time.timeScale;
            Pause();
            PauseText.gameObject.SetActive(true);
        }
    }
}

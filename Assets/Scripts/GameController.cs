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
    /// 
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
    }
    private void OpenSaveScreen()
    {
        GameOverText.gameObject.SetActive(false);
        SaveScreenCanvas.gameObject.SetActive(true);
        Slot1Name.text = PlayerPrefs.GetString("Slot1Name", "Slot 1 empty");
        Slot2Name.text = PlayerPrefs.GetString("Slot2Name", "Slot 2 empty");
        Slot3Name.text = PlayerPrefs.GetString("Slot3Name", "Slot 3 empty");
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
}

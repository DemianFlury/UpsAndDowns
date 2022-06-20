using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    private float leftEdge;
    public float speed;
    private GameController gamecontroller;
    private int oldscore;

    public MoveObstacles()
    {
        speed = 4f;
    }
    private void Awake()
    {
        gamecontroller = FindObjectOfType<GameController>();
    }
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
        if (ScoreIncreased(gamecontroller.score))
        {
            Time.timeScale += 0.001f;
        }
    }
    /// <summary>
    /// Checks, if the score has increased and returns a bool
    /// </summary>
    /// <param name="newscore"></param>
    /// <returns></returns>
    private bool ScoreIncreased(int newscore)
    {
        if (newscore == 0)
        {
            oldscore = 0;
        }
        else if (newscore > oldscore)
        {
            oldscore = newscore;
            return true;
        }

        return false;
    }
}
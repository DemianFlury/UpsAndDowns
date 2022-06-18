using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    private float leftEdge;
    public float speed;
    private GameController gamecontroller;
    private ObstacleSpawner spawner;
    private int oldscore;

    public MoveObstacles()
    {
        speed = 4f;
    }
    private void Awake()
    {
        gamecontroller = FindObjectOfType<GameController>();
        spawner = FindObjectOfType<ObstacleSpawner>();


    }
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
        if (IncreaseSpeed(gamecontroller.score))
        {
            Time.timeScale += 0.001f;
        }
    }
    private bool IncreaseSpeed(int score)
    {
        if(score == 0)
        {
            oldscore = 0;
        }
        else if (score > oldscore)
        {
            oldscore++;
            return true;
        }
        
        return false;
    }
}

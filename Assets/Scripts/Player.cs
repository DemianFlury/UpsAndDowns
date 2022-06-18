using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 direction;
    public static float gravity = -9.81f;
    public float force = 5f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimatePlayer), 0.15f, 0.15f);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * force;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void AnimatePlayer()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Scoring")
        {
            FindObjectOfType<GameController>().ScoreUp();
        }
        else if(other.tag == "Obstacle")
        {
            FindObjectOfType<GameController>().GameOver();
        }
    }
}

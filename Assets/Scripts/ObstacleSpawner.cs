using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 3f;
    public static float MinHeight = -2f;
    public static float MaxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0.1f, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject Tubes = Instantiate(prefab, transform.position, Quaternion.identity);
        Tubes.transform.position += Vector3.up * Random.Range(MinHeight, MaxHeight);
    }
}

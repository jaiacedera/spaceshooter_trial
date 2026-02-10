using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    float maxSpawnRate = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke ("SpawnEnemy", maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(Enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}

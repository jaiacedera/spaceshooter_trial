using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject TextScore;
    public GameObject Explosion;
    private bool isDestroyed = false;

    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 2f;
        TextScore = GameObject.FindGameObjectWithTag("ScoreTag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isDestroyed) return;
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            isDestroyed = true;
            PlayExplosion();

            TextScore.GetComponent<GameScore>().Score += 100;
            
            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}

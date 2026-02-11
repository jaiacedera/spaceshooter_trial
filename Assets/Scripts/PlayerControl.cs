using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject GameManagerGO;
    
    public GameObject PlayerBullet;
    public GameObject BulletPosition1;
    public GameObject BulletPosition2;
    public GameObject Explosion;

    public Text TextLives;

    const int Maxlives = 3;
    int lives;
    
    public float speed;
    
    public void Init()
    {
        lives = Maxlives;

        TextLives.text = lives.ToString();
        transform.position = new Vector2(0, 0);

        gameObject.SetActive(true);

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet1 = (GameObject)Instantiate (PlayerBullet);
            bullet1.transform.position = BulletPosition1.transform.position;

            GameObject bullet2 = (GameObject)Instantiate(PlayerBullet);
            bullet2.transform.position = BulletPosition2.transform.position;

        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2  (1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos = pos + direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            lives--;
            TextLives.text = lives.ToString();

            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive (false);
            }
            
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}

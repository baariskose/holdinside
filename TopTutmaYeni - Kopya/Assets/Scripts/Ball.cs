using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    GameObject target;
    public float speed;
    Vector3 lastVelocity;
    Rigidbody2D rb;
    Vector2 startForce = new Vector2(0.5f, 0.4f);
    public float maxVelocity;
    float yüzdelik;
    float time = 15;
    AudioSource audioSource;
    public AudioClip popSound,destroySound;
    GameController gameController;
    GameOverController overController;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
   
        startForce = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        gameController = GameObject.FindGameObjectWithTag("Script").GetComponent<GameController>();
        overController = GameObject.FindGameObjectWithTag("Engel").GetComponent<GameOverController>();
        rb.AddForce(startForce);
     
        audioSource = GameObject.FindGameObjectWithTag("Script").GetComponent<AudioSource>();
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
       
       if(rb.velocity.magnitude<0.8f)
        {
            rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y * 2);
            rb.AddForce(new Vector2(1f, 2f));
        }
       if(rb.velocity.magnitude > 1.4f)
        {
            rb.velocity = new Vector2(rb.velocity.x /2, rb.velocity.y / 2);
        }
       
        if(overController.balls.Count == 1 )
        {
            yüzdelik = 2.3f;
        }
        else if (overController.balls.Count == 2)
        {
            yüzdelik = 1.5f;
        }
        else if(overController.balls.Count == 3)
        {
            yüzdelik = 0.9f;
        }
        else if (overController.balls.Count == 4)
        {
            yüzdelik = 0.6f;
        }
        else if (overController.balls.Count == 5)
        {
            yüzdelik = 0.3f;
        }
        //Debug.Log("yüzdelik" + yüzdelik);
       
       
    }
    private void FixedUpdate()
    {
        rb.transform.Translate(rb.velocity * (yüzdelik) * Time.deltaTime * speed);
        // rb.AddRelativeForce(Vector3.forward*);
         //Debug.Log(gameObject.name + ":  "+rb.velocity.magnitude);
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Engel")
        {
            audioSource.PlayOneShot(destroySound);
        }
        if (collision.gameObject.tag == "Circle" || collision.gameObject.tag == "Ball" || collision.gameObject.tag =="CounterBall")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
            audioSource.PlayOneShot(popSound);
        }
       
        if(collision.gameObject.tag == "Sýnýr")
        {
            collision.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        }
    }
    
}

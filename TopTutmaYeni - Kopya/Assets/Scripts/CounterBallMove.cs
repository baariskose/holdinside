using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterBallMove : MonoBehaviour
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
    public AudioClip popSound;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startForce = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        rb.AddForce(startForce);
        yüzdelik = 0.1f;
        audioSource = GameObject.FindGameObjectWithTag("Script").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (rb.velocity.magnitude < 0.8f)
        {
            rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y * 2);
            rb.AddForce(new Vector2(1f, 2f));
        }
        lastVelocity = rb.velocity;
        rb.transform.Translate(rb.velocity * (yüzdelik / 1000000000) * Time.deltaTime * speed);
      //  Debug.Log(gameObject.name + ":  " + rb.velocity.magnitude);
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == "Circle"  || collision.gameObject.tag == "Sýnýr" || collision.gameObject.tag == "Ball" || collision.gameObject.tag == "CounterBall")
        {

            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
            audioSource.PlayOneShot(popSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if (collision.gameObject.tag == "Engel")
        //{ 
        //    GameObject go = GameObject.Find("center");
        //    gameObject.transform.position = go.transform.position;
        //}
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterBallMove1 : MonoBehaviour
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
       // rb.AddForce(startForce);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
   
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ChangeDirection")
        {
            gameObject.transform.Rotate(new Vector3(0, 0, gameObject.transform.rotation.z + 90));
        }
    }
}

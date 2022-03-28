using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterBallCollisionControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponentInParent<CircleCollider2D>().isTrigger = true;
            Debug.Log("girdi 1");
            Invoke("TriggerControl", 1);
        }
        
    }
   
    public void TriggerControl()
    {
        gameObject.GetComponentInParent<CircleCollider2D>().isTrigger = false;
        Debug.Log("girdi 2");
    }
}

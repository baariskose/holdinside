using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SınırKontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            this.GetComponent<EdgeCollider2D>().isTrigger = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.GetComponent<EdgeCollider2D>().isTrigger = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceOfCircle : MonoBehaviour
{

    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Scripts").GetComponent<GameController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.SetActive(false);
            if(gameController.balls.Count == 1)
            {
                Debug.Log("a");
                Invoke("GameObjectActive", 15);
            }
            else if (gameController.balls.Count == 2)
            {
                Invoke("GameObjectActive", 9);
            }
            else if (gameController.balls.Count == 3)
            {
                Invoke("GameObjectActive", 6);
            }
            else if (gameController.balls.Count == 4)
            {
                Invoke("GameObjectActive", 3);
                Debug.Log("x");
            }
            else if (gameController.balls.Count == 5)
            {
                Invoke("GameObjectActive", 3);
                Debug.Log("y");
            }

        }
    }
    public void GameObjectActive()
    {
        gameObject.SetActive(true);
    }
}

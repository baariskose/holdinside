using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CounterBall : MonoBehaviour
{
    public int hp;
    int startHp;
    int counter;
    public bool isZero;
    public TextMeshPro counterText;
    GameController gameController;
    GameOverController overController;
   public GameObject newBall;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("Script").GetComponent<GameController>();
        overController = GameObject.FindGameObjectWithTag("Engel").GetComponent<GameOverController>();
        isZero = false;
        startHp = hp;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = hp + "";
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Ball")
        {
            hp--;
            counter++;

            if (counter == 5 && SceneManager.GetActiveScene().buildIndex<52)
            {
                GameObject go = GameObject.Find("center");
                GameObject newBallClone = Instantiate(newBall, new Vector2(go.transform.position.x + Random.Range(0.5f, 1), go.transform.position.y + Random.Range(0.5f, 1)) , Quaternion.identity);
               overController.balls.Add(newBallClone);
                counter = 0;

            }
            if (hp <=0)
            {
                isZero = true;
                hp = 0;
                gameController.BallDelete(gameObject);
                Destroy(gameObject);
                
            }
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour{

    [SerializeField] private float forceValue = 4.5f;
    [SerializeField] Transform startPoint;
    const int startForce = 50;
    private Rigidbody2D myBody;
    const string player1Wall = "Player1Wall";
    const string player2Wall = "Player2Wall";
    private GameManager gm; 
    

    // Start is called before the first frame update
    void Start() {
        myBody = GetComponent<Rigidbody2D>();
        ResetBall();
        gm = FindObjectOfType<GameManager>();
        
       
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == player1Wall) {
            gm.AddToPlayerScore(2);
            ResetBall();
        } 
        if (collision.gameObject.tag == player2Wall) {
            gm.AddToPlayerScore(1);
            ResetBall();
        }
        
        
    }

  

    private void ResetBall() {
        transform.position = startPoint.position;
        myBody.velocity = Vector2.zero;
        myBody.AddForce(new Vector2(forceValue * startForce, startForce));

    }

}

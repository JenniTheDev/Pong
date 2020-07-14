using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    [SerializeField] bool isPlayerTwo;
    [SerializeField] float speed = 0.02f;
    Transform myTransform;

    int direction = 0; // 0 = still, 1 = up, -1 down
    float previousPositionY;


    // Start is called before the first frame update
    void Start() {
        myTransform = transform;
        previousPositionY = myTransform.position.y;
        
    }

    // Update is called once per frame
    void Update() {
        if (isPlayerTwo) {
            if (Input.GetKey("o"))
                MoveUp();
            else if (Input.GetKey("l"))
                MoveDown();
        } else {
            if (Input.GetKey("q"))
                MoveUp();
            else if (Input.GetKey("a"))
                MoveDown();
        }
    }

    void MoveUp() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y + speed);
    }

    void MoveDown() {
        myTransform.position = new Vector2(myTransform.position.x, myTransform.position.y - speed);
    }

    void LateUpdate() {
        previousPositionY = myTransform.position.y;

        if (previousPositionY > myTransform.position.y) {
            direction = -1;
        } else if (previousPositionY < myTransform.position.y) {
            direction = -1;
        } else {
            direction = 0; 
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        float adjust = 5 * direction;
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x, other.rigidbody.velocity.y + adjust);
    }


}

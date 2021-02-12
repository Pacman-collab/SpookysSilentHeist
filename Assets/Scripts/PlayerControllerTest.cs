    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTest : MonoBehaviour
{
    //Variables
    public float playerSpeed = 0.5f;
    Vector2 dest = Vector2.zero;
    public int scoreValue;
    public Text scoreText;


private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pellet")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 1;
            scoreCheck();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         dest = transform.position;
          scoreCheck();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         // Move closer to Destination
        Vector2 movement = Vector2.MoveTowards(transform.position, dest, playerSpeed);
        GetComponent<Rigidbody2D>().MovePosition(movement);
        
         // Check for Input if not moving
    if ((Vector2)transform.position == dest) {
        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            dest = (Vector2)transform.position + Vector2.up;
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            dest = (Vector2)transform.position + Vector2.right;
        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
            dest = (Vector2)transform.position - Vector2.up;
        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
            dest = (Vector2)transform.position - Vector2.right;
    }
    }

      //Collecting the pellets and scoring


    void scoreCheck()
{
    scoreText.text = "Score: " + scoreValue.ToString();
}


    bool valid(Vector2 dir)
     {
    // Ray Cast Wall Detector
    Vector2 pos = transform.position;
    RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
    return (hit.collider == GetComponent<Collider2D>()); 
    }

}

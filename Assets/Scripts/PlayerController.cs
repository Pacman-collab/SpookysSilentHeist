using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction = Vector2.zero;
    public Text points;
    public int scoreValue;
    private int pelletQuantity = 301;
    public Vector2 tpStart;
    public Vector2 tpEnd;
    public int lives = 3;
    public Vector2 spawn;
    public Text livesText;
    public Text loseText;
   
    
    
    void Start()
    {
      scoreCheck();
      gameStart();
       loseText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        Checkinput();
        Move();

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    
    //Collecting the pellets and scoring
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pellet")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 1;
            pelletQuantity -= 1;
            scoreCheck();
            

            
        }
        if (collision.collider.tag == "Bigsoul")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 50;
            scoreCheck();
            

            
        }
                if (collision.collider.tag == "PGram")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 20;
            scoreCheck();
            

            
        }
    


    if (collision.collider.tag == "Enemy")
    {
        Capture();
    }



        if(pelletQuantity == 0 )
            {
                LoadGame();
            }

 if (collision.collider.tag == "Teleporter1")
         {
            Teleport1();
         }

         if (collision.collider.tag == "Teleporter2")
         {
            Teleport2();
    }
        
    }

private void OnTriggerEnter2D(Collider2D co) {
    if (co.tag == "Enemy")
       Capture();
}



//Updates Score everytime peelet is picked up
void scoreCheck()
{
    points.text = " " + scoreValue.ToString();
}





//PLAYER MOVEMENT
void Checkinput()
{
    if (Input.GetKeyDown("a"))
    {
        direction = Vector2.left;
    }

   else if (Input.GetKeyDown("d"))
   {
        direction = Vector2.right;
   }
    
    else if (Input.GetKeyDown("w"))
   {
        direction = Vector2.up;
   }

   else if (Input.GetKeyDown("s"))
   {
       direction = Vector2.down;
   }
}

void Move ( )
{
    transform.position += (Vector3)(direction * speed) * Time.deltaTime;
}


  void LoadGame ()
   {
       SceneManager.LoadScene("Level2");
   }

   void Teleport1()
   {
       transform.position =tpEnd;
   }

   void Teleport2 ()
   {
       transform.position = tpStart;
   }

   void gameStart()
   {
       lives = 3;
       livesText.text = " X" + lives.ToString();
   }


void Capture()
{
    lives -= 1;
    transform.position = spawn;
    livesText.text = " X" + lives.ToString();
    if (lives == 0)
    {
        Destroy(gameObject);
        loseText.text = "Game Over, Press esc to restart";

    }
 
}

}






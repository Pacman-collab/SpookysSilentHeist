using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
     public Transform[] paths;
     int currentPos;
    public Animator animator;

     public float speed = 0.3f;

  
    // Update is called once per frame
    void Update()
   
    // Continuous position calculation
    {
        
        Vector3 movement= new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0.0f);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);
        if (transform.position != paths[currentPos].position) 
        { 

            Vector2 pos = Vector2.MoveTowards(transform.position, paths[currentPos].position,speed);
        GetComponent<Rigidbody2D>().MovePosition(pos);
         }
    // Waypoint reached, select next one
    else currentPos = (currentPos + 1) % paths.Length;
    }
}   

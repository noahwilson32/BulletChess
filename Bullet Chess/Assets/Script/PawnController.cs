using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{

    private Rigidbody2D my_rg;
    public float moveSpeed = 3f;
    public float momenetSmoothing;
    private Vector3 my_velocity = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        my_rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            Move("Right");
        }
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            Move("Left");
        }
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            Move("Up");
        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Move("Down");
        }
    }


    public void Move(string direction) 
    {
        Vector3 targetVelocity;
        if (direction == "Right")
        {
            targetVelocity = new Vector2(moveSpeed * .0988f, 0f);
        }
        else if (direction == "Left")
        {
            targetVelocity = new Vector2(moveSpeed * -.0988f, 0f);
        }
        else if (direction == "Up")
        {
            targetVelocity = new Vector2(0f, moveSpeed * .1013f);
        }
        else if (direction == "Down")
        {
            targetVelocity = new Vector2(0f, moveSpeed * -.1013f);
        }
        else
        {
            targetVelocity = new Vector2(my_rg.velocity.x, my_rg.velocity.y);
        }
        my_rg.velocity = Vector3.SmoothDamp(my_rg.velocity, targetVelocity, ref my_velocity, momenetSmoothing);
        
    }
}

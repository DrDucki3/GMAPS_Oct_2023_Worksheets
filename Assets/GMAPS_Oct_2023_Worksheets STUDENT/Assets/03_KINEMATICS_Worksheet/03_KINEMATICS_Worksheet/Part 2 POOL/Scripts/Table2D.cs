using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table2D : MonoBehaviour
{
    public List<Ball2D> balls; //List for storing ball gameobject

    private void Start()
    {

    }

    //Check collision between the ball gameobject and other balls
    bool CheckBallCollision(Ball2D toCheck)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            Ball2D ball = balls[i];

            if (ball.IsCollidingWith(toCheck) && toCheck != ball) //Check if ball gameobject is colldiing with other balls & prevent it from checking itself    
            {
                return true; //Detected collision
            }
        }

        return false; //No collision detected
    }

    private void FixedUpdate()
    {
        //Check if first ball in the list collides with other balls
        if (CheckBallCollision(balls[0]))
        {
            Debug.Log("COLLISION!");
        }
    }
}
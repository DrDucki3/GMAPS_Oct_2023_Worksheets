using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0); //Position of ball
    public HVector2D Velocity = new HVector2D(0, 0); //Velocity of ball

    [HideInInspector]
    public float Radius; //Radius of ball

    private void Start()
    {
        //Set initial position of the ball
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        //Calculate radius of ball based on sprite's size
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y) //Check collision between the ball and another point
    {
        //Calculate distance between the ball and the point
        float distance = (float)Util.FindDistance(Position, new HVector2D(x, y));
        return distance <= Radius; //Check if distance is within the ball's radius
    }

    public bool IsCollidingWith(Ball2D other) //Check collision between the ball and another ball
    {
        //Calculate distance between the ball and another ball
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius; //Check if distance is within the sum of both balls' radius
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime) //Update the ball's position based on its velocity
    {
        //Calculate the displacement of the x-axis & y-axis based on velocity times time
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        //Update the ball's position with new displacement values
        Position.x += displacementX;
        Position.y += displacementY;

        //Update the ball gameobject position
        transform.position = new Vector2(Position.x, Position.y);
    }
}
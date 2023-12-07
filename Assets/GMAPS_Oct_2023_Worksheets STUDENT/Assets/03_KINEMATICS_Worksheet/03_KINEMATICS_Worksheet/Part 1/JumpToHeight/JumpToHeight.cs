 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class JumpToHeight : MonoBehaviour
 {
     public float Height = 1f; //Allow the setting of Jump Height value
     Rigidbody rb; //Reference to Rigidbody

     private void Start()
     {
         rb = GetComponent<Rigidbody>(); //Each Player's Rigidbody component
     }

     void Jump()
     {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height

        //float v = 0;
        //float a = Physics.gravity.y;
        //float s = Height;
        //float u = Mathf.Sqrt(v * v - (2 * a * s));
        //rb.velocity = new Vector3(u - v, a, s);

        float u = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height); //Calculate initial upward velocity, -2 * acceleration due to gravity * displacement (Height)
        rb.velocity = new Vector3(0, u, 0); //Set inital upward velocity, u, to y-axis to simulate jump 
     }

     private void Update()
     {
        //Listens for space key to be pressed & calls Jump() method
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
     }
 }
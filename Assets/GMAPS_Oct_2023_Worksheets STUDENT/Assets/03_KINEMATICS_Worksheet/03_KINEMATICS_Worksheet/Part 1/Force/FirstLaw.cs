 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class FirstLaw : MonoBehaviour
 {
     public Vector3 force; //Allow the setting of Ball 1's force values of x, y and z in the Inspector
     Rigidbody rb; //Reference to Rigidbody

     void Start()
     {
         rb = GetComponent<Rigidbody>(); //Get Ball 1's Rigidbody component
         rb.AddForce(force, ForceMode.Force); //Applies continuous force based of values that has been set
    }

     void FixedUpdate()
     {
         Debug.Log(transform.position);
     }
 }
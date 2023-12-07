 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class Motion : MonoBehaviour
 {
     public Vector3 Velocity; //Allow the setting of Ball 2's velocity values of x, y and z in the Inspector

     void FixedUpdate()
     {
         float dt = Time.deltaTime; //Time

        //Calculate distance travelled on each axis based of velocity & time
         float dx = Velocity.x * dt;
         float dy = Velocity.y * dt;
         float dz = Velocity.z * dt;

        //Moves Ball 2 to new position based of Distance travelled for each axis
         transform.Translate(new Vector3(dx, dy, dz));
     }
 }

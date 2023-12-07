 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class Util
 {
     public static float FindDistance(HVector2D p1, HVector2D p2)
     {
        return (p1 - p2).Magnitude(); //Calculate the distance between 2 vectors by finding their magnitude
    }
 }
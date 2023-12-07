using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    void Start()
    {
        //Initialize mat as identity matrix & print it
        mat.SetIdentity(); 
        mat.Print();

        Question2();
    }

    void Question2()
    {
        //Create 2 new matrices for multiplication
        HMatrix2D mat1 = new HMatrix2D(1, 2, 3, 4, 5, 6, 7, 8, 9);
        HMatrix2D mat2 = new HMatrix2D(9, 8, 7, 6, 5, 4, 3, 2, 1);
        HMatrix2D resultMat = new HMatrix2D();

        resultMat = mat1 * mat2; //Store multiplication value into resultMat
        resultMat.Print(); //Print calculated matrix

        HVector2D vec1 = new HVector2D();
    }
}

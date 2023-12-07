using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3]; //For storing Matrix entries

    public HMatrix2D()
    {
        Entries = new float[3, 3]; //For initializing entries
    }
    
    public HMatrix2D(float[,] MultiArray)
    {
        //For Loop goes through row & column to transfer values to Entries
        for (int y = 0; y < 3; y++) //For each row
        {
            for (int x = 0; x < 3; x++) //For each column
            {
                Entries[y, x] = MultiArray[y, x];
            }
        }
    }

    //Use constructor overloading tp create matrix and specify positions (row, column) within it
    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    //Use constructer overloading for Matrix addition
    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMat = new HMatrix2D();
        for (int y = 0; y < 3; y++) //row
        {
            for (int x = 0; x < 3; x++) //column
            {
                newMat.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x];
            }
        }
        return newMat;
    }

    //Use constructer overloading for Matrix substraction
    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D newMat = new HMatrix2D();
        for (int y = 0; y < 3; y++) //row
        {
            for (int x = 0; x < 3; x++) //column
            {
                newMat.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x];
            }
        }
        return newMat;
    }

    //Use constructer overloading for Matrix multiplication by scalar
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D newMat = new HMatrix2D();
        for (int y = 0; y < 3; y++) //row
        {
            for (int x = 0; x < 3; x++) //column
            {
                newMat.Entries[y, x] = left.Entries[y, x] * scalar;
            }
        }
        return newMat;
    }

    // Note that the second argument is a HVector2D object
    //Use constructer overloading for Matrix multiplication by another vector
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y,
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y
        );
    }

    // Note that the second argument is a HMatrix2D object
    //Use constructer overloading for Matrix multiplication by another matrix
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],

            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],

            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],

            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],

            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    //Checks if 2 matrices are equal
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        //Goes through row & column
        for (int y = 0; y < 3; y++) //row
        {
            for (int x = 0; x < 3; x++) //column
            {
                //Checks if entries (values) of both matrices are not equal
                if (left.Entries[y, x] != right.Entries[y, x])
                    return false; 
            }
        }
        return true; 
    }

    //Checks if 2 matrices are not equal
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        //Goes through row & column
        for (int y = 0; y < 3; y++) //row
        {
            for (int x = 0; x < 3; x++) //column
            {
                //Checks if entries (values) of both matrices are equal
                if (left.Entries[y, x] == right.Entries[y, x])
                    return false; 
            }
        }
        return true; 
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float GetDeterminant()
    //{
    //    return // your code here
    //}

    //Set Entries value to 1 diagonally (top left to bottom right) (Identity Matrix)
    public void SetIdentity()
    {
        for (int y =  0; y < 3; y++) //Goes through row
        {
            for (int x = 0; x < 3; x++) //Goes through column
            {
                if (x == y) //Check if position of row and column is the same eg. [0, 0], [1, 1], [2, 2]
                {
                    Entries[y, x] = 1;
                }
                else
                {
                    Entries[y, x] = 0;
                }
            }
        }
    }

    // !this is for ternary operator
    // (x == y) ? Entries[y, x] = 1 : Entries [y, x] = 0;

    public void SetTranslationMat(float transX, float transY)
    {
        SetIdentity(); //Initialize the matrix with SetIdentity()
        Entries[0, 2] = transX; //Translate towards x-axis
        Entries[1, 2] = transY; //Translate towards y-axis
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity(); //Initialize the matrix with SetIdentity()
        float rad = rotDeg * Mathf.Deg2Rad; //Convert degrees to radians
        //Uses rotation matrix formula
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++) //Goes through row
        {
            for (int c = 0; c < 3; c++) //Goes through column
            {
                result += Entries[r, c] + "  "; //Appends matrix values into string format
            }
            result += "\n"; //Prints on next row
        }
        Debug.Log(result); //Print out he matrix result
    }
}
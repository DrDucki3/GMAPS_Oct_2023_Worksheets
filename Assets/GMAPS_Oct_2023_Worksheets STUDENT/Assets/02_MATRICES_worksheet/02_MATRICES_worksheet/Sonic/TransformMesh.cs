//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; } //Access to vertices

    //Matrices for transform
    private HMatrix2D transformMatrix = new HMatrix2D();

    //Matrices for concatenation
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager; //Reference MeshManager
    HVector2D pos = new HVector2D(); //Position Vector

    void Start()
    {
        meshManager = GetComponent<MeshManager>(); //Get MeshManager Component
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y); //Set initial position vector based on gameobject's position

        Translate(1, 1); //Translate gameobject to 1, 1
        Rotate(90); // Rotate gameobject to 90
    }


    void Translate(float x, float y)
    {
        //Initialize matrix as identity matrix & translate it
        transformMatrix.SetIdentity();
        transformMatrix.SetTranslationMat(x, y);
        
        Transform(); //Update position of vertices
        pos = transformMatrix * pos; //Update position vector
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        //Set matrices to origin and back to original position
        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y);

        //Rotate matrix
        rotateMatrix.SetRotationMat(angle);

        //Initialize matrix as identity matrix & calculate matrix concatenation
        transformMatrix.SetIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;

        Transform(); //Update position of vertices
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices; //Get vertices of clonedMesh from MeshManager

        //Goes through for loop and applies transformMatrix to vertices
        for (int i = 0; i < vertices.Length; i++) 
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        //Update clonedMesh's vertices with new transformed vertices
        meshManager.clonedMesh.vertices = vertices;
    }
}

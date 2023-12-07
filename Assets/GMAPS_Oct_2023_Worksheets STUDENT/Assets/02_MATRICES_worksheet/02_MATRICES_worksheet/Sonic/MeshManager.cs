/* Note that Mesh.vertices returns a copy of the vertices array for a mesh.
 * 
 * From the Unity documentation: Returns a copy of the vertex positions or assigns a 
 * new vertex positions array.
 * 
 * Mesh.vertices is actually a C# property, that doesn't just return a value. See the 
 * source code here, if you're interested:
 * 
 * https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Graphics/Mesh.cs
 * (line 143)
 */

using UnityEngine;

public class MeshManager : MonoBehaviour
{
    private MeshFilter meshFilter; //Reference MeshFilter

    [HideInInspector]
    public Mesh originalMesh, clonedMesh;

    //Allow other scripts to use the properties of vertices & triangles
    //but do not allow them to be edited
    public Vector3[] vertices { get; private set; }
    public int[] triangles { get; private set; }

    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>(); //Get MeshFilter Component
        originalMesh = meshFilter.sharedMesh; //Stores 

        //Creates new cloned mesh
        clonedMesh = new Mesh();
        clonedMesh.name = "clone";

        //Assign originalMesh's vertices, triangles, normals and uv properties & values to cloneMesh
        clonedMesh.vertices = originalMesh.vertices;
        clonedMesh.triangles = originalMesh.triangles;
        clonedMesh.normals = originalMesh.normals;
        clonedMesh.uv = originalMesh.uv;

        //Set clonedMesh as the main mesh for MeshFilter
        meshFilter.mesh = clonedMesh;

        //Store references to clonedMesh's vertices & triangles
        vertices = clonedMesh.vertices;
        triangles = clonedMesh.triangles;
    }
}
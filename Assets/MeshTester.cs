using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshTester : MonoBehaviour
{
    public Vector3[] vertices;
    public int[] triangles = new int[3];
    public Mesh mesh;
    public Vector2[] uvs;
    private void OnValidate()
    {
        mesh = new Mesh();
        mesh.Clear();




        // Призначаємо вершини та трикутники мешу
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Перераховуємо нормалі для правильного освітлення
        mesh.RecalculateNormals();

        // Додаємо MeshFilter і MeshRenderer
        var meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }
        meshFilter.sharedMesh = mesh;

        var meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = gameObject.AddComponent<MeshRenderer>();
        }

        mesh.uv = uvs;

    }

}

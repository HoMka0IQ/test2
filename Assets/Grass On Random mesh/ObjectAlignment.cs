using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAlignment : MonoBehaviour
{
    public GameObject grassPrefab;  // Префаб трави
    public Mesh planetMesh;         // Меш планети
    public float rotationOffset = 90f;  // Кут повороту між сусідніми вершинами

    private void Start()
    {
        SpawnGrass();
    }
    void SpawnGrass()
    {
        Vector3[] vertices = planetMesh.vertices;      // Вершини планети
        Vector3[] normals = planetMesh.normals;        // Нормалі до кожної вершини
        Debug.Log(vertices.Length);
        for (int i = 0; i < vertices.Length - 1; i++)
        {
            // Позиція першої вершини
            Vector3 position1 = vertices[i];
            Vector3 normal1 = normals[i];
            
            Debug.Log(vertices.Length);

            // Позиція наступної вершини
            Vector3 position2 = vertices[i + 1];
            Vector3 normal2 = normals[i + 1];

            // Спавн трави на першій вершині
            GameObject grass = Instantiate(grassPrefab, position1, Quaternion.identity);
            grass.transform.localPosition = vertices[i] * 6;
            Debug.Log(vertices[i] + " / " + position1 + " / " + vertices[i] * 6);
            // Обчислюємо орієнтацію на основі нормалей двох сусідніх вершин
            Vector3 upDirection = normal1;  // Встановлюємо "вгору" для об'єкта трави
            Vector3 forwardDirection = (position2 - position1).normalized;  // Напрямок до сусідньої вершини

            // Повертаємо траву для утворення 90 градусів між двома вершинами
            Quaternion grassRotation = Quaternion.LookRotation(forwardDirection, upDirection) * Quaternion.Euler(0, rotationOffset, 0);
            grass.transform.rotation = grassRotation;
        }
    }
}

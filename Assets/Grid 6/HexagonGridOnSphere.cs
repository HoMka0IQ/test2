using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonGridOnSphere : MonoBehaviour
{
    public int pointCount = 1000;
    public float radius = 1f;

    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        // Генерація точок на сфері
        points = GenerateFibonacciSphere(pointCount, radius);

        // Для візуалізації точок (додай сферу або куб для кожної точки, якщо потрібно)
        foreach (Vector3 point in points)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = point;
            sphere.transform.localScale = Vector3.one * 0.05f; // розмір точок
        }
    }

    List<Vector3> GenerateFibonacciSphere(int n, float radius)
    {
        List<Vector3> points = new List<Vector3>();

        float phi = Mathf.PI * (3f - Mathf.Sqrt(5f));  // золотий кут

        for (int i = 0; i < n; i++)
        {
            float y = 1 - (i / (float)(n - 1)) * 2;  // розподілення y від 1 до -1
            float radiusAtY = Mathf.Sqrt(1 - y * y);  // радіус кола на висоті y

            float theta = phi * i;  // обертання по довготі

            float x = Mathf.Cos(theta) * radiusAtY;
            float z = Mathf.Sin(theta) * radiusAtY;

            points.Add(new Vector3(x, y, z) * radius);
        }

        return points;
    }
    /*    public int numberOfHexagons = 100;  // Кількість точок (гексагонів)
        public float sphereRadius = 5f;     // Радіус сфери
        public GameObject hexagonPrefab;    // Префаб гексагону

        void Start()
        {
            // Генеруємо точки на поверхні сфери
            List<Vector3> pointsOnSphere = GeneratePointsOnSphere(numberOfHexagons, sphereRadius);

            // Створюємо гексагон на кожній точці
            foreach (Vector3 point in pointsOnSphere)
            {
                // Створюємо гексагон і встановлюємо його позицію
                GameObject hexagon = Instantiate(hexagonPrefab, point, Quaternion.identity);

                // Направляємо гексагон на центр сфери
                hexagon.transform.LookAt(Vector3.zero);
            }
        }

        // Метод для генерації рівномірних точок на сфері (Fibonacci Sphere)
        List<Vector3> GeneratePointsOnSphere(int numberOfPoints, float radius)
        {
            List<Vector3> points = new List<Vector3>();

            float phi = Mathf.PI * (3 - Mathf.Sqrt(5)); // Золотий кут

            for (int i = 0; i < numberOfPoints; i++)
            {
                float y = 1 - (i / (float)(numberOfPoints - 1)) * 2;  // Висота точки відносно центру
                float radiusAtY = Mathf.Sqrt(1 - y * y);              // Радіус кола на цій висоті
                float theta = phi * i;                                // Кут

                float x = Mathf.Cos(theta) * radiusAtY;
                float z = Mathf.Sin(theta) * radiusAtY;

                Vector3 point = new Vector3(x, y, z) * radius;
                points.Add(point);
            }
            return points;
        }*/
}

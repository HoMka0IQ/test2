using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFiller : MonoBehaviour
{
    public GameObject start;
    public GameObject end;

    public GameObject go;

    private void Start()
    {
        //start.transform.position = start.transform.position.normalized;
        //end.transform.position=end.transform.position.normalized;
        List<Vector3> pos = GenerateGridPointsOnSphereBetween(start.transform.position, end.transform.position,50,50);
        for (int i = 0; i < pos.Count; i++)
        {
            Instantiate(go, pos[i], Quaternion.identity);
        }
    }
    public List<Vector3> GenerateGridPointsOnSphereBetween(Vector3 startPoint, Vector3 endPoint, int numberOfRows, int numberOfColumns)
    {
        List<Vector3> points = new List<Vector3>();

        // Нормалізуємо точки, щоб вони лежали на сфері
        startPoint.Normalize();
        endPoint.Normalize();

        // Визначаємо полярні та азимутальні кути для стартової та кінцевої точок
        float startTheta = Mathf.Atan2(startPoint.z, startPoint.x);
        float startPhi = Mathf.Acos(startPoint.y);

        float endTheta = Mathf.Atan2(endPoint.z, endPoint.x);
        float endPhi = Mathf.Acos(endPoint.y);

        // Обчислюємо кроки по кутах для створення гріда
        float thetaStep = (endTheta - startTheta) / (numberOfColumns - 1);
        float phiStep = (endPhi - startPhi) / (numberOfRows - 1);

        // Створюємо точки по широті та довготі
        for (int i = 0; i < numberOfRows; i++)
        {
            float phi = startPhi + i * phiStep; // Від широти стартової до кінцевої

            for (int j = 0; j < numberOfColumns; j++)
            {
                float theta = startTheta + j * thetaStep; // Від довготи стартової до кінцевої

                // Перетворюємо сферичні координати в декартові (x, y, z)
                float x = Mathf.Sin(phi) * Mathf.Cos(theta);
                float y = Mathf.Cos(phi);
                float z = Mathf.Sin(phi) * Mathf.Sin(theta);

                points.Add(new Vector3(x, y, z));
            }
        }

        return points;
    }
}

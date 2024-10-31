using System.Collections.Generic;
using UnityEngine;

public class DungeonPlacerOnSphere : MonoBehaviour
{
    public int seed = 12345; // Сід для генерації
    public GameObject dungeonPrefab;
    public int numberOfDungeons = 5;

    public Vector3 planetCenter = Vector3.zero; // Центр планети

    public List<GameObject> dangeons;
    public GameObject de;
    private void OnValidate()
    {
        GenerateDungeonsOnSphere();
    }


    void GenerateDungeonsOnSphere()
    {
        System.Random random = new System.Random(seed);


        for (int i = 0; i < 10; i++)
        {
            Debug.Log(random.NextDouble());
        }
    }
}

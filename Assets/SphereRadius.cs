using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRadius : MonoBehaviour
{
    public GameObject go;
    public Transform cylinderPosition;
    public float cylinderRadius;
    void Start()
    {
       
        StartCoroutine(coroutine());
    }


    IEnumerator coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            // Отримуємо радіус циліндра та висоту
            cylinderRadius = cylinderPosition.localScale.x / 2;

            Vector3 direction = (go.transform.position - cylinderPosition.position).normalized;

            Vector3 directionXZ = new Vector3(direction.x, 0, direction.z).normalized;

            float clampedY = Mathf.Clamp(go.transform.position.y, cylinderPosition.position.y - 100, cylinderPosition.position.y + 100);
            go.transform.position = cylinderPosition.position + directionXZ * (cylinderRadius - 1);
            go.transform.position = new Vector3(go.transform.position.x, clampedY, go.transform.position.z);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotTest : MonoBehaviour
{
    public GameObject go;
    public GameObject target;
    Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
    public int i = 0;
    public Vector3 sphereCenter = Vector3.zero;

    // Позиція об'єкта на поверхні сфери
    public Vector3 goPosition = new Vector3(1, 1, 1);

    // Результуючий кватерніон, який визначає поворот об'єкта
    public Quaternion goRotation;

    void Update()
    {
        sphereCenter = target.transform.position;
        goPosition = go.transform.position;
        // Напрямок від об'єкта до центра сфери
        Vector3 directionToCenter = (sphereCenter - goPosition).normalized;

        // Оскільки ми хочемо, щоб вісь Y дивилася на центр сфери, напрямок до центра — це наша вісь Y
        Vector3 up = directionToCenter;

        // Визначаємо інші осі:
        // Обчислюємо вісь Z: візьмемо довільний вектор і отримуємо перпендикуляр через векторний добуток
        Vector3 right = Vector3.Cross(Vector3.forward, up).normalized;

        // Тепер обчислюємо вісь Z (її можна отримати за допомогою векторного добутку правої і верхньої осей)
        Vector3 forward = Vector3.Cross(up, right);

        // Створюємо кватерніон, де "up" — це наша вісь Y, а "forward" — вісь Z
        goRotation = Quaternion.LookRotation(forward, up);

        go.transform.rotation = goRotation;
    }
}

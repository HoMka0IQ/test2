using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Collidertest : MonoBehaviour
{
    public Mesh mesh;
    public MeshCollider meshCollider;
    async void Start()
    {
        await RemeshPlanetAsync();
    }
    private void Update()
    {
        meshCollider.sharedMesh = mesh;
    }
    public async Task RemeshPlanetAsync()
    {
        while (Application.isPlaying)
        {
            List<Task> remeshTasks = new List<Task>();

            remeshTasks.Add(Task.Run(() => {

                

            }));

            await Task.WhenAll(remeshTasks);
            meshCollider.sharedMesh = mesh;
            Debug.Log("sss");
            await Task.Delay(1000);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlockController : MonoBehaviour {
    public float MinVelocity = 5, MaxVelocity = 20;
    public int flockSize = 10;
    public FlockNPCController prefab;
    List<FlockNPCController> boids = new List<FlockNPCController>();
    public float flockSpreadE = 5, minDistFromPlayer=5, maxDistFromPlayer =20;
    public float velocityE = 5;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < flockSize; i++)
        {
            float x = transform.position.x, y = transform.position.y, z = transform.position.z;
            Vector3 position = new Vector3(Random.Range(x - flockSpreadE, x + flockSpreadE)
                                         , Random.Range(y - flockSpreadE, y + flockSpreadE)
                                         , Random.Range(z - flockSpreadE, z + flockSpreadE));
            FlockNPCController boid = Instantiate(prefab, position, transform.rotation) as FlockNPCController;
            boid.controller = this;
            boids.Add(boid);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public GameObject Player;
    public GameObject[] SpawnPoints;
    public GameObject ClosestSpawnPoint;
    public Vector3 closestVec;
	public GameObject PlayerCamera;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        closestVec = new Vector3(1000, 1000, 1000);
		PlayerCamera = GameObject.FindGameObjectWithTag ("PlayerCamera");
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void respawnPlayerFunction()
    {
        //print("RespawnFunction called");
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Vector3 dist = transform.position - SpawnPoints[i].transform.position;
            if (dist.magnitude < closestVec.magnitude)
            {
                closestVec = dist;
                ClosestSpawnPoint = SpawnPoints[i];
            }
        }
        Player.transform.position = ClosestSpawnPoint.transform.position;
		PlayerCamera.transform.position = ClosestSpawnPoint.transform.position;
        closestVec = new Vector3(1000, 1000, 1000);
    }
}

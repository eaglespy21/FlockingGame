using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public GameObject Player;
    public GameObject SpawnPoint;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnPoint = GameObject.FindGameObjectWithTag("Respawn");
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void respawnPlayerFunction()
    {
        print("RespawnFunction called");
        Player.transform.position = SpawnPoint.transform.position;
    }
}

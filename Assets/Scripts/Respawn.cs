using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {
    public GameObject Player;
    public GameObject SpawnPoint;
	public GameObject PlayerCamera;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        SpawnPoint = GameObject.FindGameObjectWithTag("Respawn");
		PlayerCamera = GameObject.FindGameObjectWithTag ("PlayerCamera");
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void respawnPlayerFunction()
    {
        //print("RespawnFunction called");
        Player.transform.position = SpawnPoint.transform.position;
		PlayerCamera.transform.position = SpawnPoint.transform.position;
    }
}

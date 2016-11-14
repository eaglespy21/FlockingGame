using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    public Vector3 oldV;
    public int randValue;
    public GameObject FlockSphere, Player;
    public bool toggle = true;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.forward * Random.value * GameController.speedNPC;
        FlockSphere = GameObject.Find("FlockSphere");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            float x = Player.transform.position.x, y = Player.transform.position.y, z = Player.transform.position.z;
            if (toggle)
            {
                transform.position = new Vector3(
                                Random.Range(x - GameController.BoundingSizeX, x + GameController.BoundingSizeX),
                                Random.Range(y - GameController.BoundingSizeY, y + GameController.BoundingSizeY),
                                Random.Range(z - GameController.BoundingSizeZ, z + GameController.BoundingSizeZ));
                //transform.parent = Player.transform;
                GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity;
                //GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else
            {
                transform.position = new Vector3(
                                Random.Range(x - GameController.BoundingDSizeX, x + GameController.BoundingDSizeX),
                                Random.Range(y - GameController.BoundingDSizeY, y + GameController.BoundingDSizeY),
                                Random.Range(z - GameController.BoundingDSizeZ, z + GameController.BoundingDSizeZ));
                GetComponent<Rigidbody>().velocity = Vector3.forward * Random.value * GameController.speedNPC;
            }
            toggle = !toggle;

        }

	
	}
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 7))
        {
            randValue = (int)(Random.value * 100);
            print("There is something in front of the object!");
            if (randValue % 2 == 0)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(GameController.mag, 0, 0));
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(-GameController.mag, 0, 0));
            }
            
        }
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, GameController.BL, GameController.BR), 
                                         Mathf.Clamp(transform.position.y, GameController.BG, GameController.BS), 
                                         transform.position.z);
    }

}

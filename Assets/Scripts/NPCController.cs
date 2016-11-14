using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    public float mag = 1;
    public Vector3 oldV;
    public int randValue;
    public GameObject FlockSphere, Player;
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
            float x = transform.position.x, y = transform.position.y, z = transform.position.z;
            transform.position = new Vector3(
                            Random.Range(x - GameController.BoundingSizeX, x + GameController.BoundingSizeX),
                            Random.Range(y - GameController.BoundingSizeY, y + GameController.BoundingSizeY),
                            Random.Range(z - GameController.BoundingSizeZ, z + GameController.BoundingSizeZ));
            transform.parent = FlockSphere.transform;
            GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity;
        }
	
	}
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 5))
        {
            randValue = (int)(Random.value * 100);
            //print("There is something in front of the object!");
            if (randValue % 2 == 0)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(mag, 0, 0));
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(-mag, 0, 0));
            }
            
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, GameController.BL, GameController.BR), 
                                         Mathf.Clamp(transform.position.y, GameController.BG, GameController.BS), 
                                         transform.position.z);
    }

}

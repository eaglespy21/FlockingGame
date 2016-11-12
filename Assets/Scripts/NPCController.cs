using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    public float mag = 1;
    public int randValue;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.forward * Random.value * GameController.speedNPC;
    }
	
	// Update is called once per frame
	void Update () {
	
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

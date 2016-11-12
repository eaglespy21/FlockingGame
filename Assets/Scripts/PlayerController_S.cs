using UnityEngine;
using System.Collections;

public class PlayerController_S : MonoBehaviour {
    public float speedCX = 1, speedCY = 1, speedCZ = 1;
    public float speedX, speedY, speedZ, rollAngle=10, leanAngle=10;
    public Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speedCY;

    }
	
	// Update is called once per frame
	void Update () {
        //CharacterController controller = GetComponent<CharacterController>();
        speedX = Input.GetAxis("Horizontal") * Time.deltaTime * speedCX;
        speedY = Input.GetAxis("Vertical") * Time.deltaTime * speedCY;
        speedZ = Input.GetAxis("Pitch") * Time.deltaTime * speedCZ;
        transform.Translate(speedX, speedZ, 0);
        //Possibly enumerate the title? 
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, -rollAngle);
        }
        else if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, rollAngle);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rollAngle);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, -rollAngle);
        }
        //Up/down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, leanAngle);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, -leanAngle);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, -leanAngle);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, leanAngle);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Rigidbody>().velocity = Vector3.forward * speedCY;
            //print(GetComponent<Rigidbody>().velocity);
        }
        //transform.Translate(0, 0, speedY);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, GameController.BL, GameController.BR),
                                         Mathf.Clamp(transform.position.y, GameController.BG, GameController.BS),
                                         transform.position.z); ;
	}
}

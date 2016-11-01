using UnityEngine;
using System.Collections;

public class PlayerController_S : MonoBehaviour {
    public float speedCX = 1, speedCY = 1, speedCZ = 1;
    public float speedX, speedY, speedZ;
    public Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speedCY;

    }
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        speedX = Input.GetAxis("Horizontal") * Time.deltaTime * speedCX;
        speedY = Input.GetAxis("Vertical") * Time.deltaTime * speedCY;
        //print(Input.GetAxis("Throttle"));
        //print("Speed"+speedY);
        speedZ = Input.GetAxis("Pitch") * Time.deltaTime * speedCZ;
        //transform.Rotate(speedZ, 0, 0);
        transform.Translate(speedX, 0, -speedZ);
        //moveDirection = new Vector3(speedX, 0, speedY);
        //moveDirection = transform.TransformDirection(moveDirection);
        //moveDirection *= speedCX;
        //controller.Move(moveDirection * Time.deltaTime);
        //controller.Move(transform.forward * speedY);
        //moveDirection = new Vector3(1 * speedX, 1 * speedZ, 0);
        //controller.Move(moveDirection);
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Rigidbody>().velocity = Vector3.forward * speedCY;
            //print(GetComponent<Rigidbody>().velocity);
        }
        //transform.Translate(0, 0, speedY);
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speedCX = 1, speedCY = 1, speedCZ = 1;
    public float speedX, speedY, speedZ;
    public Vector3 moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();
        speedX = Input.GetAxis("Horizontal") * Time.deltaTime * speedCX;
        speedY = Input.GetAxis("Vertical") * Time.deltaTime * speedCY;
        //print(Input.GetAxis("Throttle"));
        //print("Speed"+speedY);
        speedZ = Input.GetAxis("Pitch") * Time.deltaTime * speedCZ;
        transform.Rotate(speedZ, speedX, 0);
        //moveDirection = new Vector3(speedX, 0, speedY);
        //moveDirection = transform.TransformDirection(moveDirection);
        //moveDirection *= speedCX;
        //controller.Move(moveDirection * Time.deltaTime);
        controller.Move(transform.forward * speedY);
        //transform.Translate(0, 0, speedY);
	}
}

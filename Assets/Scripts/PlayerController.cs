using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speedCX = 1, speedCY = 1, speedCZ = 1;
    public float speedX, speedY, speedZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        speedX = Input.GetAxis("Yaw") * Time.deltaTime * speedCX;
        speedY = Input.GetAxis("Throttle") * Time.deltaTime * speedCY;
        print(Input.GetAxis("Throttle"));
        print("Speed"+speedY);
        speedY = Input.GetAxis("Pitch") * Time.deltaTime * speedCZ;
        transform.Rotate(0, speedX, speedZ);
        transform.Translate(0, 0, speedY);
	}
}

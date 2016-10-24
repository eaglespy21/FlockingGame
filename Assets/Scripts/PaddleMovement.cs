using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {
    public GameObject paddle;
    public int translateSpeed = 5;
    public int rotateSpeed = 400;
    public float xAxis, yAxis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        float temp = xAxis * Time.deltaTime * rotateSpeed;
        float temp1 = yAxis * Time.deltaTime * translateSpeed;
        transform.Translate(0, 0, temp1);
        //transform.rotation = Quaternion.Euler(0, temp1, 0);
        transform.Rotate(0, temp, 0);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f),Mathf.Clamp(transform.position.y,-10f, 10f),0);
	}
    void OnCollisionEnter(Collision collision)
    {
        //print("Collided");
    }
}

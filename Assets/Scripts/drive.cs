using UnityEngine;
using System.Collections;

public class drive : MonoBehaviour 
{

	Animator anim;

		public float speed = 10.0F;
		public float rotationSpeed = 100.0F;

	void Start()
	{
		anim = this.GetComponent<Animator>();
	}
		void Update()
	{
			float translation = Input.GetAxis("Vertical") * speed;
			float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
			translation *= Time.deltaTime;
			rotation *= Time.deltaTime;
			transform.Translate(0, 0, translation);
			transform.Rotate(0, rotation, 0);

		if(Input.GetKey("space"))
		{
			anim.SetBool ("isFlapping", true);
			transform.Translate (0, 0.3f, 0);
		}
		else 
		{
			anim.SetBool("isFlapping", false);
		}
		transform.Translate(0,-0.1f,0);
	}
			

}


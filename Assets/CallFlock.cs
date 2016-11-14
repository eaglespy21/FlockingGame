using UnityEngine;
using System.Collections;

public class CallFlock : MonoBehaviour {
	public GameObject bird1;
	public GameObject bird2;
	public GameObject bird3;
	public GameObject bird4;

	private bool flock;
	// Use this for initialization
	void Start () {
		flock = false;
		Debug.Log (flock);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("f")) {
			if (flock == false)
				flock = true;
			else if (flock == true)
				flock = false;
		}
		if(flock == true){
			bird1.transform.position = Vector3.MoveTowards (bird1.transform.position, transform.position - new Vector3 (1.25f, 0, 1.25f),10 * Time.deltaTime);
			bird2.transform.position = Vector3.MoveTowards (bird2.transform.position, transform.position - new Vector3 (0.75f, 0, 0.75f), 10 * Time.deltaTime);
			bird3.transform.position = Vector3.MoveTowards (bird3.transform.position, transform.position - new Vector3 (0.75f, 0, -0.75f), 10 * Time.deltaTime);
			bird4.transform.position = Vector3.MoveTowards (bird4.transform.position, transform.position - new Vector3 (1.25f, 0, -1.25f),10 * Time.deltaTime);
			bird1.transform.parent = transform;
			bird2.transform.parent = transform;
			bird3.transform.parent = transform;
			bird4.transform.parent = transform;

		}
		if (flock == false) {
			bird1.transform.parent = null;
			bird2.transform.parent = null;
			bird3.transform.parent = null;
			bird4.transform.parent = null;

		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EagleController : MonoBehaviour {
	public string[] array = new string[]{ "a", "w", "s","d" };
	public float time, changeTime, changeTimeValue=1000, changeTimeLevel2=500, gameTime, gameTimeValue = 20000;
	public bool flag1=false, flag2= false;
	public int life;
	public Image image_a,image_w,image_s,image_d;
	public GameObject npc;
	public GameObject npc2;
	public GameObject npc3;
	public GameObject npc4;
	public GameObject npc5;
	public GameObject npc6;
	public GameObject npc7;
	public GameObject npc8;

	private float distance;
	private Vector3 offset, temp_position;
	private GameObject player;
	private string text;
	private TimerAndCollectibleScript tacs;
	bool correct = false;
	// Use this for initialization
	void Start () {
		changeTime = changeTimeValue;
		player = GameObject.FindGameObjectWithTag ("Player");
		text = array [(int)Random.Range (0, 4)];
		image_a.enabled = false;
		image_w.enabled = false;
		image_s.enabled = false;
		image_d.enabled = false;
		tacs = player.GetComponent <TimerAndCollectibleScript>();
	}

	void ResetImage(){
		image_a.enabled = false;
		image_w.enabled = false;
		image_s.enabled = false;
		image_d.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, transform.position);
		transform.LookAt (player.transform.position);
		if (distance < 40 && distance > 5) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, 10 * Time.deltaTime);
			offset = player.transform.position - transform.position;

		} else if (distance <= 5) {
			transform.position = player.transform.position - offset;
			Time.timeScale = 0.5f;
			changeTime -= Time.deltaTime * 1000;
			switch (text) {
			case  "a":
				image_a.enabled = true;
				break;
			case "w":
				image_w.enabled = true;
				break;
			case "s":
				image_s.enabled = true;
				break;
			case "d":
				image_d.enabled = true;
				break;
			}
			if (changeTime <= 0) {
					changeTime = changeTimeValue;
					tacs.lives--;
					ResetImage ();
					Time.timeScale = 1f;
					Destroy (gameObject);
					text = array [(int)Random.Range (0, 4)];
					correct = false;
					flag2 = false;
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				if (text == "a" && npc.GetComponent<NPCController>().inFlock) {
					correct = true;
					//Shape as triangle

				}
				 else {
					tacs.lives--;
				}
				ResetImage ();
				Time.timeScale = 1f;
				Destroy (gameObject);
			}
			if (Input.GetKeyDown (KeyCode.W)) {
				if (text == "w"&& npc.GetComponent<NPCController>().inFlock) {
					correct = true;
					//Shape as square
				}
				 else {
					tacs.lives--;
				}
				ResetImage ();
				Time.timeScale = 1f;
				Destroy (gameObject);
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				if (text == "s"&& npc.GetComponent<NPCController>().inFlock) {
					correct = true;
					//Shape as cross
				} else {
					tacs.lives--;
				}
				ResetImage ();
				Time.timeScale = 1f;
				Destroy (gameObject);
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				if (text == "d"&& npc.GetComponent<NPCController>().inFlock) {
					correct = true;
					//Shape as circle
				} else {
					tacs.lives--;
				}
				ResetImage ();
				Time.timeScale = 1f;
				Destroy (gameObject);
			}
		}
	}
}
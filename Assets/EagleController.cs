using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EagleController : MonoBehaviour {
	public string[] array = new string[]{ "a", "w", "s","d" };
	public float time, changeTime, changeTimeValue=1000, changeTimeLevel2=500, gameTime, gameTimeValue = 20000;
	public Text letter, lifeText;
	public bool flag1=false, flag2= false;
	public int life = 3;

	private float distance;
	private Vector3 offset, temp_position;
	private GameObject player;
	bool correct = false;
	// Use this for initialization
	void Start () {
		changeTime = changeTimeValue;
		player = GameObject.FindGameObjectWithTag ("Player");
		letter.enabled = false;
		letter.text = array [(int)Random.Range (0, 4)];
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
			letter.enabled = true;
			lifeText.text = life.ToString ();
			changeTime -= Time.deltaTime * 1000;
			gameTime -= Time.deltaTime * 1000;
			if (gameTime <= 0) {
			
			}
			if (changeTime <= 0) {
				if (!flag2) {
					letter.color = Color.red;
					changeTime = changeTimeLevel2;
					flag2 = true;
				} else {
					letter.color = Color.blue;
					changeTime = changeTimeValue;
					if (!correct) {
						life--;
					}
					letter.enabled = false;
					Destroy (gameObject);
					letter.text = array [(int)Random.Range (0, 4)];
					correct = false;
					flag2 = false;
				}
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				if (letter.text == "a" && letter.color == Color.blue) {
					correct = true;
				} else if (letter.text == "a" && letter.color == Color.red) {
					correct = true;
				} else {
					life--;
				}
				Destroy (gameObject);
				letter.enabled = false;
			}
			if (Input.GetKeyDown (KeyCode.W)) {
				if (letter.text == "w" && letter.color == Color.blue) {
					correct = true;
				} else if (letter.text == "w" && letter.color == Color.red) {
					correct = true;
				} else {
					life--;
				}
				Destroy (gameObject);
				letter.enabled = false;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				if (letter.text == "s" && letter.color == Color.blue) {
					correct = true;
				} else if (letter.text == "s" && letter.color == Color.red) {
					correct = true;
				} else {
					life--;
				}
				Destroy (gameObject);
				letter.enabled = false;
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				if (letter.text == "d" && letter.color == Color.blue) {
					correct = true;
				} else if (letter.text == "d" && letter.color == Color.red) {
					correct = true;
				} else {
					life--;
				}
				Destroy (gameObject);
				letter.enabled = false;
			}
		}
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerAndCollectibleScript : MonoBehaviour {
	public float timeLeft = 30;
	public float food = 0;
	public Image heart1;
	public Image heart2;
	public Image heart3;
	public Image WindWheel;
	public Text time;
	public Text gameover;
	public Text win;
	public Button retry;
	public Button playAgain;
	public int lives = 3;
	public GameObject CollectParticle, WrongParticle;
	private PlayerController_S pc_s;
	private int isDead = 0;
	private int isWin = 0;
	private GameObject particle;
	public float startWindZone=10, endWindZone=30;
	public float health = 100;
	public Slider HealthSlider;
	public float damagePoints=3, damagePointsWindzone = 5;
	// Use this for initialization
	void Start () {
		gameover.enabled = false;
		win.enabled = false;
		pc_s = GetComponent<PlayerController_S> ();
		retry.GetComponentInChildren<Text>().text = "Try it again";
		playAgain.GetComponentInChildren<Text>().text = "Play again";
		retry.gameObject.SetActive (false);
		playAgain.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		heart1.enabled = true;
		heart2.enabled = true;
		heart3.enabled = true;
		if (isWin == 0) {
			timeLeft -= Time.fixedDeltaTime;
		}
		if (timeLeft < 0 || isDead == 1) {
			timeLeft = 0;
		} 
		time.text = timeLeft.ToString();
		if (lives == 2) {
			heart1.enabled = false;
		} else if (lives == 1) {
			heart1.enabled = false;
			heart2.enabled = false;
		} else if (lives <= 0) {
			heart1.enabled = false;
			heart2.enabled = false;
			heart3.enabled = false;
		}
		if (lives <= 0 || timeLeft <= 0) {
			Dead ();
		}
		if (transform.position.z > startWindZone && transform.position.z < endWindZone) {
			health = health - damagePoints * Time.deltaTime;
			WindWheel.GetComponent<RectTransform>().Rotate (new Vector3(0,0,-270)* Time.deltaTime);
			//print ("Losing health");
		}
		health = health - damagePoints * Time.deltaTime;
		HealthSlider.value = health;
        if (health <= 0)
        {
            //print("You died");
            GetComponent<Respawn>().respawnPlayerFunction();
            lives--;
            health = 30;
        }

    }
	/* void OnCollisionEnter(Collision col)
    {
        print("Collied with:" + col);
		if(col.collider.CompareTag("apple"))
		{
			print("Apple skin");
			food++;
			Destroy(col.gameObject);
		}
		if(col.collider.CompareTag("tree")) //replace with tag harm which contains all objects that cause harm 
		{
			print("Found palm tree");
			GetComponent<Respawn>().respawnPlayerFunction();
		}
    }*/
	void OnTriggerEnter(Collider col)
	{
        //print("Collider trigger entered" + col);
        if (col.CompareTag("apple")) {
            //print ("Apple skin");
            lives++;
            if (lives > 3) {
                lives = 3;
            }
            food++;
            Destroy(col.gameObject);
			particle = Instantiate (CollectParticle, col.transform.position, col.transform.rotation) as GameObject;
			Destroy (particle, 3);
        } /*else if (col.CompareTag ("Battery")) {
			health = health + 10;
			if (health > 100)
				health = 100;
		}*/
        else if (col.CompareTag("tree") || col.CompareTag("house")) { //replace with tag harm which contains all objects that cause harm 
			Debug.Log("Tree");                                //print ("Found palm tree");
            GetComponent<Respawn>().respawnPlayerFunction();
            lives--;
			Instantiate (WrongParticle, transform.position, transform.rotation);
		}
        else if (col.CompareTag ("End")) {
			Debug.Log ("End");
			Win ();
		}
	}
	void Dead(){
		gameover.enabled = true;
		retry.gameObject.SetActive (true);
		pc_s.enabled = false;
		GetComponent<Rigidbody>().velocity = Vector3.forward * 0;
		isDead = 1;
	}
	void Win() {

		win.enabled = true;
		playAgain.gameObject.SetActive (true);
		pc_s.enabled = false;
		GetComponent<Rigidbody>().velocity = Vector3.forward * 0;
		isWin = 1;
	}
	public void Retry(){
		SceneManager.LoadScene("Scene_Forest");
	}
}

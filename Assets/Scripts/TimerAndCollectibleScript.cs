using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerAndCollectibleScript : MonoBehaviour {
	public float timeLeft = 30;
    public float food = 0;
	public Image heart1;
	public Image heart2;
	public Image heart3;
	public Text time;

	private int lives = 3;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		heart1.enabled = true;
		heart2.enabled = true;
		heart3.enabled = true;
		timeLeft -= Time.fixedDeltaTime;
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
        print("Collider trigger entered" + col);
		if(col.CompareTag("apple"))
        {
            print("Apple skin");
			lives++;
			if (lives > 3) {
				lives = 3;
			}
            food++;
            Destroy(col.gameObject);
        }
		else if(col.CompareTag("tree")||col.CompareTag("house")) //replace with tag harm which contains all objects that cause harm 
        {
            print("Found palm tree");
            GetComponent<Respawn>().respawnPlayerFunction();
			lives--;
        }
    }
}

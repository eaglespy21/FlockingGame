using UnityEngine;
using System.Collections;

public class TimerAndCollectibleScript : MonoBehaviour {
    public float timeLeft = 30;
    public float food = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.fixedDeltaTime;
	}
    void OnCollisionEnter(Collision col)
    {
        print("Collied with:" + col);
    }
    void OnTriggerEnter(Collider col)
    {
        print("Collider trigger entered" + col);
        if(col.gameObject.name == "apple_skin")
        {
            print("Apple skin");
            food++;
            Destroy(col.gameObject);
        }
        if(col.gameObject.name == "palm_tree_1") //replace with tag harm which contains all objects that cause harm 
        {
            print("Found palm tree");
            GetComponent<Respawn>().respawnPlayerFunction();
        }
    }
}

using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
    public Vector3 oldV;
    public int randValue;
    public GameObject Player;
    public bool toggle = true;
    public bool inFlock = false;
    public GameController gameController;
    // Use this for initialization
    void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        GetComponent<Rigidbody>().velocity = Vector3.forward * Random.value * gameController.speedNPC;
        Player = GameObject.FindGameObjectWithTag("Player");
		inFlock = false;
    }

    // Update is called once per frame
    void Update() {
		//Debug.Log(gameController.invincible);
        float x = Player.transform.position.x, y = Player.transform.position.y, z = Player.transform.position.z;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
        {
            /*
			if (inFlock == true) {
				inFlock = false;
			} else {
				inFlock = true;
			}
            */
            gameController.inFlock = true;
            //if (toggle)
            //{
            /*
             //Old logic
            transform.position = new Vector3(
                            Random.Range(x - gameController.BoundingSizeX, x + gameController.BoundingSizeX),
                            Random.Range(y - gameController.BoundingSizeY, y + gameController.BoundingSizeY),
                            Random.Range(z - gameController.BoundingSizeZ, z + gameController.BoundingSizeZ));
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            */
            //New logic, this could be more efficient and succint if it were in a class or an enumeration
            Vector3 center = Player.transform.position;
                Vector3 newPosition;
                if(Input.GetKeyDown(KeyCode.S)){
                    newPosition = new Vector3(gameController.shapePositions[gameController.countNPC, 0],
                                               gameController.shapePositions[gameController.countNPC, 1],
                                               0);
					GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition; 
					transform.parent = Player.transform;
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    if(gameController.countNPC < 6)
                    {
                        newPosition = new Vector3(gameController.trianglePositions[gameController.countNPC, 0],
                                               gameController.trianglePositions[gameController.countNPC, 1],
                                               0);
                    }
                    
                    else
                    {
                        newPosition = new Vector3(
                                Random.Range(x - gameController.BoundingDSizeX, x + gameController.BoundingDSizeX),
                                Random.Range(y - gameController.BoundingDSizeY, y + gameController.BoundingDSizeY),
                                Random.Range(z - gameController.BoundingDSizeZ, z + gameController.BoundingDSizeZ));
					
                    }
					GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition; 
					transform.parent = Player.transform;

                }
                else
                {
                    double i = (gameController.countNPC * 1.0) / gameController.numOfNPC;
                    double angle = i * Mathf.PI * 2;
                    double xPos = Mathf.Sin((float)angle) * gameController.BoundingSizeX;
                    double yPos = Mathf.Cos((float)angle) * gameController.BoundingSizeY;
                    newPosition = new Vector3((float)xPos, (float)yPos, 0);
					GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition; 
					transform.parent = Player.transform;
                } 
                transform.position = center + newPosition;
                gameController.countNPC++;
                //print(gameController.countNPC);
                GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity;
                //transform.parent = Player.transform;
            //}
            //toggle = !toggle;
        }
        else if (Input.GetKeyDown(KeyCode.Space))//!toggle)
        {
            gameController.inFlock = false;
            gameController.countNPC = 0;
            transform.position = new Vector3(
                            Random.Range(x - gameController.BoundingDSizeX, x + gameController.BoundingDSizeX),
                            Random.Range(y - gameController.BoundingDSizeY, y + gameController.BoundingDSizeY),
                            Random.Range(z - gameController.BoundingDSizeZ, z + gameController.BoundingDSizeZ));
            GetComponent<Rigidbody>().velocity = Vector3.forward * Random.value * gameController.speedNPC;
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None; 
			transform.parent = null;
        }
        if (gameController.countNPC >= 8) gameController.countNPC = 0;


    }
    void FixedUpdate()
    {
		
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 7))
        {
            randValue = (int)(Random.value * 100);
            //print("There is something in front of the object!");
            if (randValue % 2 == 0)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(gameController.mag, 0, 0));
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(-gameController.mag, 0, 0));
            }
            
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, gameController.BL, gameController.BR), 
                                         Mathf.Clamp(transform.position.y, gameController.BG, gameController.BS), 
                                         transform.position.z);
    }

	void OnTriggerEnter(Collider col)
	{
		//print("Collider trigger entered" + col);
		if (gameController.inFlock == true) {
			/*if (col.CompareTag ("apple")) {
				//print ("Apple skin");
				Player.GetComponent<TimerAndCollectibleScript> ().lives++;
				if (Player.GetComponent<TimerAndCollectibleScript> ().lives > 3) {
					Player.GetComponent<TimerAndCollectibleScript> ().lives = 3;
				}
				Player.GetComponent<TimerAndCollectibleScript> ().food++;
				Destroy (col.gameObject);
				Player.GetComponent<TimerAndCollectibleScript> ().particle = Instantiate (Player.GetComponent<TimerAndCollectibleScript> ().CollectParticle, col.transform.position, col.transform.rotation) as GameObject;
				Destroy (Player.GetComponent<TimerAndCollectibleScript>().particle, 3);
			} else if (col.CompareTag ("Battery")) {
				Player.GetComponent<TimerAndCollectibleScript> ().health = Player.GetComponent<TimerAndCollectibleScript> ().health + gameController.BatteryPoint;
				if (Player.GetComponent<TimerAndCollectibleScript> ().health > 100)
					Player.GetComponent<TimerAndCollectibleScript> ().health = 100;
				Destroy (col.gameObject);
				Player.GetComponent<TimerAndCollectibleScript> ().particle = Instantiate (Player.GetComponent<TimerAndCollectibleScript> ().CollectParticle, col.transform.position, col.transform.rotation) as GameObject;
				Destroy (Player.GetComponent<TimerAndCollectibleScript> ().particle, 3);
			} else*/ if (col.CompareTag ("tree") || col.CompareTag ("house")) { //replace with tag harm which contains all objects that cause harm 
				//Debug.Log ("NpcTree");                                //print ("Found palm tree");
				if (gameController.invincible <= 0) {
					Player.GetComponent<Respawn> ().respawnPlayerFunction ();
					Player.GetComponent<TimerAndCollectibleScript> ().lives--;
					gameController.invincible = 3;
				}
				Instantiate (Player.GetComponent<TimerAndCollectibleScript> ().WrongParticle, transform.position, transform.rotation);
			} else if (col.CompareTag ("End")) {
				//Debug.Log ("End");
				Player.GetComponent<TimerAndCollectibleScript> ().Win ();
			}
		}
	}
}

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
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log (inFlock);
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A))
        {
			if (inFlock == true) {
				inFlock = false;
			} else {
				inFlock = true;
			}
            float x = Player.transform.position.x, y = Player.transform.position.y, z = Player.transform.position.z;
            if (toggle)
            {
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
                    
                }
                else
                {
                    double i = (gameController.countNPC * 1.0) / gameController.numOfNPC;
                    double angle = i * Mathf.PI * 2;
                    double xPos = Mathf.Sin((float)angle) * gameController.BoundingSizeX;
                    double yPos = Mathf.Cos((float)angle) * gameController.BoundingSizeY;
                    newPosition = new Vector3((float)xPos, (float)yPos, 0);
                } 
                transform.position = center + newPosition;
                gameController.countNPC++;
                //print(gameController.countNPC);
                GetComponent<Rigidbody>().velocity = Player.GetComponent<Rigidbody>().velocity;
                //transform.parent = Player.transform;
            }
            else if(!toggle)
            {
                gameController.countNPC = 0;
                transform.position = new Vector3(
                                Random.Range(x - gameController.BoundingDSizeX, x + gameController.BoundingDSizeX),
                                Random.Range(y - gameController.BoundingDSizeY, y + gameController.BoundingDSizeY),
                                Random.Range(z - gameController.BoundingDSizeZ, z + gameController.BoundingDSizeZ));
                GetComponent<Rigidbody>().velocity = Vector3.forward * Random.value * gameController.speedNPC;
            }
            toggle = !toggle;

        }

	
	}
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        /*
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
        */
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, gameController.BL, gameController.BR), 
                                         Mathf.Clamp(transform.position.y, gameController.BG, gameController.BS), 
                                         transform.position.z);
    }

}

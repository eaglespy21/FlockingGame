using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private static GameController v_instance = null;
	public float BL = 5, BR = 40, BG = 1, BS = 7, speedNPC = 5, mag = 5;
    public float BoundingSizeX=2, BoundingSizeY=1, BoundingSizeZ=2;             //Flock boundaries 
    public float BoundingDSizeX = 10, BoundingDSizeY = 10, BoundingDSizeZ = 10; //Dispersed flock boundaries
    public int numOfNPC = 8, countNPC=0;
    public float[,] shapePositions = new float[8,2];
    public float[,] trianglePositions = new float[6, 2];
    public float zBuffer = 3;
    public bool inFlock = false;
    public float BatteryPoint = 20;
	public float invincible = 0;
    public float score=0;
    public Text HintDisplay;
    public int sec = 2;
    public string hintS;
    public static GameController instance
    {
        get
        {
            if(v_instance == null)
            {
                v_instance = FindObjectOfType(typeof(GameController)) as GameController;
            }
            if(v_instance == null)
            {
                GameObject obj = new GameObject("GameController");
                v_instance = obj.AddComponent(typeof(GameController)) as GameController;
                Debug.Log("Could not find manager, Game controller was created automatically");
            }
            return v_instance;
        }
    }
    void OnApplicationQuit()
    {
        v_instance = null;
    }
    // Use this for initialization
    void Start () {
        //LeftLine
        shapePositions[0, 0] = -BoundingSizeX; shapePositions[0, 1] = -BoundingSizeY;
        shapePositions[1, 0] = -BoundingSizeX; shapePositions[1, 1] = 0;
        shapePositions[2, 0] = -BoundingSizeX; shapePositions[2, 1] = BoundingSizeY;
        //UpperLine
        shapePositions[3, 0] = 0;              shapePositions[3, 1] = BoundingSizeY;
        shapePositions[4, 0] = BoundingSizeX;  shapePositions[4, 1] = BoundingSizeY;
        //RightLine
        shapePositions[5, 0] = BoundingSizeX; shapePositions[5, 1] = 0;
        shapePositions[6, 0] = BoundingSizeX; shapePositions[6, 1] = -BoundingSizeY;
        //BottomLine
        shapePositions[7, 0] = 0; shapePositions[7, 1] = -BoundingSizeY;

        //triangle vertices
        trianglePositions[0, 0] = -BoundingSizeX; trianglePositions[0, 1] = -BoundingSizeY;
        trianglePositions[1, 0] = 0;              trianglePositions[1, 1] = BoundingSizeY;
        trianglePositions[2, 0] = BoundingSizeX; trianglePositions[2, 1] = -BoundingSizeY;
        //triangle midpoints
        trianglePositions[3, 0] = (trianglePositions[0, 0] + trianglePositions[1, 0]) / 2;
        trianglePositions[3, 1] = (trianglePositions[0, 1] + trianglePositions[1, 1]) / 2;
        trianglePositions[4, 0] = (trianglePositions[1, 0] + trianglePositions[2, 0]) / 2;
        trianglePositions[4, 1] = (trianglePositions[2, 1] + trianglePositions[2, 1]) / 2;
        trianglePositions[5, 0] = (trianglePositions[0, 0] + trianglePositions[2, 0]) / 2;
        trianglePositions[5, 1] = (trianglePositions[0, 1] + trianglePositions[2, 1]) / 2;
    }
	
	// Update is called once per frame
	void Update () {
		invincible -= Time.deltaTime;
        if(hintS == "Windzone")
        {
            StartCoroutine(HintDisplayEnumerator("Windzone ahead, call your flock!"));
            hintS = "";
        }
        else if(hintS == "House")
        {
            StartCoroutine(HintDisplayEnumerator("Houses ahead, disperse your flock!"));
            hintS = "";
        }
        else if(hintS == "Tree")
        {
            StartCoroutine(HintDisplayEnumerator("Forest ahead, disperse your flock!"));
            hintS = "";
        }
    }
    public IEnumerator HintDisplayEnumerator(string s)
    {
        HintDisplay.text = s;
        yield return new WaitForSeconds(sec);
        HintDisplay.text = "";
    }
}

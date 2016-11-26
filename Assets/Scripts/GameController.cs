using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    private static GameController v_instance = null;
	public float BL = 5, BR = 50, BG = 1, BS = 7, speedNPC = 5, mag = 5;
    public float BoundingSizeX=2, BoundingSizeY=1, BoundingSizeZ=2;
    public float BoundingDSizeX = 10, BoundingDSizeY = 10, BoundingDSizeZ = 10;
    public int numOfNPC = 8, countNPC=0;

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

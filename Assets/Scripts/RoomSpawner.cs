using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    private RoomTemplate template;


    // Use this for initialization
    void Start () {
        // Gives me access to rooms
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectRoom()
    {

    }

    public void PlaceRoom()
    {

    }

}

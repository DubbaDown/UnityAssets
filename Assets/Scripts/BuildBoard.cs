using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBoard : MonoBehaviour {

    //Manually entered (these will multiplied by 5
    public int columns;
    public int rows;

    //Stores the gameboard, rooms, and corridor arrays
    private RoomTemplate template;

    //Planning the Randomness
    private int randRoom;       // Randomly select a room
    private int randCorridor;   // Randomly select a corridor
    private int randX;          // Randomly select x-value for PlaceRoom
    private int randZ;          // Randomly select z-value for PlaceRoom
    private int[] plusMinus = { -1, 1 };
    private int randPlusMinus;       // Will be either +1 or -1 for random placement
    private int[] angles = { 0, 90, 180, 270 };
    private int randAngle;      // Will randomly be {0, 90, 180, 270}

    //Keeping Track of the Rooms That Are Placed
    //That way the same room cannot be selected more than once
    List<int> chosenRooms = new List<int>();
    public int roomCount;

    // Use this for initialization
    void Start() {
        columns = columns * 5;
        rows = rows * 5;
        int[,] board = new int[columns, rows];
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();

        //Used for the while loop below, each room getting placed once
        roomCount = template.rooms.Length;

        GameObject gameboard = Instantiate(template.gameboards[0], transform.position = new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        gameboard.transform.localScale = new Vector3((float)columns / 2, 0, (float)rows / 2);

        // How many rooms that exist
        while (roomCount > 0)
        {
            int selectedRoom = SelectRoom();
            PlaceRoom(selectedRoom);
            roomCount--;

        }

    }

    public int SelectRoom()
    {
        randRoom = Random.Range(0, template.rooms.Length);
        while (chosenRooms.Contains(randRoom))
        {
            randRoom = Random.Range(0, template.rooms.Length);
        }
        chosenRooms.Add(randRoom);
        return randRoom;
    }


    public void PlaceRoom(int selectedRoom)
    {
        //Determining the transformation
        randPlusMinus = Random.Range(0, 2);
        randX = Random.Range(0, (columns) + 1) * plusMinus[randPlusMinus];
        randPlusMinus = Random.Range(0, 2);
        randZ = Random.Range(0, (rows) + 1) * plusMinus[randPlusMinus];
        print("randX = " + randX);
        print("randZ = " + randZ);


        //Determining the Rotation
        randAngle = Random.Range(0, 4);

        //Placing the Room
        Instantiate(template.rooms[selectedRoom], transform.position = new Vector3((float)randX, 0.5f, (float)randZ), Quaternion.Euler(0.0f, (float)angles[randAngle], 0.0f));
    }

}


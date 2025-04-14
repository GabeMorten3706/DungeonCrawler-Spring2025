using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    private Dungeon theDungeon;

    void Start()
    {
        Core.thePlayer = new Player("Gabe");
        this.theDungeon = new Dungeon();
        this.setupRoom();
    }

    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    void Update()
    {
        bool didChangeRoom = false;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //try to go to the north
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("north");
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //try to go to the west
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //try to go to the east
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //try to go to the south
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
        }

        //did we change rooms?
        if(didChangeRoom)
        {
            this.setupRoom();
        }
    }
}

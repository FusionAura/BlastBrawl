using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathFollower : MonoBehaviour {
    Node[] PathNode;

    public GameObject Player; //object who is following the path
   
    public float MoveSpeed; // Path Speed

    float timer;//Default Timer

    int CurrentNode;

    static Vector3 CurrentPositionHolder; // Store Node Position
    static Quaternion CurrentRotationHolder; // Store Node Position
    static Vector3 startPosition;
    static Quaternion startRotate;
    public bool direction = false;
    public bool CameraMove = false;

    public GameObject MainMenu;
    public GameObject LobbyMenu;

    public GameObject MainMenuSelection;
    public GameObject PlayerLobbySelection;
    
    EventSystem m_EventSystem;
    
    // Use this for initialization
    void Start ()
    {
        m_EventSystem = EventSystem.current;
        PathNode = GetComponentsInChildren<Node> ();
        checkNode();
	}
    //Check Node and move to it
    void checkNode()
    {
        timer = 0f;
        startPosition = Player.transform.position;
        startRotate = Player.transform.rotation;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
        CurrentRotationHolder = PathNode[CurrentNode].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraMove == true && direction == false)
        {
            timer += Time.deltaTime * PathNode[CurrentNode].NodeSpeed;

            if (CurrentNode > 7)
            {

            }
            if (Player.transform.position != CurrentPositionHolder)
            {
                Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, timer);
                Player.transform.rotation = Quaternion.Lerp(startRotate, CurrentRotationHolder, timer);
            }
            else
            {
                if (CurrentNode < PathNode.Length - 1)
                {
                    CurrentNode++;
                    checkNode();
                }else
                {
                    CameraMove = false;
                    direction = true;
                    m_EventSystem.SetSelectedGameObject(PlayerLobbySelection);
                }

            }
        }
        else if (CameraMove == true &&  direction == true)
        {
            timer += Time.deltaTime * PathNode[CurrentNode].NodeSpeed;

            if (CurrentNode < 7)
            {

            }
            if (Player.transform.position != CurrentPositionHolder)
            {
                Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, timer);
                Player.transform.rotation = Quaternion.Lerp(startRotate, CurrentRotationHolder, timer);
            }
            else
            {
                if (CurrentNode >0)
                {
                    CurrentNode--;
                    checkNode();
                }
                else
                {
                    CameraMove = false;
                    direction = false;
                    m_EventSystem.SetSelectedGameObject(MainMenuSelection);
                }


            }
        }
    }
}

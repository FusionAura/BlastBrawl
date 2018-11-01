using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    private GameObject CameraOBJ;
    public GameObject SaveValues;
    public Text MenuPlayerCount;
    public GameObject PlayerLobby;
    public GameObject LoadOut;


    // Use this for initialization
    void Start () {
        CameraOBJ = GameObject.FindWithTag("Finish");
    }
    public void LoadOutObject()
    {
        LoadOut.SetActive(true);
        PlayerLobby.SetActive(false);
    }
    public void Lobby()
    {
        LoadOut.SetActive(false);
        PlayerLobby.SetActive(true);
    }
    public void Camera()
    {
        CameraOBJ.GetComponent<PathFollower>().CameraMove = true;
    }
    public void PlayerCount(int Count)
    {
        SaveValues.GetComponent<SaveValues>().playerCount = Count;
        MenuPlayerCount.GetComponent<Text>().text = ((Count+1) + " Player Game");

    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("TestLevel");
    }
    // Update is called once per frame
    void Update () {
		
	}
}

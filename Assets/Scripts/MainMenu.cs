using System;
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
        SaveValues = GameObject.FindWithTag("Messenger");
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
    public void Ability1(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "Sword";
                    break;
                }

        }
    


        /*
         *     public string Player1Ability1 = "Teleport";
    public string Player1Ability2 = "RighteousFire";

    public string Player2Ability1 = "Teleport";
    public string Player2Ability2 = "RighteousFire";

    public string Player3Ability1 = "Teleport";
    public string Player3Ability2 = "RighteousFire";

    public string Player4Ability1 = "Teleport";
    public string Player4Ability2 = "RighteousFire";
        */
    }
    public void Ability2(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "Sword";
                    break;
                }
        }
    }
    public void P2Ability1(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "Sword";
                    break;
                }
        }
    }
    public void P2Ability2(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "Sword";
                    break;
                }
        }
    }
    public void P3Ability1(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "Sword";
                    break;
                }
        }
    }
    public void P3Ability2(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "Sword";
                    break;
                }
        }
    }
    public void P4Ability1(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "Sword";
                    break;
                }
        }
    }
    public void P4Ability2(String Ability)
    {
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "Teleport";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "RighteousFire";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "HyperShield";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "EnergyBall";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "Sword";
                    break;
                }
        }
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

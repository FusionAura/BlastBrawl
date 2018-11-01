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

    public AudioClip Button;
    AudioSource audioSource ;

    public GameObject Player1A1;
    public GameObject Player1A2;
    public GameObject Player2A1;
    public GameObject Player2A2;
    public GameObject Player3A1;
    public GameObject Player3A2;
    public GameObject Player4A1;
    public GameObject Player4A2;

    // Use this for initialization
    void Start () {
        CameraOBJ = GameObject.FindWithTag("Finish");
        SaveValues = GameObject.FindWithTag("Messenger");
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void LoadOutObject()
    {
        LoadOut.SetActive(true);
        PlayerLobby.SetActive(false);
        audioSource.PlayOneShot(Button, 0.7F);
    }
    public void Lobby()
    {
        LoadOut.SetActive(false);
        PlayerLobby.SetActive(true);
        audioSource.PlayOneShot(Button, 0.7F);
    }
    public void Camera()
    {
        CameraOBJ.GetComponent<PathFollower>().CameraMove = true;
        audioSource.PlayOneShot(Button, 0.7F);
    }
    public void Ability1(String Ability)
    {
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "Teleport";
                    Player1A1.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "RighteousFire";
                    Player1A1.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "HyperShield";
                    Player1A1.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "EnergyBall";
                    Player1A1.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability1 = "Sword";
                    Player1A1.GetComponent<Text>().text = "MS";
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
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "Teleport";
                    Player1A2.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "RighteousFire";
                    Player1A2.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "HyperShield";
                    Player1A2.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "EnergyBall";
                    Player1A2.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player1Ability2 = "Sword";
                    Player1A2.GetComponent<Text>().text = "MS";
                    break;
                }
        }
    }
    public void P2Ability1(String Ability)
    {
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "Teleport";
                    Player2A1.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "RighteousFire";
                    Player2A1.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "HyperShield";
                    Player2A1.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "EnergyBall";
                    Player2A1.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability1 = "Sword";
                    Player2A1.GetComponent<Text>().text = "MS";
                    break;
                }
        }
    }
    public void P2Ability2(String Ability)
    {
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "Teleport";
                    Player2A2.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "RighteousFire";
                    Player2A2.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "HyperShield";
                    Player2A2.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "EnergyBall";
                    Player2A2.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player2Ability2 = "Sword";
                    Player2A2.GetComponent<Text>().text = "MS";
                    break;
                }
        }
    }
    public void P3Ability1(String Ability)
    {
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "Teleport";
                    Player3A1.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "RighteousFire";
                    Player3A1.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "HyperShield";
                    Player3A1.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "EnergyBall";
                    Player3A1.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability1 = "Sword";
                    Player3A1.GetComponent<Text>().text = "MS";
                    break;
                }
        }
    }
    public void P3Ability2(String Ability)
    {
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "Teleport";
                    Player3A2.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "RighteousFire";
                    Player3A2.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "HyperShield";
                    Player3A2.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "EnergyBall";
                    Player3A2.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player3Ability2 = "Sword";
                    Player3A2.GetComponent<Text>().text = "MS";
                    break;
                }
        }
    }
    public void P4Ability1(String Ability)
    {
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "Teleport";
                    Player4A1.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "RighteousFire";
                    Player4A1.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "HyperShield";
                    Player4A1.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "EnergyBall";
                    Player4A1.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability1 = "Sword";
                    Player4A1.GetComponent<Text>().text = "MS";
                    break;
                }
        }
    }

    public void P4Ability2(String Ability)
    {
        audioSource.PlayOneShot(Button, 0.7F);
        switch (Ability)
        {
            case "Teleport":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "Teleport";
                    Player4A2.GetComponent<Text>().text = "BK";
                    break;
                }
            case "RighteousFire":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "RighteousFire";
                    Player4A2.GetComponent<Text>().text = "RF";
                    break;
                }
            case "HyperShield":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "HyperShield";
                    Player4A2.GetComponent<Text>().text = "HS";
                    break;
                }
            case "EnergyBall":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "EnergyBall";
                    Player4A2.GetComponent<Text>().text = "KB";
                    break;
                }
            case "Sword":
                {
                    SaveValues.GetComponent<SaveValues>().Player4Ability2 = "Sword";
                    Player4A2.GetComponent<Text>().text = "MS";
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
        audioSource.PlayOneShot(Button, 0.7F);
        SceneManager.LoadScene("TestLevel");
    }
    // Update is called once per frame
    void Update () {
		
	}
}

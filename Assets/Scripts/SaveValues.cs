﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveValues : MonoBehaviour {


    public float playerCount = 3;
    private GameObject gameControllerObject;
    
    private Scene m_Scene;

    public string Player1Ability1 = "Teleport";
    public string Player1Ability2 = "RighteousFire";

    public string Player2Ability1 = "Teleport";
    public string Player2Ability2 = "RighteousFire";

    public string Player3Ability1 = "Teleport";
    public string Player3Ability2 = "RighteousFire";

    public string Player4Ability1 = "Teleport";
    public string Player4Ability2 = "RighteousFire";
    // Use this for initialization

    void checkLevel()
    {
        gameControllerObject = GameObject.FindWithTag("GameController");
        //Transfer abilities to Camera Objects. Sets abilities when player respawns
        gameControllerObject.GetComponent<PreGameSetup>().Cam1Object.GetComponent<GameCamera>().Ability1 = Player1Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Cam1Object.GetComponent<GameCamera>().Ability2 = Player1Ability2;

        gameControllerObject.GetComponent<PreGameSetup>().Cam2Object.GetComponent<GameCamera>().Ability1 = Player2Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Cam2Object.GetComponent<GameCamera>().Ability2 = Player2Ability2;

        gameControllerObject.GetComponent<PreGameSetup>().Cam3Object.GetComponent<GameCamera>().Ability1 = Player3Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Cam3Object.GetComponent<GameCamera>().Ability2 = Player3Ability2;

        gameControllerObject.GetComponent<PreGameSetup>().Cam4Object.GetComponent<GameCamera>().Ability1 = Player4Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Cam4Object.GetComponent<GameCamera>().Ability2 = Player4Ability2;

        //Set Abilities when players start round


        gameControllerObject.GetComponent<PreGameSetup>().Player1.GetComponent<PlayerOffense>().Ability1Name = Player1Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Player1.GetComponent<PlayerOffense>().Ability2Name = Player1Ability2;

        gameControllerObject.GetComponent<PreGameSetup>().Player2.GetComponent<PlayerOffense>().Ability1Name = Player2Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Player2.GetComponent<PlayerOffense>().Ability2Name = Player2Ability2;

        gameControllerObject.GetComponent<PreGameSetup>().Player3.GetComponent<PlayerOffense>().Ability1Name = Player3Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Player3.GetComponent<PlayerOffense>().Ability2Name = Player3Ability2;

        gameControllerObject.GetComponent<PreGameSetup>().Player4.GetComponent<PlayerOffense>().Ability1Name = Player4Ability1;
        gameControllerObject.GetComponent<PreGameSetup>().Player4.GetComponent<PlayerOffense>().Ability2Name = Player4Ability2;

        if (playerCount == 1)
        {
            //Camera.Player1Cam.active = false;
            gameControllerObject.GetComponent<PreGameSetup>().Player2.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player3.SetActive(false);
            gameControllerObject.GetComponent<PreGameSetup>().Player4.SetActive(false);
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled = false;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled = false;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled = true;
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam1.rect = new Rect(0, .5f, 1f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam2.rect = new Rect(0f, 0f, 1f, .5f);
            }

            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosX = 2;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosX =2f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosY = 1.3f;

            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosX = 0;
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosY = 0f;

            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosX = 0f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosY = 0f;
        }
        else if (playerCount == 2)
        {
            gameControllerObject.GetComponent<PreGameSetup>().Player2.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player3.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player4.SetActive(false);

            gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled = true;

            gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled = true;
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam1.rect = new Rect(0, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam2.rect = new Rect(.5f, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam3.rect = new Rect(0f, 0f, .5f, .5f);
            }

            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosX = 1.3f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosY = 1.3f;

            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosX = 0f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosY = 0f;
        }
        else if (playerCount == 3)
        {
            gameControllerObject.GetComponent<PreGameSetup>().Player2.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player3.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player4.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled = true;
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam1.rect = new Rect(0, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam2.rect = new Rect(.5f, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam3.rect = new Rect(0f, 0f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam4.rect = new Rect(.5f, 0f, .5f, .5f);
            }

            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosX = 1.3f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosY = 1.3f;

            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosX = 1.3f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosY = 1.3f;
        }
        else if (playerCount == 0)
        {
            gameControllerObject.GetComponent<PreGameSetup>().Player2.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player3.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player4.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled = true;
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam1.rect = new Rect(0, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam2.rect = new Rect(.5f, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam3.rect = new Rect(0f, 0f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam4.rect = new Rect(.5f, 0f, .5f, .5f);
            }

            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosX = 1.3f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosY = 1.3f;

            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosX = 1.3f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosY = 1.3f;
        }
        else
        {
            gameControllerObject.GetComponent<PreGameSetup>().Player2.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player3.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player4.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled = true;
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam1.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam1.rect = new Rect(0, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam2.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam2.rect = new Rect(.5f, .5f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam3.rect = new Rect(0f, 0f, .5f, .5f);
            }
            if (gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled == true)
            {
                gameControllerObject.GetComponent<PreGameSetup>().Cam4.rect = new Rect(.5f, 0f, .5f, .5f);
            }

            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam1.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosX = 1.3f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam2.GetComponent<GameCamera>().cursorPosY = 4;

            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosX = 4;
            gameControllerObject.GetComponent<PreGameSetup>().Cam3.GetComponent<GameCamera>().cursorPosY = 1.3f;

            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosX = 1.3f;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.GetComponent<GameCamera>().cursorPosY = 1.3f;







        }
        Destroy(gameObject);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_Scene = SceneManager.GetActiveScene();
        if (m_Scene.name == "MainMenu")
        {
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            checkLevel();
        }

    }


}

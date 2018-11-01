using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveValues : MonoBehaviour {


    public float playerCount = 0;
    private GameObject gameControllerObject;
    private Scene m_Scene;

    public string Player1Ability1;
    public string Player1Ability2;

    public string Player2Ability1;
    public string Player2Ability2;

    public string Player3Ability1;
    public string Player3Ability2;

    public string Player4Ability1;
    public string Player4Ability2;
    // Use this for initialization

    void checkLevel()
    {
        gameControllerObject = GameObject.FindWithTag("GameController");

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
            
        }
        else if (playerCount == 2)
        {
            gameControllerObject.GetComponent<PreGameSetup>().Player2.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player3.SetActive(true);
            gameControllerObject.GetComponent<PreGameSetup>().Player4.SetActive(false);

            gameControllerObject.GetComponent<PreGameSetup>().Cam3.enabled = true;
            gameControllerObject.GetComponent<PreGameSetup>().Cam4.enabled = false;
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

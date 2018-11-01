using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private GameObject CameraOBJ;


    // Use this for initialization
    void Start () {
        CameraOBJ = GameObject.FindWithTag("EditorOnly");
    }

    public void Camera()
    {
        CameraOBJ.GetComponent<PathFollower>().CameraMove = true;
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

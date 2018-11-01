using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour
{

    public EventSystem eventSystem;
    public GameObject selectedObject;
    public GameObject secondMenu;
    private bool buttonSelected;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (secondMenu.activeInHierarchy == false)
        {
            if (Input.GetAxisRaw("VerticalP1") != 0 && buttonSelected == false)
            {
                eventSystem.SetSelectedGameObject(selectedObject);
                buttonSelected = true;
            }
        }
        if (selectedObject.activeInHierarchy == false)
        {
            if (Input.GetAxisRaw("HorizontalP1") != 0 && buttonSelected == false)
            {
                eventSystem.SetSelectedGameObject(secondMenu);
                buttonSelected = true;
            }
        }
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
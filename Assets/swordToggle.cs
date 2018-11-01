using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordToggle : MonoBehaviour {

    public GameObject Player;
    public CapsuleCollider SwordSmall;
    public CapsuleCollider SwordLarge;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.GetComponent<PlayerAnimations>().SwordHitboxLarge == true)
        {
            SwordLarge.enabled = true;
        }
        else
        {
            SwordLarge.enabled = false;
        }
	}
}

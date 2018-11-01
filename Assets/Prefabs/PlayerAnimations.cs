using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public Animator animator;
    public float MovementY;

    public GameObject PlayerModel;
    public GameObject PlayerParent;
    private GameObject sword;
    private PlayerMovement PlayerMovementScript;
    private PlayerOffense PlayerOffenseScript;
    private PlayerHealth PlayerHealthScript;
    private GameObject MatchController;
    public bool SwordHitboxLarge = false;
    // Use this for initialization

    void Start ()
    {
        //get the animator
        MatchController = GameObject.FindWithTag("GameController");
        animator = PlayerModel.GetComponent<Animator>();
        PlayerHealthScript = PlayerParent.GetComponent<PlayerHealth>();
        PlayerMovementScript = PlayerParent.GetComponent<PlayerMovement>();
        PlayerOffenseScript = PlayerParent.GetComponent<PlayerOffense>();
        sword = this.transform.Find("Sword").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (MatchController.GetComponent<GameController>().Freeze == false)
        {
            //Hyper Shield Animations
            animator.SetBool("HyperShield", GetComponent<PlayerMovement>().HyperShield);

            //Player Jump Animations
            if (Input.GetButtonDown(PlayerMovementScript.Jump))
            {
                animator.SetTrigger("IsJumping");
            }
            if (Input.GetButtonDown(PlayerOffenseScript.Melee))
            {
                if (PlayerOffenseScript.SwordExtend == false)
                {
                    animator.SetTrigger("Attack");

                }
                else
                {
                    animator.SetTrigger("AttackAbility");

                }
            }

            //Player Wallrunning Animation
            if (PlayerMovementScript.WallRun == true)
            {
                animator.SetBool("IsWallRunning", true);
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", false);
            }
            else
            {
                animator.SetBool("IsWallRunning", false);
            }


            if (PlayerMovementScript.Controller.isGrounded == true && PlayerMovementScript.GroundPoundactive == false)
            {
                animator.SetBool("IsGrounded", true);
                //animator.ResetTrigger("IsJumping");
            }
            else
            {
                animator.SetBool("IsGrounded", false);
                animator.ResetTrigger("IsJumping");
            }

            if (PlayerMovementScript.Controller.isGrounded == true && PlayerMovementScript.WallRun == false)
            {
                if (PlayerMovementScript.Forward_speed > 0 && PlayerMovementScript.Forward_speed < 5)
                {
                    animator.SetBool("IsWalking", true);
                    animator.SetBool("IsRunning", false);
                }
                else if (PlayerMovementScript.Forward_speed >= 5)
                {
                    animator.SetBool("IsRunning", true);
                }
                else if (PlayerMovementScript.Forward_speed <= 0)
                {
                    animator.SetBool("IsWalking", false);
                    animator.SetBool("IsRunning", false);
                }
            }
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("MainAttack"))
            {
                SwordHitboxLarge = false;
            }

            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("BigAttack"))
            {
                SwordHitboxLarge = true;
            }

            //Player Attack Animation
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("MainAttack") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("BigAttack"))
            {
                PlayerOffenseScript.Attacking = true;
            }
            else
            {
                if (SwordHitboxLarge == true)
                {
                    PlayerHealthScript.Mana -= PlayerOffenseScript.SwordMPCost;
                }
                //Set animation Attack to false and reset sword hitbox size
                PlayerOffenseScript.Attacking = false;
                SwordHitboxLarge = false;




            }


            animator.SetBool("GroundPoundStart", PlayerOffenseScript.GroundPoundAttack);
            animator.SetBool("GroundPoundPause", PlayerMovementScript.StopFall);
            animator.SetBool("GroundPoundEnd", PlayerOffenseScript.GroundPoundAttack);
        }
    }
}

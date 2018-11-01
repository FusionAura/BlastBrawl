using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public Animator animator;
    public float Forward_speed;
    public float MovementY;

    public GameObject PlayerModel;
    public GameObject PlayerParent;
    private PlayerMovement PlayerMovementScript;
    private PlayerOffense PlayerOffenseScript;
    // Use this for initialization

    void Start ()
    {
        //get the animator
        animator = PlayerModel.GetComponent<Animator>();
        PlayerMovementScript = PlayerParent.GetComponent<PlayerMovement>();
        PlayerOffenseScript = PlayerParent.GetComponent<PlayerOffense>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(PlayerMovementScript.Jump) )
        {
            animator.SetTrigger("IsJumping");
        }
        if (Input.GetButtonDown(PlayerOffenseScript.Melee))
        {
            animator.SetTrigger("Attack");
        }

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
            animator.ResetTrigger("IsJumping");
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
            PlayerOffenseScript.Attacking = true;
            
        }
        else
        {
            PlayerOffenseScript.Attacking = false;
        }
    }
}

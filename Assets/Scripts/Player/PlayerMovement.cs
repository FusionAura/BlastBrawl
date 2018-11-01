using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Control Set
    public string Horizontal = "HorizontalP1";
    public string Vertical = "VerticalP1";
    public string Parkour = "ParkourP1";
    public string Jump = "JumpP1";
    //public string Horizontal = "HorizontalP1";

    //Public Variables - Easy to edit stats in editor.
    private float _Forward_speed = 0f;
    public float MaxRun_Speed = 6.0f;
    private float Acceleration = 1f;
    public float WallRunMax = 100;
    public Transform CameraT;
    public float gravity = 14.0f;
    public float jumpForce = 20.0f;
    public float fallMultiplier = 2.5f;
    public float lowjumpMultiplier = 2f;

    public int speed;

    //Private Variabler
    public bool HyperShield = false;
    private Vector3 _inputControls;
    private bool _DJump = false;
    private float _JumpPadJump;
    private float _VerticalVelocity;
    private bool _WallRun = false;
    private Vector3 _movement = Vector3.zero;
    private float _freeTimer = 0f;
    private float _freeTimerMax = 0.5f;
    private bool _freezeMovement = false;
    private bool _GroundPoundactive = false;
    private bool _GroundPoundMove = false;
    private bool _StopFall = false;
    private GameObject MatchController;
    PlayerHealth PlayerHP;

    //Bleed Status Ailment Timer Stats


    float turnSmoothVelocity;
    CharacterController _Controller;
    Vector3 input;

    private void Start()
    {
        _inputControls = new Vector3(0, 0, 0);
        //CameraT = Camera.main.transform;
        _Controller = GetComponent<CharacterController>();
        PlayerHP = GetComponent<PlayerHealth>();
        MatchController = GameObject.FindWithTag("GameController");
    }

    void Update()
    {
        if (MatchController.GetComponent<GameController>().Freeze == false)
        {
            if ((Input.GetButton(Parkour) || Input.GetAxis(Parkour) > 0.5) && _Forward_speed > 5)
            {
                MaxRun_Speed = 20.0f;
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                RaycastHit hit;

                Ray rayRight = new Ray(transform.position, transform.right);
                Ray rayLeft = new Ray(transform.position, -transform.right);
                Debug.DrawRay(transform.position, transform.right);
                Debug.DrawRay(transform.position, -transform.right);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (Physics.Raycast(rayRight, out hit) && hit.collider.CompareTag("Floor") && hit.distance < 1 && _VerticalVelocity <= 0)
                {
                    //_movement = transform.right;
                    this.transform.localScale = new Vector3(1, 1, 1);
                    _DJump = false;
                    _StopFall = true;
                    _WallRun = true;
                }
                else if (Physics.Raycast(rayLeft, out hit) && hit.collider.CompareTag("Floor") && hit.distance < 1 && _VerticalVelocity <= 0)
                {
                    this.transform.localScale = new Vector3(-1, 1, 1);
                    //_movement = transform.right;
                    _DJump = false;
                    _StopFall = true;
                    _WallRun = true;

                }
                else
                {
                    _StopFall = false;
                    _WallRun = false;

                }
            }
            else
            {
                _StopFall = false;
                _WallRun = false;
                MaxRun_Speed = 15.0f;
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            //Is the character grounded////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (_Controller.isGrounded)
            {
                _StopFall = false;

                _DJump = false;
                //apply some gravity to ensure player sticks to grond
                _VerticalVelocity = -gravity * Time.deltaTime;

                //Handle Ground Pound Movement
                if (GroundPoundactive == true && _Controller.isGrounded == true)
                {
                    if (_freeTimer <= _freeTimerMax)
                    {
                        _freeTimer += 1 * Time.deltaTime;
                        _Forward_speed = 0;
                    }
                    else
                    {
                        _freezeMovement = false;
                        _GroundPoundactive = false;
                        _GroundPoundMove = false;
                        _freeTimer = 0;
                    }
                }

            }
            else
            {
                if (GroundPoundactive == true)
                {
                    if (_GroundPoundMove == true)
                    {
                        transform.Translate(Vector3.forward);
                    }
                    _freezeMovement = true;
                    _Forward_speed = 0;
                }
                if (_StopFall == false)
                {
                    if (_VerticalVelocity < 0)
                    {
                        _VerticalVelocity -= (gravity * (fallMultiplier) * Time.deltaTime);
                    }
                    else
                    {
                        _VerticalVelocity -= gravity * Time.deltaTime;
                    }
                }
                else
                {
                    _VerticalVelocity = 0;
                }

            }

            //Jump
            if (HyperShield == false)
                JumpAction(jumpForce);


            //Character _movement//////////////////////////////////////////////////////////
            if (_freezeMovement == false || HyperShield == false)
            {
                input = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
            }
            if (HyperShield == true)
            {
                _Forward_speed = 0;
            }

            if (input != Vector3.zero)
            {
                _inputControls = input;
                //Increase acceleration for player. If smalller than max speed
                if (_Forward_speed < MaxRun_Speed)
                {
                    if (HyperShield == false)
                    {
                        _Forward_speed += Acceleration;
                    }
                }
                else
                {
                    //Else limit speed to max speed
                    _Forward_speed = MaxRun_Speed;
                }
            }
            else
            {
                if (_Forward_speed > 0)
                {
                    _Forward_speed -= Acceleration;
                }
                else
                {
                    //Else limit speed to max speed
                    _Forward_speed = 0;
                }
            }

            _movement = _inputControls.normalized;
            _movement = transform.TransformDirection(_movement);
            //If no Input?
            if (_movement != Vector3.zero)
            {


            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //If _WallRunning, Count down
            if (_StopFall == true)
            {
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (Input.GetButtonDown(Jump))
                {
                    _StopFall = false;
                    Launch(jumpForce);
                }
                if ((Input.GetButtonUp(Parkour) || Input.GetAxis(Parkour) < 0.5))
                {
                    _StopFall = false;

                }
            }

            //_movement
            UpdateMovement();
        }
    }
    //Updates _movement when called.
    public void UpdateMovement()
    {
        if (_WallRun == false)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, CameraT.localEulerAngles.y, transform.localEulerAngles.z);
        }
        //Get current Velocity from the current forward direction and verical _movement
        //_movement = transform.forward * _Forward_speed + Vector3.up * _VerticalVelocity;

        Vector3 NewMove = _movement * _Forward_speed + Vector3.up * _VerticalVelocity;
        //Move the player via Velocity
        _Controller.Move(NewMove * Time.deltaTime);

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "JumpPad")
        {
            _freezeMovement = false;
            _GroundPoundactive = false;
            _GroundPoundMove = false;
            _StopFall = false;
            GetComponent<PlayerOffense>().GroundPoundAttack = false;

            Launch(other.gameObject.GetComponent<JumpPadValues>().JumpPadForce);
        }
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    //Jump Code
    public void JumpAction(float JumpVal)
    {
        if (Input.GetButtonDown(Jump) && _Controller.isGrounded == true && GroundPoundactive == false)
        {
            _VerticalVelocity = JumpVal;
        }
        if (Input.GetButtonDown(Jump) && (_DJump == false) && _Controller.isGrounded == false && GroundPoundactive == false)
        {
            _DJump = true;
            _VerticalVelocity = JumpVal;
            
        }
        if (Input.GetButtonDown(Jump) && (_DJump == false) && _Controller.isGrounded == false && GroundPoundactive == false)
        {
            _DJump = true;
            _VerticalVelocity = JumpVal;
            
        }
    }

    public void Launch(float JumpVal)
    {
        _VerticalVelocity = JumpVal * (lowjumpMultiplier);
        UpdateMovement();
    }
    
    public float VerticalVelocity
    {
        get { return _VerticalVelocity; }
        set { _VerticalVelocity = value; }
    }
    public float Forward_speed
    {
        get { return _Forward_speed; }
        set { _Forward_speed = value; }
    }
    public Vector3 movement
    {
        get { return _movement; }
        set { _movement = value; }
    }
    public bool GroundPoundactive
    {
        get { return _GroundPoundactive; }
        set { _GroundPoundactive = value; }
    }
    public bool GroundPoundMove
    {
        get { return _GroundPoundMove; }
        set { _GroundPoundMove = value; }
    }
    public bool StopFall
    {
        get { return _StopFall; }
        set { _StopFall = value; }
    }
    public CharacterController Controller
    {
        get { return _Controller; }
        set { _Controller = value; }
    }
    public bool WallRun
    {
        get { return _WallRun; }
        set { _WallRun = value; }
    }
    
}
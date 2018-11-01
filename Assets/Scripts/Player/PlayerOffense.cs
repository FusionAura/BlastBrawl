using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffense : MonoBehaviour {

        public int PlayerNumber = 1;

    private float attackPause = 0;
    private float attackPauseTimer = 0.2f;

    public GameObject sword;
    private GameObject MatchController;
    PlayerMovement movementScript;
    CharacterController Controller;
    PlayerHealth PlayerHP;
    PlayerOffense PlayerAttack;
    PlayerAnimations PlayerAnimation;

    
    //Melee Stats
    private float meleeDamage = 25f;
    public bool Attacking = false;

    //Modifiable Stats
    public string Melee = "MeleeP1";
    public string GroundPound = "GroundPoundP1";
    public string Ability1 = "Ability1P1";
    public string Ability2 = "Ability2P1";
    public string Ability1Name = "RighteousFire";
    public string Ability2Name = "EnergyBall";


    //Particle Handling
    public GameObject Fire;
    public GameObject HyperShieldParticle;
    public GameObject Landing;
    public GameObject EnergyBallParticle;


    //Damage Values
    private float GroundPoundDamage = 15f;
    public bool GroundPoundAttack = false;

    /// ///////////////////////////////////////////////////////    /// ///////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////    /// ///////////////////////////////////////////////////////    /// ///////////////////////////////////////////////////////

    //Righeous fire
    public float RighteousFireDamage = 2f;                           //How much damage is inflict from RF
    public float RighteousFireMultiDamage = 0.2f;                    //How much damage the multi hits inflict
    private float RighteousFireMultiDamageNode = 1.1f;               //Extra Damage from the skill tree
    public float RighteousFireIFrames = 0f;                          //Iframes for RF
    public float RighteousFireIFramesMax = 1f;                       //Maximum Amount of IFrames given to a player after been hit by the attack
    private int RighteousFireMultiStrike = 4;                        //How many times the MultiStike hits
    
    private float RFCostPS = 1f;                                     //How quickly mana is depleted

    //MultiHit Speed
    private float righteousFireMultiHittimer = 0;
    private float righteousFireMultiHittimerMax = 1f;
    private float RFCastTime = 0;
    private float RFCost = 5f;

    //LifeSteal
    private float RFHPLifeSteal = 0f;                               //Steal HP from Enemy and absord a percent of it
    private float RFMPLifeSteal = 0f;

    /// ///////////////////////////////////////////////////////    /// ///////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////    /// ///////////////////////////////////////////////////////    /// ///////////////////////////////////////////////////////

    //Energy Blast
    private int MultiHit = 2;
    private float EBCost = 5;
    private float EBCostPS = 2;
    private float EBDamage = 15f;
    private float EBlastRadius = 1.5f;
    private float EBlastSpeed = 150f;
    private float EBHPLifeSteal = 0;
    private float EBMPLifeSteal = 0;
    private float EBCrit = 0;
    private float AoERadius = 0;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private float EBRateOfFire = 0f;
    private float EBRateOfFireMax = 1f;
    private float EBRateOfFireMuliti = 0f;
    private float EBRateOfFireMulitiMax = 0.3f;
    private int EBRateOfFireMulitiCount = 0;
    private int EBRateOfFireMulitiCountMax = 0;
    private float EBRateOfFireMulitiCool = 0;
    private int EBRateOfFireMulitiCoolMax = 1;

    private float ProjectileLife = 0.75f;


    public Vector3 rotation;
    public Quaternion q;

    //Sword Extend
    public bool SwordExtend = false;
    public bool SwordHitbox = false;
    public float SwordMPCost = 10f;



    //Teleport Variables
    private float TeleportDistanceMax = 100f; //the maximum distance the player will teleport
    private float TeleportDistanceVal = 0f; //The distance the player will travel
    private float TeleportDistanceSpeed = 1f; //
    private float TeleportDamageRadius = 32f;
    private float TeleportDamage = 15f;
    private float TeleportMP = 35f;
    private bool stopRay = false;
    public GameObject TeleportTarget;
    private bool TeleportHold = false;
    private Vector3 fwd;

    private GameObject SpawnTarget;
    private GameObject Target;

    //Hyper Shield Variables
    private float HSCost = 10;
    private float HSCostPS = 1;



    private float radius = 7.5f;





    // Use this for initialization
    void Start ()
    {
        Quaternion q = Quaternion.AngleAxis(100 * Time.time, Vector3.up);
        Vector3 Rotation = transform.forward * 20;
        movementScript = GetComponent<PlayerMovement>();
        Controller = GetComponent<CharacterController>();
        PlayerHP = GetComponent<PlayerHealth>();
        PlayerAttack = GetComponent<PlayerOffense>();
        PlayerAnimation = GetComponent<PlayerAnimations>();
        MatchController = GameObject.FindWithTag("GameController");
        EBRateOfFireMulitiCountMax = MultiHit;
        SpawnTarget = (GameObject)Instantiate(TeleportTarget, transform.position, movementScript.CameraT.rotation);
        Target = SpawnTarget;
        Target.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (MatchController.GetComponent<GameController>().Freeze == false)
        {

            //If Player is in the air and Ground Pound Button is pressed
            if (Controller.isGrounded == false && Input.GetButtonDown(GroundPound))
            {
                //Ground Pound is active. Reset the Pause before the attack
                GroundPoundAttack = true;
                attackPause = 0;

                //Set Ground pound to be active in Movement Script
                GetComponent<PlayerMovement>().GroundPoundactive = true;
            }


            if (GroundPoundAttack == true && GetComponent<PlayerMovement>().GroundPoundMove == false)
            {
                if (attackPause <= attackPauseTimer)
                {
                    attackPause += 1 * Time.deltaTime;
                    GetComponent<PlayerMovement>().VerticalVelocity = 0;
                    GetComponent<PlayerMovement>().StopFall = true;

                }
                else
                {
                    GetComponent<PlayerMovement>().GroundPoundMove = true;
                    GetComponent<PlayerMovement>().StopFall = false;

                }
            }
            if (GroundPoundAttack == true && Controller.isGrounded == true)
            {
                GroundPoundAction(transform.position, radius);
                GroundPoundAttack = false;
            }

            if (GetComponent<PlayerMovement>().GroundPoundactive == true && GetComponent<PlayerMovement>().StopFall == false)
            {
                attackPause = 0;
                GetComponent<PlayerMovement>().VerticalVelocity -= 2f;
                CencelGroundPound();
                RaycastHit hit;
                Ray rayForward = new Ray(transform.position, transform.forward);

                Debug.DrawRay(transform.position, transform.forward);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (Physics.Raycast(rayForward, out hit) && hit.collider.CompareTag("Floor") && hit.distance < 1 && Controller.isGrounded == false)
                {
                    GetComponent<PlayerMovement>().GroundPoundMove = false;
                }
            }
            //Righteous Fire Ability
            if (RighteousFireIFrames < RighteousFireIFramesMax)
            {
                RighteousFireIFrames += 1 * Time.deltaTime;
            }
            if (Input.GetAxis(Ability1) > 0.5)
            {
                if (Ability1Name == "RighteousFire" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    RighteousFire(transform.position, radius);
                }
                if (Ability1Name == "EnergyBall" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    EnergyBall();
                }
                if (Ability1Name == "HyperShield" && PlayerHP.Mana >= HSCost)
                {
                    HyperShield(true);
                }
                else
                {
                    HyperShield(false);
                    HyperShieldParticle.SetActive(false);
                }
                if (Ability1Name == "Sword" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    SwordExtend = true;
                    SwordHitbox = PlayerAnimation.SwordHitboxLarge;


                }
                if (Ability1Name == "Teleport" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    Teleport(true, transform.position, TeleportDamageRadius);
                }
            }
            else
            {
                if (Ability1Name == "HyperShield")
                {
                    HyperShield(false);
                    HyperShieldParticle.SetActive(false);
                }
                if (Ability1Name == "Sword")
                {
                    SwordExtend = false;
                    SwordHitbox = PlayerAnimation.SwordHitboxLarge;
                }
                if (Ability1Name == "Teleport")
                {
                    Teleport(false, transform.position, TeleportDamageRadius);
                }
                if (Ability1Name == "RighteousFire")
                {
                    Fire.SetActive(false);
                }
            }
            if (Input.GetAxis(Ability2) > 0.5)
            {
                if (Ability2Name == "RighteousFire" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    RighteousFire(transform.position, radius);
                }
                if (Ability2Name == "EnergyBall" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    EnergyBall();
                }
                if (Ability2Name == "Sword" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    SwordExtend = true;
                    SwordHitbox = PlayerAnimation.SwordHitboxLarge;
                }
                if (Ability2Name == "HyperShield" && PlayerHP.Mana >= HSCost)
                {
                    HyperShield(true);
                }
                else
                {
                    HyperShield(false);
                    HyperShieldParticle.SetActive(false);
                }
                if (Ability2Name == "Teleport" && GetComponent<PlayerMovement>().HyperShield == false)
                {
                    Teleport(true, transform.position, TeleportDamageRadius);
                }
            }
            else
            {
                //Stop Particle Effects

                if (Ability2Name == "HyperShield")
                {
                    HyperShield(false);
                    HyperShieldParticle.SetActive(false);
                }
                if (Ability2Name == "Sword")
                {
                    SwordExtend = false;
                    SwordHitbox = PlayerAnimation.SwordHitboxLarge;
                }
                if (Ability2Name == "Teleport")
                {
                    Teleport(false, transform.position, TeleportDamageRadius);
                }
                if (Ability2Name == "RighteousFire")
                {
                    Fire.gameObject.SetActive(false);
                }
            }
        }
    }
    void HyperShield(bool held)
    {
        
        if (held == true)
        {
            //If player has mana, perform the ability
            if (PlayerHP.Mana >= HSCost)
            {
                HyperShieldParticle.SetActive(true);
                PlayerHP.Mana -= HSCost;
                HSCostPS = 0;
                GetComponent<PlayerMovement>().HyperShield = held;
                print(PlayerHP.Mana);
            }
            else
            {
                HSCostPS += 1 * Time.deltaTime;
            }
        }
        else
        {
            GetComponent<PlayerMovement>().HyperShield = false;
            held = false;
        }
    }
    void Teleport(bool Held , Vector3 center, float radius)
    {
        RaycastHit hit;
        Ray rayForward = new Ray(transform.position, fwd * TeleportDistanceVal);
        Debug.DrawRay(transform.position, fwd * TeleportDistanceVal);

        //If Teleport Button is held
        if (Held)
        {
            Target.SetActive(true);

            fwd = movementScript.CameraT.transform.forward;
            TeleportHold = true;
            //Start incrementing the Teleport Range per second if smaller than the max distance
            if (TeleportDistanceVal < TeleportDistanceMax && stopRay == false)
            {
                TeleportDistanceVal += TeleportDistanceSpeed;
            }
            Target.transform.position = transform.position + fwd * TeleportDistanceVal;

            if (Physics.Raycast(rayForward, out hit, TeleportDistanceVal))
            {
                //Does the Target sphere exist
                if (TeleportTarget != null)
                {
                    Target.transform.position = hit.point;
                    stopRay = true;
                }
            }
            else
            {
                stopRay = false;
            }
        }
        else if (Held == false && TeleportHold == true) //When released, teleport the distance
        {
            if (PlayerHP.Mana >= RFCost)
            {
                if (PlayerHP.Mana >= TeleportMP)
                {
                    PlayerHP.Mana -= TeleportMP;
                }
            }
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                //Is the object another player and not the caster.
                if (hitColliders[i].CompareTag("Player") && !(hitColliders[i].gameObject == gameObject))
                {
                    //Gonna Change to a less intensive method. needs to send a value as well.
                    hitColliders[i].GetComponent<PlayerHealth>().AddDamage(TeleportDamage, this.gameObject);

                    hitColliders[i].GetComponent<PlayerHealth>().transform.Translate(this.transform.forward);
                    if (hitColliders[i].GetComponent<PlayerHealth>().Health <= 0)
                    {
                        switch (PlayerNumber)
                        {
                            //If Game is 2 Player
                            default:
                                {
                                    break;
                                }
                            case 1:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(1, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                            case 2:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(2, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                            case 3:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(3, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                            case 4:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(4, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                        }

                    }

                }
                //Next in Array of objects in Sphere Overlay
                i++;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            transform.position = transform.position + (fwd * (TeleportDistanceVal - 5));
            TeleportHold = false;
            TeleportDistanceVal = 0;
            Target.SetActive(false);

            Collider[] hitCollidersAfter = Physics.OverlapSphere(center, radius);
            int z = 0;
            while (z < hitCollidersAfter.Length)
            {
                //Is the object another player and not the caster.
                if (hitCollidersAfter[z].CompareTag("Player") && !(hitCollidersAfter[z].gameObject == gameObject))
                {
                    //Gonna Change to a less intensive method. needs to send a value as well.
                    hitCollidersAfter[z].GetComponent<PlayerHealth>().AddDamage(TeleportDamage, this.gameObject);

                    hitCollidersAfter[z].GetComponent<PlayerHealth>().transform.Translate(this.transform.forward);
                    if (hitCollidersAfter[z].GetComponent<PlayerHealth>().Health <= 0)
                    {
                        switch (PlayerNumber)
                        {
                            //If Game is 2 Player
                            default:
                                {
                                    break;
                                }
                            case 1:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(1, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                            case 2:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(2, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                            case 3:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(3, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                            case 4:
                                {
                                    MatchController.GetComponent<GameController>().UpdateScore(4, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                    break;
                                }
                        }

                    }

                }
                //Next in Array of objects in Sphere Overlay
                z++;
            }

            //stopRay = false;
            // TeleportCollide = false;
        }
    }

    
    void EnergyBall()
    {
        if (PlayerHP.Mana >= EBCost)
        {
            if (EBCostPS >= 1)
            {
                PlayerHP.Mana -= EBCost;
                EBCostPS = 0;
                print(PlayerHP.Mana);
            }
            else
            {
                EBCostPS += 1 * Time.deltaTime;
            }
            // Create the Bullet from the Bullet Prefab
            if (EBRateOfFire > EBRateOfFireMax)
            {
                // Add velocity to the bullet
                var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, movementScript.CameraT.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * EBlastSpeed;

                EnergyBall PlayerShooter = bullet.GetComponent<EnergyBall>();
                PlayerShooter.Shooter = this.gameObject;

                // Destroy the bullet after 2 seconds
                Destroy(bullet, ProjectileLife);
                EBRateOfFire = 0;

            }
            else
            {
                EBRateOfFire += 1 * Time.deltaTime;
            }
            if (MultiHit > 0)
            {
                //Can the Player shoot any more projectiles for Multi Cast?
                if (EBRateOfFireMulitiCount > 0)
                {
                    //Cast Timer for MultiCast
                    if (EBRateOfFireMuliti > EBRateOfFireMulitiMax)
                    {
                        EBRateOfFireMulitiCount -= 1;
                        EBRateOfFireMuliti = 0;
                        // Add velocity to the bullet
                        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, movementScript.CameraT.rotation);
                        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * EBlastSpeed;
                        EnergyBall PlayerShooter = bullet.GetComponent<EnergyBall>();
                        PlayerShooter.Shooter = this.gameObject;


                        // Destroy the bullet after 2 seconds
                        Destroy(bullet, ProjectileLife);
                        EBRateOfFire = 0;
                    }
                    else
                    {
                        EBRateOfFireMuliti += (1 * Time.deltaTime) * 3;
                    }
                }
                else
                {
                    //Cooldown
                    if (EBRateOfFireMulitiCool > EBRateOfFireMulitiCoolMax)
                    {
                        EBRateOfFireMulitiCount = EBRateOfFireMulitiCountMax;
                        EBRateOfFireMulitiCool = 0;
                    }
                    else
                    {
                        EBRateOfFireMulitiCool += 1 * Time.deltaTime;
                    }

                }
            }
        }
    }
    //Ground Pound Attack
    void GroundPoundAction(Vector3 center, float radius)
    {

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            //Is the object another player and not the caster.
            if (hitColliders[i].CompareTag("Player") && !(hitColliders[i].gameObject == gameObject))
            {
                //Gonna Change to a less intensive method. needs to send a value as well.
                hitColliders[i].GetComponent<PlayerHealth>().AddDamage(GroundPoundDamage,this.gameObject);

                hitColliders[i].GetComponent<PlayerHealth>().transform.Translate(this.transform.forward);
                if (hitColliders[i].GetComponent<PlayerHealth>().Health <= 0)
                {
                    switch (PlayerNumber)
                    {
                        //If Game is 2 Player
                        default:
                            {
                                break;
                            } 
                        case 1:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(1,(1* MatchController.GetComponent<GameController>().Score_Modifier));
                                break;
                            } 
                        case 2:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(2, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                break;
                            }
                        case 3:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(3, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                break;
                            }
                        case 4:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(4, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                break;
                            } 
                    }
                    
                }

            }
            //Next in Array of objects in Sphere Overlay
            i++;
        }
    }
    //Ground Pound Attack
    void CencelGroundPound()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            //Is the object another player and not the caster.
            if (hitColliders[i].CompareTag("Floor") && Controller.isGrounded == false)
            {
                GetComponent<PlayerMovement>().GroundPoundMove = false;
                GetComponent<PlayerMovement>().StopFall = false;
                attackPause = 0;
                GroundPoundAttack = false;
            }
            //Next in Array of objects in Sphere Overlay
            i++;
        }
    }

    
    //Righteous Fire Ability CAll
    void RighteousFire(Vector3 center, float radius)
    {
        if (PlayerHP.Mana >= RFCost)
        {
            Fire.SetActive(true);
            //Fire.gameObject.transform = this.transform;

            if (RFCostPS >= 1)
            {
                PlayerHP.Mana -= RFCost;
                RFCostPS = 0;
                print(PlayerHP.Mana);
            }
            else
            {
                RFCostPS += 1 * Time.deltaTime;
            }
            
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                //Is the object another player and not the caster.
                if (hitColliders[i].CompareTag("Player") && !(hitColliders[i].gameObject == gameObject))
                {
                    if (hitColliders[i].GetComponent<PlayerOffense>().RighteousFireIFrames >= hitColliders[i].GetComponent<PlayerOffense>().RighteousFireIFramesMax)
                    {

                        //Gonna Change to a less intensive method. needs to send a value as well.
                        hitColliders[i].GetComponent<PlayerHealth>().AddDamage(RighteousFireDamage, this.gameObject);

                        //If player has invested in Life Absorb, steal HP And Or Mana
                        if (RFHPLifeSteal > 0)
                        {
                            PlayerHP.Health += (RighteousFireDamage * RFHPLifeSteal);
                        }
                        if (RFMPLifeSteal > 0)
                        {
                            PlayerHP.Mana += (RighteousFireDamage * RFMPLifeSteal);
                        }
                        print("Hit Fire");
                        hitColliders[i].GetComponent<PlayerOffense>().RighteousFireIFrames = 0;

                        hitColliders[i].GetComponent<PlayerHealth>().transform.Translate(Vector3.forward);
                        if (hitColliders[i].GetComponent<PlayerHealth>().Health <= 0)
                        {
                            switch (PlayerNumber)
                            {
                                //If Game is 2 Player
                                default:
                                    {
                                        break;
                                    }
                                case 1:
                                    {
                                        MatchController.GetComponent<GameController>().UpdateScore(1, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                        break;
                                    }
                                case 2:
                                    {
                                        MatchController.GetComponent<GameController>().UpdateScore(2, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                        break;
                                    }
                                case 3:
                                    {
                                        MatchController.GetComponent<GameController>().UpdateScore(3, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                        break;
                                    }
                                case 4:
                                    {
                                        MatchController.GetComponent<GameController>().UpdateScore(4, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                                        break;
                                    }
                            }

                        }
                    }

                }
                //Next in Array of objects in Sphere Overlay
                i++;
            }
            //Every Second, Spawn a MultiHit
            if (righteousFireMultiHittimer >= righteousFireMultiHittimerMax)
            {
                righteousFireMultiHittimer = 0;
                if (RighteousFireMultiStrike == 4)
                {
                    RighteousFireMultiHit();
                    RighteousFireMultiHit();
                    RighteousFireMultiHit();
                    RighteousFireMultiHit();
                }
                else if (RighteousFireMultiStrike == 3)
                {
                    RighteousFireMultiHit();
                    RighteousFireMultiHit();
                    RighteousFireMultiHit();
                }
                else if (RighteousFireMultiStrike == 2)
                {
                    RighteousFireMultiHit();
                    RighteousFireMultiHit();
                }
                else if (RighteousFireMultiStrike == 1)
                {
                    RighteousFireMultiHit();
                }
            }
            else
            {
                righteousFireMultiHittimer += 1 * Time.deltaTime;
            }
        }
    }
    //Handles the Righteous Fire Multihit. Spawns a seperate Hitbox around the player at random.
    void RighteousFireMultiHit()
    {
        //rotation = Random.rotation.eulerAngles;
        Debug.DrawRay(transform.position, q * rotation, Color.green);
        RaycastHit Attack1;
        q = Quaternion.AngleAxis(100 * Time.time, Vector3.up);
        q.w = Random.Range(-1f, 1f);
        q.y = Random.Range(-1f, 1f);
        rotation = transform.forward * 20;
        if (Physics.SphereCast(transform.position, radius, q * rotation, out Attack1, 64) && Attack1.collider.CompareTag("Player") && !(Attack1.collider.gameObject == gameObject))
        {
            print("Attack");
            //Gonna Change to a less intensive method. needs to send a value as well.
            Attack1.collider.GetComponent<PlayerHealth>().AddDamage(RighteousFireMultiDamage * RighteousFireMultiDamageNode, this.gameObject);
            print("Hit Fire");
            Attack1.collider.GetComponent<PlayerOffense>().RighteousFireIFrames = 0;
            if (Attack1.collider.GetComponent<PlayerHealth>().Health <= 0)
            {
                switch (PlayerNumber)
                {
                    //If Game is 2 Player
                    default:
                        {
                            break;
                        }
                    case 1:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(1, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 2:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(2, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 3:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(3, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 4:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(4, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                }

            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnergyBall"  && other.GetComponent<EnergyBall>().Shooter != this.gameObject)
        {
            print(other.GetComponent<EnergyBall>().Shooter.gameObject);
            //Gonna Change to a less intensive method. needs to send a value as well.
            PlayerHP.AddDamage(EBDamage, other.GetComponent<EnergyBall>().Shooter.gameObject);

            //If player has invested in Life Absorb, steal HP And Or Mana
            if (EBHPLifeSteal > 0)
            {
                other.GetComponent<EnergyBall>().Shooter.GetComponent<PlayerHealth>().Health += (EBDamage * EBHPLifeSteal);
            }
            if (EBMPLifeSteal > 0)
            {
                other.GetComponent<EnergyBall>().Shooter.GetComponent<PlayerHealth>().Mana += (EBDamage * EBMPLifeSteal);
            }

            if (PlayerHP.Health <= 0)
            {
                print("access");
                switch (other.GetComponent<EnergyBall>().Shooter.GetComponent<PlayerHealth>().PlayerNumber)
                {
                    
                    //If Game is 2 Player
                    default:
                        {
                            break;
                        }
                    case 1:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(1, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 2:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(2, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 3:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(3, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 4:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(4, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                }
            }
        }


        //MeleeAttack Handing
        if (other.gameObject.tag == "Sword" && other.GetComponent<LazySwordFix>().Shooter.GetComponent<PlayerOffense>().Attacking == true && other.GetComponent<LazySwordFix>().Shooter != this.gameObject)
        {
            print(other.GetComponent<LazySwordFix>().Shooter);
            //print(other.GetComponent<EnergyBall>().Shooter.gameObject);
            //Gonna Change to a less intensive method. needs to send a value as well.
            PlayerHP.AddDamage(meleeDamage, this.gameObject);

            //If player has invested in Life Absorb, steal HP And Or Mana
            if (PlayerHP.Health <= 0)
            {
                print("access");
                switch (other.GetComponent<LazySwordFix>().Shooter.GetComponent<PlayerHealth>().PlayerNumber)
                {

                    //If Game is 2 Player
                    default:
                        {
                            break;
                        }
                    case 1:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(1, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 2:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(2, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 3:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(3, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                    case 4:
                        {
                            MatchController.GetComponent<GameController>().UpdateScore(4, (1 * MatchController.GetComponent<GameController>().Score_Modifier));
                            break;
                        }
                }
            }
        }

    }

    /*if (Input.GetButtonDown(Melee))
{

    RaycastHit Attack;
    Ray rayForward = new Ray(transform.position, transform.forward);
    GetComponent<PlayerMovement>().Forward_speed = 0f;
    Debug.DrawRay(transform.position, transform.forward);

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    if (Physics.Raycast(rayForward, out Attack) && Attack.collider.CompareTag("Player") && !(Attack.collider.gameObject == gameObject) && Attack.distance < meleeDistance)
    {
        Attack.collider.GetComponent<PlayerHealth>().AddDamage(50, this.gameObject);
    }
}*/

}
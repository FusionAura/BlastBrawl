using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image CurrentHealthBar;
    public Text RatioText;

    public Image CurrentManaBar;
    public Text ManaRatioText;

    public Image CurrentArmourBar;
    public Text ArmourRatioText;

    public GameObject Disable;
    public GameObject Disable2;

    public float MaxHealth = 100;
    public float HealthMaxValue = 200; 
    public float ArmourMax = 125;
    public float ArmourMaxValue = 200; 
    public bool HeavyArmour = false;

    public float ShieldMax = 50;
    public float ShieldRecoveryMax = 7f;
    public float ShieldNegative = 0f;

    private GameObject MatchController;
    public int PlayerNumber;
    private float _Health = 100;
    private float _Armour = 0;
    private float _Mana = 100;
    private float _ManaMax = 100;
    private float ShieldRecovery = 0f;
    private float Shield = 0;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private bool _poison = false;
    private float _poisonTimer = 0;
    private float _poisonTimerMax = 10;
    private float _poisonStack = 1;

    private bool _bleed = false;
    private bool _chill = false;
    private bool _ignite = false;
    private bool _silence = false;
    public float ratio;
    public float ratioMP;
    public float ratioArmour;
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////


    PlayerOffense OffenseScript;


    void Start()
    {
        MatchController = GameObject.FindWithTag("GameController");
        Disable = GameObject.FindWithTag("P3HudRemove");
        Disable2 = GameObject.FindWithTag("P4HudRemove");
        OffenseScript = GetComponent<PlayerOffense>();
        PlayerNumber = OffenseScript.PlayerNumber;
        switch (PlayerNumber)
        {
        default:
            {
                break;
            }
        case 1:
            {
                CurrentHealthBar = GameObject.FindWithTag("P1HP").GetComponent<Image>();
                RatioText = GameObject.FindWithTag("P1HPRatio").GetComponent<Text>();

                CurrentManaBar = GameObject.FindWithTag("P1MP").GetComponent<Image>();
                ManaRatioText = GameObject.FindWithTag("P1MPRatio").GetComponent<Text>();

                CurrentArmourBar = GameObject.FindWithTag("P1Armour").GetComponent<Image>();
                ArmourRatioText = GameObject.FindWithTag("P1ArmourRatio").GetComponent<Text>();
                break;
            }
        case 2:
            {
                CurrentHealthBar = GameObject.FindWithTag("P2HP").GetComponent<Image>();
                RatioText = GameObject.FindWithTag("P2HPRatio").GetComponent<Text>();

                CurrentManaBar = GameObject.FindWithTag("P2MP").GetComponent<Image>();
                ManaRatioText = GameObject.FindWithTag("P2MPRatio").GetComponent<Text>();

                CurrentArmourBar = GameObject.FindWithTag("P2Armour").GetComponent<Image>();
                ArmourRatioText = GameObject.FindWithTag("P2ArmourRatio").GetComponent<Text>();
                break;
            }
        case 3:
            {
                    if (MatchController.GetComponent<PreGameSetup>().PlayerCount > 1)
                    {
                        CurrentHealthBar = GameObject.FindWithTag("P3HP").GetComponent<Image>();
                        RatioText = GameObject.FindWithTag("P3HPRatio").GetComponent<Text>();

                        CurrentManaBar = GameObject.FindWithTag("P3MP").GetComponent<Image>();
                        ManaRatioText = GameObject.FindWithTag("P3MPRatio").GetComponent<Text>();

                        CurrentArmourBar = GameObject.FindWithTag("P3Armour").GetComponent<Image>();
                        ArmourRatioText = GameObject.FindWithTag("P3ArmourRatio").GetComponent<Text>();
                    }
                    break;
            }
        case 4:
            {
                    if (MatchController.GetComponent<PreGameSetup>().PlayerCount > 2)
                    {
                        CurrentHealthBar = GameObject.FindWithTag("P4HP").GetComponent<Image>();
                        RatioText = GameObject.FindWithTag("P4HPRatio").GetComponent<Text>();

                        CurrentManaBar = GameObject.FindWithTag("P4MP").GetComponent<Image>();
                        ManaRatioText = GameObject.FindWithTag("P4MPRatio").GetComponent<Text>();

                        CurrentArmourBar = GameObject.FindWithTag("P4Armour").GetComponent<Image>();
                        ArmourRatioText = GameObject.FindWithTag("P4ArmourRatio").GetComponent<Text>();
                        
                    }
                    break;
            }
        }

        



        switch (PlayerNumber)
        {
            default:
                {
                    break;
                }
            case 1:
                {
                    MatchController.GetComponent<PreGameSetup>().Player1 = this.gameObject;
                    break;
                }
            case 2:
                {
                    MatchController.GetComponent<PreGameSetup>().Player2 = this.gameObject;
                    break;
                }
            case 3:
                {
                    MatchController.GetComponent<PreGameSetup>().Player3 = this.gameObject;
                    break;
                }
            case 4:
                {
                    MatchController.GetComponent<PreGameSetup>().Player4 = this.gameObject;
                    break;
                }
        }

    }

    // Update is called once per frame
    void Update ()
    {
        ratio = _Health / MaxHealth;
        CurrentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        RatioText.text = "HP: " + (ratio * 100).ToString() + '%';

        ratioMP = _Mana / _ManaMax;
        CurrentManaBar.rectTransform.localScale = new Vector3(ratioMP, 1, 1);
        ManaRatioText.text = "MP: " + (ratioMP * 100).ToString() + '%';

        ratioArmour = _Armour / ArmourMax;
        CurrentArmourBar.rectTransform.localScale = new Vector3(ratioArmour, 1, 1);
        ArmourRatioText.text = "Armour: " + (ratioArmour * 100).ToString() + '%';
  



        //If Health is Larger than the maximum amount of Health, deplete health slowly back to the max
        if (_Health > MaxHealth)
        {
            _Health -= 1 * Time.deltaTime;
        }
        //If Armour is Larger than the maximum amount of Armour, deplete Armour slowly back to the max
        if (_Armour > ArmourMax)
        {
            _Armour -= 1 * Time.deltaTime;
        }
        //If Mana is Larger than the maximum amount of Mana, deplete Mana slowly back to the max
        if (Shield < ShieldMax)
        {
            if (ShieldRecovery >= ShieldRecoveryMax)
            { 
                Shield += 1 * Time.deltaTime;
                ShieldRecovery = ShieldRecoveryMax;
            }
            else
            {
                ShieldRecovery += 1 * Time.deltaTime;
            }
        }
        else
        {
            Shield = ShieldMax;
        }
        //If Mana is Larger than the maximum amount of Mana, deplete Mana slowly back to the max
        if (_Mana > _ManaMax)
        {
            _Mana -= 1 * Time.deltaTime;
        }
        //If Mana is smaller than the maximum amount of Mana, restore mana back to the minimum value
        if (_Mana < _ManaMax)
        {
            _Mana += 1 * Time.deltaTime;
        }
    }
    //Damage Handling
    public void AddDamage(float damage,GameObject Attacker)
    {
        if (GetComponent<PlayerMovement>().HyperShield == false)
        {
            ShieldRecovery = 0;
            if (Shield <= 0)
            {
                //If player has regular Armour, Half the Damage
                if (HeavyArmour == false && _Armour > 0)
                {
                    _Health -= Mathf.RoundToInt(damage / 2);
                    _Armour -= damage;
                    if (_Armour < 0)
                    {
                        _Armour = 0;
                    }
                }
                //If heavy Armour, Divide the damage by a third
                else if (HeavyArmour == true && _Armour > 0)
                {
                    _Health -= Mathf.RoundToInt(damage / 3);
                    _Armour -= damage;
                    if (_Armour < 0)
                    {
                        _Armour = 0;
                    }
                }
                //Player takes full damage
                else
                {
                    Health -= damage;
                }
            }
            else
            {
                Shield -= damage;
                if (Shield < 0)
                {
                    ShieldNegative = Shield * -1;
                    Shield = 0;
                    _Health -= ShieldNegative;

                }
            }
            //Destroy the Player if No Health
            if (_Health <= 0)
            {
                //Allow option for Penalties for being fragged. This will only be called if the player was attacked by another player.
                if (Attacker != null)
                {
                    switch (PlayerNumber)
                    {
                        default:
                            {
                                break;
                            }
                        case 1:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(1, (-1 * MatchController.GetComponent<GameController>().FraggedPenalties));
                                break;
                            }
                        case 2:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(2, (-1 * MatchController.GetComponent<GameController>().FraggedPenalties));
                                break;
                            }
                        case 3:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(3, (-1 * MatchController.GetComponent<GameController>().FraggedPenalties));
                                break;
                            }
                        case 4:
                            {
                                MatchController.GetComponent<GameController>().UpdateScore(4, (-1 * MatchController.GetComponent<GameController>().FraggedPenalties));
                                break;
                            }
                    }
                }
                //No Health Destroys the Player
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Increase Health if Touch Health Pickup
        if (other.gameObject.tag == "Health")
        {
            if (_Health < MaxHealth)
            {
                _Health += (other.gameObject.GetComponent<HealthBoost>().HealthGain);
            }
            else if (_Health > HealthMaxValue)
            {
                //Prevent Player from accumilating a massive amount of Health. Health is set to a hard limit
                _Health = HealthMaxValue;
            }
        }
        //Increase Health if Touch Health Pickup
        if (other.gameObject.tag == "EnergyTank")
        {
            if (_Mana < _ManaMax)
            {
                _Mana += (other.gameObject.GetComponent<EnergyTank>().EnergyGain);
            }
            else if (_Mana > _ManaMax)
            {
                //Prevent Player from accumilating a massive amount of Health. Health is set to a hard limit
                _Mana = _ManaMax;
            }
        }
        //Increase Armour if Touch Armour
        if (other.gameObject.tag == "Armour")
        {
            //Determine the armour type the player gets.
            if (_Armour < ArmourMaxValue)
            {
                _Armour += (other.gameObject.GetComponent<ArmourBoost>().ArmourGain);
            }
            else
            {
                //Prevent Player from accumilating a massive amount of Armour. Armour is set to a hard limit
                _Armour = ArmourMaxValue;
            }

            //Determine if Player gets Regular Armour or Heavy Armour
            if (HeavyArmour == true && _Armour <= 100 && (other.gameObject.GetComponent<ArmourBoost>().Heavy) == false)
            {
                HeavyArmour = false;
            }
            else if (HeavyArmour == false && (other.gameObject.GetComponent<ArmourBoost>().Heavy) == true)
            {
                HeavyArmour = true;
            }
            else
            {
                HeavyArmour = false;
            }
        }

        //Kill the player if Suicide. Deduct points with penalty
        if (other.gameObject.tag == "KillPlane")
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
                        MatchController.GetComponent<GameController>().UpdateScore(1, (-1 * MatchController.GetComponent<GameController>().SuicidePenalties));
                        break;
                    }
                case 2:
                    {
                        MatchController.GetComponent<GameController>().UpdateScore(2, (-1 * MatchController.GetComponent<GameController>().SuicidePenalties));
                        break;
                    }
                case 3:
                    {
                        MatchController.GetComponent<GameController>().UpdateScore(3, (-1 * MatchController.GetComponent<GameController>().SuicidePenalties));
                        break;
                    }
                case 4:
                    {
                        MatchController.GetComponent<GameController>().UpdateScore(4, (-1 * MatchController.GetComponent<GameController>().SuicidePenalties));
                        break;
                    }
            }
            Destroy(gameObject);
        }
    }
    public float Health
    {
        get { return _Health; }
        set { _Health = value; }
    }
    public float Mana
    {
        get { return _Mana; }
        set { _Mana = value; }
    }

 
}

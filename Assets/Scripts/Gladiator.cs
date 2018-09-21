/*
 * Created by: Patrick Nguyen 
 * Last Modified: 22-Jan-2015
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gladiator : MonoBehaviour
{
    // postion constants
    private const float laneHeight = 3f;
    private const float spawnX = 25f;
    private const float spawnY = -22.5f;

    // base stats 
    private const float baseHp = 500f;
    private const float baseAttack = 15f;

    // stats
    public static float TotalHp;
    public static float TotalAttack;
    public static float CurrentHp;

    private float speed = 8f;
    public static Vector2 position;
    private Vector2 newPosition;
    private Transform spawnPoint;

    // switches
    public static bool isImmune; 
 
    public static Animator animations;
    public static SpriteRenderer spriteController;
    public static Quaternion defaultRotation;

    public static bool EnableMovement = true;
    public static bool EnableAttack = true;
    private bool enableLaneChange = true;


    // status bar 
    public Text healthText;
    public Image healthBar;

    // imported 
    public GameObject slash;
    public GameObject whirling;
    public GameObject sonic;
    public GameObject defend;
    public GameObject blinding;

    public Button slashButton;
    public Button whirlingButton;
    public Button sonicButton;
    public Button defendButton;
    public Button blindingButton;

    // skill objects to use in many other scripts
    public static Slash slashSkill;
    public static Whirling whirlingSkill;
    public static Sonic sonicSkill;
    public static Defend defendSkill;
    public static Blinding blindingSkill;

  
    // wasnt private before
    private  IEnumerator DimensionCleared(string sceneToChange)
    {
        float fadeTime = GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(sceneToChange);
    }


    // collisions trigger detector
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == Reaper.ReaperSlashSkill.GetSkillObject.name + "(Clone)")
        {
            RecieveDamage(Reaper.ReaperSlashSkill.GetDamage);
        }
        else if (col.gameObject.name == Reaper.ReaperShadowSkill.GetSkillObject.name + "(Clone)")
        {
            RecieveDamage(Reaper.ReaperShadowSkill.GetDamage);
        }
        else if (col.gameObject.name == Reaper.ReaperScytheSkill.GetSkillObject.name + "(Clone)")
        {
            Destroy(col.gameObject);
            RecieveDamage(Reaper.ReaperScytheSkill.GetDamage);
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
       
    }

    // moves the gladiator and animates movement
    private void Move(bool north, bool south, bool east, bool west)
    {
        float vertical = 0;
        float horizontal = 0;

        animations.SetBool("WalkState", true);

        if(EnableMovement == true)
        {
            if (west == true)
            {
                spriteController.flipX = true;
                horizontal = -this.speed;
            }
            else if (east == true)
            {
                spriteController.flipX = false;
                horizontal = this.speed;
            }
            else
            {
                animations.SetBool("WalkState", false);
            }

 
            if (north == true)
            {
                vertical = this.speed;
                enableLaneChange = false;
            }
            else if (south == true)
            {
                vertical = -this.speed;
                enableLaneChange = false;
            }              
        }
        else
        {
            animations.SetBool("WalkState", false);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal, vertical);
    }

    private void RecieveDamage(float damage)
    {
        CurrentHp = CurrentHp - damage; // virtual health 

        // changes physical health bar
        float enemyDamage = damage / TotalHp; // ratio of damage taken to total hp
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, 0f, enemyDamage); // changes healthbar

        if (CurrentHp <= 0)
        {
            Debug.Log("dead");
            //Destroy(this.gameObject);
        }
    }

    void Start()
    {
        animations = GetComponent<Animator>(); 
        spriteController = GetComponent<SpriteRenderer>(); 

        // initiates stats
        TotalHp = baseHp;
        TotalAttack = baseAttack;
        CurrentHp = TotalHp;

        EnableMovement = true;
        EnableAttack = true;

        // initial positioning
        spawnPoint = GameObject.Find("GladiatorSpawn").transform;
        transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
        position = transform.position;
        newPosition = position;

        // creates all the skills
        slashSkill = new Slash(slashButton, slash);
        whirlingSkill = new Whirling(whirlingButton, whirling);
        sonicSkill = new Sonic(sonicButton, sonic);
        defendSkill = new Defend(defendButton, defend);
        blindingSkill = new Blinding(blindingButton, blinding);
    }

  
    void Update()
    {
        // updates skills
        whirlingSkill.Update();
        sonicSkill.Update();
        slashSkill.Update();
        defendSkill.Update();
        blindingSkill.Update();

        position = transform.position;

        // movement control
        if (EnableMovement == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                newPosition.y = position.y;
                Move(true, false, false, false);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                newPosition.y = position.y;
                Move(false, true, false, false);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(false, false, true, false);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(false, false, false, true);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Move(false, false, false, false);
            }
        }
        else
        {
            if(enableLaneChange == true)
            {
                Move(false, false, false, false);
            }      
        }

        // vertical lane changing
        if(enableLaneChange == false)
        {
            float ratio = 0; // account for uncertainty of velocity
            if (newPosition.y - position.y <= -3)
            {
                ratio = (newPosition.y - position.y) + 3f;
                transform.position = new Vector2(position.x, position.y + ratio);
                Move(false, false, false, false);
                enableLaneChange = true;
            }
            else if (newPosition.y - position.y >= 3)
            {
                ratio = (newPosition.y - position.y) - 3f;
                transform.position = new Vector2(position.x, position.y + ratio);
                Move(false, false, false, false);
                enableLaneChange = true;
            }

            EnableAttack = enableLaneChange;
            EnableMovement = enableLaneChange;
        }


        // plays attack animations
        if (EnableAttack == true)
        {
            if (slashSkill.GetSkillButton.interactable == true)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    this.ActivateSkill();
                    Gladiator.animations.Play("Slash");
                }
            }

            if (whirlingSkill.GetSkillButton.interactable == true)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    this.ActivateSkill();
                    Gladiator.animations.Play("Whirling");
                }
            }


            if (sonicSkill.GetSkillButton.interactable == true)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    this.ActivateSkill();
                    Gladiator.animations.Play("Sonic");
                }
            }

            if (defendSkill.GetSkillButton.interactable == true)
            {
                if (Input.GetKey(KeyCode.C))
                {
                    this.ActivateSkill();
                    Gladiator.animations.Play("Defend");
                }
            }

            if (blindingSkill.GetSkillButton.interactable == true)
            {
                if (Input.GetKey(KeyCode.V))
                {
                    this.ActivateSkill();
                    Gladiator.animations.Play("Blinding");
                }
            }
        }
        else
        {
            slashSkill.GetSkillButton.interactable = false;
            sonicSkill.GetSkillButton.interactable = false;
            whirlingSkill.GetSkillButton.interactable = false;
            defendSkill.GetSkillButton.interactable = false;
            blindingSkill.GetSkillButton.interactable = false;
        }
    }

    // start of skill execution
    private void ActivateSkill()
    {
        EnableMovement = false;
        EnableAttack = false;
    }

    // used in animator, end of skill execution
    public void EndSkill()
    {
        EnableMovement = true;
        EnableAttack = true;
    }

 #region Skill Triggers

    public void ChooseSlash()
    {
        slashSkill.ExecuteSkill();
    }

    public void ChooseWhirling()
    {
        whirlingSkill.ExecuteSkill();
    }

    public void ChooseSonic()
    {
        sonicSkill.ExecuteSkill();
    }

    public void ChooseDefend()
    {
        defendSkill.ExecuteSkill();
    }

    public void ChooseBlinding()
    {
        blindingSkill.ExecuteSkill();
    }

#endregion

}


/*
       // if within illumination field
       if (isIlluminated == true)
       {
           float heal = ExecuteSkills.illuminationSkill.GetDamage;

           if (currentHp + heal <= totalHp)
           {
               currentHp += heal;
           }
           else if (currentHp < totalHp)
           {
               currentHp += (totalHp - currentHp);
           }

           healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, 1f, heal /totalHp);
       }
       */

// when gladiator recieves heals
/*
 * 
        if (currentHp > 0) // health is above zero
        {
            if (isDefeated == false)
            {
                int hpTemp = (int)currentHp;
                healthText.text = "Health:" + hpTemp.ToString() + "/" + totalHp.ToString();
            }
        }
        else
        {
            isDefeated = true;
            healthText.text = "You Have Been Defeated!";
           // animations.SetBool("HeroDies", true); // animates death
            Joystick.isActivated = false;
        }




if (isHealed == true)
{
    if (currentHp + ExecuteSkills.divineProtectionSkill.GetDamage > totalHp)
    {
        currentHp = totalHp;
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, 1f, 1f);
    }
    else
    {
        float heal = ExecuteSkills.divineProtectionSkill.GetDamage;
        currentHp = currentHp + heal;
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, 1f, heal / totalHp);
    }

    isHealed = false;
}
*/




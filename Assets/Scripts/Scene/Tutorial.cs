using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // tutorial 
    private int tutorialSteps = 1;
    private bool enableTouch = true;
    private bool joystickOff = false;
    public static bool tutorialMode;
    public static bool touchingTarget;
    public static bool tutorialCloneDies;
    private float timeLeft;

    // imported buttons
    public GameObject basicSlash;
    public GameObject whirlingTides;
    public GameObject sonicSlash;
    public GameObject divineProtection;
    public GameObject illumination;

    // tutorial usage
    public GameObject health;
    public GameObject attackSkills;

    public GameObject tutorialTop;
    public GameObject tutorialBottom;
    public Text tutorialTextTop;
    public Text tutorialTextBottom;
    public Image joystick;
    public GameObject portal;

    // now proceed through the portal to begin your journey

    // Use this for initialization
    void Start ()
    {
        tutorialMode = true;
        tutorialTop.gameObject.SetActive(false);
        tutorialBottom.gameObject.SetActive(false);
        tutorialBottom.gameObject.SetActive(true);
        tutorialTop.gameObject.SetActive(false);
        joystick.gameObject.SetActive(false);
        health.gameObject.SetActive(false);

        basicSlash.gameObject.SetActive(false);
        whirlingTides.gameObject.SetActive(false);
        sonicSlash.gameObject.SetActive(false);
        divineProtection.gameObject.SetActive(false);
        illumination.gameObject.SetActive(false);
        portal.gameObject.SetActive(false);
        portal.GetComponent<SpriteRenderer>().enabled = false;
    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        timeLeft = countdownValue;
        while (timeLeft > 0)
        { 
            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        }
    }


    void Update ()
    {
        // code for an interactive tutorial 
        if (tutorialMode == true)
        {

            if (timeLeft == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (enableTouch == true)
                    {
                        tutorialSteps++;
                    }
                }
            }

            if (tutorialSteps == 1)
            {
                tutorialTextBottom.text = "Welcome! You've Been Selected To Participate In The Dimensional Gladiator Games! Tap To Continue.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 2)
            {
                attackSkills.gameObject.SetActive(true);
                tutorialTextBottom.text = "I'm Asura. The Mythic Champion Of This Tournament. I'll Be Teaching You The Rules Of The Games.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 3)
            {
                enableTouch = false;
                tutorialTop.gameObject.SetActive(true);
                tutorialBottom.gameObject.SetActive(false);
                joystick.gameObject.SetActive(true);
                tutorialTextTop.text = "To Begin, Use The D-Pad Located At The Bottom Left Corner To Move To The Yellow Circle";

                if (touchingTarget == true)
                {
                    tutorialSteps = tutorialSteps + 1;                  
                }
            }
            if (tutorialSteps == 4)
            {
                enableTouch = true;
                joystick.gameObject.SetActive(false);
                tutorialTextTop.text = "Now That You've Got Movement Working. Let Me Explain Your Skills. Tap Anywhere To Continue.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 5)
            {
                basicSlash.gameObject.SetActive(true);
                tutorialTextTop.text = "The Largest Attack Skill Is Your Basic Slash. An Ordinary, Close Ranged Slash."; 
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 6)
            {
                whirlingTides.gameObject.SetActive(true);
                basicSlash.gameObject.SetActive(false);
                tutorialTextTop.text = "This Next Skill Is Sonic Slash. Used To Deal Slashing Damage From A Distance.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 7)
            {
                sonicSlash.gameObject.SetActive(true);
                whirlingTides.gameObject.SetActive(false);
                tutorialTextTop.text = "Next, This Skill Is Whirling Tides. Used To Deal AoE Damage Around You.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 8)
            {
                divineProtection.gameObject.SetActive(true);
                sonicSlash.gameObject.SetActive(false);
                tutorialTextTop.text = "Now, This Skill Is Divine Protection. Used To Spark Up Health & Become Immune From Attacks.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 9)
            {
                illumination.gameObject.SetActive(true);
                divineProtection.gameObject.SetActive(false);
                tutorialTextTop.text = "This Skill Is Illumination. Used To Heal Yourself And Damage Enemies Who Stand In Its Sphere.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 10)
            {
                enableTouch = false;
                joystick.gameObject.SetActive(true);
                basicSlash.gameObject.SetActive(true);
                sonicSlash.gameObject.SetActive(true);
                whirlingTides.gameObject.SetActive(true);
                divineProtection.gameObject.SetActive(true);
                illumination.gameObject.SetActive(true);
                tutorialTextTop.text = "Now Test Your Skills To Find And Defeat My Clone!";

                // when clone dies
                if (tutorialCloneDies == true)
                {
                    tutorialSteps = tutorialSteps + 1;
                }
            }
            if (tutorialSteps == 11)
            {
                enableTouch = true;
                Joystick.isActivated = false;
                tutorialBottom.gameObject.SetActive(true);
                tutorialTop.gameObject.SetActive(false);
                attackSkills.gameObject.SetActive(false);
                joystick.gameObject.SetActive(false);
                tutorialTextBottom.text = "Now That You Have The Basics Of The Control. Let Me Now Explain The Rules Of The Games.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 12)
            {
                tutorialTextBottom.text = "The Goal Of The Games Is To Progress Through Higher Dimensions And Gain More Power.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 13)
            {
                tutorialTextBottom.text = "To Progress Through Dimensions, 3 Shadows Of The Enemy, Then The Enemy Himself Must Be Defeated.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 14)
            {
                tutorialTextBottom.text = "If Your Health Drops To Zero Or Your Run Out Of Time, You Die And Your Run Comes To An End.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 15)
            {
                tutorialTextBottom.text = "After A Dimension Is Cleared, You Gain Skill Points; Which Are Used To Upgrade Skills Abilities.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 16)
            {
                tutorialTextBottom.text = "However, Be Warned. Enemy Gladiators Gain Significant Amounts Of Power As Dimensions Increase.";
                StartCoroutine(StartCountdown(1));
            }
            if (tutorialSteps == 17)
            {
                tutorialTextBottom.text = "One Last Tip To Remember: The Higher The Dimension, The Higher The Power, The Higher The Glory!";
                StartCoroutine(StartCountdown(1));
            }

            if (tutorialSteps == 18)
            {
                tutorialTop.gameObject.SetActive(true);
                attackSkills.gameObject.SetActive(true);
                joystick.gameObject.SetActive(true);
                tutorialBottom.gameObject.SetActive(false);
                tutorialTextTop.text = "Now, Find And Proceed Through The Portal To Begin Your Quest For Glory!";
                portal.gameObject.SetActive(true);
                portal.GetComponent<SpriteRenderer>().enabled = true;
                portal.transform.Rotate(0, 0, 20);
            }
        }
    } 
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameControl : MonoBehaviour
{
    public Button continueButton;
    public Button newGameButton;

    public static int dimension = 1; // which level --> infinite
    public static int realm = 1; // which world --> landscape
    public static int skillPoints = 100;
    public static int shadowsDefeated;
    public static int power;

    // only possible persistent variables to access
    public enum SavedVariables
    {
        sonicSlashUpgrades,
        whirlingTidesUpgrades,
        divineProtectionUpgrades,
        illuminationUpgrades,

        doneTutorial,
        canLoadGame,

        savedPower,
        savedShadowsTotal,
        savedDimension, 
        savedRealm,
        savedSkillPoints,

        topPower,
        topDimension,
        topShadowsDefeated
    }


    // loads last game stats
    public void LoadSavedGame()
    {
        if (PlayerPrefs.GetString(Convert.ToString(SavedVariables.canLoadGame)) == "True")
        {
            dimension = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedDimension));
            shadowsDefeated = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedShadowsTotal));
            power = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedPower));
            skillPoints = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedSkillPoints));

            LoadRealm();
            // array of variables, armor, skills, gold,skill points, attribute points, etc, skill tier
        }
    }

    private IEnumerator LoadLevel(string sceneToChange)
    {
        float fadeTime = GameObject.Find("_Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(sceneToChange);
    }

    // loads last game world
    public void LoadRealm()
    {
        realm = PlayerPrefs.GetInt("savedRealm");

        if (PlayerPrefs.GetInt("savedRealm") == 1)
        {
            StartCoroutine(LoadLevel("Grassland Arena"));
        }
        else if (PlayerPrefs.GetInt("savedRealm") == 2)
        {
            StartCoroutine(LoadLevel("Magmus Arena"));
        }
        else if (PlayerPrefs.GetInt("savedRealm") == 3)
        {
            StartCoroutine(LoadLevel("Grassland Arena"));
        }
    }

    void Update()
    {
        // disable new game and continue button when under certain conditions    
        if (PlayerPrefs.GetString("canLoadGame") == "False") // || PlayerPrefs.GetString("doneTutorial") != "True")
        {
           // continueButton.enabled = false;
            continueButton.interactable = false;
        }
        if (PlayerPrefs.GetString("doneTutorial") != "True")
        {
           // newGameButton.enabled = false;
        }
    }

    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // resets all required persistent data for a new game
    public void ResetData()
    {
        int[] resetArray = new int[4];
        PlayerPrefsX.SetIntArray(Convert.ToString(SavedVariables.sonicSlashUpgrades), resetArray);
        PlayerPrefsX.SetIntArray(Convert.ToString(SavedVariables.whirlingTidesUpgrades), resetArray);
        PlayerPrefsX.SetIntArray(Convert.ToString(SavedVariables.divineProtectionUpgrades), resetArray);
        PlayerPrefsX.SetIntArray(Convert.ToString(SavedVariables.illuminationUpgrades), resetArray);

        // done tutorial
        PlayerPrefs.SetString(Convert.ToString(SavedVariables.canLoadGame), "False");
        PlayerPrefs.SetInt(Convert.ToString(SavedVariables.savedPower), 0);
        PlayerPrefs.SetInt(Convert.ToString(SavedVariables.savedShadowsTotal), 0);
        PlayerPrefs.SetInt(Convert.ToString(SavedVariables.savedSkillPoints), 0);

        PlayerPrefs.SetInt(Convert.ToString(SavedVariables.savedDimension), 1);
        PlayerPrefs.SetInt(Convert.ToString(SavedVariables.savedRealm), 1);

        dimension = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedDimension));
        realm = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedRealm));

        skillPoints = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedSkillPoints));
        shadowsDefeated = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedShadowsTotal));
        power = PlayerPrefs.GetInt(Convert.ToString(SavedVariables.savedPower));


       // PlayerPrefs.SetFloat("topPower", 0);
       // PlayerPrefs.SetFloat("topDimension", 1);
       // PlayerPrefs.SetFloat("topShadowsDefeated", 0);
    }
}

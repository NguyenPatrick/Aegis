/*
 * Created by: Patrick Nguyen 
 * Last Modified: 22-Jan-2015
 * Created for: ICS3UR
 * Final App Project – Gladiator of Dimensions
*/
// Controls the win and lose scene

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Defeat : MonoBehaviour
{
    public Text gameInfo;
    private string dimensionText;
    private bool winGame;

    void Start()
    {
        // if player beats level
        if (true)//Enemy.bossDefeated == true)
        {
            winGame = true;
            GameControl.dimension = GameControl.dimension + 1;
            GameControl.realm = GameControl.realm + 1;
            GameControl.skillPoints = GameControl.skillPoints + 5;

            if (GameControl.realm > 3)
            {
                GameControl.realm = 1;
            }
            PlayerPrefs.SetString(Convert.ToString(GameControl.SavedVariables.canLoadGame), "True");
            PlayerPrefs.SetInt(Convert.ToString(GameControl.SavedVariables.savedDimension), GameControl.dimension);
            PlayerPrefs.SetInt(Convert.ToString(GameControl.SavedVariables.savedShadowsTotal), GameControl.shadowsDefeated);
            PlayerPrefs.SetInt(Convert.ToString(GameControl.SavedVariables.savedPower), GameControl.power);
            PlayerPrefs.SetInt(Convert.ToString(GameControl.SavedVariables.savedRealm), GameControl.realm);
            PlayerPrefs.SetInt(Convert.ToString(GameControl.SavedVariables.savedSkillPoints), GameControl.skillPoints);
        }
        else
        {
            PlayerPrefs.SetString(Convert.ToString(GameControl.SavedVariables.canLoadGame), "False");
        }

        // permanently saves highscore
        if (PlayerPrefs.GetFloat(Convert.ToString(GameControl.SavedVariables.topPower)) < GameControl.power)
        {
            PlayerPrefs.SetFloat(Convert.ToString(GameControl.SavedVariables.topPower), GameControl.power);
        }
        if (PlayerPrefs.GetFloat(Convert.ToString(GameControl.SavedVariables.topDimension)) < GameControl.dimension)
        {
            PlayerPrefs.SetFloat(Convert.ToString(GameControl.SavedVariables.topDimension), GameControl.dimension);
        }
        if (PlayerPrefs.GetFloat(Convert.ToString(GameControl.SavedVariables.topShadowsDefeated)) < GameControl.shadowsDefeated)
        {
            PlayerPrefs.SetFloat(Convert.ToString(GameControl.SavedVariables.topShadowsDefeated), GameControl.shadowsDefeated);
        }
    }

    void Update()
    {
        // displays text
        if (winGame == true)
        {
            gameInfo.text = "Next Dimension: " + GameControl.dimension.ToString() + "\n" + "\n"
                + "Total Power: " + GameControl.power.ToString() + "\n" + "\n"
                + "Enemies Defeated: " + GameControl.shadowsDefeated.ToString() + "\n" + "\n"
                + "(+5) Skill Points: " + GameControl.skillPoints.ToString();
        }
        else
        {
            gameInfo.text = "Dimension Reached: " + GameControl.dimension.ToString() + "\n"
                + "Highest Dimension: " + PlayerPrefs.GetFloat(Convert.ToString(GameControl.SavedVariables.topDimension)).ToString() + "\n" + "\n"
                + "Total Power: " + GameControl.power.ToString() + "\n"
                + "Highest Power: " + PlayerPrefs.GetFloat(Convert.ToString(GameControl.SavedVariables.topPower)).ToString() + "\n" + "\n"
                + "Enemies Defeated: " + GameControl.shadowsDefeated.ToString() + "\n"
                + "Most Enemies Defeated: " + PlayerPrefs.GetFloat(Convert.ToString(GameControl.SavedVariables.topShadowsDefeated)).ToString();
        }
    }
}


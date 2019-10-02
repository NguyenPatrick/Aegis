using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

// skill tree to ugrade all of the current skills

public class SkillTree : MonoBehaviour
{
    // UI text info
    public Text skillNameText;
    public Text skillDescriptionText;
    public Text skillDetailsText;
    public Text skillUpgradesInfoText;
    public Text skillPointsText;

    // keeps track of the skill info
    private string skillName;
    private string skillDescription;
    private string skillDetails;
    private string skillUpgradesInfo;
    private static Skills.SkillTypes skillSelected;
    private GameControl.SavedVariables saveSkillInfo;

    // methods that hold which upgrade to execute
    private static Action<int> skillUpgrade1;
    private static Action<int> skillUpgrade2;
    private static Action<int> skillUpgrade3;
    private static Action<int> skillUpgrade4;

    // temp storage for the upgrade levels of skills
    private int[] skillUpgradeStorageTemp = new int[NUMBER_OF_UPGRADES];
    private const int NUMBER_OF_UPGRADES = 4;

    #region Constants
    // max upgrades for each upgrade
    private const int MAX_INCREASE_DAMAGE = 100;
    private const int MAX_REDUCE_COOLDOWN = 10;
    private const int MAX_INCREASE_DURATION = 10;
    private const int MAX_TIER_UPGRADE = 3;

    // cost to upgrade
    private const int SKILL_UPGRADE_COST = 1;
    private const int TIER_UPGRADE_COST = 5;

    #endregion

    public enum SavedVariables
    {
        sonicSlashUpgrades,
        whirlingTidesUpgrades,
        divineProtectionUpgrades,
        illuminationUpgrades
    }


    // chooses which the skill then displays informations and UI text/images
    // input methods for skills may change in the future
    public void SelectSonicSlash()
    {
        SelectSkillUpgrades(Skills.SkillTypes.SONIC_SLASH, GameControl.SavedVariables.sonicSlashUpgrades,
            IncreaseDamage, ReduceCooldown, IncreaseDuration, TierUpgrade);
    }
    public void SelectWhirlingTides()
    {
        SelectSkillUpgrades(Skills.SkillTypes.WHIRLING_TIDES, GameControl.SavedVariables.whirlingTidesUpgrades,
            IncreaseDamage, ReduceCooldown, IncreaseDuration, TierUpgrade);
    }
    public void SelectDivineProtection()
    {
        SelectSkillUpgrades(Skills.SkillTypes.DIVINE_PROTECTION, GameControl.SavedVariables.divineProtectionUpgrades,
            IncreaseDamage, ReduceCooldown, IncreaseDuration, TierUpgrade);
    }
    public void SelectIllumination()
    {
        SelectSkillUpgrades(Skills.SkillTypes.ILLUMINATION, GameControl.SavedVariables.illuminationUpgrades,
            IncreaseDamage, ReduceCooldown, IncreaseDuration, TierUpgrade);
    }

    // determines which upgrades each skill gets
    private void SelectSkillUpgrades(Skills.SkillTypes whichSkill, GameControl.SavedVariables skillInfo, Action<int> whichUpgrade1,
        Action<int> whichUpgrade2, Action<int> whichUpgrade3, Action<int> whichUpgrade4)
    {
        skillSelected = whichSkill;
        saveSkillInfo = skillInfo;
        skillUpgradeStorageTemp =
            PlayerPrefsX.GetIntArray(Convert.ToString(skillInfo));

        skillUpgrade1 = whichUpgrade1;
        skillUpgrade2 = whichUpgrade2;
        skillUpgrade3 = whichUpgrade3;
        skillUpgrade4 = whichUpgrade4;
    }

    // executes upgrades for each skill via buttons
    public void ExecuteUpgrade1()
    {
        skillUpgrade1(0);
    }
    public void ExecuteUpgrade2()
    {
        skillUpgrade2(1);
    }
    public void ExecuteUpgrade3()
    {
        skillUpgrade3(2);
    }
    public void ExecuteUpgrade4()
    {
        skillUpgrade4(3);
    }

    private bool AbleToUpgrade(int cost)
    {
        if (GameControl.skillPoints >= cost)
        {
            GameControl.skillPoints = GameControl.skillPoints - cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    #region Skill Upgrade Changes
    // upgrades _damage if skill is an attack
    public void IncreaseDamage(int upgradeNumber)
    {
        if (skillUpgradeStorageTemp[upgradeNumber] < MAX_INCREASE_DAMAGE)
        {
            if (AbleToUpgrade(SKILL_UPGRADE_COST))
            {
                skillUpgradeStorageTemp[upgradeNumber] = skillUpgradeStorageTemp[upgradeNumber] + 1; 
                PushSkillUpgrades();
            }
        }
    }

    private void ReduceCooldown(int upgradeNumber)
    {
        if (skillUpgradeStorageTemp[upgradeNumber] < MAX_REDUCE_COOLDOWN)
        {
            if (AbleToUpgrade(2 * SKILL_UPGRADE_COST))
            {
                skillUpgradeStorageTemp[upgradeNumber] = skillUpgradeStorageTemp[upgradeNumber] + 1;
                PushSkillUpgrades();
            }
        }
    }

    private void IncreaseDuration(int upgradeNumber)
    {
        if (skillUpgradeStorageTemp[upgradeNumber] < MAX_INCREASE_DURATION)
        {
            if (AbleToUpgrade(2 * SKILL_UPGRADE_COST))
            {
                skillUpgradeStorageTemp[upgradeNumber] = skillUpgradeStorageTemp[upgradeNumber] + 1;
                PushSkillUpgrades();
            }
        }
    }

    private void TierUpgrade(int upgradeNumber)
    {
        if (skillUpgradeStorageTemp[upgradeNumber] < MAX_TIER_UPGRADE)
        {
            if (AbleToUpgrade(TIER_UPGRADE_COST))
            {
                skillUpgradeStorageTemp[upgradeNumber] = skillUpgradeStorageTemp[upgradeNumber] + 1;
                PushSkillUpgrades();
            }
        }
    }

    #endregion

    // called when the back button it clicked --> updates gladiator skill functions & powa
    // save as persistent until gladiator dies. --> then calls the reset function that reduces everything to nil
    void PushSkillUpgrades()
    {
        string skillUpgradesName = Convert.ToString(saveSkillInfo);
        PlayerPrefsX.SetIntArray(skillUpgradesName, skillUpgradeStorageTemp);
    }

    void Update()
    {
        string coolDown;
        string duration;
        string tierLevel;
        string damage;
        string saveSkill;

        /*
        ExecuteSkills.sonicSlashSkill.Push();
        ExecuteSkills.whirlingTidesSkill.Push();
        ExecuteSkills.divineProtectionSkill.Push();
        ExecuteSkills.illuminationSkill.Push();

        if (skillSelected == Skills.SkillTypes.SONIC_SLASH)
        {
            coolDown = ExecuteSkills.sonicSlashSkill.GetCoolDownTime.ToString();
            duration = ExecuteSkills.sonicSlashSkill.GetDurationTime.ToString();
            tierLevel = ExecuteSkills.sonicSlashSkill.GetTierLevel.ToString();
            damage = ExecuteSkills.sonicSlashSkill.GetDamage.ToString();
            saveSkill = Convert.ToString(SavedVariables.sonicSlashUpgrades);

            skillName = "Sonic Slash";

            skillDescription =
                  "Channel the potential energy within your "
                + "blade to unleash a powerful, ranged, "
                + "supersonic slash";

            skillDetails =
                  damage + " Damage" + "\n"
                + coolDown + ".sec Cooldown" + "\n"
                + duration + ".sec Duration" + "\n";

            skillUpgradesInfo =
                  "Increase Damage (+10) - " + PlayerPrefsX.GetIntArray(saveSkill)[0] + "/" + MAX_INCREASE_DAMAGE + "\n" + "\n"
                + "Decrease Cooldown (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[1] + "/" + MAX_REDUCE_COOLDOWN + "\n" + "\n"
                + "Increase Duration (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[2] + "/" + MAX_INCREASE_DURATION + "\n" + "\n";
        }

        else if (skillSelected == Skills.SkillTypes.WHIRLING_TIDES)
        {
            coolDown = ExecuteSkills.whirlingTidesSkill.GetCoolDownTime.ToString();
            duration = ExecuteSkills.whirlingTidesSkill.GetDurationTime.ToString();
            tierLevel = ExecuteSkills.whirlingTidesSkill.GetTierLevel.ToString();
            damage = ExecuteSkills.whirlingTidesSkill.GetDamage.ToString();
            saveSkill = Convert.ToString(SavedVariables.whirlingTidesUpgrades);

            skillName = "Whirling Tides";

            skillDescription =
                  "Channel the medium of air surrounding your "
                + "blade to unleash a whirling tide "
                + "of piercing energy";

            skillDetails =
                  damage + " Damage/Hit" + "\n"
                + coolDown + ".sec Cooldown" + "\n"
                + duration + ".sec Duration" + "\n";

            skillUpgradesInfo =
                  "Increase Damage (+1) - " + PlayerPrefsX.GetIntArray(saveSkill)[0] + "/" + MAX_INCREASE_DAMAGE + "\n" + "\n"
                + "Decrease Cooldown (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[1] + "/" + MAX_REDUCE_COOLDOWN + "\n" + "\n"
                + "Increase Duration (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[2] + "/" + MAX_INCREASE_DURATION + "\n" + "\n";
        }

       else if (skillSelected == Skills.SkillTypes.DIVINE_PROTECTION)
        {
            coolDown = ExecuteSkills.divineProtectionSkill.GetCoolDownTime.ToString();
            duration = ExecuteSkills.divineProtectionSkill.GetDurationTime.ToString();
            tierLevel = ExecuteSkills.divineProtectionSkill.GetTierLevel.ToString();
            damage = ExecuteSkills.divineProtectionSkill.GetDamage.ToString();
            saveSkill = Convert.ToString(SavedVariables.divineProtectionUpgrades);

            skillName = "Divine Protection";

            skillDescription =
                  "Channel the defensive energy within "
                + "your shield to restore health and "
                + "temporarily defend against any "
                + "physical attack";

            skillDetails =
                  damage + " Heal" + "\n"
                + coolDown + ".sec Cooldown" + "\n"
                + duration + ".sec Duration" + "\n";

            skillUpgradesInfo =
                "Increase Heal (+15) - " + PlayerPrefsX.GetIntArray(saveSkill)[0] + "/" + MAX_INCREASE_DAMAGE + "\n" + "\n"
              + "Decrease Cooldown (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[1] + "/" + MAX_REDUCE_COOLDOWN + "\n" + "\n"
              + "Increase Duration (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[2] + "/" + MAX_INCREASE_DURATION + "\n" + "\n";
        }

        else if (skillSelected == Skills.SkillTypes.ILLUMINATION)
        {
            coolDown = ExecuteSkills.illuminationSkill.GetCoolDownTime.ToString();
            duration = ExecuteSkills.illuminationSkill.GetDurationTime.ToString();
            tierLevel = ExecuteSkills.illuminationSkill.GetTierLevel.ToString();
            damage = ExecuteSkills.illuminationSkill.GetDamage.ToString();
            saveSkill = Convert.ToString(SavedVariables.illuminationUpgrades);

            skillName = "Illumination";

            skillDescription =
                  "Channel the holy energy within "
                + "your armor to generate a holy field that "
                + "restores health and drains enemy health";

            skillDetails =
                  damage + " Per Tick" + "\n"
                + coolDown + ".sec Cooldown" + "\n"
                + duration + ".sec Duration" + "\n";

            skillUpgradesInfo =
                  "Increase Tick (+0.1) - " + PlayerPrefsX.GetIntArray(saveSkill)[0] + "/" + MAX_INCREASE_DAMAGE + "\n" + "\n"
                + "Decrease Cooldown (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[1] + "/" + MAX_REDUCE_COOLDOWN + "\n" + "\n"
                + "Increase Duration (.25sec) - " + PlayerPrefsX.GetIntArray(saveSkill)[2] + "/" + MAX_INCREASE_DURATION + "\n" + "\n";
        }

        skillNameText.text = skillName;
        //skillDescriptionText.text = skillDescription;
        skillDetailsText.text = skillDetails;
        skillUpgradesInfoText.text = skillUpgradesInfo;
        skillPointsText.text = "x" + GameControl.skillPoints.ToString();
        */
    }
}


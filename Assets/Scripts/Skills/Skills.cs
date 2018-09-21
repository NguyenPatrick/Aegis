/*
 * Created by: Patrick Nguyen and Bryan Battershill
 * Last Modified: 17-Jan-2016
 * App Project – Gladiator of Dimensions

 * general skill class with the basics functions to create new skills
 * has properties and methods skills should have
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Skills : MonoBehaviour
{
    // protected properties
    protected float _coolDown;
    protected float _damage;
    protected float _duration;
    protected float _speed;
    protected Button _button;
    protected GameObject _skillObject;
    protected GameObject _skillObjectClone;
    protected List<GameObject> _allSkillObjects = new List<GameObject>();

    protected float _damageUpgrade; 
    protected float _coolDownUpgrade; 
    protected float _durationUpgrade;
    protected int _tierValue;



    #region Get and Set

    public Button GetSkillButton
    {
        get { return _button; }
    }
    public GameObject GetSkillObject
    {
        get { return _skillObject;  }
    }
    /*
    protected Button SetSkillButton
    {
        set { _button = value; }
    }
   

    protected GameObject SetSkillObject
    {
        set { _skillObject = value; }
    }
    public GameObject GetSkillObject
    {
        get { return _skillObject; }
    }

    protected GameObject SetSkillObjectClone
    {
        set { _skillObjectClone = value; }
    }
    public GameObject GetSkillObjectClone
    {
        get { return _skillObjectClone; }
    }

    protected float SetCoolDownTime
    {
        set { _coolDown = value; }
    }
    public float GetCoolDownTime
    {
        // returns cooldown with bonus cooldown
      //  get { return _coolDown - (COOLDOWN_DECREASE_BONUS * _bonusCoolDownValue); }
    }

    protected float SetDurationTime
    {
        set { _duration = value; }
    }
    public float GetDurationTime
    {
        // returns duration with bonus duration
        get { return _duration + (DURATION_INCREASE_BONUS * _bonusDurationValue); }
    }

    protected int SetTierLevel
    {
        set { _tierValue = value; }
    }
    public int GetTierLevel
    {
        get { return _tierValue; }
    }


    protected float SetDamage
    {
        set { _damage = value; }
    }
    public float GetDamage
    {
        // returns damage with bonus damage
        get { return _damage + (DAMAGE_INCREASE_BONUS * _bonusDamageValue); }
    }
    

    protected float SetBonusDamageValue
    {
        set { _bonusDamageValue = value; }
    }
    public float GetBonusDamageValue
    {
        get { return _bonusDamageValue; }
    }

    protected float SetBonusCoolDownValue
    {
        set { _bonusCoolDownValue = value; }
    }
    protected float GetBonusCoolDownValue
    {
        get { return _bonusCoolDownValue; }
    }

    protected float SetBonusDurationValue
    {
        set { _bonusDurationValue = value; }
    }
    protected float GetBonusDurationValue
    {
        get { return _bonusDurationValue; }
    }
    */
    #endregion

    public enum SkillTypes
    { WHIRLING_TIDES, SONIC_SLASH, ILLUMINATION,DIVINE_PROTECTION}

    public float GetDamage
    {
        get { return this._damage; }
    }


    // executes the basic functions of each skill
    protected void ActivateSkill()
    {
        this._button.image.fillAmount = 0;
        this._button.interactable = false;
        Destroy(this._skillObjectClone, this._duration);

        for (int i = 0; i < _allSkillObjects.Count; i++)
        {
            Destroy(this._allSkillObjects[i], this._duration);
        }
    }

    // used to activate the button cooldown using image fill
    public void StartButtonFill()
    {
        double buttonFillRatio;
        buttonFillRatio = 1.00 / ((Application.targetFrameRate) * (this._coolDown));

        if (this._button.image.fillAmount != 1)
        {
            this._button.image.fillAmount = this._button.image.fillAmount + (float)buttonFillRatio;
        }
        else
        {
            this._button.interactable = true;
        }
    }
}

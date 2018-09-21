/*
 * Created by: Patrick Nguyen
 * Last Modified: 17-Jan-2018
 * this script inherits from the skills class and
 * activates the slash attack for basic slash & sonic slash
*/

using UnityEngine;
using UnityEngine.UI;

public class Defend : Skills
{
    private const float spawnDistance = 0.1f;
    private const float spawnHeight = 0.5f;

    // intial values
    private const float initialCoolDown = 2f;//8f;
    private const float initialDuration = 2f;

    // constructor 
    public Defend(Button skillButton, GameObject skillObject)
    {
        this._damage = Gladiator.TotalAttack;
        this._coolDown = initialCoolDown;
        this._duration = initialDuration;
        this._button = skillButton;
        this._skillObject = skillObject;
    }

    // activates the skill
    public void ExecuteSkill()
    {
        Vector2 newGladiatorPosition;
        //Gladiator.isImmune = true;

        newGladiatorPosition = new Vector2(Gladiator.position.x - spawnDistance, Gladiator.position.y - spawnHeight);
        this._skillObjectClone = ((GameObject)Instantiate(this._skillObject, newGladiatorPosition, this._skillObject.transform.rotation));
        this._skillObjectClone.transform.parent = GameObject.Find("Gladiator").transform;
               
        ActivateSkill();
    }

    public void Update()
    {
        this.StartButtonFill();
    }
}

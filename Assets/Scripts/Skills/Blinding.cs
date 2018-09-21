/*
 * Created by: Patrick Nguyen
 * Last Modified: 17-Jan-2016
 * this script inherits from the skills class and
 * activates the slash attack for basic slash & sonic slash
*/

using UnityEngine;
using UnityEngine.UI;

public class Blinding : Skills
{
    private const float spawnDistance = 1.75f;
    private const float spawnHeight = .5f;

    // intial values
    private const float initialCoolDown = 2f;//7f;
    private const float initalDuration = 0.75f;
    private const float initialStunDuration = 1f;

    private float initialSpeed = 15f;
    private float _stunDuration;


    // constructor 
    public Blinding(Button skillButton, GameObject skillObject)
    {
        this._damage = Mathf.Ceil(Gladiator.TotalAttack * 1.5f);
        this._coolDown = initialCoolDown;
        this._duration = initalDuration;
        this._button = skillButton;
        this._skillObject = skillObject;
        this._speed = initialSpeed;
        this._stunDuration = initialStunDuration;
    }

    // activates the skill
    public void ExecuteSkill()
    {
        Vector2 newGladiatorPosition;

        if (Gladiator.spriteController.flipX == true)
        {
            newGladiatorPosition = new Vector2(Gladiator.position.x - spawnDistance, Gladiator.position.y - spawnHeight);
            this._skillObjectClone = (GameObject)Instantiate(this._skillObject, newGladiatorPosition, this._skillObject.transform.rotation);
            this._skillObjectClone.GetComponent<SpriteRenderer>().flipX = true;
            this._skillObjectClone.transform.Rotate(0, 0, 90);
            this._skillObjectClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-this._speed, 0);
        }
        else
        {
            newGladiatorPosition = new Vector2(Gladiator.position.x + spawnDistance, Gladiator.position.y - spawnHeight);
            this._skillObjectClone = (GameObject)Instantiate(this._skillObject, newGladiatorPosition, this._skillObject.transform.rotation);
            this._skillObjectClone.transform.Rotate(0, 0, -90);
            this._skillObjectClone.GetComponent<Rigidbody2D>().velocity = new Vector2(this._speed, 0);
        }

        ActivateSkill();
    }

    public float GetStunDuration
    {
        get { return this._stunDuration; }
    }

    public void Update()
    {
        this.StartButtonFill();
    }
}

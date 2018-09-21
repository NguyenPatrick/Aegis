/*
 * Created by: Patrick Nguyen
 * Last Modified: 17-Jan-2016
 * this script inherits from the skills class and
 * activates the slash attack for basic slash & sonic slash
*/

using UnityEngine;
using UnityEngine.UI;

public class Sonic : Skills
{
    private const float spawnDistance = 2f; // distance from gladiator where slash attack spawns
    private const float spawnHeight = -0.05f; // aligns auto attacks

    // intial values
    private const float initialCoolDown = 2f; //8.5f;
    private const float initialDuration = 0.75f;
    private const float initialSpeed = 15f;

    private bool enableSlash;
    private float speedDirection;
    private Vector2 lastPostion;
    private float slashCounter;

    private float _slashNumber; // plus bonus
    private float _slashSpeed; // plus bonus
    
    // upgrade duration, slash number, slash speed, 

    // constructor 
    public Sonic(Button skillButton, GameObject skillObject)
    {
        this._damage = Gladiator.TotalAttack;
        this._coolDown = initialCoolDown;
        this._duration = initialDuration;
        this._button = skillButton;
        this._skillObject = skillObject;
        this._speed = initialSpeed;
        this._slashNumber = 2;
    }

    // activates the skill
    public void ExecuteSkill()
    {
        slashCounter = 0;
        enableSlash = true;
        Vector2 newGladiatorPosition;

        if (Gladiator.spriteController.flipX == true)
        {
            speedDirection = -this._speed;
            newGladiatorPosition = new Vector2(Gladiator.position.x - spawnDistance, Gladiator.position.y - spawnHeight);
            this._skillObjectClone = (GameObject)Instantiate(this._skillObject, newGladiatorPosition, this._skillObject.transform.rotation);
            this._skillObjectClone.GetComponent<SpriteRenderer>().flipX = true;
            this._skillObjectClone.transform.Rotate(0, 0, 90);
            this._skillObjectClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speedDirection, 0);
        }
        else
        {
            speedDirection = this._speed;
            newGladiatorPosition = new Vector2(Gladiator.position.x + spawnDistance, Gladiator.position.y - spawnHeight);
            this._skillObjectClone = (GameObject)Instantiate(this._skillObject, newGladiatorPosition, this._skillObject.transform.rotation);
            this._skillObjectClone.transform.Rotate(0, 0, -90);
            this._skillObjectClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speedDirection, 0);
        }

        ActivateSkill();
    }

    public void Update()
    {
        this.StartButtonFill();

        if (this._skillObjectClone == null && this.enableSlash == true)
        {
            if(slashCounter < this._slashNumber)
            {
                speedDirection = -speedDirection;
                float rotateVal = speedDirection / Mathf.Abs(speedDirection);
                this._skillObjectClone = (GameObject)Instantiate(this._skillObject, lastPostion, this._skillObject.transform.rotation);
                this._skillObjectClone.transform.Rotate(0, 0, -rotateVal * 90);
                this._skillObjectClone.GetComponent<Rigidbody2D>().velocity = new Vector2(speedDirection, 0);

                if (speedDirection < 0)
                {
                    this._skillObjectClone.GetComponent<SpriteRenderer>().flipX = true;
                }

                Destroy(this._skillObjectClone, this._duration * (2f/3f));
                slashCounter++;
            }
            else
            {
                enableSlash = false;
            }
        }
        else
        {
            if (this._skillObjectClone != null)
            {
                lastPostion = this._skillObjectClone.GetComponent<Rigidbody2D>().position;
                // this._skillObjectClone.transform.Rotate(0, 0, -(speedDirection/Mathf.Abs(speedDirection)) * 0.75f);
            }
        }     
    }
}

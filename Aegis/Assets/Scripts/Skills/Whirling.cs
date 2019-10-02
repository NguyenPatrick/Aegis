using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Whirling : Skills
{  
    // intial values
    private float _radius;
    private float _rotationSpeed;
    private List<float> _swordAngles = new List<float>();

    // constants
    private const float initialCoolDown = 2f; //12f; 
    private const float initialDuration = 4f; // max 6f
    private const float initialRotationSpeed = 5f; // max 10f
    private const float initialRadius = 3f; // max 4.5f

    private const float spawnDistance = 0f; 
    private const float spawnHeight = 0.5f;

    private float _swordLevel; // special upgrade
    private float _radiusLevel; // upgrade
    private float _rotationSpeedLevel;
    private float _durationLevel;

    // upgrades: duration, cooldown, radius, sword level 

 
    // constructor 
    public Whirling(Button skillButton, GameObject skillObject)
    {
        this._damage = Mathf.Ceil(Gladiator.TotalAttack / 2);
        this._coolDown = initialCoolDown; 
        this._duration = initialDuration; // plus bonus
        this._swordLevel = 1; // plus bonus
        this._radius = initialRadius;
        this._rotationSpeed = initialRotationSpeed;

        this._button = skillButton;
        this._skillObject = skillObject;
    }

    // activates the skill
    public void ExecuteSkill()
    {
        Vector2 position;
        this._swordAngles.Clear();
        this._allSkillObjects.Clear();

        float angleRatio = (2 * Mathf.PI) / Mathf.Pow(2, this._swordLevel);
        float swordRatio = 360 / Mathf.Pow(2, this._swordLevel);
             
        // sword creation
        for (float angle = 0,  rotate = 0; angle < (2 * Mathf.PI); angle = angle + angleRatio, rotate = rotate + swordRatio)
        {
            position = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * this._radius;
            this._skillObjectClone = (GameObject)Instantiate(this._skillObject, position, this._skillObject.transform.rotation);
            this._skillObjectClone.transform.parent = GameObject.Find("Gladiator").transform;
            this._skillObjectClone.transform.Rotate(0, 0, -rotate);
            this._allSkillObjects.Add(this._skillObjectClone);
            this._swordAngles.Add(angle);
        }

        ActivateSkill();
    }

    public void Update()
    {
        this.StartButtonFill();

        for (int i = 0; i < _allSkillObjects.Count; i++)
        {
            this._swordAngles[i] += this._rotationSpeed * Time.deltaTime;

            if (this._allSkillObjects[i] != null)
            {
                this._allSkillObjects[i].transform.Rotate(0, 0, -this._rotationSpeed * Time.deltaTime * (180 / Mathf.PI));
                var offset = new Vector2(Mathf.Sin(this._swordAngles[i]), Mathf.Cos(this._swordAngles[i])) * this._radius; ;
                Vector2 newGladiatorPosition = new Vector2(Gladiator.position.x, Gladiator.position.y - spawnHeight);
                this._allSkillObjects[i].transform.position = newGladiatorPosition + offset;
            }
        }
    }
}

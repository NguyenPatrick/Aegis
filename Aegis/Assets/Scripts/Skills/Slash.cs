/*
 * Created by: Patrick Nguyen
 * Last Modified: 17-Jan-2018
 * this script inherits from the skills class and
 * activates the slash attack for basic slash & sonic slash
*/

using UnityEngine;
using UnityEngine.UI;

public class Slash : Skills
{
    private const float spawnDistance = 1.75f; 
    private const float spawnHeight = .5f; 
 
    // intial values
    private const float initialCoolDown = 1f;
    private const float initialDuration = .25f;

    // constructor 
    public Slash(Button skillButton, GameObject skillObject)
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
        this._allSkillObjects.Clear();

        if (Gladiator.spriteController.flipX == true)
        {
            newGladiatorPosition = new Vector2(Gladiator.position.x - spawnDistance, Gladiator.position.y - spawnHeight);
            this._allSkillObjects.Add((GameObject)Instantiate(this._skillObject, newGladiatorPosition, this._skillObject.transform.rotation));
            this._allSkillObjects[this._allSkillObjects.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0);
            this._allSkillObjects[this._allSkillObjects.Count - 1].transform.Rotate(0, 0, 90);
        }
        else
        {
            newGladiatorPosition = new Vector2(Gladiator.position.x + spawnDistance, Gladiator.position.y - spawnHeight);
            this._allSkillObjects.Add((GameObject)Instantiate(this._skillObject, newGladiatorPosition, this._skillObject.transform.rotation));
            this._allSkillObjects[this._allSkillObjects.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
            this._allSkillObjects[this._allSkillObjects.Count - 1].transform.Rotate(0, 0, -90);
        }

        ActivateSkill();
    }

    public void Update()
    {
        this.StartButtonFill();
    }


    /*
    public void ExecuteSonic()
    {
        if (this._allSkillObjects[this._allSkillObjects.Count - 1] != null)
        {
            this._allSkillObjects[this._allSkillObjects.Count - 1].transform.Rotate(0, 0, -20);
            if (Gladiator.spriteController.flipX == true)
            {
                this._allSkillObjects[this._allSkillObjects.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0);
            }
            else
            {
                this._allSkillObjects[this._allSkillObjects.Count - 1].GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0);
            }
        }
    }
    */
}
 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public static float TotalAttack;
    protected float totalHp;
    protected float currentHp;
    protected float speed;
    protected string identity;
    protected float attackRange;

    protected Animator animations;
    protected Quaternion defaultRotation;
    protected Rigidbody2D body;
    protected Vector2 position;

    protected bool enableAttack = true;
    protected bool enableMovement = true;

    public GameObject healthBar;


    public void Attack()
    {
        this.enableMovement = false;
        this.enableAttack = true;
    }

    public void EnableMovement()
    {
        this.enableMovement = true;
    }

    public void EnableAttack()
    {
        this.enableAttack = true; 
    }
   

    void OnTriggerStay2D(Collider2D col)
    {

    }

    // getting trigger collisions from gladiator skills
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == Gladiator.blindingSkill.GetSkillObject.name + "(Clone)")
        {
            RecieveDamage(Gladiator.blindingSkill.GetDamage);
            StartCoroutine(Stunned(Gladiator.blindingSkill.GetStunDuration));
            Destroy(col.gameObject);
        }
        else if (col.gameObject.name == Gladiator.whirlingSkill.GetSkillObject.name + "(Clone)")
        {
            RecieveDamage(Gladiator.whirlingSkill.GetDamage);
        }
        else if (col.gameObject.name == Gladiator.slashSkill.GetSkillObject.name + "(Clone)")
        {
            RecieveDamage(Gladiator.slashSkill.GetDamage);
        }
        else if (col.gameObject.name == Gladiator.sonicSkill.GetSkillObject.name + "(Clone)")
        {
            RecieveDamage(Gladiator.sonicSkill.GetDamage);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

    }

    private  IEnumerator Stunned(float time)
    {
        // activate the bar to show stun time
        this.enableMovement = false;
        this.enableAttack = false;
        yield return new WaitForSeconds(time);
        this.enableMovement = true;
        this.enableAttack = true;
    }


    private void RecieveDamage(float takeDamage)
    {
        Debug.Log(takeDamage);
        this.currentHp = this.currentHp - takeDamage;

        // used for health bar
        float hitDamage = takeDamage / totalHp;
        float damage = hitDamage / 0.75f;

        healthBar.transform.localScale += new Vector3(-hitDamage, 0, 0);
        healthBar.transform.localPosition += new Vector3(-damage / 2, 0, 0);

        if (this.currentHp <= 0)
        {
            // add one to the lane counter
            Destroy(this.gameObject);
        }
    }
}






















using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reaper : Enemy {

    // constants
    private const float initialHp = 125f;
    private const float initialAttack = 10f;
    private const float initialSpeed = 2.75f;
    private const float maxSpeed = 3.5f;
    private const float initalRange = 3f;

    private ReaperSlash slashSkill;
    private ReaperShadow shadowSkill;
    private ReaperScythe scytheSkill;

    public static ReaperSlash ReaperSlashSkill;
    public static ReaperShadow ReaperShadowSkill;
    public static ReaperScythe ReaperScytheSkill;

    public GameObject slash;
    public GameObject shadow;
    public GameObject scythe;


    // constructor
    void Start()
    {
        TotalAttack = initialAttack;
        this.totalHp = initialHp;
        this.currentHp = initialHp;
        this.speed = initialSpeed;
        this.attackRange = initalRange;
        this.identity = this.transform.name;

        this.animations = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.position = this.GetComponent<Rigidbody2D>().position;

        slashSkill = new ReaperSlash(this.identity, slash);
        shadowSkill = new ReaperShadow(this.identity, shadow);
        scytheSkill = new ReaperScythe(this.identity, scythe);

        ReaperSlashSkill = slashSkill;
        ReaperShadowSkill = shadowSkill;
        ReaperScytheSkill = scytheSkill;
    }


    void Update()
    {
        this.position = this.body.position;
        Vector2 relativePosition = new Vector2(Gladiator.position.x - this.position.x, Gladiator.position.y - this.position.y);


        if (((relativePosition.x <= -this.attackRange) || (relativePosition.x >= this.attackRange)) && this.enableMovement == true)
        {
            this.body.velocity = new Vector2(-this.speed, 0);
        }
        else
        {
            this.body.velocity = new Vector2(0, 0);
        }

        if(this.enableAttack == true)
        {
            if (shadowSkill.GetAttackState == true && relativePosition.x >= -shadowSkill.GetRange)
            {
                this.animations.Play("Inverse Slash");
                StartCoroutine(shadowSkill.ActivateCoolDown());
            }
            else if (scytheSkill.GetAttackState == true && relativePosition.x >= -scytheSkill.GetRange)
            {
                this.animations.Play("Full Slash");
                StartCoroutine(scytheSkill.ActivateCoolDown());
            }
            if (slashSkill.GetAttackState == true && relativePosition.x >= -slashSkill.GetRange)
            {
                this.animations.Play("Slash");
                StartCoroutine(slashSkill.ActivateCoolDown());
            }
        }    
            
        scytheSkill.Update();
    }

    public void SlashAttack()
    {
        slashSkill.Execute();

    }

    public void ScytheAttack()
    {
        scytheSkill.Execute();
    
    }

    public void ShadowAttack()
    {
        shadowSkill.Execute();
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperShadow : EnemySkill {

    private const float initialRange = 12f;
    private const float initialDuration = 3f;
    private const float initialCoolDown = 8f;
    private const float initialSpeed = 5f;
    private const float spawnDistance = 0f;
    private const float spawnHeight = 0.5f;

    private const float maxCoolDown = 1.5f;
    private const float maxSpeed = 7.5f;



    public ReaperShadow(string name, GameObject shadow)
    {
        this._target = name;
        this._damage = Reaper.TotalAttack * 2;
        this._duration = initialDuration;
        this._coolDown = initialCoolDown; // plus bonus
        this._range = initialRange;
        this._skillObject = shadow;
        this._speed = initialSpeed;
    }

    public void Execute()
    {
        Vector2 newPosition = GameObject.Find(this._target).GetComponent<Rigidbody2D>().position;
        GameObject temp = (GameObject)Instantiate(this._skillObject, newPosition, defaultRotation);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-this._speed, 0);
        Destroy(temp, this._duration);
    }


    public void Upgrade()
    {

    }
}

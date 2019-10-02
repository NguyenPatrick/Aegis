using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperSlash : EnemySkill {

    private const float initialRange = 3.5f;
    private const float initialDuration = 0.25f;
    private const float initialCoolDown = 1.25f;
    private const float initialSpeed = 5f;

    private const float spawnDistance = 2f;
    private const float spawnHeight = 0f;

    private const float maxCoolDown = 0.5f;
   

    public ReaperSlash(string name, GameObject slash)
    {
        this._target = name;
        this._damage = Reaper.TotalAttack;
        this._duration = initialDuration;
        this._coolDown = initialCoolDown; // plus bonus
        this._range = initialRange;
        this._skillObject = slash;
        this._speed = initialSpeed;
    }

    public void Execute()
    {
        Vector2 newPosition = GameObject.Find(this._target).GetComponent<Rigidbody2D>().position;
        newPosition.x = newPosition.x - spawnDistance;
        GameObject temp = (GameObject)Instantiate(this._skillObject, newPosition, defaultRotation);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-this._speed, 0);
        temp.transform.Rotate(0, 0, 90);
        Destroy(temp, this._duration);
    }
    
}

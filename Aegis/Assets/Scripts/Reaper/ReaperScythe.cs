using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperScythe : EnemySkill {

    private const float initialRange = 25f;
    private const float initialDuration = 2f;
    private const float initialCoolDown = 6f;
    private const float initialSpeed = 10f;

    private const float spawnDistance = 1f;
    private const float spawnHeight = 0f;

    private const float maxCoolDown = 1.5f;
    private GameObject temp;
    //private int[] criticalLevels = new int [5, 10, 20];

  
    public ReaperScythe(string name, GameObject scythe)
    {
        this._target = name;
        this._skillObject = scythe;
        this._damage = Reaper.TotalAttack * 1.5f;
        this._duration = initialDuration;
        this._coolDown = initialCoolDown; // plus bonus
        this._speed = initialSpeed;
        this._range = (this._speed * this._duration) * 0.75f;
    }

    public void Execute()
    {
        this._allSkillObjects.Clear();
        Vector2 newPosition = GameObject.Find(this._target).GetComponent<Rigidbody2D>().position;
        newPosition.x = newPosition.x - spawnDistance;
        temp = (GameObject)Instantiate(this._skillObject, newPosition, defaultRotation);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-this._speed, 0);
        Destroy(temp, this._duration);
    }

    public void Update()
    {
        if (temp != null)
        {
            temp.transform.Rotate(0, 0, 25);
        }
    }
}

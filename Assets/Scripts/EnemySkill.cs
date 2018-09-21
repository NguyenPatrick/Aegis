using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour {

    // protected properties
    protected float _coolDown;
    protected float _damage;
    protected float _duration;
    protected float _range;
    protected string _target;
    protected float _speed;
    
    protected GameObject _skillObject;
    protected List<GameObject> _allSkillObjects = new List<GameObject>();
    protected Quaternion defaultRotation;

    protected float _damageUpgrade;
    protected float _coolDownUpgrade;
    protected float _durationUpgrade;
    protected int _tierValue;
    

    protected bool _enableAttack = true;

    public float GetRange
    {
        get { return this._range; }
    }

    public GameObject GetSkillObject
    {
        get { return this._skillObject; }
    }

    public float GetDamage
    {
        get { return this._damage; }
    }

   

    public bool GetAttackState
    {
        get { return this._enableAttack; }
    }
    
    public IEnumerator ActivateCoolDown()
    {  
        this._enableAttack = false;
        yield return new WaitForSeconds(this._coolDown);
        this._enableAttack = true;
    }
}

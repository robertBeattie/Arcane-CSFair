using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int weaponDamage = 10;
    [SerializeField] protected float weaponAttackSpeed = .1f;
    [SerializeField] public float attackRange = 1;
    float NextAttack = 0;
    protected Transform Hand;

    protected virtual void Awake()
    {
        Hand = this.gameObject.transform.parent;
    }

    public virtual bool Attack() {
        if (Time.time > NextAttack) {
            NextAttack = Time.time + weaponAttackSpeed;
            return true;
        }
        return false;
		
    }
}

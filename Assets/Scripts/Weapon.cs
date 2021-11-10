using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float weaponDamage = 10;
    [SerializeField] protected float weaponAttackSpeed = .1f;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Collidable
{
    [SerializeField] float weaponDamage = 10;
    [SerializeField] float weaponSpeed = 10;
    //cool down
    //Time

    protected override void OnColide(Collider2D coll) {
        if(coll.tag == "Character") {
            Debug.Log(this.gameObject.name + " hit " + coll.name);
		}
    }


}

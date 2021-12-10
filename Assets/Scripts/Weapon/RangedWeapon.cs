using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] GameObject prefabProjectile;
    [SerializeField] float projectileSpeed = 10;

	public override bool Attack() {
        if (!base.Attack()) return false;
        float rot = Hand.rotation.eulerAngles.z;
        FindObjectOfType<AudioManager>().Play("MagicShoot");
        Projectile p = Instantiate(prefabProjectile, Hand.position, Quaternion.Euler(0, 0, rot)).GetComponent<Projectile>();
        //damage, projectile speed, hand -> owner 
        p.Set(weaponDamage, projectileSpeed, Hand.parent.gameObject);

        return true;
    }
        
	
}

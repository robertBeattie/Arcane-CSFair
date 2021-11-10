using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField] GameObject prefabProjectile;
    [SerializeField] float weaponDamage = 10;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float weaponAttackSpeed = .1f;
    float NextAttack = 0;
    Transform Hand;
	private void Awake() {
        Hand = this.gameObject.transform.parent;
    }

	public void Attack() {
        if(Time.time > NextAttack) {
            float rot = Hand.rotation.eulerAngles.z;
            Projectile p = Instantiate(prefabProjectile, Hand.position, Quaternion.Euler(0, 0, rot)).GetComponent<Projectile>();
            //damage, projectile speed, hand -> owner 
            p.Set(weaponDamage, projectileSpeed, Hand.parent.gameObject);

            NextAttack = Time.time + weaponAttackSpeed;
        }
            
    }
        
	
}

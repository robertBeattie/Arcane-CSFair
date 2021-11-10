using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Collidable
{
    [SerializeField] float projectileDamage = 10;
    [SerializeField] float projectileSpeed = 10;
    GameObject projectileCreator;
    protected override void OnColide(Collider2D coll) {
        if ((coll.tag == "Character" || coll.tag == "Blocking") && coll.gameObject != projectileCreator) {
            Debug.Log(this.gameObject.name + " hit " + coll.name);
            if(coll.tag == "Character") {
                coll.gameObject.GetComponent<Health>().UpdateHealth(-projectileDamage);

            }
            Destroy(this.gameObject);
        }
    }

	void FixedUpdate() {
        transform.Translate(transform.up * projectileSpeed * Time.deltaTime);
    }

    public void Set(float damgage, float speed, GameObject creator) {
        projectileDamage = damgage;
        projectileSpeed = speed;
        projectileCreator = creator;

        Destroy(this.gameObject, 3f);
    }

}

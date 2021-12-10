using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MeleeWeapon : Weapon 
{
    [SerializeField] LayerMask collidable;
    private ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    private ArrayList protectedHits = new ArrayList();
    private Transform owner;
    private bool isAttacking = false;

    protected override void Awake() {
        base.Awake();
        boxCollider = GetComponent<BoxCollider2D>();
        owner = Hand.parent;
    }

    protected virtual void Update() {
        // Collision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++) {
            //checks if the hit anything or if the hit is not on the collidable LayerMask
            if (hits[i] == null || protectedHits.Contains(hits[i]) || collidable != (collidable | (1 << hits[i].gameObject.layer))) {
                continue;
            }

            OnColide(hits[i]);
            //The arry is not cleaned up, so we 
            hits[i] = null;

        }
        if (!isAttacking)
            protectedHits.Clear();
    }

    protected void OnColide(Collider2D coll) {
        if ((coll.tag == "Character") && coll.transform != owner && isAttacking) {
            //Debug.Log(gameObject.name + " hit " + coll.name);
            coll.gameObject.GetComponent<Character>().UpdateHealth(-weaponDamage);
            protectedHits.Add(coll);
        }
    }

    public override bool Attack() {
        if (!base.Attack() || isAttacking) 
            return false;

        StartCoroutine("SwingWeapon");

        return true;
    }

    IEnumerator SwingWeapon() {
        isAttacking = true;
        int swingAngle = 180;
        int swingDistance = 5;
        int swingRate = swingAngle / swingDistance;
		for (int i = 0; i < swingRate; i++) {
            transform.Rotate(new Vector3(0, 0, swingDistance));
            yield return new WaitForSeconds(weaponAttackSpeed/swingRate);
        }
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        isAttacking = false;
    }
}

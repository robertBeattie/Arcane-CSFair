using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Collectable
{	
	protected override void OnColide(Collider2D coll) {
		if (!collected) {
			base.OnCollect();
			Debug.Log("Picked up " + gameObject.name);
			GetComponentInChildren<SpriteRenderer>().enabled = false;
		}

	}
}

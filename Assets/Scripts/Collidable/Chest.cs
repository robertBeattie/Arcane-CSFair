using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
	[SerializeField] Sprite emptyChest;
	//[SerializeField] int goldAmount = 5;
	protected override void OnColide(Collider2D coll) {
		if (!collected) {
			base.OnCollect();
			Debug.Log("Chest Collected by " + coll.name );
			GetComponent<SpriteRenderer>().sprite = emptyChest;
		}

	}
}

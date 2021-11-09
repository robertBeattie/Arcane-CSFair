using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
	protected bool collected;

	protected override void OnColide(Collider2D coll) {
		if(coll.tag == "Player") {
			OnCollect();
		}
		 
	}

	protected void OnCollect() {
		collected = true;
	}
}

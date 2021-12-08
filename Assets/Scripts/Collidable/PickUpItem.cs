using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Collectable
{	
	[SerializeField] ItemData item; 
	InventoryController inventoryController;
	protected override void Awake() {
		base.Awake();
		inventoryController = Camera.main.GetComponent<InventoryController>();
	}
	protected override void OnColide(Collider2D coll) {
		if (!collected) {
			base.OnCollect();
			//add to inventory 
			Debug.Log("Picked up " + gameObject.name + " by " + coll.gameObject.name);
			//refernce coll.gameObject.getComponet<Inventory>().add(item)

			inventoryController.AddFromGroundToInventory(item);
			Destroy(this.gameObject);
		}

	}
}

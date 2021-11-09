using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{ 
     public void UpdateHand(Vector2 mousePos, Vector3 ParentCharacterPos) {
        transform.up = (mousePos - (Vector2)ParentCharacterPos).normalized;
	}
}

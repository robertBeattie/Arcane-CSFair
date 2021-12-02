using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{ 
     public void UpdateHand(Vector2 target, Vector3 ParentCharacterPos) {
        transform.up = (target - (Vector2)ParentCharacterPos).normalized;
	}
}

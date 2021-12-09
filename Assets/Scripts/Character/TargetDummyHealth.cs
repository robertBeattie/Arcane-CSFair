using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDummyHealth : Character
{
    bool died = false;
    protected override void onDeath() {
        if(!died)
            StartCoroutine("ResetHealth");
    }

    IEnumerator ResetHealth() {
        died = true;
        yield return new WaitForSeconds(2f);
       health = maxHealth;
        died = false;
	}
}

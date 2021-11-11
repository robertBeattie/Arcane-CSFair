using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHealthBar : MonoBehaviour
{
    RectTransform healthbar;
    Health characterHealth;
	private void Awake() {
		characterHealth = GetComponentInParent<Health>();
		healthbar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponentInParent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
    {
        healthbar.sizeDelta = new Vector2(characterHealth.GetHealth()/100, 0.1f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHealthBar : MonoBehaviour
{
    RectTransform healthbar;
    Health characterHealth;
	float maxHealth;
	private void Awake() {
		characterHealth = GetComponentInParent<Health>();
		maxHealth = characterHealth.GetMaxHealth();
		healthbar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponentInParent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
    {
        healthbar.sizeDelta = new Vector2(characterHealth.GetHealth()/ maxHealth, 0.1f);
	}
}

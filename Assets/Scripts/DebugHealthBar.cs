using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHealthBar : MonoBehaviour
{
    [SerializeField] RectTransform healthbar;
    [SerializeField] Health characterHealth;
	float maxHealth;
	float healthBarHeight;
	[SerializeField] float scale = 1;
	private void Awake() {
		if(characterHealth == null) 
			characterHealth = GetComponentInParent<Health>();
		maxHealth = characterHealth.GetMaxHealth();
		if (healthbar == null) 
			healthbar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponentInParent<RectTransform>();
		healthBarHeight = healthbar.sizeDelta.y;
	}

	// Update is called once per frame
	void Update()
    {
        healthbar.sizeDelta = new Vector2((characterHealth.GetHealth()/ maxHealth) * scale, healthBarHeight);
	}
}

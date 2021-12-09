using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHealthBar : MonoBehaviour
{
    [SerializeField] RectTransform healthbar;
    [SerializeField] Character characterHealth;
	float maxHealth;
	float healthBarHeight;
	[SerializeField] float scale = 1;
	private void Start() {
		if(characterHealth == null) 
			characterHealth = GetComponentInParent<Character>();
		maxHealth = characterHealth.maxHealth;
		if (healthbar == null) 
			healthbar = transform.GetChild(0).GetChild(0).GetChild(0).GetComponentInParent<RectTransform>();
		healthBarHeight = healthbar.sizeDelta.y;
	}

	// Update is called once per frame
	void Update()
    {
        healthbar.sizeDelta = new Vector2((characterHealth.health/ maxHealth) * scale, healthBarHeight);
		if(transform.parent.localScale.x == 1){
			transform.localScale = Vector3.one;
		}else{
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}
}

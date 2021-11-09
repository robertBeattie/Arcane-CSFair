using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 0f;
    [SerializeField] private float maxHealth = 100f;

    void Awaken()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
	{
        health += mod;
        //if health <= 0 Throw onDeath Event
        if(health <= 0) {
            onDeath();
		}
	}

    void onDeath() {
        Destroy(this.gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stats stats;

    private int STAMINA_TO_HEALTH_MOD = 5;
    private int WILL_TO_MANA_MOD = 10;


    public int xp;
    [SerializeField] public int health;
    public int maxHealth;
    [SerializeField] public int mana; 
    public int maxMana;
    
    public int attPwr = 0;

    public int stamina = 0;

    public int will = 0;

    public int physDef = 0;

    public int magicDef = 0;

    public float critDmg = 0;

    public int crit = 0; 

    public int haste = 0; 

    public int evade = 0;

	private void Awake() {
        ReadinStats();

    }


    private void ReadinStats() {
        if(stats == null) return;
        xp = stats.xp;

        maxHealth = stats.stamina * STAMINA_TO_HEALTH_MOD;
        health = maxHealth;
        maxMana = stats.will * WILL_TO_MANA_MOD;
        mana = maxMana;

        attPwr = stats.attPwr;
        physDef = stats.physDef;
        magicDef = stats.magicDef;

        critDmg = stats.critDmg;
        crit = stats.crit;
        haste = stats.haste;
        evade = stats.evade;

    }

    public void UpdateHealth(int mod)
	{
        health += mod;
        //if health <= 0 Throw onDeath Event
        if(health <= 0) {
            health = 0;
            onDeath();
		}
	}
    protected virtual void onDeath() {
        Destroy(this.gameObject);
	}
}

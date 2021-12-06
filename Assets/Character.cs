using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Stats stats;

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

    public float critDmg = 1.75f;

    public int crit = 100; 

    public int haste = 0; 

    public int evade = 0;   
}

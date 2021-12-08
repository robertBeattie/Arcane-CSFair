using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats Default", menuName = "CharacterStats/StatsObject", order = 1)]
public class Stats : ScriptableObject
{  
    //xperience
    public int xp;

    //Stamina - every point = 5 health
    public int stamina = 10;
    //Will -every point = 10mana
    public int will = 10;


    //Atk Pwr - Damage, Heals, Damage Sheilds
    public int attPwr = 10;
    //Phys Def reduces Phy damage by this much
    public int physDef = 0;
    //Magic Def reduces Magic damage by this much
    public int magicDef = 0;


    //Crit Dmg damage scale of critical attacks base 175%
    public float critDmg = 1.75f;
    //Crit = 20 is 1% crit chance
    public int crit = 100; // 5% base
    //Haste = 20 is 1% casting time reduction
    public int haste = 0; 
    //Evade = 20 is 1% chance to dodge 
    public int evade = 0;
}

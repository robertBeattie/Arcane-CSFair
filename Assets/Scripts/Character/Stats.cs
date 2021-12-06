using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats Default", menuName = "CharacterStats/StatsObject", order = 1)]
public class Stats : ScriptableObject
{  
    public int xp;

    //Atk Pwr - Damage, Heals, Damage Sheilds
    public int AttPwr = 0;
    //Will -every point = 10mana
     public int Stamina = 0;
    //Phys Def reduces Phy damage by this much
    public int Will = 0;
    //Stamina - every point = 5 health
    public int PhysDef = 0;
    //Magic Def reduces Magic damage by this much
    public int MagicDef = 0;
    //Crit Dmg damage scale of critical attacks base 175%
    public float CritDmg = 1.75f;
    //Crit = 20 is 1% crit chance
    public int Crit = 100; // 5% base
    //Haste = 20 is 1% casting time reduction
    public int Haste = 0; 
    //Evade = 20 is 1% chance to dodge 
    public int Evade = 0;
}

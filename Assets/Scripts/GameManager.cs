using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    // Ressources
    [SerializeField] List<Sprite> playerSprites;
    [SerializeField] List<Sprite> weaponSprites;
    [SerializeField] List<int> weaponPrices;
    [SerializeField] List<int> xpTable;

    // references

    // Logic
    public int gold;
    public int experience;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private float mana = 0f;
    [SerializeField] private float maxMana = 100f;

    void Awaken()
    {
        mana = maxMana;
    }

    public void UpdateMana(float mod)
    {
        mana += mod;
    }
}

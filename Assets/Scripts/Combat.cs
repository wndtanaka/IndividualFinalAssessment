using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack(CharacterStats targetStats)
    {
        targetStats.TakeDamage(myStats.damage.GetValue()); // calling TakeDamage functions and damage value
    }
}

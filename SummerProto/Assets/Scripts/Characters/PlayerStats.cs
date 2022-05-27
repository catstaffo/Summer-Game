using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int maxLevel = 50;
    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentXP;
    [SerializeField] int[] xpForNextLevel;
    [SerializeField] int baseLevelXP = 100;

    [SerializeField] int maxHP = 100;
    [SerializeField] int currentHP;

    [SerializeField] int maxMana = 30;
    [SerializeField] int currentMana;

    [SerializeField] int dexterity;
    [SerializeField] int defense;
    [SerializeField] int luck;

    int xpFloatOne = (int)0.02f;
    int xpFloatTwo = (int)3.06f;
    int xpFloatThree = (int)105.65f;

    // Start is called before the first frame update
    void Start()
    {
        xpForNextLevel = new int[maxLevel];
        xpForNextLevel[1] = baseLevelXP;

        for(int i = 2; i < xpForNextLevel.Length; i++)
            {
                xpForNextLevel[i] = (xpFloatOne * i * i * i + xpFloatTwo * i * i + xpFloatThree * i);
                // already individually turned these floats into int
                // but just found out that this can also be achieved
                // by simply placing a (int) at the beginning of this entire expression
                // for sake of memory-learning not changing here
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            AddXP(100);
        }
    }

    public void AddXP(int amountOfXP)
    {
        currentXP += amountOfXP; // currentXP = current XP + amountofXP
        if(currentXP > xpForNextLevel[playerLevel])
        {
            currentXP -= xpForNextLevel[playerLevel];
            playerLevel++;
            maxHP = maxHP * (int) 1.18f;
            currentHP = maxHP;
            maxMana = maxMana * (int) 1.06f;
            currentMana = maxMana;

            if(playerLevel % 2 == 0) // modulo checks for remainder
                                     // if there is no remainder i.e. even
                                     // then this executes
            {
                dexterity++;
            }
            else // odd
            {
                defense++;
            }
        }
    }
}

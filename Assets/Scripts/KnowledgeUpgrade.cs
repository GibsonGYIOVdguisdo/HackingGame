using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class KnowledgeUpgrade: Upgrade
{
    public float Modifier = (float)0.50;
    public int Chance = 40;

    public override string Name 
    { 
        get 
        {
            return "Knowledge Upgrade";
        } 
    }

    public int ApplyModifier(int amount)
    {
        float newAmount = amount;
        for (int i = 0; i < Level; i++)
        {
            if (((int)Random.Range(1, 100)) <= Chance)
            {
                newAmount += newAmount * Modifier;
            }
        }

        return (int)Mathf.Ceil(newAmount);
    }
}

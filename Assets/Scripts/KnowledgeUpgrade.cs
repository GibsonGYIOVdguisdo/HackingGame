using System.Runtime.ExceptionServices;
using UnityEngine;

public class KnowledgeUpgrade: Upgrade
{
    public float Modifier = (float)0.10;

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
            if (((int)Random.Range(1, 10)) == 1)
            {
                newAmount *= Modifier;
            }
        }


        return (int)Mathf.Ceil(newAmount);
    }
}

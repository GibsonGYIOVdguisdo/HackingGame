using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int DefaultVictimMoney = 10;
    public int DefaultVictimMoneyVariance = 4;

    public int CalculateVictimMoney()
    {
        int newMoney = Random.Range(DefaultVictimMoney - DefaultVictimMoneyVariance, DefaultVictimMoney + DefaultVictimMoneyVariance);

        newMoney = FindFirstObjectByType<KnowledgeUpgrade>().ApplyModifier(newMoney);

        return newMoney;
    }
}

using System.Data.SqlTypes;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private static int s_money = 0;

    public int GetMoney()
    {
        return s_money;
    }

    public void SetMoney(int amount)
    {
        s_money = amount;
    }
}
    
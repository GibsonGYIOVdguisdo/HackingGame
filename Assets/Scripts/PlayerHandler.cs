using System.Data.SqlTypes;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private static int s_money;

    // Upgrades information
    private static int s_programmingLevel;


    public event System.Action<int> OnMoneyChanged;

    public int Money { 
        set
        {
            s_money = Mathf.Max(0, value);
            OnMoneyChanged?.Invoke(s_money);
        }
        get 
        {
            return s_money;
        }
    }
}
    
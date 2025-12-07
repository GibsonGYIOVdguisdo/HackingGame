using System.Data.SqlTypes;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private static int s_money;

    public event System.Action<int> OnScoreChanged;

    public int Money { 
        set
        {
            s_money = Mathf.Max(0, value);
            OnScoreChanged?.Invoke(s_money);
        }
        get 
        {
            return s_money;
        }
    }
}
    
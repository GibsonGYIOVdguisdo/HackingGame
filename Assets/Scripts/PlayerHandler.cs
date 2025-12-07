using System.Data.SqlTypes;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private static int s_money;
    
    public int Money { 
        set
        {
            s_money = Mathf.Max(0, value);
        }
        get 
        {
            return s_money;
        }
    }
}
    
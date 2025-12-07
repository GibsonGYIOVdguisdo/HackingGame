using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private int _money = 10000;
    public event System.Action<int> OnMoneyChanged;

    // Upgrade Related
    public KnowledgeUpgrade KnowledgeUpgrade;

    public int Money { 
        set
        {
            _money = Mathf.Max(0, value);
            OnMoneyChanged?.Invoke(_money);
        }
        get 
        {
            return _money;
        }
    }
}
    
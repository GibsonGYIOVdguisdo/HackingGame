using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class UpgradeItem : MonoBehaviour
{
    private string _name = "";
    private int _cost = 0;
    private int _level = 0;

    public int Cost
    {
        get
        {
            return _cost;
        }
        set
        {
            _cost = value;
        }
    }

    public int Level 
    { 
        get
        {
            return _level;
        } 
    }

    public virtual int Purchase()
    {
        FindFirstObjectByType<PlayerHandler>().Money -= _cost;
        _level += 1;
        return _level;
    }

    public int PurchaseIfPossible()
    {
        PlayerHandler playerHandler = FindFirstObjectByType<PlayerHandler>();
        if (playerHandler.Money >= _cost)
        {
            return Purchase();
        }
        return _level;
    }
}

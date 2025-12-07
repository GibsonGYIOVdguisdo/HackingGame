using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public abstract class UpgradeItem : MonoBehaviour
{
    public GameObject MoneyTextGameObject;
    public GameObject UpgradeNameTextGameObject;

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
        UpdateCost();
        UpdateDisplayedData();

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

    public virtual void UpdateCost()
    {
        _cost = _cost + (_level * 1);
    }

    private void UpdateDisplayedData()
    {
        MoneyTextGameObject.GetComponent<TextMeshProUGUI>().text = "£" + _cost.ToString();
        UpgradeNameTextGameObject.GetComponent<TextMeshProUGUI>().text = _name;
    }
}

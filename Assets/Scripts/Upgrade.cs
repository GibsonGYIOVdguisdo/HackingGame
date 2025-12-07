using TMPro;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    public virtual string Name 
    { 
        get 
        {
            return "";
        } 
    }

    public TextMeshProUGUI InfoTMP;

    public int BaseCost = 1;
    public float Multiplier = 2;

    private int _level = 0;

    public int Cost
    {
        get
        {
            return BaseCost * ((int)Mathf.Pow(Multiplier, _level));
        }
    }

    public int Level
    {
        get
        {
            return _level;
        }
    }

    public event System.Action<int, int> OnPurchase;

    void Start()
    {
        UpdateDisplayedData();
    }

    public void Purchase()
    {
        if (FindFirstObjectByType<PlayerHandler>().Money > Cost)
        {
            FindFirstObjectByType<PlayerHandler>().Money -= Cost;
            FindAnyObjectByType<NotifcationHandler>().CreateNotification($"Successfully purchased {name} for £{Cost}");
            _level += 1;
            UpdateDisplayedData();
            OnPurchase?.Invoke(_level, Cost);
        }
    }

    public void UpdateDisplayedData()
    {
        InfoTMP.text = Name + "\n£" + Cost;
    }
}

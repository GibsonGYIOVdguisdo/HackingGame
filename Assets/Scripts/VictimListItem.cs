using System;
using TMPro;
using UnityEngine;

public class VictimListItem : MonoBehaviour
{
    public GameObject NameAndDescriptionGameObject;
    public GameObject MoneyTextGameObject;

    private Victim _victim;
    private string _defaultNameText;
    private string _defaultMoneyText;

    public Victim Victim {
        get
        {
            return _victim;
        }
        set
        {
            _victim = value;
            UpdateDisplayedDetails();
        }
    }

    void Awake()
    {
        _defaultNameText = NameAndDescriptionGameObject.GetComponent<TextMeshProUGUI>().text;
        _defaultMoneyText = MoneyTextGameObject.GetComponent<TextMeshProUGUI>().text;
    }

    private void Start()
    {
        _victim = new Victim();
        UpdateDisplayedDetails();
    }

    private void UpdateDisplayedDetails()
    {
        string newNameText = _defaultNameText;
        string newMoneyText = _defaultMoneyText;
        
        newNameText = newNameText.Replace("{Name}", _victim.FirstName + " " + _victim.LastName);
        newNameText = newNameText.Replace("{Description}", _victim.Vulnerability);
        newMoneyText = newMoneyText.Replace("{Money}", "£" + _victim.Money.ToString());

        NameAndDescriptionGameObject.GetComponent<TextMeshProUGUI>().text = newNameText;
        MoneyTextGameObject.GetComponent<TextMeshProUGUI>().text = newMoneyText;
    }
}

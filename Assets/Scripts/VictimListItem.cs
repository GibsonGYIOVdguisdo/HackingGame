using System;
using TMPro;
using UnityEngine;

public class VictimListItem : MonoBehaviour
{
    public GameObject NameAndDescriptionGameObject;
    public GameObject MoneyTextGameObject;
    private string _defaultNameText;
    private string _defaultMoneyText;

    private string _name = "";
    private string _description = "";
    private string _money = "";

    public string Name
    {
        set
        {
            _name = value;
            UpdateDisplayedDetails();
        }
    }

    public string Description
    {
        set
        {
            _description = value;
            UpdateDisplayedDetails();
        }
    }

    public int Money
    {
        set
        {
            _money = "£" + value.ToString();
            UpdateDisplayedDetails();
        }
    }


    void Awake()
    {
        _defaultNameText = NameAndDescriptionGameObject.GetComponent<TextMeshProUGUI>().text;
        _defaultMoneyText = MoneyTextGameObject.GetComponent<TextMeshProUGUI>().text;
    }

    private void UpdateDisplayedDetails()
    {
        string newNameText = _defaultNameText;
        string newMoneyText = _defaultMoneyText;

        newNameText = newNameText.Replace("{Name}", _name);
        newNameText = newNameText.Replace("{Description}", _description);
        newMoneyText = newMoneyText.Replace("{Money}", _money);

        NameAndDescriptionGameObject.GetComponent<TextMeshProUGUI>().text = newNameText;
        MoneyTextGameObject.GetComponent<TextMeshProUGUI>().text = newMoneyText;
    }
}

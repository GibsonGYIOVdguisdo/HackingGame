using TMPro;
using UnityEngine;

public class BankUpdater : MonoBehaviour
{
    public GameObject MoneyTextGameObject;

    private PlayerHandler _playerHandler;

    void Start()
    {
        _playerHandler = FindFirstObjectByType<PlayerHandler>();
        _playerHandler.OnMoneyChanged += UpdateMoney;
    }

    private void UpdateMoney(int amount)
    {
        MoneyTextGameObject.GetComponent<TextMeshProUGUI>().text = FormatMoney(amount);
    }

    private string FormatMoney(int amount)
    {
        return "£" + amount.ToString();
    }
}

using TMPro;
using UnityEngine;

public class VictimListItem : MonoBehaviour
{
    public GameObject NameAndDescriptionGameObject;
    public GameObject MoneyTextGameObject;

    private Victim _victim;
    private string _defaultNameText;
    private string _defaultMoneyText;
    private float _lifeTimeTimer = 0;

    public float DefaultLifeTime = 10;
    public float LifeTimeVariance = 2;

    private float _lifeTime;

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
        int victimsMoney = FindFirstObjectByType<UpgradeManager>().CalculateVictimMoney();
        _lifeTime = Random.Range(DefaultLifeTime - LifeTimeVariance, DefaultLifeTime + LifeTimeVariance);

        _victim = new Victim(victimsMoney);
        UpdateDisplayedDetails();
    }

    public void Update()
    {
        _lifeTimeTimer += Time.deltaTime;
        if (_lifeTimeTimer >= _lifeTime)
        {
            FindFirstObjectByType<VictimListManager>().RemoveVictim(this);
        }
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

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void OnClick()
    {
        VictimInfoManager victimInfoManager = FindFirstObjectByType<VictimInfoManager>(FindObjectsInactive.Include);
        victimInfoManager.Victim = _victim;
        victimInfoManager.ShowPanel();
    }
}

using TMPro;
using UnityEngine;

public class VictimInfoManager : MonoBehaviour
{
    public GameObject NameGameObject;
    public GameObject DescriptionGameObject;
    public GameObject VulnerabilityGameObject;
    
    private Victim _victim;

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

    private void UpdateDisplayedDetails()
    {
        NameGameObject.GetComponent<TextMeshProUGUI>().text = _victim.FirstName + " " + _victim.LastName;
        DescriptionGameObject.GetComponent<TextMeshProUGUI>().text = _victim.Description;
        VulnerabilityGameObject.GetComponent<TextMeshProUGUI>().text = _victim.VulnerabilityDescription;
    }

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        HideAllPanels();
        gameObject.SetActive(true);
    }

    private void HideAllPanels()
    {
        for (int i = 0; i < gameObject.transform.parent.childCount; i++)
        {
            gameObject.transform.parent.GetChild(i).gameObject.SetActive(false);
        }
    }
}

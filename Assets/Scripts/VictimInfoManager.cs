using TMPro;
using UnityEngine;

public class VictimInfoManager : MonoBehaviour
{
    public GameObject NameGameObject;
    public GameObject DescriptionGameObject;
    public GameObject VulnerabilityGameObject;

    private Victim _victim;

    public Victim victim { 
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
}

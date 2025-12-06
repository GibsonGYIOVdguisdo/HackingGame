using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class VictimListManager : MonoBehaviour
{
    private HashSet<VictimListItem> _victimListItems = new HashSet<VictimListItem>();
    public GameObject VictimListGameObject;
    public GameObject VictimItemPrefab;

    void Start()
    {
        AddNewVictim();
        AddNewVictim();
        AddNewVictim();
        AddNewVictim();
        AddNewVictim();
        AddNewVictim();
        AddNewVictim();
    }

    private void AddNewVictim()
    {
        Victim newVictim = new Victim();
        GameObject victimItem = Instantiate(VictimItemPrefab);
        _victimListItems.Add(victimItem.GetComponent<VictimListItem>());
        victimItem.transform.SetParent(VictimListGameObject.transform);
    }
}

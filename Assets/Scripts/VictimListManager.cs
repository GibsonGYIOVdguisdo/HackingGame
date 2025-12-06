using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class VictimListManager : MonoBehaviour
{
    private HashSet<VictimListItem> _victimListItems = new HashSet<VictimListItem>();
    public GameObject VictimListGameObject;
    public GameObject VictimItemPrefab;


    private VictimListItem CreateVictim()
    {
        Victim newVictim = new Victim();
        GameObject victimItem = Instantiate(VictimItemPrefab);
        _victimListItems.Add(victimItem.GetComponent<VictimListItem>());
        victimItem.transform.SetParent(VictimListGameObject.transform);
        return victimItem.GetComponent<VictimListItem>();
    }

    public void RemoveVictim(VictimListItem victimListItem)
    {
        _victimListItems.Remove(victimListItem);
        victimListItem.Destroy();
    }
}

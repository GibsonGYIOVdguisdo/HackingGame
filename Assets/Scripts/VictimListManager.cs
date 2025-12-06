using UnityEngine;
using System.Collections.Generic;

public class VictimListManager : MonoBehaviour
{
    private List<Victim> _victims = new List<Victim>();
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
        _victims.Add(newVictim);
        victimItem.transform.SetParent(VictimListGameObject.transform);

        VictimListItem victimListItem = victimItem.GetComponent<VictimListItem>();
        victimListItem.Victim = newVictim;
    }
}

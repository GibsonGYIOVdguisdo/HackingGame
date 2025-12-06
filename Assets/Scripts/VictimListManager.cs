using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class VictimListManager : MonoBehaviour
{
    private HashSet<VictimListItem> _victimListItems = new HashSet<VictimListItem>();
    public GameObject VictimListGameObject;
    public GameObject VictimItemPrefab;

    public const float SecondsBetweenResets = 600;
    public const float MaxVictimCount = 10;
    
    private float _resetTimer = 0;

    private void Start()
    {
        RegenerateVictimList();
    }


    void Update()
    {
        _resetTimer += Time.deltaTime;
        if (_resetTimer > SecondsBetweenResets)
        {
            RegenerateVictimList();
            _resetTimer = 0;
        }
    }
    
    private void RegenerateVictimList()
    {
        for (int i = 0; i < MaxVictimCount; i++)
        {
            CreateVictim();
        }
    }

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

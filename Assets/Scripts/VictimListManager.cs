using System;
using System.Collections.Generic;
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

    public VictimListItem CreateVictim()
    {
        GameObject victimItem = Instantiate(VictimItemPrefab);
        _victimListItems.Add(victimItem.GetComponent<VictimListItem>());
        victimItem.transform.SetParent(VictimListGameObject.transform);
        victimItem.transform.localScale = new Vector3(1, 1, 1);
        return victimItem.GetComponent<VictimListItem>();
    }

    public void RemoveVictim(VictimListItem victimListItem)
    {
        _victimListItems.Remove(victimListItem);
        victimListItem.Destroy();
    }
    public void RemoveVictim(Victim victim)
    {
        foreach(VictimListItem currentVictimItem in _victimListItems){
            if (currentVictimItem.Victim == victim)
            {
                _victimListItems.Remove(currentVictimItem);
                currentVictimItem.Destroy();
                return;
            }
        }
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

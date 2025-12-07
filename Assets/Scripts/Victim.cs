using System;
using Unity.VisualScripting;
using UnityEngine;
    
public class Victim
{
    private int _money = 0;
    private string _firstName;
    private string _lastName;
    private string _description;
    private Vulnerability _vulnerability;

    public string FirstName
    {
        get
        {
            return _firstName;
        }
    }

    public string LastName { 
        get { 
            return _lastName; 
        } 
    }

    public string Description
    {
        get
        {
            return _description;
        }
    }

    public string VulnerabilityDescription
    {
        get
        {
            return _vulnerability.Description;
        }
    }

    public string Vulnerability
    {
        get
        {
            return _vulnerability.Name;
        }
    }
    public int Money
    {
        get
        {
            return _money;
        }
    }

    public Victim(int money)
    {
        _firstName = ChooseFirstName();
        _lastName = ChooseLastName();
        _description = ChooseDescription();
        _vulnerability = new Vulnerability();
        _money = money;
    }

    private string ChooseFirstName()
    {
        return "FirstName";
    }
    
    private string ChooseLastName()
    {
        return "LastName";
    }

    private string ChooseDescription()
    {
        return "This is a victim description";
    }
}

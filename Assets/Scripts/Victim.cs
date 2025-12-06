using System;
using UnityEngine;
    
public class Victim
{
    private int _money = 0;
    private string _firstName;
    private string _lastName;
    private string _description;
    private string _hackingDescription;
    private string _hackType;

    private enum _hackTypes { Malware, Email };

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

    public string HackingDescription
    {
        get
        {
            return _hackingDescription;
        }
    }

    public string HackType
    {
        get
        {
            return _hackType;
        }
    }
    public int Money
    {
        get
        {
            return _money;
        }
    }

    public Victim()
    {
        _firstName = ChooseFirstName();
        _lastName = ChooseLastName();
        _description = ChooseDescription();
        _hackingDescription = ChooseHackingDescription();
        _hackType = ChooseHackingType();
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

    private string ChooseHackingDescription()
    {
        return "This is a description of the hack";
    }

    private string ChooseHackingType()
    {
        var hacktypes = Enum.GetNames(typeof(_hackTypes));
        string randomHackType = hacktypes[UnityEngine.Random.Range(0, hacktypes.Length)];
        return randomHackType;
    }
}

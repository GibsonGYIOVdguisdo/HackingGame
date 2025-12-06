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

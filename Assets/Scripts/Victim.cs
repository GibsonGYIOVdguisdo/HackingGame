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
        string[] allOptions = FileManager.ReadSeperatedValuesFromFile("FirstNameOptions");
        return allOptions[UnityEngine.Random.Range(0, allOptions.Length)];
    }
    
    private string ChooseLastName()
    {
        string[] allOptions = FileManager.ReadSeperatedValuesFromFile("LastNameOptions");
        return allOptions[UnityEngine.Random.Range(0, allOptions.Length)];
    }

    private string ChooseDescription()
    {
        string[] allOptions = FileManager.ReadSeperatedValuesFromFile("DescriptionOptions");
        string selectedOption = allOptions[UnityEngine.Random.Range(0, allOptions.Length)];
        selectedOption = selectedOption.Replace("{FirstName}", _firstName);
        selectedOption = selectedOption.Replace("{LastName}", _lastName);

        return selectedOption;
    }

    public string GenerateEmail()
    {
        if ((int)Random.Range(0,2) == 1)
        {
            return _firstName + (int)Random.Range(0, 999) + "@email.com";
        }
        else
        {
            return _firstName + "." + _lastName + "@email.com";
        }
    }
}

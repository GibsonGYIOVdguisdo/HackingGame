using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CapchaManager : MonoBehaviour
{
    public GameObject CapchaImageGameObject;
    public GameObject InputFieldGameObject;

    public Sprite[] _spritesForCapcha;
    public string[] _answersForCapcha;


    private string _capchaAnswer;
    private Image _capchaImage;
    private InputField _inputField;

    private Victim _victim;

    public Victim Victim
    {
        get
        {
            return _victim;
        }
        set
        {
            _victim = value;
        }
    }


    private void Start()
    {
        _capchaImage = CapchaImageGameObject.GetComponent<Image>();
        StartNewCapchaGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendAnswer(GetInputString());
        }
    }

    public void StartNewCapchaGame()
    {
        ChooseCapcha(Random.Range(0, _spritesForCapcha.Length));
    }

    private void EndCapchaGame()
    {
        ResetInputBox();
        FindFirstObjectByType<PlayerHandler>().Money += _victim.Money;
        VictimListManager victimListManager = FindFirstObjectByType<VictimListManager>(FindObjectsInactive.Include);
        victimListManager.RemoveVictim(_victim);
        victimListManager.CreateVictim();
        victimListManager.ShowPanel();
        SendHackSuccessNotification();
    }

    void ResetInputBox()
    {
        InputFieldGameObject.GetComponent<TMP_InputField>().text = "";
    }

    void SendAnswer(string guess)
    {
        if(guess == _capchaAnswer)
        {
            EndCapchaGame();
        }
        else
        {
            ResetInputBox();
        }
    }

    string GetInputString()
    {
        return InputFieldGameObject.GetComponent<TMP_InputField>().text;
    }

    void ChooseCapcha(int i)
    {
        _capchaAnswer = _answersForCapcha[i];
        _capchaImage.sprite = _spritesForCapcha[i];
    }


    /// <summary>
    /// Default Panel Actions
    /// </summary>

    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        HideAllPanels();
        gameObject.SetActive(true);
        StartNewCapchaGame();
    }

    private void HideAllPanels()
    {
        for (int i = 0; i < gameObject.transform.parent.childCount; i++)
        {
            gameObject.transform.parent.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void SendHackSuccessNotification()
    {
        FindFirstObjectByType<NotifcationHandler>().CreateNotification($"Hack on {_victim.FirstName} was a success! \n+£{_victim.Money}");
    }
}

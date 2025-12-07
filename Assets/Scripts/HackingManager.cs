
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class HackingManager : MonoBehaviour
{
    public GameObject GrayTextGameObject;
    public GameObject PlayerTextGameObject;
    private TextMeshProUGUI _grayTextTMP;
    private TextMeshProUGUI _playerTextTMP;
    private string _textToType = "";
    private int _textPosition = 0;
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
            _textPosition = 0;
            if (_grayTextTMP)
            {
                SetTextToType(Vulnerability.GetRandomTypingText(_victim.Vulnerability));

            }
        }
    }

    void Start()
    {
        _grayTextTMP = GrayTextGameObject.GetComponent<TextMeshProUGUI>();
        _playerTextTMP = PlayerTextGameObject.GetComponent<TextMeshProUGUI>();
        SetTextToType(Vulnerability.GetRandomTypingText(_victim.Vulnerability));
    }

    private void Update()
    {

        if (_textPosition >= _textToType.Length)
        {
            EndTypingGame();
            return;
        }

        char currentChar = _textToType[_textPosition];
        
        if (currentChar == ' ')
        {
            IncrementPosition();
        }
        else if (char.IsLetterOrDigit(currentChar))
        {
            if (Input.GetKeyDown(currentChar.ToString().ToLower()))
            {
                IncrementPosition();
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                IncrementPosition();
            }
        }

    }

    private void EndTypingGame()
    {
        FindFirstObjectByType<PlayerHandler>().Money += _victim.Money;
        VictimListManager victimListManager = FindFirstObjectByType<VictimListManager>(FindObjectsInactive.Include);
        victimListManager.RemoveVictim(_victim);
        victimListManager.CreateVictim();
        victimListManager.ShowPanel();
        SendHackSuccessNotification();
    }

    private void SetTextToType(string textToType)
    {
        string newText = Vulnerability.GetRandomTypingText(_victim.Vulnerability);
        if (_victim.Vulnerability == "Email")
        {
            newText = "To: " + _victim.GenerateEmail() + "\n" + newText;
        }

        _textToType = newText;
        _grayTextTMP.text = newText;
        _playerTextTMP.text = "";
        _textPosition = 0;
    }

    private void UpdatePlayerText()
    {
        _playerTextTMP.text = _textToType.Substring(0, _textPosition);
    }
    
    private void IncrementPosition()
    {
        _textPosition += 1;
        UpdatePlayerText();
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

    private void SendHackSuccessNotification()
    {
        FindFirstObjectByType<NotifcationHandler>().CreateNotification($"Hack on {_victim.FirstName} was a success! \n+£{_victim.Money}");
    }
}
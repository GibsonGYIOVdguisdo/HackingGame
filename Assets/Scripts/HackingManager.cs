using TMPro;
using UnityEngine;

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
        }
    }

    private void Start()
    {
        _grayTextTMP = GrayTextGameObject.GetComponent<TextMeshProUGUI>();
        _playerTextTMP = PlayerTextGameObject.GetComponent<TextMeshProUGUI>();
        ChooseTextToType();
    }

    private void Update()
    {
        char currentChar = _textToType[_textPosition];
        Debug.Log(currentChar);

        if (char.IsLetterOrDigit(currentChar))
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

        if (_textPosition == _textToType.Length)
        {
            FindFirstObjectByType<PlayerHandler>().Money += _victim.Money;
        }
    }

    private void ChooseTextToType()
    {
        _textToType = "private int _money = 0;\nprivate string _firstName;\nprivate string _lastName;\nprivate string _description;\nprivate Vulnerability _vulnerability;";
        _grayTextTMP.text = _textToType;
        _playerTextTMP.text = "";
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
}
using TMPro;
using UnityEngine;

public class HackingManager : MonoBehaviour
{
    public GameObject GrayTextGameObject;
    public GameObject PlayerTextGameObject;
    private TextMeshProUGUI _grayTextTMP;
    private TextMeshProUGUI _playerTextTMP;

    private void Start()
    {
        _grayTextTMP = GrayTextGameObject.GetComponent<TextMeshProUGUI>();
        _playerTextTMP = PlayerTextGameObject.GetComponent<TextMeshProUGUI>();
        ChooseTextToType();
    }

    private void ChooseTextToType()
    {
        _grayTextTMP.text = "private int _money = 0;\r\nprivate string _firstName;\r\nprivate string _lastName;\r\nprivate string _description;\r\nprivate Vulnerability _vulnerability;";
        _playerTextTMP.text = "";
    }


}

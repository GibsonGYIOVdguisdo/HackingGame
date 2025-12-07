
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LoginUsersSelectionChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public GameObject nameText;
    public GameObject objectInDiscription;

    private float _openedHeight;
    private float _closedOrDefualtHeight;

    private Image _image;
    private RectTransform _rectTransform;

    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
        _rectTransform = gameObject.GetComponent<RectTransform>();
        SetButtonHeightValues(30f);
        DeselectThisUserProfile();
    }

    private void SetButtonHeightValues(float increaseAmount)
    {
        _closedOrDefualtHeight = _rectTransform.sizeDelta.y;
        _openedHeight = _rectTransform.sizeDelta.y + increaseAmount;
    }

    private void SelectThisUserProfile()
    {
        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, _openedHeight);
        objectInDiscription.SetActive(true);
        nameText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopLeft;

        Color c = _image.color;
        c.a = 1;
        _image.color = c;


    }

    private void DeselectThisUserProfile()
    {
        _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, _closedOrDefualtHeight);
        objectInDiscription.SetActive(false);
        nameText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.MidlineLeft;

        Color c = _image.color;
        c.a = 0;
        _image.color = c;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectThisUserProfile();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DeselectThisUserProfile();
    }

    public void OnSelect(BaseEventData eventData)
    {
        SelectThisUserProfile();

    }

    public void OnDeselect(BaseEventData eventData)
    {
        DeselectThisUserProfile();

    }
}

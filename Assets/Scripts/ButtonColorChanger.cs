using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    private List<TextMeshProUGUI> _textChildrenOfButton = new List<TextMeshProUGUI>();

    private void Start()
    {
        TextMeshProUGUI[] textChildrenOfButton = gameObject.GetComponentsInChildren<TextMeshProUGUI>(true);
        for (int i = 0; i < textChildrenOfButton.Length; i++)
        {
            _textChildrenOfButton.Add(textChildrenOfButton[i].gameObject.GetComponent<TextMeshProUGUI>());
        }
    }

    private void SetTextColors(Color color)
    {
        for (int i = 0; i < _textChildrenOfButton.Count(); i++)
        {
            _textChildrenOfButton[i].color = color;
        }
    }

    private void SetButtonSpriteColor(Color color)
    {
        gameObject.GetComponent<Image>().color = color;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        SetTextColors(Color.black);
        SetButtonSpriteColor(Color.white);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetTextColors(Color.white);
        SetButtonSpriteColor(Color.black);
    }

    public void OnSelect(BaseEventData eventData)
    {
        SetTextColors(Color.black);
        SetButtonSpriteColor(Color.white);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        SetTextColors(Color.white);
        SetButtonSpriteColor(Color.black);
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotifcationHandler : MonoBehaviour

{
    public int LingerTimer = 3;
    public GameObject NotificationPrefab;

    private IEnumerator NotificationChangePosition(float progress, GameObject notification)
    {
        yield return new WaitForSeconds(progress);
        notification.transform.position = new Vector2(1845 - 1000 * Mathf.Pow(progress, 1 / 20f), 60);
    }
    private IEnumerator NotificationChangeTransparency(float progress, GameObject notification)
    {
        yield return new WaitForSeconds(progress * 3 + LingerTimer);
        notification.GetComponent<Image>().color = new Vector4(255, 255, 255, 1 - progress);
        notification.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = new Vector4(0, 0, 0, 1 - progress);
    }
    
    private IEnumerator DeleteNotifcation(GameObject notification)
    {
        yield return new WaitForSeconds(8);
        Destroy(notification);
    }

    public void CreateNotification(string text)
    {
        GameObject notification = Instantiate(NotificationPrefab);
        notification.transform.SetParent(transform);
        notification.transform.position = new Vector2(845 + 1000, 60);

        notification.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = text;

        for (float i = 1; i < 101; i++)
        {
            StartCoroutine(NotificationChangePosition(i / 100f, notification));
            StartCoroutine(NotificationChangeTransparency(i / 100f, notification));
        }

        DeleteNotifcation(notification);
    }
}

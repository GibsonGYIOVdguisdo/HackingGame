using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private PlayerHandler _playerHandler;

    void Start()
    {
        _playerHandler = GetComponent<PlayerHandler>();
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;

    private void OnEnable()
    {
        GameEvents.OnLevelUp += OpenLevelUpPanel;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelUp -= OpenLevelUpPanel;
    }

    private void OpenLevelUpPanel()
    {
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }


}

using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private GameObject levelUpPanel;


    public void ClosePanel()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

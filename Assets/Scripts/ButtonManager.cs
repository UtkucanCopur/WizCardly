using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private int buttonIndex;

    public void ClosePanel()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void SelectedButtonIndex()
    {
        GameEvents.ButtonSelected(buttonIndex);
    }

}

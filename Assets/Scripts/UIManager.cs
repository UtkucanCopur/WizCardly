using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private Button[] powerUpButtons;
    [SerializeField] private Sprite[] powerUpButtonFrames;
    

    private void OnEnable()
    {
        GameEvents.OnLevelUp += OpenLevelUpPanel;
        GameEvents.OnLevelUp += ButtonFrameSelector;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelUp -= OpenLevelUpPanel;
        GameEvents.OnLevelUp -= ButtonFrameSelector;
    }

    private void OpenLevelUpPanel()
    {
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void ButtonFrameSelector()
    {
        int rand;
        for (int i = 0; i < powerUpButtons.Length; i++)
        {
            rand = Random.Range(0, powerUpButtonFrames.Length);
            powerUpButtons[i].image.sprite = powerUpButtonFrames[rand];
        }
    }


}

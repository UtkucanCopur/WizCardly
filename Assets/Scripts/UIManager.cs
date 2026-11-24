using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private Button[] powerUpButtons;
    [SerializeField] private TextMeshProUGUI[] powerUpInfo;
    [SerializeField] private Image[] powerUpImages;
    [SerializeField] private PowerUpData[] powerUps;
    [SerializeField] private string[] currentPowerUps;
    [SerializeField] private GameObject mageEffect;



    private void OnEnable()
    {
        GameEvents.OnLevelUp += OpenLevelUpPanel;
        GameEvents.OnLevelUp += ButtonFrameSelector;
        GameEvents.OnButtonSelected += GetPowerUpName;
        GameEvents.OnMageEffectActive += OpenMageEffect;
    }

    private void OnDisable()
    {
        GameEvents.OnMageEffectActive -= OpenMageEffect;
        GameEvents.OnLevelUp -= OpenLevelUpPanel;
        GameEvents.OnLevelUp -= ButtonFrameSelector;
        GameEvents.OnButtonSelected -= GetPowerUpName;
    }

    private void OpenMageEffect()
    {
        mageEffect.SetActive(true);
        Invoke("CloseMageEffect", .3f);
    }
    private void CloseMageEffect() => mageEffect.SetActive(false);

    

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
        for (int i = 0; i < 3; i++)
        {
            rand = UnityEngine.Random.Range(0, powerUps.Length);
            powerUpButtons[i].image.sprite = powerUps[rand].Frame;
            powerUpInfo[i].text = powerUps[rand].PowerUpInfo;
            powerUpImages[i].sprite = powerUps[rand].PowerUpImage;
            currentPowerUps[i] = powerUps[rand].methodName;

        }
    }

    public void GetPowerUpName(int index)
    {
        string selectedPowerUp = currentPowerUps[index];
        GameEvents.PowerUpSelected(selectedPowerUp);
    }

    


    


}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private UIManager manager;
    [SerializeField] private Dictionary<string, Action> powerUpMethods = new Dictionary<string, Action>();


    private void OnEnable()
    {
        GameEvents.OnPowerUpSelected += ApplyPowerUp;
    }
    private void OnDisable()
    {
        GameEvents.OnPowerUpSelected -= ApplyPowerUp;
    }


    private void Awake()
    {
        powerUpMethods.Add("IncreaseAttackValue", IncreaseAttackValue);
        powerUpMethods.Add("IncreaseMaxHealth", IncreaseMaxHealth);
        powerUpMethods.Add("IncreaseSpeed", IncreaseSpeed);
        powerUpMethods.Add("IncreaseExpMultiplier", IncreaseExpMultiplier);
    }

    private void ApplyPowerUp(string methodName)
    {
        if (powerUpMethods.TryGetValue(methodName, out Action method))
        {
            method.Invoke();
        }
        else
        {
            Debug.LogWarning("PowerUp bulunamadı: " + methodName);
        }
    }

    public void IncreaseAttackValue()
    {
        playerData.damage += 5;
        playerData.damage = Mathf.Clamp(playerData.damage, 0f, 9999);
    }

    public void IncreaseMaxHealth()
    {
        playerData.maxHealth += 10;
        playerData.health += 10;
        playerData.health = Mathf.Clamp(playerData.health, 0f, playerData.maxHealth);
    }

    public void IncreaseSpeed()
    {
        playerData.speed += 1f;
        playerData.speed = Mathf.Clamp(playerData.speed, 0f, 10f);
    }

    public void IncreaseExpMultiplier()
    {
        playerData.expMultiplier += .5f;
        playerData.expMultiplier = Mathf.Clamp(playerData.expMultiplier, 1f, 5f);
    }


}

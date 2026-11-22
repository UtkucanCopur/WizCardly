using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    

    public enum PowerUpTypes
    {
        ACTIVE,
        PASSIVE,
        GUN

    }


    [SerializeField] private PlayerData playerData;
    [SerializeField] private PowerUpData powerUpData;
    [SerializeField] private PowerUpTypes powerUpTypes;

    public void RandomPowerUpSelector()
    {
        switch (powerUpTypes)
        {
            case PowerUpTypes.ACTIVE:
                int rand = Random.Range(0, powerUpData.ActivePowerUpImages.Length);
                break;
            case PowerUpTypes.PASSIVE:
                break;
            case PowerUpTypes.GUN:
                break;
            default:
                break;
        }
    }

    public void IncreaseAttackValue(float amount)
    {
        playerData.damage += amount;
        playerData.damage = Mathf.Clamp(playerData.damage, 0f, 9999);
    }

    public void IncreaseMaxHealth(float amount)
    {
        playerData.maxHealth += amount;
        playerData.health += amount;
        playerData.health = Mathf.Clamp(playerData.health, 0f, playerData.maxHealth);
    }

    public void IncreaseSpeed(float amount)
    {
        playerData.speed += amount;
        playerData.speed = Mathf.Clamp(playerData.speed, 0f, 10f);
    }

    public void IncreaseExpMultiplier(float amount)
    {
        playerData.expMultiplier += amount;
        playerData.expMultiplier = Mathf.Clamp(playerData.expMultiplier, 1f, 5f);
    }


}

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerStatManager : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Camera cam;
    [SerializeField] private Volume volume;
    [SerializeField] private Vignette vignette;

    private void OnEnable()
    {
        GameEvents.OnLowEnemyDeath += GainExp;
    }

    private void OnDisable()
    {
        GameEvents.OnLowEnemyDeath -= GainExp;
    }


    private void Awake()
    {
        playerData.health = playerData.maxHealth;
        if (cam == null) 
            cam = Camera.main;
        volume.profile.TryGet(out vignette);
    }



    public void TakeDamage(float damage)
    {
        playerData.health -= damage;
    }


    
    public void ChangeSpeedValue(float amount, bool isPositive)
    {
        if (playerData.speed <= 0) return;

        if (isPositive)
            playerData.speed = playerData.speed + amount;
        else
            playerData.speed = playerData.speed - amount;

        playerData.speed = Mathf.Clamp(playerData.speed, 2f, 10f);

    }

    private void GainExp(float amount)
    {
        playerData.exp += amount;
        CheckExp();
    }
    private void CheckExp()
    {
        if (playerData.exp >= playerData.maxExp)
        {
            GameEvents.LevelUp();
        }
    }

    public void ChangeVisual()
    {
        vignette.intensity.value = 0.55f;
        Invoke("ResetVisual", 2f);
        //Change FOV
    }

    public void ResetVisual()
    {
        vignette.intensity.value = 0f;
    }

    public void ChangeExpValue()
    {
        //Add or remove exp 
    }

    public void ChangeDamageValue()
    {
        //Increase or decrease damage value
    }


}

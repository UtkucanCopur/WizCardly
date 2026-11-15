using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxExp;
    [SerializeField] private float currentExp;





    private void OnEnable()
    {
        GameEvents.OnLowEnemyDeath += GainExp;
    }

    private void OnDisable()
    {
        GameEvents.OnLowEnemyDeath -= GainExp;
    }

    private void CheckExp()
    {
        if (currentExp >= maxExp)
        {
            GameEvents.LevelUp();
        }
    }

    private void GainExp(float amount)
    {
        currentExp += amount;
        CheckExp();
    }
}

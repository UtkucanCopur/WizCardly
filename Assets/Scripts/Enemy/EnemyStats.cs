using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour , IDamageable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private ParticleSystem bloodEffect;

    private void Awake()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        bloodEffect.Play();
        if (currentHealth <= 0)
        {
            Die();            
        }
    }

    

    private void Die()
    {
        Destroy(gameObject);
        GameEvents.LowEnemyDeath(10f);
    }
}

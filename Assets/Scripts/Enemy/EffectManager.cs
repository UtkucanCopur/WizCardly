using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public bool isWet;
    public bool isIce;
    public bool isFrost;
    public bool isElectiricity;
    public bool isFire;


    private EnemyMovement enemyMovement;
    private EnemyStats enemyStats;
    private Animator animator;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyStats = GetComponent<EnemyStats>();
        animator = GetComponent<Animator>();
    }


    public void HitEffect(string bulletType)
    {
        switch (bulletType)
        {
            case "Wet":
                isWet = true;
                CheckEffects();
                Debug.Log("Enemy is wet");
                break;
            case "Ice":
                isIce = true;
                CheckEffects();
                Debug.Log("Enemy is ice");
                break;
            case "Electric":
                isElectiricity = true;
                Debug.Log("Enemy is electric");
                break;
            case "Fire":
                isFire = true;
                Debug.Log("Enemy is fire");
                break;
            case "Dark":
                isFire = true;
                Debug.Log("Enemy is dark");
                break;
            default:
                Debug.Log("default bullet");
                break;
        }
    }

    private void CheckEffects()
    {
        if (isWet && isIce)
            StartFreeze();
    }

    public void StartFreeze()
    {
        StartCoroutine(FreezeEnemy());
    }

    IEnumerator FreezeEnemy()
    {
        enemyMovement.SetSpeed(0f);
        animator.speed = 0f;
        yield return new WaitForSeconds(3f);
        RefreshFreezeEffect();
        enemyMovement.SetSpeed(3.5f);
        animator.speed = 1f;
    }

    private void RefreshFreezeEffect()
    {
        isWet = false;
        isIce = false;
    }



}

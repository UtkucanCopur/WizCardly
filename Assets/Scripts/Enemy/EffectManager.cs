using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EffectManager : MonoBehaviour
{
    public bool isWet;
    public bool isIce;
    public bool isFrost;
    public bool isElectiricity;
    public bool isFire;

    public bool electricityControl = false;

    private EnemyMovement enemyMovement;
    private EnemyStats enemyStats;
    private Animator animator;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyStats = GetComponent<EnemyStats>();
        animator = GetComponent<Animator>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        if (electricityControl)
            StartElectricity();
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
                CheckEffects();
                //ElectricMovementEffect();
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
        if (isWet && isElectiricity)
            electricityControl = true;
    }

    public void StartElectricity()
    {
        LayerMask enemyLayerMask = LayerMask.GetMask("Enemy");
        Collider[] effectedEnemies = Physics.OverlapBox(transform.position, 
            new Vector3(10, 1, 10),
            Quaternion.identity,
            enemyLayerMask);

        lineRenderer.positionCount = effectedEnemies.Length;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        

        lineRenderer.useWorldSpace = true;

        for (int i = 0; i <= effectedEnemies.Length - 1; i++)
        {
            lineRenderer.SetPosition(i, effectedEnemies[i].transform.position + Vector3.up * 1f);
        }

        foreach (Collider c in effectedEnemies)
        {
            c.GetComponent<EnemyMovement>().SetSpeed(0f);
            c.GetComponent<Animator>().speed = 0f;
        }

        Invoke("RefreshElectricEffect", .5f);
    }

    public void ElectricMovementEffect()
    {
        StartCoroutine(ElectricEnemy());
    }

    IEnumerator ElectricEnemy()
    {
        
        enemyMovement.SetSpeed(0f);
        animator.speed = 0f;
        yield return new WaitForSeconds(0.5f);
        enemyMovement.SetSpeed(3.5f);
        animator.speed = 1f;

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

    private void RefreshElectricEffect()
    {
        isWet = false;
        isElectiricity = false;
        electricityControl = false;

        lineRenderer.positionCount = 0;

        LayerMask enemyLayerMask = LayerMask.GetMask("Enemy");
        Collider[] effectedEnemies = Physics.OverlapBox(transform.position,
            new Vector3(10, 1, 10),
            Quaternion.identity,
            enemyLayerMask);

        foreach (Collider c in effectedEnemies)
        {
            c.GetComponent<EnemyMovement>().SetSpeed(3.5f);
            c.GetComponent<Animator>().speed = 1f;
        }

    }

    



}

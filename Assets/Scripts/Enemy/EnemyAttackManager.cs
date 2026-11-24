using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackManager : MonoBehaviour
{

    public enum EnemyTypes
    {
        ALIEN,
        MINATOUR,
        ORC,
        MAGE
    }


    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerStatManager playerStatManager;

    public EnemyTypes enemyType;

    private void Awake()
    {
        if (playerStatManager == null)
            playerStatManager = player.GetComponent<PlayerStatManager>();
        

    }


    public void AttackStart() => animator.SetBool("isAttacking", true);
    public void AttackEnd()
    {
        agent.speed = 3.5f;
        Debug.Log("player uzakta");
        animator.SetBool("isAttacking", false);
    }

    public void AttackPlayer()
    {
        switch(enemyType)
        {
            case EnemyTypes.ALIEN:
                player.GetComponent<PlayerStatManager>().TakeDamage(5);
                AttackStart();
                break;
            case EnemyTypes.MINATOUR:
                AttackStart();
                break;
            case EnemyTypes.ORC:
                
                AttackStart();
                break;
            case EnemyTypes.MAGE:
                
                //fireBall.GetComponent<FireBall>().Launch();
                AttackStart();
                break;
            default:
                break;
        }


        //player.GetComponent<PlayerStatManager>().TakeDamage(25);
        //player.GetComponent<PlayerStatManager>().ChangeSpeedValue(3f, false);
        //playerStatManager.ChangeVisual();
        //playerStatManager.ChangeExpValue(10);
        //playerStatManager.ChangeDamageValue(10,false);
    }

    public void MinatourAttackPower()
    {
        playerStatManager.ChangeVisual();
        player.GetComponent<PlayerStatManager>().TakeDamage(10);
    }
    public void OrcAttackPower()
    {
        playerStatManager.ChangeSpeedValue(1f, false);
        player.GetComponent<PlayerStatManager>().TakeDamage(15);
    }
    public void MageAttackPower()
    {
        GameEvents.MageEffectActive();
        playerStatManager.ChangeExpValue(20);
        player.GetComponent<PlayerStatManager>().TakeDamage(20);
    }

}

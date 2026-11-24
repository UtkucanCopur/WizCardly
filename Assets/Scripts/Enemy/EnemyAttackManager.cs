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
    [SerializeField] private GameObject fireBall;

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
                player.GetComponent<PlayerStatManager>().TakeDamage(10);
                AttackStart();
                break;
            case EnemyTypes.ORC:
                player.GetComponent<PlayerStatManager>().TakeDamage(15);
                AttackStart();
                break;
            case EnemyTypes.MAGE:
                player.GetComponent<PlayerStatManager>().TakeDamage(20);
                fireBall.GetComponent<FireBall>().Launch();
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

    public void MinatourAttackPower() => playerStatManager.ChangeVisual();
    public void OrcAttackPower() => playerStatManager.ChangeSpeedValue(1f, false);
    public void MageAttackPower() => playerStatManager.ChangeExpValue(20);

}

using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackManager : MonoBehaviour
{

    public enum EnemyTypes
    {
        ALIEN,
        MINATOUR
    }


    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerStatManager playerStatManager;
    [SerializeField] private EnemyTypes enemyType;

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


}

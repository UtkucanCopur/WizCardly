using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private float updateInterval;
    [SerializeField] private EnemyAttackManager attackManager;
    [SerializeField] private EnemyAttackManager.EnemyTypes type;
    private float timer;





    private void Awake()
    {
        type = GetComponent<EnemyAttackManager>().enemyType;
    }

    private void Update()
    {
        FollowPlayer();
    }

    

    private void FollowPlayer()
    {
        timer -= Time.deltaTime;

        if (agent != null && timer <= 0f)
        {
            agent.SetDestination(player.transform.position);
            timer = updateInterval;
            
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 3f && type != EnemyAttackManager.EnemyTypes.MAGE)
            {
                Debug.Log("player yakýnda");
                attackManager.AttackPlayer();
                agent.speed = 0f;
            }

            if (distance <= 20f && type == EnemyAttackManager.EnemyTypes.MAGE)
            {
                attackManager.AttackPlayer();
                agent.speed = 0f;
            }
             
        }
    }

    public void SetSpeed(float amount) => agent.speed = amount;


}

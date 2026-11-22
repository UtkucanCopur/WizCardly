using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private float updateInterval;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerStatManager playerStatManager;

    private float timer;

    private void Awake()
    {
        playerStatManager = player.GetComponent<PlayerStatManager>();
    }

    private void Update()
    {
        FollowPlayer();
    }

    public void KickStart() => animator.SetBool("isKicking", true);
    public void KickEnd()
    {
        agent.speed = 3.5f;
        Debug.Log("player uzakta");
        animator.SetBool("isKicking", false);
    }

    public void KickPlayer()
    {
        //player.GetComponent<PlayerStatManager>().TakeDamage(25);
        //player.GetComponent<PlayerStatManager>().ChangeSpeedValue(3f, false);
        playerStatManager.ChangeVisual();
    }

    private void FollowPlayer()
    {
        timer -= Time.deltaTime;

        if (agent != null && timer <= 0f)
        {
            agent.SetDestination(player.transform.position);
            timer = updateInterval;
            
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 3f)
            {
                Debug.Log("player yakýnda");
                KickStart();
                agent.speed = 0f;
            }
             
        }
    }

    public void SetSpeed(float amount) => agent.speed = amount;


}

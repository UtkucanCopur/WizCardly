using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private float updateInterval;

    private float timer;

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
        }
    }

}

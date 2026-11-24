using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private bool isGoing;

    private void Update()
    {
        if (isGoing)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            transform.position += dir * 5f * Time.deltaTime;
        }
        
    }


    public void Launch()
    {
        isGoing = true;
    }

}

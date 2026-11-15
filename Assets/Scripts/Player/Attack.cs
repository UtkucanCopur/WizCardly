using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private int currentBulletIndex;



    private void Awake()
    {
        
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            particle.Play();
            Ray ray = new Ray(fpsCamera.transform.position,fpsCamera.transform.forward);
            currentBulletIndex--;
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Debug.Log($"vurulan obje {hit.collider.name}");
                if (hit.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.TakeDamage(25);
                }
            }
            if (currentBulletIndex <= 0)
            {
                Invoke("Reload", 2f);
            }


            Debug.Log("attack");
        
        }

    }

    
    private void Reload()
    {
        Debug.Log("Reloading");
        currentBulletIndex = 7;
    }

}

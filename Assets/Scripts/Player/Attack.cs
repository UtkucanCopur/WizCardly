using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private int currentBulletIndex;
    [SerializeField] private GameObject currentWeapon;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject bazookaRocket;


    private void OnEnable()
    {
        GameEvents.OnWeaponChanged += GetCurrentWeapon;
    }

    private void OnDisable()
    {
        GameEvents.OnWeaponChanged -= GetCurrentWeapon;
    }

    

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            
            currentWeapon.GetComponent<ParticleSystem>().Play();
            Ray ray = new Ray(fpsCamera.transform.position,fpsCamera.transform.forward);
            currentBulletIndex--;
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                Debug.Log($"vurulan obje {hit.collider.name}");
                if (hit.collider.TryGetComponent<IDamageable>(out IDamageable damageable) &&
                    hit.collider.TryGetComponent<EffectManager>(out EffectManager effectManager))
                {
                    damageable.TakeDamage(playerData.damage);
                    string currentBulletType = currentWeapon.GetComponent<BulletManager>().GetBulletType();
                    effectManager.HitEffect(currentBulletType);
                    if (currentWeapon.CompareTag("Bazooka"))
                    {
                        bazookaRocket.SetActive(true);
                        bazookaRocket.transform.position = hit.collider.transform.position;
                        Invoke("CloseRocket", 1f);
                        Collider[] enemies = Physics.OverlapSphere(hit.transform.position, 5f);
                        foreach (Collider c in enemies)
                        {
                            if (c.TryGetComponent<EffectManager>(out EffectManager manager))
                            {
                                manager.HitEffect(currentBulletType);
                                Debug.Log("efekt uygulandı" + c.name);
                            }
                        }
                    }
                }
            }
            if (currentBulletIndex <= 0)
            {
                Invoke("Reload", 2f);
            }


            Debug.Log("attack");
        
        }

    }

    private void CloseRocket() => bazookaRocket.SetActive(false);

    private void GetCurrentWeapon(GameObject weapon) => currentWeapon = weapon;

    

    
    private void Reload()
    {
        Debug.Log("Reloading");
        currentBulletIndex = 7;
    }

}

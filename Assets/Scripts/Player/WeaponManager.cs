using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponArray;
    [SerializeField] private GameObject currentWeapon;
    [SerializeField] private GameObject lastWeapon;


    private bool isSniperRifleOpen;
    private bool isUziOpen;
    private bool isBazookaOpen;
    private bool isShotgunOpen;

    private void OnEnable()
    {
        GameEvents.OnSniperRifleOpen += OpenSniperRifle;
        GameEvents.OnUziOpen += OpenUzi;
        GameEvents.OnBazookaOpen += OpenBazooka;
        GameEvents.OnShotgunOpen += OpenShotgun;
    }

    private void OnDisable()
    {
        GameEvents.OnSniperRifleOpen -= OpenSniperRifle;
        GameEvents.OnUziOpen -= OpenUzi;
        GameEvents.OnBazookaOpen -= OpenBazooka;
        GameEvents.OnShotgunOpen -= OpenShotgun;
    }



    private void Awake()
    {
        currentWeapon = weaponArray[0];
        
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            lastWeapon = currentWeapon;
            lastWeapon.SetActive(false);
            currentWeapon = weaponArray[0];
            currentWeapon.SetActive(true);
            GameEvents.ChangeWeapon(currentWeapon);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame && isSniperRifleOpen)
        {
            lastWeapon = currentWeapon;
            lastWeapon.SetActive(false);
            currentWeapon = weaponArray[1];
            currentWeapon.SetActive(true);
            GameEvents.ChangeWeapon(currentWeapon);

        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame && isUziOpen)
        {
            lastWeapon = currentWeapon;
            lastWeapon.SetActive(false);
            currentWeapon = weaponArray[2];
            currentWeapon.SetActive(true);
            GameEvents.ChangeWeapon(currentWeapon);

        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame && isBazookaOpen)
        {
            lastWeapon = currentWeapon;
            lastWeapon.SetActive(false);
            currentWeapon = weaponArray[3];
            currentWeapon.SetActive(true);
            GameEvents.ChangeWeapon(currentWeapon);

        }
        if (Keyboard.current.digit5Key.wasPressedThisFrame && isShotgunOpen)
        {
            lastWeapon = currentWeapon;
            lastWeapon.SetActive(false);
            currentWeapon = weaponArray[4];
            currentWeapon.SetActive(true);
            GameEvents.ChangeWeapon(currentWeapon);

        }


    }

    private void OpenSniperRifle() => isSniperRifleOpen = true;
    private void OpenUzi() => isUziOpen = true;
    private void OpenBazooka() => isBazookaOpen = true;
    private void OpenShotgun() => isShotgunOpen = true;



}

using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponArray;
    [SerializeField] private GameObject currentWeapon;
    [SerializeField] private GameObject lastWeapon;


    private void OnEnable()
    {
        GameEvents.OnSniperRifleOpen += OpenSniperRifle;
        GameEvents.OnUziOpen += OpenUzi;
    }

    private void OnDisable()
    {
        GameEvents.OnSniperRifleOpen -= OpenSniperRifle;
        GameEvents.OnUziOpen -= OpenUzi;
    }


    private bool isSniperRifleOpen;
    private bool isUziOpen;

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

    }

    private void OpenSniperRifle() => isSniperRifleOpen = true;
    private void OpenUzi() => isUziOpen = true;



}

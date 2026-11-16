using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponArray;
    [SerializeField] private GameObject currentWeapon;
    [SerializeField] private GameObject lastWeapon;

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
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            lastWeapon = currentWeapon;
            lastWeapon.SetActive(false);
            currentWeapon = weaponArray[1];
            currentWeapon.SetActive(true);
            GameEvents.ChangeWeapon(currentWeapon);

        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            lastWeapon = currentWeapon;
            lastWeapon.SetActive(false);
            currentWeapon = weaponArray[2];
            currentWeapon.SetActive(true);
            GameEvents.ChangeWeapon(currentWeapon);

        }

    }



}

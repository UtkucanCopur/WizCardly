using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action<float> OnLowEnemyDeath;
    public static event Action OnLevelUp;
    public static event Action<GameObject> OnWeaponChanged;
    public static event Action<int> OnButtonSelected;
    public static event Action<string> OnPowerUpSelected;
    public static event Action OnSniperRifleOpen;
    public static event Action OnUziOpen;











    public static void SniperRifleOpen() { OnSniperRifleOpen?.Invoke(); }
    public static void UziOpen() { OnUziOpen?.Invoke(); }
    public static void PowerUpSelected(string methodName) {  OnPowerUpSelected(methodName); }
    public static void ButtonSelected(int index) => OnButtonSelected?.Invoke(index);
    public static void ChangeWeapon(GameObject weapon) => OnWeaponChanged?.Invoke(weapon);
    public static void LevelUp() => OnLevelUp?.Invoke();
    public static void LowEnemyDeath(float amount) => OnLowEnemyDeath?.Invoke(amount);

}

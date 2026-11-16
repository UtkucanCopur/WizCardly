using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action<float> OnLowEnemyDeath;
    public static event Action OnLevelUp;
    public static event Action<GameObject> OnWeaponChanged;








    public static void ChangeWeapon(GameObject weapon) => OnWeaponChanged?.Invoke(weapon);
    public static void LevelUp() => OnLevelUp?.Invoke();
    public static void LowEnemyDeath(float amount) => OnLowEnemyDeath?.Invoke(amount);

}

using System;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class PowerUpData : MonoBehaviour
{
    public Image[] PowerUpFrames;
    public Image[] ActivePowerUpImages;
    public string[] ActivePowerUpInfo;
    public Image[] PassivePowerUpImages;
    public string[] PassivePowerUpInfo;
    public Image[] GunPowerUpImages;
    public string[] GunPowerUpInfo;
}

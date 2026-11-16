using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public bool none;
    public bool wet;
    public bool ice;
    public bool electric;
    public bool fire;
    public bool dark;
    


    public string GetBulletType()
    {
        if (wet)
            return "Wet";
        if (ice)
            return "Ice";
        if (electric)
            return "Electric";
        if (fire)
            return "Fire";
        if (dark)
            return "Dark";

        return "None";
    }
    


}

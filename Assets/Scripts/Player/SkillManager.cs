using UnityEngine;
using UnityEngine.InputSystem;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireRing;
    private bool isFireRingOpen;



    private void OnEnable()
    {
        GameEvents.OnFireRingOpen += GetFireRing;
    }

    private void OnDisable()
    {
        GameEvents.OnFireRingOpen -= GetFireRing;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isFireRingOpen)
        {
            fireRing.Play();
            
            
        }
    }

    public void GetFireRing() => isFireRingOpen = true;

}

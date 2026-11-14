using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private InputSystem_Actions inputAction;
    public Camera cam;
    private float xRotation = 0f;

    public float xSensivity;
    public float ySensivity;


    private void Awake()
    {
        inputAction = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    private void Update()
    {
        ProcessLook(inputAction.Player.Look.ReadValue<Vector2>());
    }


    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //apply this to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensivity);

    }

}

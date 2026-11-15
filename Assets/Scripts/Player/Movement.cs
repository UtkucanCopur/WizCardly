using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded;

    private void Awake()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }


    private void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal +
                       transform.forward * vertical;

        characterController.Move(move * speed * Time.deltaTime);

        


    }

    



}

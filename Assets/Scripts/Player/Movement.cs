using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;

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
        Vector3 move = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(speed * Time.deltaTime * move);
    }



}

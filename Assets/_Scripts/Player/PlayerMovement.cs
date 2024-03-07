using UnityEngine;

    

public class PlayerMovement : MonoBehaviour 
{

    [Header("Movement")]
    float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float groundDrag;
    // --------------------------
    [Header("KeyBinds")]
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;
    float horizontalInput;
    float verticalInput;
    // -----------------------------refs
    [SerializeField] Transform playerModel;
    bool grounded;
    Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        moveSpeed = walkSpeed;
    }

    void Update(){
        GetInputs();
        RotatePlayer();
    }

    void FixedUpdate(){
        MovePlayer();

    }

    private void MovePlayer(){
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

             
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void GetInputs(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(sprintKey)){// ------------change when implement states
            moveSpeed = sprintSpeed;
        }else if(Input.GetKeyUp(sprintKey)){
            moveSpeed = walkSpeed;
        }
    }

    private void RotatePlayer(){
        // Vector3 inputDir = transform.forward * verticalInput + transform.right * horizontalInput;

        // if(inputDir != Vector3.zero)
        //     playerModel.forward = Vector3.Slerp(playerModel.forward, inputDir.normalized, rotationSpeed * Time.deltaTime); ------------------- to rotate towards move direction

        // Get the mouse position in the world coordinates
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));

        // Calculate the direction from the player to the mouse position
        Vector3 directionToMouse = mousePos - transform.position;
        directionToMouse.y = 0f; // Ensure no vertical rotation

        // Rotate the player towards the mouse
        if (directionToMouse != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);
            playerModel.rotation = Quaternion.Slerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    
}
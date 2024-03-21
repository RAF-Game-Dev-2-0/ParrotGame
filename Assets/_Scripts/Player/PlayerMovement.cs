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
    [SerializeField] GameObject mainCamObj;
    [SerializeField] Transform orientation;
    bool grounded;
    Rigidbody rb;

    void Start(){
        //invisible cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 

        // define rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        moveSpeed = walkSpeed;
    }

    void Update(){
        GetInputs();
        RotatePlayer();

        //view direction (orientation) rotate orientation towards main cam view
        Vector3 viewDir = transform.position - new Vector3(mainCamObj.transform.position.x, transform.position.y, mainCamObj.transform.position.z);
        orientation.forward = viewDir.normalized;
    }

    void FixedUpdate(){
        MovePlayer();

    }

    private void MovePlayer(){
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

             
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
        // ------------------------------------------------------------------------------rotate model towards cam view
        playerModel.forward = orientation.forward;

        // ----------------------------------------------------------------------------------------------------- to rotate model towards move direction
        // Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // if(inputDir != Vector3.zero)
        //     playerModel.forward = Vector3.Slerp(playerModel.forward, inputDir.normalized, rotationSpeed * Time.deltaTime);
        // ------------------------------------------- ----------------------------------------

        // // Get the mouse position in the world coordinates ------------------------------------------------------------------------------------------------------------ rotation towards mouse
        // Vector3 mousePos = Input.mousePosition;
        // mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));

        // // Calculate the direction from the player to the mouse position
        // Vector3 directionToMouse = mousePos - transform.position;
        // directionToMouse.y = 0f; // Ensure no vertical rotation

        // // Rotate the player towards the mouse
        // if (directionToMouse != Vector3.zero)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(directionToMouse);
        //     playerModel.rotation = Quaternion.Slerp(playerModel.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // }
        // -------------------------------------------------------------------------
    }

    
}
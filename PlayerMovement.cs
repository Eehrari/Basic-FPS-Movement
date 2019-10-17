using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _sensitivity;
    [SerializeField]
    public GameObject fpsCamera;

    Vector3 velocity = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    float cameraUpAndDownRotation = 0;
    float currentCameraUpAndDownRotation = 0;

    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
	// Player Movement
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        Vector3 movementHorizontal = transform.right * _horizontal;
        Vector3 movemntVertical = transform.forward * _vertical;
        Vector3 _moveVelocity = (movementHorizontal + movemntVertical).normalized * _speed;
        Move(_moveVelocity);

	// Player Mouse X Rotation
        float _yRotation = Input.GetAxis("Mouse X");
        Vector3 _yRotationVector = new Vector3(0, _yRotation, 0)*_sensitivity;
        Rotate(_yRotationVector);

	// Player Mouse Y Rotation
        float cameraUpDownRotation = Input.GetAxis("Mouse Y")*_sensitivity;
        CameraRotation(cameraUpDownRotation);
    }
    private void FixedUpdate()
    {
	// Move Player
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
        }

	//Rotate X 
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

	//Rotate Y
        if (fpsCamera != null)
        {
            currentCameraUpAndDownRotation -= cameraUpAndDownRotation;
            currentCameraUpAndDownRotation = Mathf.Clamp(currentCameraUpAndDownRotation, -85, 85);
            fpsCamera.transform.localEulerAngles = new Vector3(currentCameraUpAndDownRotation, 0, 0);

        }
    }
    void Move(Vector3 velocityMovement)
    {
        velocity = velocityMovement;
    }
    void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }
    void CameraRotation(float cameraUpDownRotation)
    {
        cameraUpAndDownRotation = cameraUpDownRotation;
    }
}

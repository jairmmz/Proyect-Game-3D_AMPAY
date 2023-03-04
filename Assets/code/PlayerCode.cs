using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
	
	Transform cam;
	
	CharacterController control;
	
	public float speedCam;
	
	public float playerSpeed;
	
	public float gravityForce;
	
	public float jumpForce;
	
	
	float gravityMove = 0;
	
	float camRotation = 0f;
	
    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetChild(0).GetComponent<Transform>();
		control = GetComponent<CharacterController>();
		
		//Ocultar mouse.
		//Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");
		
		//Rotar el personaje
		transform.Rotate(new Vector3(0, mouseX, 0) * speedCam * Time.deltaTime);
		
		camRotation -= mouseY * speedCam * Time.deltaTime;
		
		//Para que la camara no rote de más.
		camRotation = Mathf.Clamp(camRotation, -90, 90);
		cam.localRotation = Quaternion.Euler(new Vector3(camRotation, 0, 0));

		//Para el movimiento wasd
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");
		
		Vector3 movement = (transform.right * moveX + transform.forward * moveZ) * playerSpeed * Time.deltaTime;
		
		control.Move(movement);
		
		control.Move(new Vector3(0, gravityMove, 0) * Time.deltaTime);
		
		if(!control.isGrounded){
			gravityMove += gravityForce;
		}else{
			gravityMove = 0f;
		}
		
		if(Input.GetKeyDown(KeyCode.Space) && control.isGrounded){
			gravityMove = jumpForce;
		}
	}
}

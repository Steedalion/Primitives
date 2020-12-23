using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	InputControl input; 
	Rigidbody rb;
	public float jumpingForce;
	public float moveForce;
    // Start is called before the first frame update
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		input = new InputControl();
		input.Player.Jump.performed += x =>Jump();
		input.Player.Move.performed += axis => Move(axis.ReadValue<Vector2>());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void Jump()
	{
		Debug.Log("Jump");
		rb.AddForce(transform.up * jumpingForce);
	}
	void Move(Vector2 movement)
	{
		
		rb.AddForce(movement * moveForce);
	}
}

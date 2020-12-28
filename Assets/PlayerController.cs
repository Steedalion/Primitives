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
	public float limitZ;
	Transform _transform;
	bool isOnGround;
    // Start is called before the first frame update
	void Awake()
	{
		_transform = transform;
		rb = GetComponent<Rigidbody>();
		input = new InputControl();
		input.Player.Jump.performed += x =>Jump();
		input.Player.Move.performed += axis => Move(axis.ReadValue<Vector2>());
        
    }

    // Update is called once per frame
    void Update()
    {
	    if(transform.position.z > limitZ)
	    {
		     	transform.position = new Vector3(transform.position.x, transform.position.y, limitZ);
	    }
    }
	void Jump()
	{
		Debug.Log("Jump");
		if(isOnGround){
			rb.AddForce(Vector3.up * jumpingForce);}
	}
	void Move(Vector2 movement)
	{
		Vector3 move3 = new Vector3(movement.x,0, movement.y);
		
		rb.AddForce(move3 * moveForce);
		
	}
	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	protected IEnumerator OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.other.CompareTag("Ground"))
		{
			isOnGround = true;
		}
		yield return null;
	}
	
	
	// OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider.
	protected IEnumerator OnCollisionExit(Collision collisionInfo)
	{if(collisionInfo.other.CompareTag("Ground"))
	{
		isOnGround = false;
	}
		yield return null;
	}
	// This function is called when the object becomes enabled and active.
	protected void OnEnable()
	{
		input.Enable();
	}
	// This function is called when the behaviour becomes disabled () or inactive.
	protected void OnDisable()
	{
		input.Disable();
	}
}

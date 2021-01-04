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
	public float limitX;
	bool isGrounded;
	Vector3 moveDirection;
	bool hasPowerup = false;
	Vector3 powerupOffset;
	
	public GameObject powerupIndicator;
	public AudioClip jumpSound;
	public AudioClip powerupCollisionSound;
	public ParticleSystem powerupCollisionParticle;
	public ParticleSystem runningParticle;
    // Start is called before the first frame update
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		input = new InputControl();
		input.Player.Jump.performed += x =>Jump();
		input.Player.Move.performed += axis => Move(axis.ReadValue<Vector2>());
		input.Player.Move.canceled += axis => moveDirection = Vector3.zero;
	}
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected IEnumerator Start()
	{
		powerupOffset = powerupIndicator.transform.position - transform.position;
		powerupIndicator.SetActive(false);
		
		yield return null;
	}

    // Update is called once per frame
    void Update()
	{
		transform.Translate(moveDirection * moveForce * Time.deltaTime);
	    if(transform.position.z > limitZ)
	    {
		     	transform.position = new Vector3(transform.position.x, transform.position.y, limitZ);
	    }
		if(Mathf.Abs(transform.position.x) > limitX)
		{
			float x = limitX * Mathf.Sign(transform.position.x);
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}
		if (hasPowerup)
		{
			powerupIndicator.transform.position = transform.position + powerupOffset;
		}
    }
	void Jump()
	{
		Debug.Log("Jump");
		if(isGrounded){
			AudioSource.PlayClipAtPoint(jumpSound, transform.position);
			rb.AddForce(Vector3.up * jumpingForce);}
	}
	void Move(Vector2 movement)
	{
		Debug.Log("Move");
		moveDirection = new Vector3(movement.x,0, movement.y);
		
		
		
	}
	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	protected IEnumerator OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.other.CompareTag("Ground"))
		{
			isGrounded = true;
		}
		if (hasPowerup && collisionInfo.other.CompareTag("Obstacle"))
		{
			Destroy(collisionInfo.other.gameObject);
			AudioSource.PlayClipAtPoint(powerupCollisionSound, transform.position);
			powerupCollisionParticle.Play();
			powerupCollisionParticle.transform.position = collisionInfo.other.transform.position;
		}
		yield return null;
	}
	
	
	// OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider.
	protected IEnumerator OnCollisionExit(Collision collisionInfo)
	{
		if(collisionInfo.other.CompareTag("Ground"))
		{
			isGrounded = false;
		}
		yield return null;
	}
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected IEnumerator OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Powerup"))
		{
			Destroy(other.gameObject);
			StartCoroutine(GetPowerup());
		}
		yield return null;
	}
	
	IEnumerator GetPowerup()
	{
		hasPowerup = true;
		powerupIndicator.SetActive(true);
		yield return new WaitForSeconds(5f);
		powerupIndicator.SetActive(false);
		hasPowerup = false;
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

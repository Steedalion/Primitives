using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateJump : MonoBehaviour
{
	Animator anim;
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	// OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider.
	protected void OnCollisionExit(Collision collisionInfo)
	{
		collisionInfo.other.CompareTag("Ground");
		{
			anim.SetTrigger("Jump_trig");
		}
	}
}

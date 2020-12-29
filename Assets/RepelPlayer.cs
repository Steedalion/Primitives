using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelPlayer : MonoBehaviour
{
	public float repelForce;

    
	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	protected IEnumerator OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.other.CompareTag("Player"))
		{
			GameObject player = collisionInfo.other.gameObject;
			Rigidbody playerBody = player.GetComponent<Rigidbody>();
			Vector3 away =player.transform.position -  transform.position;
			playerBody.AddForce(away*repelForce, ForceMode.Impulse);
			
		}
		yield return null;
	}
}

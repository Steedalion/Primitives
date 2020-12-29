using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	protected IEnumerator OnTriggerExit(Collider other)
	{
		Debug.Log("Exited");
		Destroy(other.gameObject);
		
		yield return null;
	}
}

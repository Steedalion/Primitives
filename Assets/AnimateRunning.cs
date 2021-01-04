using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateRunning : MonoBehaviour
{
	Animator anim;
    // Start is called before the first frame update
    void Start()
    {
	    anim = GetComponent<Animator>();
	    anim.SetFloat("Speed_f", 8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

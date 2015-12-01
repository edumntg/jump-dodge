using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {


    Animator anim;
    public GameObject thePlayer;

    Bounce bounceScript;
	// Use this for initialization
	void Start () 
    {
        anim = gameObject.GetComponent<Animator>();
        bounceScript = GetComponentInChildren<Bounce>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(bounceScript != null && bounceScript.isBouncing)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
	}
}

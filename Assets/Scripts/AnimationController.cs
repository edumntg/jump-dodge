using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {


    Animator anim;
    public GameObject thePlayer;
	// Use this for initialization
	void Start () 
    {
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Bounce bounceScript = GetComponentInChildren<Bounce>();
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

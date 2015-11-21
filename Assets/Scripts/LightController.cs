using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	Animator anim;

	void Start () {
        anim = gameObject.GetComponent<Animator>();
        anim.speed = 0.050f;
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.backgroundColor = GetComponent<Light>().color;

        if(Mathf.Round(gameObject.transform.position.z) <= -7.85 )
        {
            if(anim.GetBool("IsDay") == true)
            {
                anim.SetBool("IsDay", false);
            }
            else
            {
                anim.SetBool("IsDay", true);
            }
            gameObject.transform.position = new Vector3(0, 0, 8);
        }
	}
}

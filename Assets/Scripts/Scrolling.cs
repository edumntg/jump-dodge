using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {

    public Vector3 speed = new Vector3(2, 0, 0);
    public Vector3 direction = new Vector3(-1, 0, 0);

    public bool linkedToCamera = false;
    public bool isLooping = true;
    Vector3 movement;

    int lastXPos;
	void Start () {
        //

	}
	
	// Update is called once per frame
	void Update () {
        Transform[] childs = gameObject.GetComponentsInChildren<Transform>();
        movement = new Vector3(speed.x * direction.x, speed.y * direction.y, speed.z * direction.z);
        movement *= Time.deltaTime / 5;
        foreach(Transform t in childs)
        {
            if (t.name.Contains("Road") || t.name.Contains("Grass") || t.name.Contains("Tree"))
            {
                t.Translate(movement);
            }
        }


        if(linkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
	}
}

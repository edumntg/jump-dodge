using UnityEngine;
using System.Collections;
using System;

public class Scrolling : MonoBehaviour {

	public Vector3 speed = Game.baseScrollingSpeed;
	public Vector3 direction = Game.baseScrollingDirection;

    public bool linkedToCamera = false;
    public bool isLooping = true;
    public bool scroll = true;

    Vector3 movement;
    int timeElapsed = 0;
    int lastIncreased = 0;
    

	void Start () {
        //

	}
	
	// Update is called once per frame
	void Update () {

        if(!scroll)
        {
            return;
        }

        Transform[] childs = gameObject.GetComponentsInChildren<Transform>();
        movement = new Vector3(speed.x * direction.x, speed.y * direction.y, speed.z * direction.z);
        movement *= Time.deltaTime;
        foreach(Transform t in childs)
        {
            if (t.name.Contains("Road") || t.name.Contains("Tree") || t.name.Contains("Grass") || t.name.Contains("Coin"))
            {
                t.Translate(movement);
            }
        }

        if(linkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        timeElapsed = Convert.ToInt32(Time.time);
        if(timeElapsed > 0 && timeElapsed % Game.speedIncreaseTime == 0 && timeElapsed > lastIncreased)
        {
            lastIncreased = timeElapsed;
            speed += Game.scrollingSpeedIncrease;
        }
	}
}

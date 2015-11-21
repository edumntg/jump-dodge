﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public bool isOnFloor;
    bool alive;
    public bool started = false;
	// Use this for initialization
	void Start () {
        isOnFloor = false;
        alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isOnFloor = true;
        }
        if(other.gameObject.tag == "Obstacle")
        {
            //PLAYER IS DEAD!!!!!
            Scrolling environmentScrolling = other.GetComponentInParent<Scrolling>();
            if(environmentScrolling != null)
            {
                environmentScrolling.speed = Vector3.zero;
                Kill();
            }
        }
    }

    public Vector3 GetPosition() { return transform.position; }
    public bool CanJump() { return gameObject.transform.position.y == 0.5f; }
    public bool GetGameObject() { return gameObject; }

    public void Kill()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        if(anim != null && anim.GetBool("Alive") == true)
        {
            anim.Stop();
        }
        alive = false;

    }
}
using UnityEngine;
using System.Collections;
using System;

public class Jump : MonoBehaviour
{
    public bool isJumping = false;
    public float jumpDistance = 5.0f;

    Vector3 moveDistance;
    Vector3 moveDirection;

    int jumpFpsDuration = 20;

    Player player;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            //gameObject.GetComponent<Rigidbody>().AddForce(jumpForce);
            isJumping = true;
            moveDistance = new Vector3(0.0f, 5.0f, 0.0f);
            moveDirection = new Vector3(0.0f, 1.0f, 0.0f);
            player.started = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && !isJumping)
        {
            isJumping = true;
            moveDistance = new Vector3(0.0f, 5.0f, 3.0f);
            moveDirection = new Vector3(0.0f, 1.0f, 1.0f);
            player.started = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && !isJumping)
        {
            isJumping = true;
            moveDistance = new Vector3(0.0f, 5.0f, 3.0f);
            moveDirection = new Vector3(0.0f, 1.0f, -1.0f);
            player.started = true;
        }
        if (isJumping)
        {
            gameObject.transform.position += new Vector3(0, (moveDistance.y / jumpFpsDuration) * moveDirection.y, (moveDistance.z / jumpFpsDuration) * moveDirection.z);
            if (Convert.ToInt32(gameObject.GetComponent<BoxCollider>().transform.position.y) == Convert.ToInt32(moveDistance.y))
            {
                moveDirection = new Vector3(0.0f, -1.0f, moveDirection.z);
            }
        }

    }

    int i = 0;
    void OnTriggerEnter(Collider other)
    {
        i += 1;
        isJumping = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log("Collision" + i);
        
    }
}

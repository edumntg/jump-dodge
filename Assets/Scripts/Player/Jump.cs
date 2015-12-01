using UnityEngine;
using System.Collections;
using System;

public class Jump : MonoBehaviour
{

    public bool isJumping = false;
    public float jumpDistance = 5.0f;

    Vector3 moveDistance;
	float jumpSpeed = 0.30f; //interpolation speed
    Player player;
	Vector3[] endPos = new Vector3[2];
	int jumpState = 0; // 0 for going up, 1 for going down
	
    void Start()
    {
        player = GetComponent<Player>();
    }
	
    void Update()
    {
		if(!player.alive)
		{
			return;
		}

        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            isJumping = true;
            moveDistance = new Vector3(0.0f, 5.0f, 0.0f);
            player.StartGame();

			//
			endPos[0] = new Vector3(gameObject.transform.position.x + moveDistance.x / 2, gameObject.transform.position.y + moveDistance.y, gameObject.transform.position.z + moveDistance.z / 2);
			endPos[1] = new Vector3(gameObject.transform.position.x + moveDistance.x, gameObject.transform.position.y, gameObject.transform.position.z + moveDistance.z);
		
		}
        if (Input.GetKeyDown(KeyCode.A) && !isJumping)
        {
            isJumping = true;
            moveDistance = new Vector3(0.0f, 5.0f, 3.0f);
            player.StartGame();
			//
			endPos[0] = new Vector3(gameObject.transform.position.x + moveDistance.x / 2, gameObject.transform.position.y + moveDistance.y, gameObject.transform.position.z + moveDistance.z / 2);
			endPos[1] = new Vector3(gameObject.transform.position.x + moveDistance.x, gameObject.transform.position.y, gameObject.transform.position.z + moveDistance.z);
        }
        if (Input.GetKeyDown(KeyCode.D) && !isJumping)
        {
            isJumping = true;
            moveDistance = new Vector3(0.0f, 5.0f, 3.0f);
            player.StartGame();
			//
			endPos[0] = new Vector3(gameObject.transform.position.x + moveDistance.x / 2, gameObject.transform.position.y + moveDistance.y, gameObject.transform.position.z - moveDistance.z / 2);
			endPos[1] = new Vector3(gameObject.transform.position.x + moveDistance.x, gameObject.transform.position.y, gameObject.transform.position.z - moveDistance.z);
        }

        if (isJumping)
        {
			Vector3 startPos = gameObject.transform.position;
			gameObject.transform.position = Vector3.Lerp(startPos, endPos[jumpState], jumpSpeed);
			if(Mathf.Ceil (gameObject.transform.position.y) == Mathf.Ceil(endPos[jumpState].y))
			{
				if(jumpState == 0)
				{
					jumpState = 1;
				}
			}
        }

    }
	
    void OnTriggerEnter(Collider other)
    {
		if(other.transform.tag == "Floor")
		{
			isJumping = false;
			jumpState = 0;
		}        
    }
}

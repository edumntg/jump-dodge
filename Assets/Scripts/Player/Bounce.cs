using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

    Player player;
    public bool isBouncing = false;

    float lerpTime;
    float currentLerpTime;
    float perc = 1;

    Vector3 startPos;
    Vector3 endPos;

    bool move = false;

	// Use this for initialization
	void Start ()
    {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            if(perc == 1 && player.CanJump())
            {
                isBouncing = true;
                lerpTime = 1;
                currentLerpTime = 0;
                player.started = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.W) && player.CanJump())
        {
            move = false;
            player.isOnFloor = false;
        }
        
        startPos = player.GetPosition();

        if (!move)
        {
            endPos = startPos;
        }

        if(Input.GetKeyDown(KeyCode.D) && player.CanJump())
        {
            endPos = new Vector3(startPos.x, startPos.y, startPos.z - 3);
            move = true;
            player.isOnFloor = false;
        }

        if (Input.GetKeyDown(KeyCode.A) && player.CanJump())
        {
            endPos = new Vector3(startPos.x, startPos.y, startPos.z + 3);
            move = true;
            player.isOnFloor = false;
        }
        currentLerpTime += Time.deltaTime * 5;
        perc = currentLerpTime / lerpTime;
        if (move)
        {
            foreach (Transform t in gameObject.GetComponentsInChildren<Transform>())
            {
                t.position = Vector3.Lerp(startPos, endPos, perc);
            }
        }

        if (perc > 0.8)
        {
            perc = 1;
        }

        if (Mathf.Round(perc) == 1)
        {
            isBouncing = false;
        }
	}
}

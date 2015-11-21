using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {


    float lerpTime;
    float currentLerpTime;
    float perc = 1;

    Vector3 startPos;
    Vector3 endPos;

    float endRotation = 0;

    bool firstInput;
    public bool justJump;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if(perc == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
            }
        }

        startPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.D) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            endRotation = 90;
        }

        if (Input.GetKeyDown(KeyCode.A) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            endRotation = 270;
        }       
        if (Input.GetKeyDown(KeyCode.W) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            endRotation = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            endRotation = 180;
        }
        if (firstInput)
        {
            currentLerpTime += Time.deltaTime * 5;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.rotation = Quaternion.Euler(0, endRotation, 0);
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, perc);
            

            if (perc > 0.8)
            {
                perc = 1;
            }

            if (Mathf.Round(perc) == 1)
            {
                justJump = false;
            }
        }

	}
}

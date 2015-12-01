using UnityEngine;
using System.Collections;

public static class Game {

	//public variables/config

	//scrolling
	public static Vector3 baseScrollingSpeed = new Vector3(15.0f, 0.0f, 0.0f);
	public static Vector3 baseScrollingDirection = new Vector3(-1.0f, 0.0f, 0.0f);
	public static Vector3 scrollingSpeedIncrease = new Vector3(2.0f, 0.0f, 0.0f);
	public static int speedIncreaseTime = 15; //ms
}

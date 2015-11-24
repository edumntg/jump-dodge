using UnityEngine;
using System.Collections;

public class Character {

	public int id;
    public string name;
    public bool blocked;
    public string fileDir;
    public Vector3 basePosition;

    public Character()
    {
        basePosition = Vector3.zero;
    }

    public int GetId() { return id; }
    public string GetName() { return name; }
    public bool IsBlocked() { return blocked; }
    public string GetDirectory() { return fileDir; } 
    public Vector3 GetBasePosition() {return basePosition;}
}

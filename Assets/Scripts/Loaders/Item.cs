using UnityEngine;
using System.Collections;

public class Item
{
    public int id;
    public string name;
    public string description;
    public string fileDir;
    public Vector3 basePosition;
    public GameObject gameObject;

    public Item()
    {
        basePosition = Vector3.zero;
    }

    public int GetId() { return id; }
    public string GetName() { return name; }
    public string GetDecription() { return description; }
    public string GetDirectory() { return fileDir; } 
    public Vector3 GetBasePosition() {return basePosition;}

    public GameObject GetGameObject() { return gameObject; }

}

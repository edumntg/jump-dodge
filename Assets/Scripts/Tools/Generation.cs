using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Generation : MonoBehaviour {
    Items items;
    Characters characters;

    List<GameObject> tiles = new List<GameObject>();
    List<GameObject> obstacles = new List<GameObject>();
    string[] ObstaclesArray = { "Small Tree", "Tall Tree" };
    string[] TilesArray = { "Road", "Grass" };

	void Start () 
    {
        //let's create the player
        items = new Items();
        characters = new Characters();
        if (items.LoadItems() && characters.LoadCharacters())
        {
            Object prefab;
            prefab = Resources.Load(characters.GetCharacter("Guy").GetDirectory(), typeof(GameObject));
            GameObject PlayerObject = Instantiate(prefab) as GameObject;
            PlayerObject.transform.position = new Vector3(0, 0.5f, 0);
            PlayerObject.transform.SetParent(gameObject.transform.parent.FindChild("PlayerObject").transform);
            for (int i = -4; i <= 4; i++) //initial 8 tiles
            {
                int rand = Random.Range(0, 2);
                GameObject ObjectI;
                Item item = items.GetItem(TilesArray[rand]);
                prefab = Resources.Load(item.GetDirectory(), typeof(GameObject));
                ObjectI = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                ObjectI.transform.position = new Vector3(i * 9, 0, 0) + item.GetBasePosition();
                ObjectI.transform.SetParent(gameObject.transform.FindChild("Tiles").transform);
                tiles.Add(ObjectI);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
        GameObject lastRoad = tiles[tiles.Count - 1];
        Vector3 distance = lastRoad.transform.position - GetPlayer().position;
        if(distance.x <= 25)
        {
            int rand = Random.Range(0, 2);
            GameObject ObjectI;
            Object prefab;
            Item item = items.GetItem(TilesArray[rand]);
            prefab = Resources.Load(item.GetDirectory(), typeof(GameObject));
            ObjectI = Instantiate(prefab) as GameObject;
            ObjectI.transform.position = new Vector3(lastRoad.transform.position.x + 9, 0, item.GetBasePosition().z);
            ObjectI.transform.SetParent(gameObject.transform.FindChild("Tiles").transform);
            tiles.Add(ObjectI);
            
            //let's add obstacles to this tile
            Player player = gameObject.transform.parent.GetComponentInChildren<Player>();
            if (player != null && player.started == true)
            {
                int obstaclesCount = Random.Range(0, 3); //1 to 2
                int[] separations = { -3, 0, 3 };
                for (int k = 1; k <= obstaclesCount; k++)
                {
                    string obstacleName = ObstaclesArray[Random.Range(0, ObstaclesArray.Length - 1)];
                    item = items.GetItem(obstacleName);
                    Vector3 basePosition = ObjectI.transform.position;
                    Vector3 obstaclePosition = new Vector3(basePosition.x, 0, 0) + item.GetBasePosition() + new Vector3(separations[(int)Random.Range(0, 3)], 0, separations[(int)Random.Range(0, 3)]);
                    prefab = Resources.Load(item.GetDirectory(), typeof(GameObject));
                    GameObject ObstacleObject = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                    ObstacleObject.transform.position = obstaclePosition;
                    ObstacleObject.transform.SetParent(gameObject.transform.FindChild("Obstacles").transform);
                    obstacles.Add(ObstacleObject);
                }
            }
        }

        //let's delete roads outside of camera
        foreach(GameObject it in tiles)
        {
            distance = GetPlayer().position - it.transform.position;
            if(distance.x >= 20 && GetPlayer().position.x > it.transform.position.x && tiles.Count > 9)
            {
                Destroy(it);
                tiles.Remove(it);
                break;
            }
        }

        foreach(GameObject it in obstacles)
        {
            distance = GetPlayer().position - it.transform.position;
            if (Mathf.Abs(distance.x) >= 30 && GetPlayer().position.x > it.transform.position.x)
            {
                Destroy(it);
                obstacles.Remove(it);
                break;
            }
        }
	}

    Transform GetPlayer()
    {
        foreach(Transform t in gameObject.transform.parent.GetComponentsInChildren<Transform>())
        {
            if(t.name == "PlayerObject")
            {
                return t;
            }
        }
        return null;
    }

    List<GameObject> GetObjectsAround(GameObject obj, List<GameObject> list)
    {
        List<GameObject> objs = new List<GameObject>();
        Vector3 main = obj.transform.position;
        Vector3[] positions = 
        {
            new Vector3(main.x + 1, main.y, main.z + 1),
            new Vector3(main.x + 1, main.y, main.z),
            new Vector3(main.x + 1, main.y, main.z - 1),
            new Vector3(main.x, main.y, main.z + 1),
            new Vector3(main.x, main.y, main.z - 1),
            new Vector3(main.x - 1, main.y, main.z + 1),
            new Vector3(main.x - 1, main.y, main.z),
            new Vector3(main.x - 1, main.y, main.z - 1)
        };

        foreach(GameObject o in list)
        {
            foreach(Vector3 pos in positions)
            {
                if(o.transform.position == pos)
                {
                    objs.Add(o);
                }
            }
        }
        return objs;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System;

public class Items {

    string file = "Assets/Scripts/Loaders/items.xml";
    bool loaded = false;
    List<Item> items = new List<Item>();

    public bool LoadItems()
    {
        Item item = null;
        
        if(File.Exists(file))
        {
            XmlTextReader reader = new XmlTextReader(file);
            while(reader.Read())
            {
                switch(reader.Name.ToString().ToLower())
                {
                    case "item": //assuming there is more than one item
                        item = new Item();
                        if(reader.HasAttributes)
                        {
                            while(reader.MoveToNextAttribute())
                            {
                                switch(reader.Name.ToString().ToLower())
                                {
                                    case "id":
                                        item.id = Convert.ToInt32(reader.Value);
                                        break;
                                    case "name":
                                        item.name = reader.Value;
                                        break;
                                    case "description":
                                        item.description = reader.Value;
                                        break;
                                    case "file":
                                        item.fileDir = reader.Value;
                                        break;
                                    case "base": //base position declared
                                        string val = reader.Value;
                                        string[] split = val.Split(',');
                                        item.basePosition = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                                        break;
                                }
                            }
                            //if we get this point, it's mean there is no more attrs to read
                            if (item != null)
                            {
                                items.Add(item);
                            }
                        }
                        break;
                }
            }
            reader.Close();
            loaded = true;
        }
        return loaded;

    }

    public Item GetItem(int id)
    {
        return items.Find(x => x.id == id);
    }

    public Item GetItem(string name)
    {
        return items.Find(x => x.name == name);
    }
}

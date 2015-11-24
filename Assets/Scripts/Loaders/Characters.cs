using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;
using System.Collections.Generic;

public class Characters {

    string file = "Assets/Scripts/Loaders/characters.xml";
    bool loaded = false;
    List<Character> characters = new List<Character>();

    public bool LoadCharacters()
    {
        Character chart = null;

        if (File.Exists(file))
        {
            XmlTextReader reader = new XmlTextReader(file);
            while (reader.Read())
            {
                switch (reader.Name.ToString().ToLower())
                {
                    case "character": //assuming there is more than one chart
                        chart = new Character();
                        if (reader.HasAttributes)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                switch (reader.Name.ToString().ToLower())
                                {
                                    case "id":
                                        chart.id = Convert.ToInt32(reader.Value);
                                        break;
                                    case "name":
                                        chart.name = reader.Value;
                                        break;
                                    case "blocked":
                                        chart.blocked = (Convert.ToInt32(reader.Value) == 1);
                                        break;
                                    case "file":
                                        chart.fileDir = reader.Value;
                                        break;
                                    case "base": //base position declared
                                        string val = reader.Value;
                                        string[] split = val.Split(',');
                                        chart.basePosition = new Vector3(float.Parse(split[0]), float.Parse(split[1]), float.Parse(split[2]));
                                        break;
                                }
                            }
                            //if we get this point, it's mean there is no more attrs to read
                            if (chart != null)
                            {
                                characters.Add(chart);
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

    public Character GetCharacter(int id)
    {
        return characters.Find(x => x.id == id);
    }

    public Character GetCharacter(string name)
    {
        return characters.Find(x => x.name == name);
    }
}

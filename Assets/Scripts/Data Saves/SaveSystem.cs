using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable] public class Data
{
    public bool alreadyPlayed = false;
    public int eventCounter;
    public int[] stats;
    public bool firstTime = true;
}

public class SaveSystem
{
    public static Data data = new Data();

    public static void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string directory = Application.persistentDataPath;

        Directory.CreateDirectory(directory);

        string path = directory + "/saves.dat";

        FileStream file = File.Create(path);

        formatter.Serialize(file, data);

        file.Close();
    }

    public static void Load()
    {
        string directory = Application.persistentDataPath;

        string path = directory + "/saves.dat";

        if (!File.Exists(path))
        {
            Save();
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        data = (Data)formatter.Deserialize(file);

        file.Close();

        Debug.Log("Settings Loaded");
    }
}
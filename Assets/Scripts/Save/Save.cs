using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class Save
{
    public static void SavePlayerdata(PlayerManager player)
    {
        // Reference a new Binary Formatter 'formatter'
        BinaryFormatter formatter = new BinaryFormatter();
        // Create new string 'path' which will be our save location. 'Application.persistentDataPath' is a Unity understood name.
        string path = Application.persistentDataPath + "/save.png";
        //file stream create file at path
        FileStream stream = new FileStream(path, FileMode.Create);
        //dataToSave with player info
        DataToSave data = new DataToSave(player);
        //format and serialize location and data
        formatter.Serialize(stream, data);
        // Once all the data above has been saved, stop.
        stream.Close();
    }

    public static DataToSave LoadPlayerdata()
    {
        string path = Application.persistentDataPath + "/save.png";
        // 'if File.Exists(string)' is a check to see if the specified file exists
        if (File.Exists(path))
        {
            // Reference a new Binary Formatter 'formatter'
            BinaryFormatter formatter = new BinaryFormatter();
            // New instance of FileStream to open the file at the specified path
            FileStream stream = new FileStream(path, FileMode.Open);
            // Define 'data' as the specified file path as deserialized by the Binary Formatter 
            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            // Once all the data has been loaded, stop.
            stream.Close();
            // Return the loaded data
            return data;
        }

        else
        {
            Debug.Log("woopsie, couldn't find file to load.");
            return null;
        }
    }

}

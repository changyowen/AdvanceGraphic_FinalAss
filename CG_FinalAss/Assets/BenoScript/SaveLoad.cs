using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveData (DataStoreLoad data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Profile.bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        ProfileData profiledata = new ProfileData(data);

        formatter.Serialize(stream, profiledata);
        stream.Close();
        
    }

    public static ProfileData LoadData()
    {
        string path = Application.persistentDataPath + "/Profile.bin";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ProfileData data = formatter.Deserialize(stream) as ProfileData;

            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Profile not found in " + path);
            return null;
        }
    }

}

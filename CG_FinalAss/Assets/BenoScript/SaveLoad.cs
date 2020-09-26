using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveData (DataStoreLoad data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + data.profileText[0].text + ".bin";
        FileStream stream = new FileStream(path, FileMode.Create);

        ProfileData profiledata = new ProfileData(data);

        formatter.Serialize(stream, profiledata);
        stream.Close();
        
    }

}

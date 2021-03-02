using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void saveData(float health, float posX, float posY, float posZ)
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.itproger";
        FileStream file = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(health, posX, posY, posZ);

        binary.Serialize(file, data);
        file.Close();
    }

    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/player.itproger";
        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            PlayerData data = binary.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

}

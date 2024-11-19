using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameState
{
    public PlayerCharacter Player { get; set; }
    public List<Item> InventoryItems { get; set; }
    public int PlayerLevel { get; set; }
}

public static class GameManager
{
    public static void SaveGame(GameState state, string filepath)
    {
        FileStream file = File.Create(filepath);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, state);
        file.Close();
        Console.WriteLine("Game saved.");
    }

    public static GameState LoadGame(string filepath)
    {
        if (File.Exists(filepath))
        {
            FileStream file = File.Open(filepath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            GameState state = (GameState)bf.Deserialize(file);
            file.Close();
            Console.WriteLine("Game loaded.");
            return state;
        }
        else
        {
            Console.WriteLine("No saved game found.");
            return null;
        }
    }
}

using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveManager
{
    //Сохранение данных в файл GameData.gd
    public static void SavingSystem() 
    {
        BinaryFormatter bf= new BinaryFormatter();
        string path = "/GameData.gd";
        FileStream stream = new FileStream(path, FileMode.Create);
        string score =GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScr>().GetScore();
        bf.Serialize(stream, score);
        stream.Close();
    }
}

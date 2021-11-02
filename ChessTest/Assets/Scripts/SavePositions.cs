using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavePositions
{
    public static void SavePos(MainTela m)
    {
        BinaryFormatter binary = new BinaryFormatter();

        string path = Application.persistentDataPath + "/posi.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PosicaoPeca p = new PosicaoPeca(m);

        binary.Serialize(stream, p);
        stream.Close();
        Debug.Log("SALVO!!");
    }

    public static PosicaoPeca LoadPos()
    {
        string path = Application.persistentDataPath + "/posi.dat";
        if (File.Exists(path))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PosicaoPeca p = binary.Deserialize(stream) as PosicaoPeca;
            stream.Close();
            Debug.Log("CARREGADO!!");
            return p;
        }
        Debug.Log("ERROR " + path);
        return null;
    }
}

using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class IdentifierList
{
    public bool useTags = true;
    public List<string> identifiers = new List<string>();
}

public class ExternalListReader : MonoBehaviour
{
    public string fileName = "list.json"; // coloque em StreamingAssets

    public IdentifierList ReadFromJson()
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        if (!File.Exists(path))
        {
            Debug.LogError($"ExternalListReader: arquivo não encontrado em {path}");
            return new IdentifierList();
        }

        string json = File.ReadAllText(path);

        try
        {
            IdentifierList data = JsonUtility.FromJson<IdentifierList>(json);
            return data ?? new IdentifierList();
        }
        catch (System.Exception e)
        {
            Debug.LogError("ExternalListReader: falha ao desserializar JSON: " + e.Message);
            return new IdentifierList();
        }
    }

    // Método utilitário para ler CSV simples (uma coluna)
    public IdentifierList ReadFromCsv()
    {
        string path = Path.Combine(Application.streamingAssetsPath, fileName);
        var list = new IdentifierList();

        if (!File.Exists(path))
        {
            Debug.LogError($"ExternalListReader: CSV não encontrado em {path}");
            return list;
        }

        var lines = File.ReadAllLines(path);

        foreach (var l in lines)
        {
            var t = l.Trim();
            if (!string.IsNullOrEmpty(t))
                list.identifiers.Add(t);
        }

        return list;
    }
}

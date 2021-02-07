using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;
using Newtonsoft.Json;

public class SaveProtoBuf : ISaveFile
{
    const string FILE_EXTENSION = ".prot";

    public void Save<T>(string key, T saveItem, string filePath)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("Key = nullOrEmpty!");
            return;
        }

        filePath += FILE_EXTENSION;

        object jsonData = saveItem;

        string jsonString;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

        if (File.Exists(filePath))
        {
            jsonString = Serializer.Deserialize<string>(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            if (keyValuePairs.ContainsKey(key))
            {
                keyValuePairs[key] = jsonData;
            }

            else
            {
                keyValuePairs.Add(key, jsonData);
            }
        }

        else
        {
            keyValuePairs.Add(key, jsonData);
        }

        jsonString = JsonConvert.SerializeObject(keyValuePairs);

        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            Serializer.Serialize(stream, jsonString);
            stream.Flush();
        }

    }

    public void Save(Dictionary<string, object> itemsDictionary, string filePath)
    {
        if (itemsDictionary == null)
        {
            Debug.LogError("ItemsDictionary = null!");
            return;
        }

        filePath += FILE_EXTENSION;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
        string jsonString;

        if (File.Exists(filePath))
        {
            jsonString = Serializer.Deserialize<string>(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            foreach (var key in itemsDictionary.Keys)
            {
                if (string.IsNullOrEmpty(key))
                {
                    Debug.LogError("Key = nullOrEmpty!");
                    continue;
                }

                else if (keyValuePairs.ContainsKey(key))
                {
                    keyValuePairs[key] = itemsDictionary[key];
                }

                else
                {
                    keyValuePairs.Add(key, itemsDictionary[key]);
                }
            }
        }

        else
        {
            keyValuePairs = itemsDictionary;
        }

        jsonString = JsonConvert.SerializeObject(keyValuePairs);

        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            Serializer.Serialize(stream, jsonString);
            stream.Flush();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveJson : ISaveFile
{
    const string FILE_EXTENSION = ".json";

    public void Save<T>(string key, T saveItem, string filePath)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("Key = nullOrEmpty!");
            return;
        }

        filePath += FILE_EXTENSION;

        Debug.LogError(filePath);

        object jsonData = saveItem;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);

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

        File.WriteAllText(filePath, JsonConvert.SerializeObject(keyValuePairs));

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

        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);

            keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);

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

        File.WriteAllText(filePath, JsonConvert.SerializeObject(keyValuePairs));

    }
}

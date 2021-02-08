using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class SaveProtoBuf : ISaveFile
{
    const string FILE_EXTENSION = ".prot";

    IReadFile<FileStream> readFile = new ReadFileProtoBuf();
    IWriteFile<string> writeFile = new WriteFileProtoBuf();

    public async Task Save<T>(string key, T saveItem, string filePath)
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

        if (readFile.Exists(filePath))
        {
            Stream source = await readFile.GetContent(filePath);

            jsonString = Serializer.Deserialize<string>(source);

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

        writeFile.WriteFile(filePath, jsonString);
    }

    public async Task Save(Dictionary<string, object> itemsDictionary, string filePath)
    {
        if (itemsDictionary == null)
        {
            Debug.LogError("ItemsDictionary = null!");
            return;
        }

        filePath += FILE_EXTENSION;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
        string jsonString;

        if (readFile.Exists(filePath))
        {
            Stream source = await readFile.GetContent(filePath);

            jsonString = Serializer.Deserialize<string>(source);

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

        writeFile.WriteFile(filePath, jsonString);
    }
}

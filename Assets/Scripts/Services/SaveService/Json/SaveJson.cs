using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class SaveJson : ISaveFile
{
    const string FILE_EXTENSION = ".json";

    IReadFile<string> readFile = new ReadFileJson();

    IWriteFile<string> writeFile = new WriteFileJson();

    public async Task Save<T>(string key, T saveItem, string filePath)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("Key = nullOrEmpty!");
        }

        filePath += FILE_EXTENSION;

        object jsonData = saveItem;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

        if (readFile.Exists(filePath))
        {
            string data = await readFile.GetContent(filePath);
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

        string jsonString = JsonConvert.SerializeObject(keyValuePairs);

        await writeFile.WriteFile(filePath, jsonString);
    }

    public async Task Save(Dictionary<string, object> itemsDictionary, string filePath)
    {
        if (itemsDictionary == null)
        {
            Debug.LogError("ItemsDictionary = null!");
        }

        filePath += FILE_EXTENSION;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

        if (readFile.Exists(filePath))
        {
            string data = await readFile.GetContent(filePath);

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

        string jsonString = JsonConvert.SerializeObject(keyValuePairs);

        await writeFile.WriteFile(filePath, jsonString);
    }
}

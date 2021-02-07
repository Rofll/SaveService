using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ProtoBuf;
using Newtonsoft.Json.Linq;

public class LoadProtoBuf : ILoadFile
{
    const string FILE_EXTENSION = ".prot";

    IReadFile<FileStream> readFile = new ReadFileProtoBuf();

    public T Load<T>(string key, string filePath)
    {
        filePath += FILE_EXTENSION;

        if (readFile.Exists(filePath))
        {
            Dictionary<string, object> keyValuePairs;

            string jsonString = Serializer.Deserialize<string>(readFile.GetContent(filePath));

            keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            if (keyValuePairs.ContainsKey(key))
            {
                return (keyValuePairs[key] as JObject).ToObject<T>();
            }

            else
            {
                Debug.LogError("Key doesn't exsist!");
                return default;
            }
        }

        else
        {
            Debug.LogError("File doesn't exsist!");
            return default;
        }
    }
}

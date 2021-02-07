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

    public T Load<T>(string key, string filePath)
    {
        filePath += FILE_EXTENSION;

        if (File.Exists(filePath))
        {
            Dictionary<string, object> keyValuePairs;

            string jsonString = Serializer.Deserialize<string>(new FileStream(filePath, FileMode.Open, FileAccess.Read));

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

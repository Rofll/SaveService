using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadJoson : ILoadFile
{
    const string FILE_EXTENSION = ".json";

    public T Load<T>(string key, string filePath)
    {
        filePath += FILE_EXTENSION;

        if (File.Exists(filePath))
        {
            
            Dictionary<string, object> keyValuePairs;
            keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(filePath));

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

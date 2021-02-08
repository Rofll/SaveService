using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class LoadJoson : ILoadFile
{
    const string FILE_EXTENSION = ".json";

    IReadFile<string> readFile = new ReadFileJson();

    public async Task<T> Load<T>(string key, string filePath)
    {
        filePath += FILE_EXTENSION;

        if (readFile.Exists(filePath))
        {
            
            Dictionary<string, object> keyValuePairs;

            string value = await readFile.GetContent(filePath);

            keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);

            if (keyValuePairs.ContainsKey(key))
            {
                JObject jObject = keyValuePairs[key] as JObject;

                if (jObject != null)
                {
                    return jObject.ToObject<T>();
                }

                else
                {
                    JValue jValue = new JValue(keyValuePairs[key]);

                    return jValue.ToObject<T>();
                }
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

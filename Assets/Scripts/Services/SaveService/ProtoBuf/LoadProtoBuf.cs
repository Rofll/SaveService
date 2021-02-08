using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ProtoBuf;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

public class LoadProtoBuf : ILoadFile
{
    const string FILE_EXTENSION = ".prot";

    IReadFile<FileStream> readFile = new ReadFileProtoBuf();

    public async Task<T> Load<T>(string key, string filePath)
    {
        filePath += FILE_EXTENSION;

        if (readFile.Exists(filePath))
        {
            Dictionary<string, object> keyValuePairs;

            FileStream fileStream = await readFile.GetContent(filePath);

            string jsonString = Serializer.Deserialize<string>(fileStream);

            Debug.LogError(jsonString);

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

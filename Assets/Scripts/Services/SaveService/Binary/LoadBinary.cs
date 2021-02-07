using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBinary : ILoadFile
{
    const string FILE_EXTENSION = ".bin";

    IReadFile<Dictionary<string, object>> readFile = new ReadFileBinary();

    public T Load<T>(string key, string filePath)
    {
        filePath += FILE_EXTENSION;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

        if (readFile.Exists(filePath))
        {
            keyValuePairs = readFile.GetContent(filePath);

            if (keyValuePairs.ContainsKey(key))
            {
                return (T)keyValuePairs[key];
            }

            else
            {
                Debug.LogError("Key doesn't exist!");
                return default;
            }
        }

        else
        {
            Debug.LogError("File doesn't exist");
            return default;
        }
    }
}

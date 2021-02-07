using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadBinary : ILoadFile
{
    const string FILE_EXTENSION = ".bin";

    public T Load<T>(string key, string filePath)
    {
        filePath += FILE_EXTENSION;

        Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

        BinaryFormatter binaryFormatter = new BinaryFormatter()
        {
            AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
            TypeFormat = System.Runtime.Serialization.Formatters.FormatterTypeStyle.TypesWhenNeeded
        };

        if (File.Exists(filePath))
        {
            byte[] data = File.ReadAllBytes(filePath);

            using (var memoryStream = new MemoryStream(data))
            {
                keyValuePairs = binaryFormatter.Deserialize(memoryStream) as Dictionary<string, object>;
            }

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

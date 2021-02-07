using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveBinary : ISaveFile
{
    const string FILE_EXTENSION = ".bin";

    public void Save<T>(string key, T saveItem, string filePath)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("Key = nullOrEmpty!");
            return;
        }

        filePath += FILE_EXTENSION;

        object saveItemObject = saveItem;

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
                keyValuePairs[key] = saveItemObject;
            }

            else
            {
                keyValuePairs.Add(key, saveItemObject);
            }
        }

        else
        {
            keyValuePairs.Add(key, saveItemObject);
        }

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, keyValuePairs);
        }
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

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, keyValuePairs);
        }

    }
}

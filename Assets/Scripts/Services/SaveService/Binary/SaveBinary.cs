using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

public class SaveBinary : ISaveFile
{
    const string FILE_EXTENSION = ".bin";

    IReadFile<Dictionary<string, object>> readFile = new ReadFileBinary();
    IWriteFile<Dictionary<string, object>> writeFile = new WriteFileBinary();

    public async Task Save<T>(string key, T saveItem, string filePath)
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

        if (readFile.Exists(filePath))
        {
            keyValuePairs = await readFile.GetContent(filePath);

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

        writeFile.WriteFile(filePath, keyValuePairs);
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

        BinaryFormatter binaryFormatter = new BinaryFormatter()
        {
            AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
            TypeFormat = System.Runtime.Serialization.Formatters.FormatterTypeStyle.TypesWhenNeeded
        };

        if (readFile.Exists(filePath))
        {
            keyValuePairs = await readFile.GetContent(filePath);

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

        writeFile.WriteFile(filePath, keyValuePairs);
    }
}

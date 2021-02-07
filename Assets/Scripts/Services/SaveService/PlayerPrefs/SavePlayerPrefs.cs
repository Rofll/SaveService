using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SavePlayerPrefs : ISavePalyerPrefs
{
    public void Save<T>(string key, T saveItem)
    {
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError("Key = nullOrEmpty!");
            return;
        }

        string jsonData = JsonConvert.SerializeObject(saveItem);

        PlayerPrefs.SetString(key, jsonData);
    }

    public void Save(Dictionary<string, object> keyValuePairs)
    {
        if (keyValuePairs == null)
        {
            Debug.LogError("Dictionary keyValuePairs == null!");
            return;
        }

        foreach (var key in keyValuePairs.Keys)
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError("Key = nullOrEmpty!");
                continue;
            }

            string jsonData = JsonConvert.SerializeObject(keyValuePairs[key]);

            PlayerPrefs.SetString(key, jsonData);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class LoadPlayerPrefs : ILoadPalyerPrefs
{
    public T Load<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(key));
        }

        else
        {
            Debug.LogError("Key doesn't exsist!");
            return default;
        }
    }
}

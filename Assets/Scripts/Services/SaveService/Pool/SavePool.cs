using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePool : ISavePool
{
    Dictionary<string, object> saveDictionary;

    public Dictionary<string, object> SaveDictionary => saveDictionary;

    public SavePool()
    {
        saveDictionary = new Dictionary<string, object>();
    }

    public void AddSaveItem<T>(string key, T item)
    {
        if (saveDictionary.ContainsKey(key))
        {
            saveDictionary[key] = item;
        }

        else
        {
            saveDictionary.Add(key, item);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavePool
{
    Dictionary<string, object> SaveDictionary { get; }
    void AddSaveItem<T>(string key, T item);
}

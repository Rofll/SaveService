using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveFile
{
    void Save<T>(string key, T saveItem, string filePath);
    void Save(Dictionary<string, object> keyValuePairs, string filePath);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveJson
{
    void Save<T>(string key, T saveItem, string filePath);
}

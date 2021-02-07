using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveBinary
{
    void Save<T>(string key, T saveItem, string filePath);
}

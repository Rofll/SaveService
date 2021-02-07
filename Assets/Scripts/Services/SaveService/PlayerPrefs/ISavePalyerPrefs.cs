using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavePalyerPrefs
{
    void Save<T>(string key, T saveItem);
    void Save(Dictionary<string, object> keyValuePairs);
}

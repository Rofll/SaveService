using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ISaveFile
{
    Task Save<T>(string key, T saveItem, string filePath);
    Task Save(Dictionary<string, object> keyValuePairs, string filePath);
}

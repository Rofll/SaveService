using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ISaveService
{
    Task Save<T>(string key, T saveItem, ESaveFormat saveFormat = ESaveFormat.PlayerPrefs, string filePath = null);
    Task Save(Dictionary<string, object> itemsDictionary, ESaveFormat saveFormat, string filePath = null);
    Task<T> Load<T>(string key, ESaveFormat saveFormat = ESaveFormat.PlayerPrefs, string filePath = null);
}

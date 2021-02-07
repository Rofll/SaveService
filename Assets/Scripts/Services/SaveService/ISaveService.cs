using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveService
{
    void Save<T>(string key, T saveItem, ESaveFormat saveFormat = ESaveFormat.PlayerPrefs, string filePath = null);
    T Load<T>(string key, ESaveFormat saveFormat = ESaveFormat.PlayerPrefs, string filePath = null);
}

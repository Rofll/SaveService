using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadJson
{
    T Load<T>(string key, string filePath);
}

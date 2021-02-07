using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadFile
{
    T Load<T>(string key, string filePath);
}

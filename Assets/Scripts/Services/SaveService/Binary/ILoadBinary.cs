using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadBinary
{
    T Load<T>(string key, string filePath);
}

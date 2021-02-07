using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadPalyerPrefs
{
    T Load<T>(string key);
}

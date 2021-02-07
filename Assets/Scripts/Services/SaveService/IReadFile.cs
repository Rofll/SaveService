using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReadFile<T>
{
    bool Exists(string path);

    T GetContent(string path);
}

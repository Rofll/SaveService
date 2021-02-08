using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IReadFile<T>
{
    bool Exists(string path);

    Task<T> GetContent(string path);
}

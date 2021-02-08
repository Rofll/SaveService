using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ILoadFile
{
    Task<T> Load<T>(string key, string filePath);
}

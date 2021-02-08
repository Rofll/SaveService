using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IWriteFile<T>
{
    public Task WriteFile(string filePath, T data);
}

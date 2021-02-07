using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWriteFile<T>
{
    public void WriteFile(string filePath, T data);
}

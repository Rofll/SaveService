using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteFileJson : IWriteFile<string>
{
    public void WriteFile(string filePath, string data)
    {
        File.WriteAllText(filePath, data);
    }
}

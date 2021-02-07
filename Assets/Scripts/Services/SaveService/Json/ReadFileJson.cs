using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFileJson : IReadFile<string>
{
    public bool Exists(string path)
    {
        return File.Exists(path);
    }

    public string GetContent(string path)
    {
        return File.ReadAllText(path);
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFileProtoBuf : IReadFile<FileStream>
{
    public bool Exists(string path)
    {
        return File.Exists(path);
    }

    public FileStream GetContent(string path)
    {
       return new FileStream(path, FileMode.Open, FileAccess.Read);
    }
}

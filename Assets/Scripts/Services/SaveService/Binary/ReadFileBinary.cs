using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class ReadFileBinary : IReadFile<Dictionary<string, object>>
{
    BinaryFormatter binaryFormatter;

    public ReadFileBinary()
    {
        binaryFormatter = new BinaryFormatter()
        {
            AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
            TypeFormat = System.Runtime.Serialization.Formatters.FormatterTypeStyle.TypesWhenNeeded
        };
    }

    public bool Exists(string path)
    {
        return File.Exists(path);
    }

    public async Task<Dictionary<string, object>> GetContent(string path)
    {
        byte[] data = File.ReadAllBytes(path);

        Dictionary<string, object> keyValuePairs;

        using (var memoryStream = new MemoryStream(data))
        {
            keyValuePairs = binaryFormatter.Deserialize(memoryStream) as Dictionary<string, object>;
        }

        return keyValuePairs;
    }
}

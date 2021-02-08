using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class WriteFileBinary : IWriteFile<Dictionary<string, object>>
{
    BinaryFormatter binaryFormatter;

    public WriteFileBinary()
    {
        binaryFormatter = new BinaryFormatter()
        {
            AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
            TypeFormat = System.Runtime.Serialization.Formatters.FormatterTypeStyle.TypesWhenNeeded
        };
    }

    public async Task WriteFile(string filePath, Dictionary<string, object> data)
    {
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }
}

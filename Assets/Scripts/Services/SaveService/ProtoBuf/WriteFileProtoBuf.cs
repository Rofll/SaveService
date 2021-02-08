using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class WriteFileProtoBuf : IWriteFile<string>
{
    public async Task WriteFile(string filePath, string data)
    {
        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            Serializer.Serialize(stream, data);
            stream.Flush();
        }

        await Task.Delay(10);
    }
}

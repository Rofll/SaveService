using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class WriteFileJson : IWriteFile<string>
{
    public async Task WriteFile(string filePath, string data)
    {
        byte[] encodedText = Encoding.Default.GetBytes(data);

        using (FileStream sourceStream = new FileStream(filePath,
            FileMode.Create, FileAccess.Write, FileShare.None,
            bufferSize: 4096, useAsync: true))
        {
            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        };
    }
}

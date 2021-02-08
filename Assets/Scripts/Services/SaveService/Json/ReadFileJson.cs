using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ReadFileJson : IReadFile<string>
{
    public bool Exists(string path)
    {
        return File.Exists(path);
    }

    public async Task<string> GetContent(string filePath)
    {
        using var sourceStream =
        new FileStream(
            filePath,
            FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize: 4096, useAsync: true);

        var sb = new StringBuilder();

        byte[] buffer = new byte[0x1000];
        int numRead;
        while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
        {
            string text = Encoding.Default.GetString(buffer, 0, numRead);
            sb.Append(text);
        }

        return sb.ToString();
    }
}

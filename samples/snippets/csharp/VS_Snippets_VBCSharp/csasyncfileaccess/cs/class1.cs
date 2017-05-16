// Using Async for File Access

//<Snippet1>
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
//</Snippet1>


class Class1
{
    //<Snippet2>
    public async void ProcessWrite()
    {
        string filePath = @"temp2.txt";
        string text = "Hello World\r\n";

        await WriteTextAsync(filePath, text);
    }

    private async Task WriteTextAsync(string filePath, string text)
    {
        byte[] encodedText = Encoding.Unicode.GetBytes(text);

        using (FileStream sourceStream = new FileStream(filePath,
            FileMode.Append, FileAccess.Write, FileShare.None,
            bufferSize: 4096, useAsync: true))
        {
            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        };
    }
    //</Snippet2>


    private async Task WriteTextAsync2(string filePath, string text)
    {
        byte[] encodedText = Encoding.Unicode.GetBytes(text);

        using (FileStream sourceStream = new FileStream(filePath,
            FileMode.Append, FileAccess.Write, FileShare.None,
            bufferSize: 4096, useAsync: true))
        {
            //<Snippet3>
            Task theTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            await theTask;
            //</Snippet3>
        };
    }


    //<Snippet4>
    public async void ProcessRead()
    {
        string filePath = @"temp2.txt";

        if (File.Exists(filePath) == false)
        {
            Debug.WriteLine("file not found: " + filePath);
        }
        else
        {
            try
            {
                string text = await ReadTextAsync(filePath);
                Debug.WriteLine(text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }

    private async Task<string> ReadTextAsync(string filePath)
    {
        using (FileStream sourceStream = new FileStream(filePath,
            FileMode.Open, FileAccess.Read, FileShare.Read,
            bufferSize: 4096, useAsync: true))
        {
            StringBuilder sb = new StringBuilder();

            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }
    }
    //</Snippet4>


    //<Snippet5>
    public async void ProcessWriteMult()
    {
        string folder = @"tempfolder\";
        List<Task> tasks = new List<Task>();
        List<FileStream> sourceStreams = new List<FileStream>();

        try
        {
            for (int index = 1; index <= 10; index++)
            {
                string text = "In file " + index.ToString() + "\r\n";

                string fileName = "thefile" + index.ToString("00") + ".txt";
                string filePath = folder + fileName;

                byte[] encodedText = Encoding.Unicode.GetBytes(text);

                FileStream sourceStream = new FileStream(filePath,
                    FileMode.Append, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true);

                Task theTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                sourceStreams.Add(sourceStream);

                tasks.Add(theTask);
            }

            await Task.WhenAll(tasks);
        }

        finally
        {
            foreach (FileStream sourceStream in sourceStreams)
            {
                sourceStream.Close();
            }
        }
    }
    //</Snippet5>

}

---
title: "How to: Upload files with FTP"
description: "This article shows a sample of how to upload a file to an FTP server."
ms.date: "06/26/2018"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: e40f17c5-dd12-4c62-9dbf-00ab491382dc
---
# How to: Upload files with FTP

This sample shows how to upload a file to an FTP server.

## Example

```csharp
using System;
using System.IO;
using System.Net;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static async Task Main()
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            // Copy the contents of the file to the request stream.
            await using FileStream fileStream = File.Open("testfile.txt", FileMode.Open, FileAccess.Read);
            await using Stream requestStream = request.GetRequestStream();
            await fileStream.CopyToAsync(requestStream);

            using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
        }
    }
}
```

```vb
Imports System.IO
Imports System.Net

Namespace Examples.System.Net
    Public Module WebRequestGetExample
        Public Sub Main()
            ' Get the object used to communicate with the server.
            Dim request As FtpWebRequest = CType(WebRequest.Create("ftp://www.contoso.com/test.htm"), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.UploadFile

            ' This example assumes the FTP site uses anonymous logon.
            request.Credentials = New NetworkCredential("anonymous", "janeDoe@contoso.com")

            ' Copy the contents of the file to the request stream.
            Using fileStream As FileStream = File.Open("testfile.txt", FileMode.Open, FileAccess.Read),
                  requestStream As Stream = request.GetRequestStream()
                fileStream.CopyTo(requestStream)
            End Using

            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}")
            End Using
        End Sub
    End Module
End Namespace
```

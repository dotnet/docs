---
title: "How to: List directory contents with FTP"
description: "This article shows a sample of how to list the directory contents of an FTP server."
ms.date: "06/25/2018"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 130c64c9-7b7f-4672-9b3b-d946bd2616c5
---
# How to: List directory contents with FTP

This sample shows how to list the directory contents of an FTP server.

## Example

```csharp
using System;
using System.IO;
using System.Net;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void Main ()
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();
        }
    }
}
```

```vb
Imports System
Imports System.IO
Imports System.Net

Namespace Examples.System.Net
    Public Class WebRequestGetExample
        Public Shared Sub Main()
            ' Get the object used to communicate with the server.
            Dim request As FtpWebRequest = CType(WebRequest.Create("ftp://www.contoso.com/"), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails

            ' This example assumes the FTP site uses anonymous logon.
            request.Credentials = New NetworkCredential("anonymous", "janeDoe@contoso.com")

            Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)

            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(responseStream)
            Console.WriteLine(reader.ReadToEnd())

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription)

            reader.Close()
            response.Close()
        End Sub
    End Class
End Namespace
```
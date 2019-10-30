---
title: "How to: Request a Web Page and Retrieve the Results as a Stream"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: d32b7f35-29d8-4fb7-ad71-d219edc5e359
---
# How to: Request a Web Page and Retrieve the Results as a Stream

This example shows how to request a Web page and retrieve the results in a stream.
  
## Example

```csharp
var myClient = new WebClient();
Stream response = myClient.OpenRead("https://docs.microsoft.com/dotnet/");
// The stream data is used here.
response.Close();
```

```vb
Dim myClient As New WebClient()
Dim response As Stream = myClient.OpenRead("https://docs.microsoft.com/dotnet/")
' The stream data is used here.
response.Close()
```

## Compiling the Code

 This example requires:

- References to the <xref:System.IO> and <xref:System.Net> namespaces.

## See also

- [Requesting Data](requesting-data.md)

---
title: ".NET 6 breaking change: FileStream.Position updated after ReadAsync or WriteAsync completion"
description: Learn about the .NET 6 breaking change in core .NET libraries where FileStream.Position is updated after ReadAsync or WriteAsync completion.
ms.date: 05/05/2021
---
# FileStream.Position updates after ReadAsync or WriteAsync completes

<xref:System.IO.FileStream.Position?displayProperty=nameWithType> is now updated after <xref:System.IO.FileStream.ReadAsync%2A> or <xref:System.IO.FileStream.WriteAsync%2A> completes.

## Change description

In previous .NET versions on Windows, <xref:System.IO.FileStream.Position?displayProperty=nameWithType> is updated after the asynchronous read or write operation starts. Starting in .NET 6, <xref:System.IO.FileStream.Position?displayProperty=nameWithType> is updated after those operations complete.

The following code shows how the value of <xref:System.IO.FileStream.Position?displayProperty=nameWithType> differs between previous .NET versions and .NET 6.

```csharp
byte[] bytes = new byte[10_000];
string path = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());

using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None, bufferSize: 4096, useAsync: true))
{
    Task[] writes = new Task[3];

    writes[0] = fs.WriteAsync(bytes, 0, bytes.Length);
    Console.WriteLine(fs.Position);  // 10000 in .NET 5, 0 in .NET 6

    writes[1] = fs.WriteAsync(bytes, 0, bytes.Length);
    Console.WriteLine(fs.Position);  // 20000 in .NET 5, 0 in .NET 6

    writes[2] = fs.WriteAsync(bytes, 0, bytes.Length);
    Console.WriteLine(fs.Position);  // 30000 in .NET 5, 0 in .NET 6

    await Task.WhenAll(writes);
    Console.WriteLine(fs.Position);  // 30000 in all versions
}
```

## Version introduced

.NET 6

## Reason for change

<xref:System.IO.FileStream> has never been thread-safe, but until .NET 6, .NET has tried to support multiple concurrent calls to its asynchronous methods (<xref:System.IO.FileStream.ReadAsync%2A> and <xref:System.IO.FileStream.WriteAsync%2A>) on Windows.

This change was introduced to allow for 100% asynchronous file I/O with <xref:System.IO.FileStream> and to fix the following issues:

- [FileStream.FlushAsync ends up doing synchronous writes](https://github.com/dotnet/runtime/issues/27643)
- [Win32 FileStream turns async reads into sync reads](https://github.com/dotnet/runtime/issues/16341)

Now, when buffering is enabled (that is, the `bufferSize` argument that's passed to the [FileStream constructor](xref:System.IO.FileStream.%23ctor%2A) is greater than 1), every <xref:System.IO.FileStream.ReadAsync%2A> and <xref:System.IO.FileStream.WriteAsync%2A> operation is serialized.

## Recommended action

- Modify any code that relied on the position being set before operations completed.

- To enable the .NET 5 behavior in .NET 6, specify an `AppContext` switch or an environment variable. By setting the switch to `true`, you opt out of all performance improvements made to `FileStream` in .NET 6.

  ```json
  {
      "configProperties": {
          "System.IO.UseNet5CompatFileStream": true
      }
  }
  ```

  ```cmd
  set DOTNET_SYSTEM_IO_USENET5COMPATFILESTREAM=1
  ```

## Affected APIs

- <xref:System.IO.FileStream.Position?displayProperty=fullName>

<!--

### Category

- Core .NET libraries

### Affected APIs

- `P:System.IO.FileStream.Position`

-->

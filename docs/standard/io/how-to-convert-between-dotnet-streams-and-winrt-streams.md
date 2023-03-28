---
description: "Learn more about: How to: Convert between .NET Framework and Windows Runtime streams (Windows only)"
title: "How to: Convert between .NET Framework and Windows Runtime streams (Windows only)"
ms.date: "01/14/2019"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 23a763ea-8348-4244-9f8c-a4280b870b47
---
# How to: Convert between .NET Framework and Windows Runtime streams (Windows only)

.NET Framework for UWP apps is a subset of the full .NET Framework. Because of security and other requirements for UWP apps, you can't use the full set of .NET Framework APIs to open and read files. For more information, see [.NET for UWP apps overview](/previous-versions/windows/apps/br230302(v=vs.140)). However, you may want to use .NET Framework APIs for other stream manipulation operations. To manipulate these streams, you can convert between a .NET Framework stream type, such as <xref:System.IO.MemoryStream> or <xref:System.IO.FileStream>, and a Windows Runtime stream, such as <xref:Windows.Storage.Streams.IInputStream>, <xref:Windows.Storage.Streams.IOutputStream>, or <xref:Windows.Storage.Streams.IRandomAccessStream>.

The <xref:System.IO.WindowsRuntimeStreamExtensions?displayProperty=nameWithType> class contains methods that make these conversions easy. However, underlying differences between .NET Framework and Windows Runtime streams affect the results of using these methods, as described in the following sections:

## Convert from a Windows Runtime to a .NET Framework stream

To convert from a Windows Runtime stream to a .NET Framework stream, use one of the following <xref:System.IO.WindowsRuntimeStreamExtensions?displayProperty=nameWithType> methods:

- <xref:System.IO.WindowsRuntimeStreamExtensions.AsStream%2A?displayProperty=nameWithType> converts a random-access stream in the Windows Runtime to a managed stream in .NET for UWP apps.
  
- <xref:System.IO.WindowsRuntimeStreamExtensions.AsStreamForWrite%2A?displayProperty=nameWithType> converts an output stream in the Windows Runtime to a managed stream in .NET for UWP apps.
  
- <xref:System.IO.WindowsRuntimeStreamExtensions.AsStreamForRead%2A?displayProperty=nameWithType> converts an input stream in the Windows Runtime to a managed stream in .NET for UWP apps.

The Windows Runtime offers stream types that support reading only, writing only, or reading and writing. These capabilities are maintained when you convert a Windows Runtime stream to a .NET Framework stream. Furthermore, if you convert a Windows Runtime stream to a .NET Framework stream and back, you get the original Windows Runtime instance back.

It's best practice to use the conversion method that matches the capabilities of the Windows Runtime stream you want to convert. However, since <xref:Windows.Storage.Streams.IRandomAccessStream> is readable and writeable (it implements both <xref:Windows.Storage.Streams.IOutputStream> and <xref:Windows.Storage.Streams.IInputStream>), the conversion methods maintain the capabilities of the original stream. For example, using <xref:System.IO.WindowsRuntimeStreamExtensions.AsStreamForRead%2A?displayProperty=nameWithType> to convert an <xref:Windows.Storage.Streams.IRandomAccessStream> doesn't limit the converted .NET Framework stream to being readable. It's also writable.

## Example: Convert Windows Runtime random-access to .NET Framework stream

To convert from a Windows Runtime random-access stream to a .NET Framework stream, use the <xref:System.IO.WindowsRuntimeStreamExtensions.AsStream%2A?displayProperty=nameWithType> method.

The following code example prompts you to select a file, opens it with Windows Runtime APIs, and then converts it to a .NET Framework stream. It reads the stream and outputs it to a text block. You would typically manipulate the stream with .NET Framework APIs before outputting the results.

```csharp
// Create a file picker.
FileOpenPicker picker = new FileOpenPicker();
picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
picker.ViewMode = PickerViewMode.List;
picker.FileTypeFilter.Add(".txt");

// Show picker, enabling user to pick one file.
StorageFile result = await picker.PickSingleFileAsync();
if (result != null)
{
    try
    {
        // Retrieve the stream. This method returns a IRandomAccessStreamWithContentType.
        var stream = await result.OpenReadAsync();

        // Convert the stream to a .NET stream using AsStream, pass to a
        // StreamReader and read the stream.
        using (StreamReader sr = new StreamReader(stream.AsStream()))
        {
            TextBlock1.Text = sr.ReadToEnd();
        }
    }
    catch (Exception ex)
    {
        // ...
    }
}       
```

## Convert from a .NET Framework to a Windows Runtime stream

To convert from a .NET Framework stream to a Windows Runtime stream, use one of the following <xref:System.IO.WindowsRuntimeStreamExtensions?displayProperty=nameWithType> methods:

- <xref:System.IO.WindowsRuntimeStreamExtensions.AsInputStream%2A?displayProperty=nameWithType> converts a managed stream in .NET for UWP apps to an input stream in the Windows Runtime.
  
- <xref:System.IO.WindowsRuntimeStreamExtensions.AsOutputStream%2A?displayProperty=nameWithType> converts a managed stream in .NET for UWP apps to an output stream in the Windows Runtime.
  
- <xref:System.IO.WindowsRuntimeStreamExtensions.AsRandomAccessStream%2A?displayProperty=nameWithType> converts a managed stream in .NET for UWP apps to a random-access stream that the Windows Runtime can use for reading or writing.

When you convert a .NET Framework stream to a Windows Runtime stream, the capabilities of the converted stream depend on the original stream. For example, if the original stream supports both reading and writing, and you call <xref:System.IO.WindowsRuntimeStreamExtensions.AsInputStream%2A?displayProperty=nameWithType> to convert the stream, the returned type is an `IRandomAccessStream`. `IRandomAccessStream` implements `IInputStream` and `IOutputStream`, and supports reading and writing.

.NET Framework streams don't support cloning, even after conversion. If you convert a .NET Framework stream to a Windows Runtime stream and call <xref:Windows.Storage.Streams.InMemoryRandomAccessStream.GetInputStreamAt%2A> or <xref:Windows.Storage.Streams.IRandomAccessStream.GetOutputStreamAt%2A>, which call <xref:Windows.Storage.Streams.RandomAccessStreamOverStream.CloneStream%2A>, or if you call <xref:Windows.Storage.Streams.RandomAccessStreamOverStream.CloneStream%2A> directly, an exception occurs.

## Example: Convert .NET Framework to Windows Runtime random-access stream

To convert from a .NET Framework stream to a Windows Runtime random-access stream, use the <xref:System.IO.WindowsRuntimeStreamExtensions.AsRandomAccessStream%2A> method, as shown in the following example:

> [!IMPORTANT]
> Make sure that the .NET Framework stream you are using supports seeking, or copy it to a stream that does. You can use the <xref:System.IO.Stream.CanSeek%2A?displayProperty=nameWithType> property to determine this.

```csharp
// Create an HttpClient and access an image as a stream.
var client = new HttpClient();
Stream stream = await client.GetStreamAsync("https://learn.microsoft.com/en-us/dotnet/images/hub/featured-1.png");
// Create a .NET memory stream.
var memStream = new MemoryStream();
// Convert the stream to the memory stream, because a memory stream supports seeking.
await stream.CopyToAsync(memStream);
// Set the start position.
memStream.Position = 0;
// Create a new bitmap image.
var bitmap = new BitmapImage();
// Set the bitmap source to the stream, which is converted to a IRandomAccessStream.
bitmap.SetSource(memStream.AsRandomAccessStream());
// Set the image control source to the bitmap.
Image1.Source = bitmap;
```

## See also

- [Quickstart: Read and write a file (Windows)](/previous-versions/windows/apps/hh464978(v=win.10))  
- [.NET for Windows Store apps overview](/previous-versions/windows/apps/br230302(v=vs.140))  
- [.NET for Windows Store apps APIs](/previous-versions/br230232(v=vs.120))

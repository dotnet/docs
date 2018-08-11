---
title: "How to: Convert Between .NET Framework Streams and Windows Runtime Streams"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 23a763ea-8348-4244-9f8c-a4280b870b47
author: "mairaw"
ms.author: "mairaw"
---
# How to: Convert Between .NET Framework Streams and Windows Runtime Streams

The .NET Framework for Windows Store apps is a subset of the full .NET Framework. Because of security and other requirements for Windows Store apps, you cannot use the full set of .NET Framework APIs to open and read files. For more information, see [.NET for Windows Store apps overview](https://docs.microsoft.com/previous-versions/windows/apps/br230302(v=vs.140)). However, you may want to use .NET Framework APIs for other stream manipulation operations. To manipulate these streams, you may find it necessary to convert between a .NET Framework stream type such as <xref:System.IO.MemoryStream> or <xref:System.IO.FileStream>, and a Windows Runtime stream such as <xref:Windows.Storage.Streams.IInputStream>, <xref:Windows.Storage.Streams.IOutputStream>, or <xref:Windows.Storage.Streams.IRandomAccessStream>.

The [System.IO.WindowsRuntimeStreamExtensions](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.aspx) class contains methods that make these conversions easy. However, there are underlying differences between streams in the .NET Framework and the Windows Runtime that will affect the results of using these methods. The details are described in the following sections.

## Converting from a Windows Runtime stream to a .NET Framework stream

You can convert from a Windows Runtime stream to a .NET Framework stream by using one of the following [System.IO.WindowsRuntimeStreamExtensions](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.aspx) methods:

[System.IO.WindowsRuntimeStreamExtensions.AsStream](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asstream.aspx)  
Converts a random-access stream in the Windows Runtime to a managed stream in the .NET for Windows Store apps subset.

[System.IO.WindowsRuntimeStreamExtensions.AsStreamForWrite](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asstreamforwrite.aspx)  
Converts an output stream in the Windows Runtime to a managed stream in the .NET for Windows Store apps subset.

[System.IO.WindowsRuntimeStreamExtensions.AsStreamForRead](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asstreamforread.aspx)  
Converts an input stream in the Windows Runtime to a managed stream in the .NET for Windows Store apps subset.

The Windows Runtime offers stream types that support reading only, writing only or reading and writing, and these capabilities are maintained when you convert a Windows Runtime stream to a .NET Framework stream. Furthermore, if you convert a Windows Runtime stream to a .NET Framework stream and back, you get the original Windows Runtime instance back. It’s best practice to use the conversion method that matches the capabilities of the Windows Runtime stream you would like to convert. However, since <xref:Windows.Storage.Streams.IRandomAccessStream> is readable and writeable (it implements both <xref:Windows.Storage.Streams.IOutputStream> and <xref:Windows.Storage.Streams.IInputStream>, you can use any of the conversion methods and the capabilities of the original stream are maintained. For example, using [System.IO.WindowsRuntimeStreamExtensions.AsStreamForRead](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asstreamforread.aspx) to convert an <xref:Windows.Storage.Streams.IRandomAccessStream> will not limit the converted .NET Framework stream to being readable only; it will also be writable.

### To convert from a Windows Runtime random-access stream to a .NET Framework stream

- Use the [System.IO.WindowsRuntimeStreamExtensions.AsStream](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asstream.aspx) method.

  The following code example shows how to prompt the user to select a file, open it with Windows Runtime APIs, and then convert it to a .NET Framework stream, which is read and output to a text block. In this scenario, you would typically manipulate the stream with .NET Framework APIs before outputting the results.

  To run this example, you must create a Windows Store XAML app that contains a text block named `TextBlock1` and a button named  `Button1`. The button click event must be associated with the `button1_Click` method shown in the example.

  [!code-csharp[System.IO.WindowsRuntimeStreamExtensionsEx#Imports](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/cs/mainpage.xaml.cs#imports)]
  [!code-vb[System.IO.WindowsRuntimeStreamExtensionsEx#Imports](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/vb/mainpage.xaml.vb#imports)]
  [!code-csharp[System.IO.WindowsRuntimeStreamExtensionsEx#1](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/cs/mainpage.xaml.cs#1)]
  [!code-vb[System.IO.WindowsRuntimeStreamExtensionsEx#1](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/vb/mainpage.xaml.vb#1)]

## Converting from a .NET Framework stream to a Windows Runtime stream

You can convert from a .NET Framework stream to a Windows Runtime stream by using one of the following [System.IO.WindowsRuntimeStreamExtensions](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.aspx) methods:

[System.IO.WindowsRuntimeStreamExtensions.AsInputStream](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asinputstream.aspx)
 Converts a managed stream in the .NET for Windows Store apps subset to an input stream in the Windows Runtime.

[System.IO.WindowsRuntimeStreamExtensions.AsOutputStream](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asoutputstream.aspx)
 Converts a managed stream in the .NET for Windows Store apps subset to an output stream in the Windows Runtime.

[AsRandomAccessStream](../../../docs/standard/cross-platform/windowsruntimestreamextensions-asrandomaccessstream-method.md)
 Converts a managed stream in the .NET for Windows Store apps subset to a random-access stream that can be used for reading or writing in the Windows Runtime.

When you convert a .NET Framework stream to a Windows Runtime stream, the capabilities of the converted stream will depend on the original stream. For example, if the original stream supports both reading and writing, and you call[System.IO.WindowsRuntimeStreamExtensions.AsInputStream](https://msdn.microsoft.com/library/system.io.windowsruntimestreamextensions.asinputstream.aspx) to convert the stream, the returned type will be an `IRandomAccessStream`, which  implements `IInputStream` and `IOutputStream`, and supports reading and writing.

.NET Framework streams do not support cloning, even after conversion. This means that if you convert a .NET Framework stream to a Windows Runtime stream and call <xref:Windows.Storage.Streams.InMemoryRandomAccessStream.GetInputStreamAt%2A> or <xref:Windows.Storage.Streams.IRandomAccessStream.GetOutputStreamAt%2A>, which call <xref:Windows.Storage.Streams.RandomAccessStreamOverStream.CloneStream%2A> or call <xref:Windows.Storage.Streams.RandomAccessStreamOverStream.CloneStream%2A> directly, an exception will occur.

### To convert from a .NET Framework stream to a Windows Runtime random-access stream

- Use the [AsRandomAccessStream](../../../docs/standard/cross-platform/windowsruntimestreamextensions-asrandomaccessstream-method.md) method, as shown in the following example:

  > [!IMPORTANT]
  > Ensure that the .NET Framework stream you are using supports seeking, or copy it to a stream that does. You can use the <xref:System.IO.Stream.CanSeek%2A?displayProperty=nameWithType> property to determine this.

  To run this example, you must create a Windows Store XAML app that targets the .NET Framework 4.5.1 and contains a text block named `TextBlock2` and a button named `Button2`. The button click event must be associated with the `button2_Click` method shown in this example.

  [!code-csharp[System.IO.WindowsRuntimeStreamExtensionsEx#Imports](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/cs/mainpage.xaml.cs#imports)]
  [!code-vb[System.IO.WindowsRuntimeStreamExtensionsEx#Imports](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/vb/mainpage.xaml.vb#imports)]
  [!code-csharp[System.IO.WindowsRuntimeStreamExtensionsEx#2](~/samples/snippets/csharp/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/cs/mainpage.xaml.cs#2)]
  [!code-vb[System.IO.WindowsRuntimeStreamExtensionsEx#2](~/samples/snippets/visualbasic/VS_Snippets_CLR_System/system.io.windowsruntimestreamextensionsex/vb/mainpage.xaml.vb#2)]

## See Also

[Quickstart: Reading and writing a file (Windows)](https://msdn.microsoft.com/library/windows/apps/hh464978.aspx)  
[.NET for Windows Store apps overview](http://msdn.microsoft.com/library/windows/apps/br230302.aspx)  
[.NET for Windows Store apps – supported APIs](https://msdn.microsoft.com/library/windows/apps/br230232.aspx)  
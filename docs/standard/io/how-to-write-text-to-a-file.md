---
title: "How to: Write text to a file"
ms.date: "01/04/2019"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "writing text to files"
  - "I/O [.NET Framework], writing text to files"
  - "streams, writing text to files"
  - "data streams, writing text to files"
ms.assetid: 060cbe06-2adf-4337-9e7b-961a5c840208
author: "mairaw"
ms.author: "mairaw"
---
# How to: Write text to a file
This topic shows different ways to write text to a file for .NET or Universal Windows (UWP) apps. 

The following classes and methods are typically used to write text to a file:  
  
-   <xref:System.IO.StreamWriter> contains methods to write to a file synchronously: <xref:System.IO.StreamWriter.Write%2A> and <xref:System.IO.TextWriter.WriteLine%2A>, or asynchronously: <xref:System.IO.StreamWriter.WriteAsync%2A> and <xref:System.IO.StreamWriter.WriteLineAsync%2A>.  
  
-   <xref:System.IO.File> is for .NET apps. It provides static methods to write text to a file, such as <xref:System.IO.File.WriteAllLines%2A> and <xref:System.IO.File.WriteAllText%2A>, or to append text to a file: <xref:System.IO.File.AppendAllLines%2A>, <xref:System.IO.File.AppendAllText%2A>, and <xref:System.IO.File.AppendText%2A>.  
  
-   <xref:Windows.Storage.FileIO> is for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps. It contains asynchronous methods to write text to a file: <xref:Windows.Storage.FileIO.WriteLinesAsync%2A> and <xref:Windows.Storage.FileIO.WriteTextAsync%2A>, or to append text to a file: <xref:Windows.Storage.FileIO.AppendLinesAsync%2A> and <xref:Windows.Storage.FileIO.AppendTextAsync%2A>.  

- <xref:System.IO.Path> is for strings that have file or directory path information. It contains the <xref:System.IO.Path.Combine%2A> method, which allows concatenation of strings to build a file or directory path.

## Examples: Write text with StreamWriter and File 

The following examples show how to:
1. Synchronously write text to a new file using the <xref:System.IO.StreamWriter> class, one line at a time. The new text file is saved to the *My Documents* folder. Because the <xref:System.IO.StreamWriter> object is declared and instantiated in a `using` statement, the <xref:System.IO.StreamWriter.Dispose%2A> method is invoked, which automatically flushes and closes the stream.  
   
1. Append text to the text file created in the first example, using the <xref:System.IO.StreamWriter> class.   
   
1. Asynchronously write text to a new file using the <xref:System.IO.StreamWriter> class. To invoke the <xref:System.IO.StreamWriter.WriteAsync%2A> method, the method call must be within an `async` method. The new text file is saved to the *My Documents* folder.  
   
1. Write text to a new file and append new lines of text to the same file using the <xref:System.IO.File> class. The <xref:System.IO.File.WriteAllText%2A> and <xref:System.IO.File.AppendAllLines%2A> methods open and close the file automatically. If the path you provide to the <xref:System.IO.File.WriteAllText%2A> method already exists, the file is overwritten.  

> [!NOTE]
> These examples show only the minimum amount of code needed. A real-world app usually provides more robust error checking and exception handling.  
  
[!code-csharp[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.basicio.textfiles/cs/source.cs)] 
[!code-vb[Conceptual.BasicIO.TextFiles#WriteLine](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.basicio.textfiles/vb/source.vb)]  

## Example: Write user input to text in a UWP app  
 The following example shows how to asynchronously write user input to a text file in a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app. Because of security considerations, opening a file from a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app typically requires the use of a <xref:Windows.Storage.Pickers.FileOpenPicker> control. In this example, the `FileOpenPicker` is filtered to show text files.  
  
```xaml  
<Page  
    x:Class="OpenFileWindowsStore.MainPage"  
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  
    xmlns:local="using:OpenFileWindowsStore"  
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"  
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
    mc:Ignorable="d">  
  
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">  
        <Button Content="save text to a file" HorizontalAlignment="Left" Margin="103,417,0,0" VerticalAlignment="Top"   
                Width="329" Height="86" FontSize="35" Click="Button_Click"/>  
        <TextBox Name="UserInputTextBox"  FontSize="18" HorizontalAlignment="Left" Margin="106,146,0,0"   
                 TextWrapping="Wrap" Text="Write some text here, and select a file to write it to." VerticalAlignment="Top"   
                 Height="201" Width="558" AcceptsReturn="True"/>  
        <TextBlock Name="StatusTextBox" HorizontalAlignment="Left" Margin="106,570,0,147" TextWrapping="Wrap" Text="Status:"   
                   VerticalAlignment="Center" Height="51" Width="1074" FontSize="18" />  
    </Grid>  
</Page>  
```  
  
 [!code-csharp[OpenFileWindowsStore#Code](../../../samples/snippets/csharp/VS_Snippets_CLR/openfilewindowsstore/cs/mainpage.xaml.cs#code)]
 [!code-vb[OpenFileWindowsStore#Code](../../../samples/snippets/visualbasic/VS_Snippets_CLR/openfilewindowsstore/vb/mainpage.xaml.vb#code)]  
  
## See also

- <xref:System.IO.StreamWriter>  
- <xref:System.IO.Path>  
- <xref:System.IO.File.CreateText%2A?displayProperty=nameWithType>  
- [How to: Enumerate directories and files](../../../docs/standard/io/how-to-enumerate-directories-and-files.md)  
- [How to: Read and write to a newly-created data file](../../../docs/standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)  
- [How to: Open and append to a log file](../../../docs/standard/io/how-to-open-and-append-to-a-log-file.md)  
- [How to: Read text from a file](../../../docs/standard/io/how-to-read-text-from-a-file.md)  
- [File and stream I/O](../../../docs/standard/io/index.md)

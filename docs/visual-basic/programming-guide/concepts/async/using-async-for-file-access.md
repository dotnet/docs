---
description: "Learn more about: Using Async for File Access (Visual Basic)"
title: "Using Async for File Access"
ms.date: 04/23/2026
ms.assetid: c989305f-08e3-4687-95c3-948465cda202
ai-usage: ai-assisted
---
# Using Async for File Access (Visual Basic)

Use the Async feature to access files. By using the Async feature, you can call into asynchronous methods without using callbacks or splitting your code across multiple methods or lambda expressions. To make synchronous code asynchronous, call an asynchronous method instead of a synchronous method and add a few keywords to the code.

Consider adding asynchrony to file access calls for these reasons:

- Asynchrony makes UI applications more responsive because the UI thread that launches the operation can perform other work. If the UI thread must execute code that takes a long time (for example, more than 50 milliseconds), the UI might freeze until the I/O is complete and the UI thread can again process keyboard and mouse input and other events.

- Asynchrony improves the scalability of ASP.NET and other server-based applications by reducing the need for threads. If the application uses a dedicated thread per response and a thousand requests are being handled simultaneously, a thousand threads are needed. Asynchronous operations often don’t need to use a thread during the wait. They use the existing I/O completion thread briefly at the end.

- The latency of a file access operation might be very low under current conditions, but the latency might greatly increase in the future. For example, a file might be moved to a server that's across the world.

- The added overhead of using the Async feature is small.

- Multiple asynchronous I/O operations can run without blocking the calling thread.

## Run the examples

To run the examples in this topic, create a **WPF Application** or a **Windows Forms Application** and then add a **Button**. In the button's `Click` event, add a call to the first method in each example.

In the following examples, include the following `Imports` statements.

```vb
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
```

## Use of the FileStream class

The examples in this topic use the <xref:System.IO.FileStream> class, which has an option that causes asynchronous I/O to occur at the operating system level. By using this option, you can avoid blocking a ThreadPool thread in many cases. To enable this option, specify the `useAsync=true` or `options=FileOptions.Asynchronous` argument in the constructor call.

You can’t use this option with <xref:System.IO.StreamReader> and <xref:System.IO.StreamWriter> if you open them directly by specifying a file path. However, you can use this option if you provide them a <xref:System.IO.Stream> that the <xref:System.IO.FileStream> class opened. Asynchronous calls are faster in UI apps even if a ThreadPool thread is blocked, because the UI thread isn’t blocked during the wait.

## Write text

The following example writes text to a file. At each await statement, the method immediately exits. When the file I/O is complete, the method resumes at the statement that follows the await statement. The async modifier is in the definition of methods that use the await statement.

```vb
Public Async Sub ProcessWrite()
    Dim filePath = "temp2.txt"
    Dim text = "Hello World" & ControlChars.CrLf

    Await WriteTextAsync(filePath, text)
End Sub

Private Async Function WriteTextAsync(filePath As String, text As String) As Task
    Dim encodedText As Byte() = Encoding.Unicode.GetBytes(text)

    Using sourceStream As New FileStream(filePath,
        FileMode.Append, FileAccess.Write, FileShare.None,
        bufferSize:=4096, useAsync:=True)

        Await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
    End Using
End Function
```

The original example has the statement `Await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)`, which is a contraction of the following two statements:

```vb
Dim theTask As Task = sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
Await theTask
```

The first statement returns a task and causes file processing to start. The second statement with the await causes the method to immediately exit and return a different task. When the file processing later completes, execution returns to the statement that follows the await. For more information, see  [Control Flow in Async Programs (Visual Basic)](control-flow-in-async-programs.md).

## Read text

The following example reads text from a file. The text is buffered and, in this case, placed into a <xref:System.Text.StringBuilder>. Unlike in the previous example, the evaluation of the await produces a value. The <xref:System.IO.Stream.ReadAsync*> method returns a <xref:System.Threading.Tasks.Task>\<<xref:System.Int32>>, so the evaluation of the await produces an `Int32` value (`numRead`) after the operation completes. For more information, see [Async Return Types (Visual Basic)](async-return-types.md).

```vb
Public Async Sub ProcessRead()
    Dim filePath = "temp2.txt"

    If File.Exists(filePath) = False Then
        Debug.WriteLine("file not found: " & filePath)
    Else
        Try
            Dim text As String = Await ReadTextAsync(filePath)
            Debug.WriteLine(text)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End If
End Sub

Private Async Function ReadTextAsync(filePath As String) As Task(Of String)

    Using sourceStream As New FileStream(filePath,
        FileMode.Open, FileAccess.Read, FileShare.Read,
        bufferSize:=4096, useAsync:=True)

        Dim sb As New StringBuilder

        Dim buffer As Byte() = New Byte(&H1000) {}
        Dim numRead As Integer
        numRead = Await sourceStream.ReadAsync(buffer, 0, buffer.Length)
        While numRead <> 0
            Dim text As String = Encoding.Unicode.GetString(buffer, 0, numRead)
            sb.Append(text)

            numRead = Await sourceStream.ReadAsync(buffer, 0, buffer.Length)
        End While

        Return sb.ToString
    End Using
End Function
```

## Multiple asynchronous I/O operations

The following example starts multiple async write operations. The runtime queues these operations, and the underlying implementation might use operating system (OS) async I/O or thread pool threads depending on the platform and configuration, so actual concurrency depends on OS and hardware. For each file, the <xref:System.IO.Stream.WriteAsync*> method returns a task that is added to a list of tasks. The `Await Task.WhenAll(tasks)` statement exits the method and resumes within the method when file processing is complete for all of the tasks.

The example closes all <xref:System.IO.FileStream> instances in a `Finally` block after the tasks are complete. If each `FileStream` was instead created in a `Using` statement, the `FileStream` might be disposed of before the task was complete.

The async approach avoids blocking the calling thread while I/O is pending. In many cases, throughput improvements depend on the OS, the hardware, and, on some platforms, .NET runtime behavior such as thread pool limits and scheduling.

```vb
Public Async Sub ProcessWriteMult()
    Dim folder = "tempfolder\"
    Dim tasks As New List(Of Task)
    Dim sourceStreams As New List(Of FileStream)

    Try
        For index = 1 To 10
            Dim text = "In file " & index.ToString & ControlChars.CrLf

            Dim fileName = "thefile" & index.ToString("00") & ".txt"
            Dim filePath = folder & fileName

            Dim encodedText As Byte() = Encoding.Unicode.GetBytes(text)

            Dim sourceStream As New FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize:=4096, useAsync:=True)

            Dim theTask As Task = sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
            sourceStreams.Add(sourceStream)

            tasks.Add(theTask)
        Next

        Await Task.WhenAll(tasks)
    Finally
        For Each sourceStream As FileStream In sourceStreams
            sourceStream.Close()
        Next
    End Try
End Sub
```

When using the <xref:System.IO.Stream.WriteAsync*> and <xref:System.IO.Stream.ReadAsync*> methods, you can specify a <xref:System.Threading.CancellationToken> to cancel the operation mid-stream. For more information, see [Fine-Tuning Your Async Application (Visual Basic)](fine-tuning-your-async-application.md) and [Cancellation in Managed Threads](../../../../standard/threading/cancellation-in-managed-threads.md).

## See also

- [Asynchronous Programming with Async and Await (Visual Basic)](index.md)
- [Async Return Types (Visual Basic)](async-return-types.md)
- [Control Flow in Async Programs (Visual Basic)](control-flow-in-async-programs.md)

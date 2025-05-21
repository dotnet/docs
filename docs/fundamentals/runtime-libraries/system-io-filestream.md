---
title: System.IO.FileStream class
description: Learn about the System.IO.FileStream class.
ms.date: 12/31/2023
ms.topic: article
---
# System.IO.FileStream class

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.IO.FileStream> class to read from, write to, open, and close files on a file system, and to manipulate other file-related operating system handles, including pipes, standard input, and standard output. You can use the <xref:System.IO.FileStream.Read%2A>, <xref:System.IO.FileStream.Write%2A>, <xref:System.IO.Stream.CopyTo%2A>, and <xref:System.IO.FileStream.Flush%2A> methods to perform synchronous operations, or the <xref:System.IO.FileStream.ReadAsync%2A>, <xref:System.IO.FileStream.WriteAsync%2A>, <xref:System.IO.Stream.CopyToAsync%2A>, and <xref:System.IO.FileStream.FlushAsync%2A> methods to perform asynchronous operations. Use the asynchronous methods to perform resource-intensive file operations without blocking the main thread. This performance consideration is particularly important in a Windows 8.x Store app or desktop app where a time-consuming stream operation can block the UI thread and make your app appear as if it is not working. <xref:System.IO.FileStream> buffers input and output for better performance.

> [!IMPORTANT]
> This type implements the <xref:System.IDisposable> interface. When you have finished using the type, you should dispose of it either directly or indirectly. To dispose of the type directly, call its <xref:System.IDisposable.Dispose%2A> method in a `try`/`catch` block. To dispose of it indirectly, use a language construct such as `using` (in C#) or `Using` (in Visual Basic). For more information, see the "Using an Object that Implements IDisposable" section in the <xref:System.IDisposable> interface topic.

The <xref:System.IO.FileStream.IsAsync> property detects whether the file handle was opened asynchronously. You specify this value when you create an instance of the <xref:System.IO.FileStream> class using a constructor that has an `isAsync`, `useAsync`, or `options` parameter. When the property is `true`, the stream utilizes overlapped I/O to perform file operations asynchronously. However, the <xref:System.IO.FileStream.IsAsync> property does not have to be `true` to call the <xref:System.IO.FileStream.ReadAsync%2A>, <xref:System.IO.FileStream.WriteAsync%2A>, or <xref:System.IO.Stream.CopyToAsync%2A> method. When the <xref:System.IO.FileStream.IsAsync> property is `false` and you call the asynchronous read and write operations, the UI thread is still not blocked, but the actual I/O operation is performed synchronously.

The <xref:System.IO.FileStream.Seek%2A> method supports random access to files. <xref:System.IO.FileStream.Seek%2A> allows the read/write position to be moved to any position within the file. This is done with byte offset reference point parameters. The byte offset is relative to the seek reference point, which can be the beginning, the current position, or the end of the underlying file, as represented by the three members of the <xref:System.IO.SeekOrigin> enumeration.

> [!NOTE]
> Disk files always support random access. At the time of construction, the <xref:System.IO.FileStream.CanSeek> property value is set to `true` or `false` depending on the underlying file type. If the underlying file type is FILE_TYPE_DISK, as defined in winbase.h, the <xref:System.IO.FileStream.CanSeek> property value is `true`. Otherwise, the <xref:System.IO.FileStream.CanSeek> property value is `false`.

If a process terminates with part of a file locked or closes a file that has outstanding locks, the behavior is undefined.

For directory operations and other file operations, see the <xref:System.IO.File>, <xref:System.IO.Directory>, and <xref:System.IO.Path> classes. The <xref:System.IO.File> class is a utility class that has static methods primarily for the creation of <xref:System.IO.FileStream> objects based on file paths. The <xref:System.IO.MemoryStream> class creates a stream from a byte array and is similar to the <xref:System.IO.FileStream> class.

For a list of common file and directory operations, see [Common I/O Tasks](../../standard/io/common-i-o-tasks.md).

## Detection of stream position changes

When a <xref:System.IO.FileStream> object does not have an exclusive hold on its handle, another thread could access the file handle concurrently and change the position of the operating system's file pointer that is associated with the file handle. In this case, the cached position in the <xref:System.IO.FileStream> object and the cached data in the buffer could be compromised. The <xref:System.IO.FileStream> object routinely performs checks on methods that access the cached buffer to ensure that the operating system's handle position is the same as the cached position used by the <xref:System.IO.FileStream> object.

If an unexpected change in the handle position is detected in a call to the <xref:System.IO.FileStream.Read%2A> method, .NET discards the contents of the buffer and reads the stream from the file again. This can affect performance, depending on the size of the file and any other processes that could affect the position of the file stream.

If an unexpected change in the handle position is detected in a call to the <xref:System.IO.FileStream.Write%2A> method, the contents of the buffer are discarded and an <xref:System.IO.IOException> exception is thrown.

A <xref:System.IO.FileStream> object will not have an exclusive hold on its handle when either the <xref:System.IO.FileStream.SafeFileHandle> property is accessed to expose the handle or the <xref:System.IO.FileStream> object is given the <xref:System.IO.FileStream.SafeFileHandle> property in its constructor.

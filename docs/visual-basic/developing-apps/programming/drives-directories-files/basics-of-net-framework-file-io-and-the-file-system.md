---
title: "Basics of .NET Framework File I/O and the File System (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "file access, file I/O in Visual Basic"
  - "file attributes, determining"
  - "streams, fundamental operations"
  - "file permissions"
  - "streams"
  - "streams, definition"
ms.assetid: 49d837c0-cf28-416f-8606-4d83d7b479ef
caps.latest.revision: 30
author: dotnet-bot
ms.author: dotnetcontent
---
# Basics of .NET Framework File I/O and the File System (Visual Basic)
Classes in the <xref:System.IO> namespace are used to work with drives, files, and directories.  
  
 The <xref:System.IO> namespace contains the <xref:System.IO.File> and <xref:System.IO.Directory> classes, which provide the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] functionality that manipulates files and directories. Because the methods of these objects are static or shared members, you can use them directly without creating an instance of the class first. Associated with these classes are the <xref:System.IO.FileInfo> and <xref:System.IO.DirectoryInfo> classes, which will be familiar to users of the `My` feature. To use these classes, you must fully qualify the names or import the appropriate namespaces by including the `Imports` statement(s) at the beginning of the affected code. For more information, see [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md).  
  
> [!NOTE]
>  Other topics in this section use the `My.Computer.FileSystem` object instead of `System.IO` classes to work with drives, files, and directories. The `My.Computer.FileSystem` object is intended primarily for use in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] programs. `System.IO` classes are intended for use by any language that supports the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)], including [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
## Definition of a Stream  
 The [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] uses streams to support reading from and writing to files. You can think of a stream as a one-dimensional set of contiguous data, which has a beginning and an end, and where the cursor indicates the current position in the stream.  
  
 ![Cursor shows current position in the filestream.](../../../../visual-basic/developing-apps/programming/drives-directories-files/media/filestream.gif "FileStream")  
  
## Stream Operations  
 The data contained in the stream may come from memory, a file, or a TCP/IP socket. Streams have fundamental operations that can be applied to them:  
  
-   Reading. You can read from a stream, transferring data from the stream into a data structure, such as a string or an array of bytes.  
  
-   **Writing**. You can write to a stream, transferring data from a data source into the stream.  
  
-   **Seeking**. You can query and modify your position in the stream.  
  
 For more information, see [Composing Streams](../../../../standard/io/composing-streams.md).  
  
## Types of Streams  
 In the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)], a stream is represented by the <xref:System.IO.Stream> class, which forms the abstract class for all other streams. You cannot directly create an instance of the <xref:System.IO.Stream> class, but must use one of the classes it implements.  
  
 There are many types of streams, but for the purposes of working with file input/output (I/O), the most important types are the <xref:System.IO.FileStream> class, which provides a way to read from and write to files, and the <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream> class, which provides a way to create files and directories in isolated storage. Other streams that can be used when working with file I/O include:  
  
-   <xref:System.IO.BufferedStream>  
  
-   <xref:System.Security.Cryptography.CryptoStream>  
  
-   <xref:System.IO.MemoryStream>  
  
-   <xref:System.Net.Sockets.NetworkStream>.  
  
 The following table lists tasks commonly accomplished with a stream:  
  
|To|See|
|---|---|   
|Read and write to a data file|[How to: Read and Write to a Newly Created Data File](../../../../standard/io/how-to-read-and-write-to-a-newly-created-data-file.md)|  
|Read text from a file|[How to: Read Text from a File](../../../../standard/io/how-to-read-text-from-a-file.md)|  
|Write text to a file|[How to: Write Text to a File](../../../../standard/io/how-to-write-text-to-a-file.md)|  
|Read characters from a string|[How to: Read Characters from a String](../../../../standard/io/how-to-read-characters-from-a-string.md)|  
|Write characters to a string|[How to: Write Characters to a String](../../../../standard/io/how-to-write-characters-to-a-string.md)|  
|Encrypt data|[Encrypting Data](../../../../standard/security/encrypting-data.md)|  
|Decrypt data|[Decrypting Data](../../../../standard/security/decrypting-data.md)|  
  
## File Access and Attributes  
 You can control how files are created, opened, and shared with the <xref:System.IO.FileAccess>, <xref:System.IO.FileMode>, and <xref:System.IO.FileShare> enumerations, which contain the flags used by the constructors of the <xref:System.IO.FileStream> class. For example, when you open or create a new <xref:System.IO.FileStream>, the <xref:System.IO.FileMode> enumeration allows you to specify whether the file is opened for appending, whether a new file is created if the specified file does not exist, whether the file is overwritten, and so forth.  
  
 The <xref:System.IO.FileAttributes> enumeration enables the gathering of file-specific information. The <xref:System.IO.FileAttributes> enumeration returns the file's stored attributes, such as whether it is compressed, encrypted, hidden, read-only, an archive, a directory, a system file, or a temporary file.  
  
 The following table lists tasks involving file access and file attributes:  
  
|To|See|  
|---|---|
|Open and append text to a log file|[How to: Open and Append to a Log File](../../../../standard/io/how-to-open-and-append-to-a-log-file.md)|  
|Determine the attributes of a file|<xref:System.IO.FileAttributes>|  
  
## File Permissions  
 Controlling access to files and directories can be done with the <xref:System.Security.Permissions.FileIOPermission> class. This may be particularly important for developers working with Web Forms, which by default run within the context of a special local user account named ASPNET, which is created as part of the [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] and [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] installations. When such an application requests access to a resource, the ASPNET user account has limited permissions, which may prevent the user from performing actions such as writing to a file from a Web application. For more information, see <xref:System.Security.Permissions.FileIOPermission>.  
  
## Isolated File Storage  
 Isolated storage is an attempt to solve problems created when working with files where the user or code may lack necessary permissions. Isolated storage assigns each user a data compartment, which can hold one or more stores. Stores can be isolated from each other by user and by assembly. Only the user and assembly that created a store have access to it. A store acts as a complete virtual file system—within one store you can create and manipulate directories and files.  
  
 The following table lists tasks commonly associated with isolated file storage.  
  
|To|See|
|---|---|  
|Create an isolated store|[How to: Obtain Stores for Isolated Storage](../../../../standard/io/how-to-obtain-stores-for-isolated-storage.md)|  
|Enumerate isolated stores|[How to: Enumerate Stores for Isolated Storage](../../../../standard/io/how-to-enumerate-stores-for-isolated-storage.md)|  
|Delete an isolated store|[How to: Delete Stores in Isolated Storage](../../../../standard/io/how-to-delete-stores-in-isolated-storage.md)|  
|Create a file or directory in isolated storage|[How to: Create Files and Directories in Isolated Storage](../../../../standard/io/how-to-create-files-and-directories-in-isolated-storage.md)|  
|Find a file in isolated storage|[How to: Find Existing Files and Directories in Isolated Storage](../../../../standard/io/how-to-find-existing-files-and-directories-in-isolated-storage.md)|  
|Read from or write to a file in insolated storage|[How to: Read and Write to Files in Isolated Storage](../../../../standard/io/how-to-read-and-write-to-files-in-isolated-storage.md)|  
|Delete a file or directory in isolated storage|[How to: Delete Files and Directories in Isolated Storage](../../../../standard/io/how-to-delete-files-and-directories-in-isolated-storage.md)|  
  
## File Events  
 The <xref:System.IO.FileSystemWatcher> component allows you to watch for changes in files and directories on your system or on any computer to which you have network access. For example, if a file is modified, you might want to send a user an alert that the change has taken place. When changes occur, one or more events are raised, stored in a buffer, and handed to the <xref:System.IO.FileSystemWatcher> component for processing.  
  
## See Also  
 [Composing Streams](../../../../standard/io/composing-streams.md)  
 [File and Stream I/O](../../../../standard/io/index.md)  
 [Asynchronous File I/O](../../../../standard/io/asynchronous-file-i-o.md)  
 [Classes Used in .NET Framework File I/O and the File System (Visual Basic)](../../../../visual-basic/developing-apps/programming/drives-directories-files/classes-used-in-net-framework-file-io-and-the-file-system.md)

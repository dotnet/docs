---
title: Using objects that implement IDisposable
description: Using objects that implement IDisposable
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/19/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: df780a6e-734e-44b8-9747-9f7783f79e20
---

# Using objects that implement IDisposable

The common language runtime's garbage collector reclaims the memory used by unmanaged objects, but types that use unmanaged resources implement the [IDisposable](xref:System.IDisposable) interface to allow this unmanaged memory to be reclaimed. When you finish using an object that implements [IDisposable](xref:System.IDisposable), you should call the object's [IDisposable.Dispose](xref:System.IDisposable.Dispose) implementation. You can do this in one of two ways:

* With the C# `using` statement or the Visual Basic `Using` statement.

* By implementing a `try/finally` block. 

## The using statement

The `using` statement in C# and the `Using` statement in Visual Basic simplify the code that you must write to create and clean up an object. The `using` statement obtains one or more resources, executes the statements that you specify, and automatically disposes of the object. However, the `using` statement is useful only for objects that are used within the scope of the method in which they are constructed. 

The following example uses the `using` statement to create and release a [System.IO.StreamReader](xref:System.IO.StreamReader) object.

```cs
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Char[] buffer = new Char[50];
      using (StreamReader s = new StreamReader("File1.txt")) {
         int charsRead = 0;
         while (s.Peek() != -1) {
            charsRead = s.Read(buffer, 0, buffer.Length);
            //
            // Process characters read.
            //   
         }
         s.Close();    
      }

   }
}
```

```vb
Imports System.IO

Module Example
   Public Sub Main()
      Dim buffer(49) As Char
      Using s As New StreamReader("File1.txt")
         Dim charsRead As Integer
         Do While s.Peek() <> -1
            charsRead = s.Read(buffer, 0, buffer.Length)         
            ' 
            ' Process characters read.
            '
         Loop
         s.Close()
      End Using
   End Sub
End Module
```

Note that although the [StreamReader](xref:System.IO.StreamReader) class implements the [IDisposable](xref:System.IDisposable) interface, which indicates that it uses an unmanaged resource, the example doesn't explicitly call the [StreamReader.Dispose](xref:System.IO.StreamReader.Dispose(System.Boolean)) method. When the C# or Visual Basic compiler encounters the `using` statement, it emits intermediate language (IL) that is equivalent to the following code that explicitly contains a `try/finally` block. 

```cs
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Char[] buffer = new Char[50];
      {
         StreamReader s = new StreamReader("File1.txt"); 
         try {
            int charsRead = 0;
            while (s.Peek() != -1) {
               charsRead = s.Read(buffer, 0, buffer.Length);
               //
               // Process characters read.
               //   
            }
            s.Close();
         }
         finally {
            if (s != null)
               ((IDisposable)s).Dispose();     
         }       
      }
   }
}
```

```vb
Imports System.IO

Module Example
   Public Sub Main()
      Dim buffer(49) As Char
''      Dim s As New StreamReader("File1.txt")
With s As New StreamReader("File1.txt")
      Try
         Dim charsRead As Integer
         Do While s.Peek() <> -1
            charsRead = s.Read(buffer, 0, buffer.Length)         
            ' 
            ' Process characters read.
            '
         Loop
         s.Close()
      Finally
         If s IsNot Nothing Then DirectCast(s, IDisposable).Dispose()
      End Try
End With
   End Sub
End Module
```

The C# `using` statement also allows you to acquire multiple resources in a single statement, which is internally equivalent to nested using statements. The following example instantiates two [StreamReader](xref:System.IO.StreamReader) objects to read the contents of two different files. 

```cs
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      Char[] buffer1 = new Char[50], buffer2 = new Char[50];

      using (StreamReader version1 = new StreamReader("file1.txt"),
                          version2 = new StreamReader("file2.txt")) {
         int charsRead1, charsRead2 = 0;
         while (version1.Peek() != -1 && version2.Peek() != -1) {
            charsRead1 = version1.Read(buffer1, 0, buffer1.Length);
            charsRead2 = version2.Read(buffer2, 0, buffer2.Length);
            //
            // Process characters read.
            //
         }
         version1.Close();
         version2.Close();
      }
   }
}
```

## Try/finally block

Instead of wrapping a `try/finally` block in a `using` statement, you may choose to implement the `try/finally` block directly. This may be your personal coding style, or you might want to do this for one of the following reasons: 

* To include a `catch` block to handle any exceptions thrown in the `try` block. Otherwise, any exceptions thrown by the `using` statement are unhandled, as are any exceptions thrown within the `using` block if a `try/catch` block isn't present. 

* To instantiate an object that implements [IDisposable](xref:System.IDisposable) whose scope is not local to the block within which it is declared. 

The following example is similar to the previous example, except that it uses a `try/catch/finally` block to instantiate, use, and dispose of a [StreamReader](xref:System.IO.StreamReader) object, and to handle any exceptions thrown by the [StreamReader](xref:System.IO.StreamReader) constructor and its [ReadToEnd](xref:System.IO.StreamReader.ReadToEnd) method. Note that the code in the `finally` block checks that the object that implements [IDisposable](xref:System.IDisposable) isn't `null` before it calls the [Dispose](xref:System.IDisposable.Dispose) method. Failure to do this can result in a [NullReferenceException](xref:System.NullReferenceException) exception at run time. 

```cs
using System;
using System.Globalization;
using System.IO;

public class Example
{
   public static void Main()
   {
      StreamReader sr = null;
      try {
         sr = new StreamReader("file1.txt");
         String contents = sr.ReadToEnd();
         sr.Close();
         Console.WriteLine("The file has {0} text elements.", 
                           new StringInfo(contents).LengthInTextElements);    
      }      
      catch (FileNotFoundException) {
         Console.WriteLine("The file cannot be found.");
      }   
      catch (IOException) {
         Console.WriteLine("An I/O error has occurred.");
      }
      catch (OutOfMemoryException) {
         Console.WriteLine("There is insufficient memory to read the file.");   
      }
      finally {
         if (sr != null) sr.Dispose();     
      }
   }
}
```

```vb
Imports System.Globalization
Imports System.IO

Module Example
   Public Sub Main()
      Dim sr As StreamReader = Nothing
      Try 
         sr = New StreamReader("file1.txt")
         Dim contents As String = sr.ReadToEnd()
         sr.Close()
         Console.WriteLine("The file has {0} text elements.", 
                           New StringInfo(contents).LengthInTextElements)    
      Catch e As FileNotFoundException
         Console.WriteLine("The file cannot be found.")
      Catch e As IOException
         Console.WriteLine("An I/O error has occurred.")
      Catch e As OutOfMemoryException
         Console.WriteLine("There is insufficient memory to read the file.")   
      Finally 
         If sr IsNot Nothing Then sr.Dispose()     
      End Try
   End Sub
End Module
```

You can follow this basic pattern if you choose to implement or must implement a `try/finally` block, because your programming language doesn't support a `using` statement but does allow direct calls to the [Dispose](xref:System.IDisposable.Dispose) method. 

## See Also

[Cleaning up unmanaged resources](unmanaged.md)



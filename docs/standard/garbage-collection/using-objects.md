---
title: "Using Objects That Implement IDisposable | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Dispose method"
  - "try/finally block"
  - "garbage collection, encapsulating resources"
ms.assetid: 81b2cdb5-c91a-4a31-9c83-eadc52da5cf0
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
<<<<<<< HEAD
# Using Objects That Implement IDisposable
The common language runtime's garbage collector reclaims the memory used by unmanaged objects, but types that use unmanaged resources implement the <xref:System.IDisposable> interface to allow this unmanaged memory to be reclaimed. When you finish using an object that implements <xref:System.IDisposable>, you should call the object's <xref:System.IDisposable.Dispose%2A?displayProperty=fullName> implementation. You can do this in one of two ways:  
  
-   With the C# **using** statement or the Visual Basic `Using` statement.  
  
-   By implementing a `try`/`finally` block.  
  
## The using statement  
 The **using** statement in C# and the `Using` statement in Visual Basic simplify the code that you must write to create and clean up an object. The **using** statement obtains one or more resources, executes the statements that you specify, and automatically disposes of the object. However, the **using** statement is useful only for objects that are used within the scope of the method in which they are constructed.  
  
 The following example uses the `using` statement to create and release a <xref:System.IO.StreamReader?displayProperty=fullName> object.  
  
 [!code-csharp[Conceptual.Disposable#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using1.cs#1)]
 [!code-vb[Conceptual.Disposable#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/using1.vb#1)]  
  
 Note that although the <xref:System.IO.StreamReader> class implements the <xref:System.IDisposable> interface, which indicates that it uses an unmanaged resource, the example doesn't explicitly call the <xref:System.IO.StreamReader.Dispose%2A?displayProperty=fullName> method. When the C# or Visual Basic compiler encounters the `using` statement, it emits intermediate language (IL) that is equivalent to the following code that explicitly contains a `try`/`finally` block.  
  
 [!code-csharp[Conceptual.Disposable#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using3.cs#3)]
 [!code-vb[Conceptual.Disposable#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/using3.vb#3)]  
  
 The C# **using** statement also allows you to acquire multiple resources in a single statement, which is internally equivalent to nested **using** statements. The following example instantiates two <xref:System.IO.StreamReader> objects to read the contents of two different files.  
  
 [!code-csharp[Conceptual.Disposable#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using4.cs#4)]  
  
## Try/finally block  
 Instead of wrapping a `try`/`finally` block in a `using` statement, you may choose to implement the `try`/`finally` block directly. This may be your personal coding style, or you might want to do this for one of the following reasons:  
  
-   To include a `catch` block to handle any exceptions thrown in the `try` block. Otherwise, any exceptions thrown by the `using` statement are unhandled, as are any exceptions thrown within the `using` block if a `try`/`catch` block isn't present.  
  
-   To instantiate an object that implements <xref:System.IDisposable> whose scope is not local to the block within which it is declared.  
  
 The following example is similar to the previous example, except that it uses a `try`/`catch`/`finally` block to instantiate, use, and dispose of a <xref:System.IO.StreamReader> object, and to handle any exceptions thrown by the <xref:System.IO.StreamReader> constructor and its <xref:System.IO.StreamReader.ReadToEnd%2A> method. Note that the code in the `finally` block checks that the object that implements <xref:System.IDisposable> isn't `null` before it calls the <xref:System.IDisposable.Dispose%2A> method. Failure to do this can result in a <xref:System.NullReferenceException> exception at run time.  
  
 [!code-csharp[Conceptual.Disposable#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using5.cs#6)]
 [!code-vb[Conceptual.Disposable#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/using5.vb#6)]  
  
 You can follow this basic pattern if you choose to implement or must implement a `try`/`finally` block, because your programming language doesn't support a `using` statement but does allow direct calls to the <xref:System.IDisposable.Dispose%2A> method.  
  
 If your language doesn't support direct calls to the <xref:System.IDisposable.Dispose%2A> method (for example, in C++), you can generally use your language's destructor syntax.  
  
## See Also  
 [Cleaning Up Unmanaged Resources](../../../docs/standard/garbage-collection/unmanaged.md)   
 [using Statement](~/docs/csharp/language-reference/keywords/using-statement.md)   
 [Using Statement](~/docs/visual-basic/language-reference/statements/using-statement.md)
=======

# Using objects that implement IDisposable

The common language runtime's garbage collector reclaims the memory used by unmanaged objects, but types that use unmanaged resources implement the [IDisposable](xref:System.IDisposable) interface to allow this unmanaged memory to be reclaimed. When you finish using an object that implements [IDisposable](xref:System.IDisposable), you should call the object's [IDisposable.Dispose](xref:System.IDisposable.Dispose) implementation. You can do this in one of two ways:

* With the C# `using` statement or the Visual Basic `Using` statement.

* By implementing a `try/finally` block. 

## The using statement

The `using` statement in C# and the `Using` statement in Visual Basic simplify the code that you must write to create and clean up an object. The `using` statement obtains one or more resources, executes the statements that you specify, and automatically disposes of the object. However, the `using` statement is useful only for objects that are used within the scope of the method in which they are constructed. 

The following example uses the `using` statement to create and release a [System.IO.StreamReader](xref:System.IO.StreamReader) object.

```csharp
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

```csharp
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

```csharp
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

```csharp
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


>>>>>>> master

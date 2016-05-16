# Using Objects That Implement IDisposable

The common language runtime's garbage collector reclaims the memory used by unmanaged objects, but types that use unmanaged resources implement the [IDisposable](http://dotnet.github.io/api/System.IDisposable.html) interface to allow the memory to be reclaimed. When you finish using an object that implements `IDisposable`, you should call the object's [IDisposable.Dispose](http://dotnet.github.io/api/System.IDisposable.html#System_IDisposable_Dispose) implementation. You can do this in one of two ways:

* With the C# `using` statement.

* By implementing a `try/finally` block. 

> **Note**
>
> If the disposable object is owned by another object, you'll need to implement a `Dispose` method for that object. See [Implementing a Dispose Method](essentials/gc/unmanaged/implementingdispose.md)

## The using statement

The `using` statement simplifies the code that you must write to create and clean up an object. The `using` statement obtains one or more resources, executes the statements that you specify, and automatically disposes of the object. However, the `using` statement is useful only for objects that are used within the scope of the method in which they are constructed. 

The following example uses the `using` statement to create and release a [System.IO.StreamReader](http://dotnet.github.io/api/System.IO.StreamReader.html) object.

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
      }

   }
}
```

Note that although the `StreamReader` class implements the `IDisposable` interface, which indicates that it uses an unmanaged resource, the example doesn't explicitly call the `StreamReader.Dispose` method. When the compiler encounters the `using` statement, it emits intermediate language (IL) that is equivalent to the following code that explicitly contains a `try/finally` block. 

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

The `using` statement also allows you to acquire multiple resources in a single statement, which is internally equivalent to nested `using` statements. The following example instantiates two `StreamReader` objects to read the contents of two different files. 

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

Instead of enclosing a `try/finally` block in a `using` statement, you may choose to implement the `try/finally` block directly. This may be your personal coding style, or you might want to do this for one of the following reasons: 

* To include a `catch` block to handle any exceptions thrown in the `try` block. Otherwise, any exceptions thrown by the `using` statement are unhandled, as are any exceptions thrown within the `using` block if a `try/catch` block isn't present. 

* To instantiate an object that implements `IDisposable` whose scope is not local to the block within which it is declared.

The following example is similar to the previous example, except that it uses a `try/catch/finally` block to instantiate, use, and dispose of a `StreamReader` object, and to handle any exceptions thrown by the `StreamReader` constructor and its `ReadToEnd` method. Note that the code in the finally block checks that the object that implements `IDisposable` isn't `null` before it calls the `Dispose` method. Failure to do this can result in a [NullReferenceException](http://dotnet.github.io/api/System.NullReferenceException.html) exception at run time. 

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

You can follow this basic pattern if you choose to implement or must implement a `try/finally` block because your programming language doesn't support a `using` statement but does allow direct calls to the `Dispose` method. 

## See Also

[Cleaning Up Unmanaged Resources](essentials/gc/unmanagedresources.md)





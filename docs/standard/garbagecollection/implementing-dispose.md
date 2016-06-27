---
title: Implementing a Dispose Method
description: Implementing a Dispose Method
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 194213c3-d188-4b5d-961f-2f104202a215
---

# Implementing a Dispose Method

You implement a [Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) method to release unmanaged resources used by your application. The .NET garbage collector does not allocate or release unmanaged memory. 

The pattern for disposing an object, referred to as a dispose pattern, imposes order on the lifetime of an object. The dispose pattern is used only for objects that access unmanaged resources, such as file and pipe handles, registry handles, wait handles, or pointers to blocks of unmanaged memory. This is because the garbage collector is very efficient at reclaiming unused managed objects, but it is unable to reclaim unmanaged objects.

The dispose pattern has two variations:

* You wrap each unmanaged resource that a type uses in a safe handle (that is, in a class derived from [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle)). In this case, you implement the [IDisposable](https://docs.microsoft.com/dotnet/core/api/System.IDisposable) interface and an additional `Dispose(Boolean)` method. This is the recommended variation and doesn't require overriding the [Object.Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize) method. 

> **Note**
>
> The [Microsoft.Win32.SafeHandles](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles) namespace provides a set of classes derived from [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle), which are listed in the [Using safe handles](#Using-safe-handles) section. If you can't find a class that is suitable for releasing your unmanaged resource, you can implement your own subclass of [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle). 
 
* You implement the [IDisposable](https://docs.microsoft.com/dotnet/core/api/System.IDisposable) interface and an additional `Dispose(Boolean`) method, and you also override the [Object.Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize) method. You must override [Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize) to ensure that unmanaged resources are disposed of if your [IDisposable.Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) implementation is not called by a consumer of your type. If you use the recommended technique discussed in the previous bullet, the [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) class does this on your behalf. 

To help ensure that resources are always cleaned up appropriately, a [Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) method should be callable multiple times without throwing an exception. 

The code example provided for the [GC.KeepAlive](https://docs.microsoft.com/dotnet/core/api/System.GC#System_GC_KeepAlive_System_Object_) method shows how aggressive garbage collection can cause a finalizer to run while a member of the reclaimed object is still executing. It is a good idea to call the [KeepAlive](https://docs.microsoft.com/dotnet/core/api/System.GC#System_GC_KeepAlive_System_Object_) method at the end of a lengthy Dispose method.

## Dispose() and Dispose(Boolean)

The [IDisposable](https://docs.microsoft.com/dotnet/core/api/System.IDisposable) interface requires the implementation of a single parameterless method, [Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose). However, the dispose pattern requires two `Dispose methods` to be implemented: 

* A public non-virtual [IDisposable.Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) implementation that has no parameters.

* A protected virtual `Dispose` method whose signature is:

  ```cs
  protected virtual void Dispose(bool disposing)
  ```

### The Dispose() overload

Because the public, non-virtual, parameterless `Dispose` method is called by a consumer of the type, its purpose is to free unmanaged resources and to indicate that the finalizer, if one is present, doesn't have to run. Because of this, it has a standard implementation:

```cs
public void Dispose()
{
   // Dispose of unmanaged resources.
   Dispose(true);
   // Suppress finalization.
   GC.SuppressFinalize(this);
}
```

The `Dispose` method performs all object cleanup, so the garbage collector no longer needs to call the objects' [Object.Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize) override. Therefore, the call to the [GC.SuppressFinalize](https://docs.microsoft.com/dotnet/core/api/System.GC.System_GC_SuppressFinalize_System_Object_) method prevents the garbage collector from running the finalizer. If the type has no finalizer, the call to [SuppressFinalize](https://docs.microsoft.com/dotnet/core/api/System.GC.System_GC_SuppressFinalize_System_Object_) has no effect. Note that the actual work of releasing unmanaged resources is performed by the second overload of the `Dispose` method.

### The Dispose(Boolean) overload

In the second overload, the *disposing* parameter is a [Boolean](https://docs.microsoft.com/dotnet/core/api/System.Boolean) that indicates whether the method call comes from a [Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) method (its value is `true`) or from a finalizer (its value is `false`). 

The body of the method consists of two blocks of code: 

* A block that frees unmanaged resources. This block executes regardless of the value of the *disposing* parameter. 

* A conditional block that frees managed resources. This block executes if the value of *disposing* is `true`. The managed resources that it frees can include: 

    **Managed objects that implement IDisposable**. The conditional block can be used to call their [Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) implementation. If you have used a safe handle to wrap your unmanaged resource, you should call the [SafeHandle.Dispose(Boolean](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle.html#System_Runtime_InteropServices_SafeHandle_Dispose_System_Boolean_) implementation here. 

    **Managed objects that consume large amounts of memory or consume scarce resources.** Freeing these objects explicitly in the `Dispose` method releases them faster than if they were reclaimed non-deterministically by the garbage collector. 


If the method call comes from a finalizer (that is, if *disposing* is `false`), only the code that frees unmanaged resources executes. Because the order in which the garbage collector destroys managed objects during finalization is not defined, calling this `Dispose` overload with a value of `false` prevents the finalizer from trying to release managed resources that may have already been reclaimed. 

## Implementing the dispose pattern for a base class

If you implement the dispose pattern for a base class, you must provide the following: 

> **Important**
>
> You should implement this pattern for all base classes that implement [IDisposable](https://docs.microsoft.com/dotnet/core/api/System.IDisposable) and are not `sealed`. 
 
* A [Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) implementation that calls the `Dispose(Boolean)` method. 

* A `Dispose(Boolean)` method that performs the actual work of releasing resources. 

* Either a class derived from [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) that wraps your unmanaged resource (recommended), or an override to the [Object.Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize) method. The [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle)SafeHandle class provides a finalizer that frees you from having to code one. 

Here's the general pattern for implementing the dispose pattern for a base class that uses a safe handle. 

```cs
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class BaseClass : IDisposable
{
   // Flag: Has Dispose already been called?
   bool disposed = false;
   // Instantiate a SafeHandle instance.
   SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

   // Public implementation of Dispose pattern callable by consumers.
   public void Dispose()
   { 
      Dispose(true);
      GC.SuppressFinalize(this);           
   }

   // Protected implementation of Dispose pattern.
   protected virtual void Dispose(bool disposing)
   {
      if (disposed)
         return; 

      if (disposing) {
         handle.Dispose();
         // Free any other managed objects here.
         //
      }

      // Free any unmanaged objects here.
      //
      disposed = true;
   }
}
```

> **Note** 
>
> The previous example uses a [SafeFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeFileHandle) object to illustrate the pattern; any object derived from [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) could be used instead. Note that the example does not properly instantiate its [SafeFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeFileHandle) object. 
 
Here's the general pattern for implementing the dispose pattern for a base class that overrides [Object.Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize). 

```cs
using System;

class BaseClass : IDisposable
{
   // Flag: Has Dispose already been called?
   bool disposed = false;

   // Public implementation of Dispose pattern callable by consumers.
   public void Dispose()
   { 
      Dispose(true);
      GC.SuppressFinalize(this);           
   }

   // Protected implementation of Dispose pattern.
   protected virtual void Dispose(bool disposing)
   {
      if (disposed)
         return; 

      if (disposing) {
         // Free any other managed objects here.
         //
      }

      // Free any unmanaged objects here.
      //
      disposed = true;
   }

   ~BaseClass()
   {
      Dispose(false);
   }
}
```

## Implementing the dispose pattern for a derived class

A class derived from a class that implements the [IDisposable](https://docs.microsoft.com/dotnet/core/api/System.IDisposable) interface shouldn't implement [IDisposable](https://docs.microsoft.com/dotnet/core/api/System.IDisposable), because the base class implementation of [IDisposable.Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose) is inherited by its derived classes. Instead, to implement the dispose pattern for a derived class, you provide the following: 

* A `protected Dispose(Boolean)` method that overrides the base class method and performs the actual work of releasing the resources of the derived class. This method should also call the `Dispose(Boolean)` method of the base class and pass it a value of `true` for the *disposing* argument. 

* Either a class derived from [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) that wraps your unmanaged resource (recommended), or an override to the [Object.Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize) method. The [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) class provides a finalizer that frees you from having to code one. If you do provide a finalizer, it should call the `Dispose(Boolean)` overload with a *disposing* argument of `false`. 

Here's the general pattern for implementing the dispose pattern for a derived class that uses a safe handle: 

```cs
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class DerivedClass : BaseClass
{
   // Flag: Has Dispose already been called?
   bool disposed = false;
   // Instantiate a SafeHandle instance.
   SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

   // Protected implementation of Dispose pattern.
   protected override void Dispose(bool disposing)
   {
      if (disposed)
         return; 

      if (disposing) {
         handle.Dispose();
         // Free any other managed objects here.
         //
      }

      // Free any unmanaged objects here.
      //

      disposed = true;
      // Call base class implementation.
      base.Dispose(disposing);
   }
}
```

> **Note** 
>
> The previous example uses a [SafeFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeFileHandle) object to illustrate the pattern; any object derived from [SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) could be used instead. Note that the example does not properly instantiate its [SafeFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeFileHandle) object. 

Here's the general pattern for implementing the dispose pattern for a derived class that overrides [Object.Finalize](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_Finalize):

```cs
using System;

class DerivedClass : BaseClass
{
   // Flag: Has Dispose already been called?
   bool disposed = false;

   // Protected implementation of Dispose pattern.
   protected override void Dispose(bool disposing)
   {
      if (disposed)
         return; 

      if (disposing) {
         // Free any other managed objects here.
         //
      }

      // Free any unmanaged objects here.
      //
      disposed = true;

      // Call the base class implementation.
      base.Dispose(disposing);
   }

   ~DerivedClass()
   {
      Dispose(false);
   }
}
```

## Using safe handles

Writing code for an object's finalizer is a complex task that can cause problems if not done correctly. Therefore, we recommend that you construct [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) objects instead of implementing a finalizer.

Classes derived from the [System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle) class simplify object lifetime issues by assigning and releasing handles without interruption. They contain a critical finalizer that is guaranteed to run while an application domain is unloading. The following derived classes in the [Microsoft.Win32.SafeHandles](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles) namespace provide safe handles: 

* The [SafeFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeFileHandle), [SafeMemoryMappedFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeMemoryMappedFileHandle), and [SafePipeHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafePipeHandle) class, for files, memory mapped files, and pipes. 

* The [SafeMemoryMappedViewHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeMemoryMappedViewHandle) class, for memory views. 

* The [SafeNCryptKeyHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeNCryptKeyHandle), [SafeNCryptProviderHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeNCryptProviderHandle), and [SafeNCryptSecretHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeNCryptSecretHandle) classes, for cryptography constructs. 

* The [SafeRegistryHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeRegistryHandle) class, for registry keys. 

* The [SafeWaitHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeWaitHandle) class, for wait handles. 

## Using a safe handle to implement the dispose pattern for a base class

The following example illustrates the dispose pattern for a base class, `DisposableStreamResource`, that uses a safe handle to encapsulate unmanaged resources. It defines a `DisposableResource` class that uses a [SafeFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeFileHandle) to wrap a [Stream](https://docs.microsoft.com/dotnet/core/api/System.IO.Stream) object that represents an open file. The `DisposableResource` method also includes a single property, `Size`, that returns the total number of bytes in the file stream. 

```cs
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

public class DisposableStreamResource : IDisposable
{
   // Define constants.
   protected const uint GENERIC_READ = 0x80000000;
   protected const uint FILE_SHARE_READ = 0x00000001;
   protected const uint OPEN_EXISTING = 3;
   protected const uint FILE_ATTRIBUTE_NORMAL = 0x80;
   protected IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
   private const int INVALID_FILE_SIZE = unchecked((int) 0xFFFFFFFF);

   // Define Windows APIs.
   [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
   protected static extern IntPtr CreateFile (
                                  string lpFileName, uint dwDesiredAccess, 
                                  uint dwShareMode, IntPtr lpSecurityAttributes, 
                                  uint dwCreationDisposition, uint dwFlagsAndAttributes, 
                                  IntPtr hTemplateFile);

   [DllImport("kernel32.dll")]
   private static extern int GetFileSize(SafeFileHandle hFile, out int lpFileSizeHigh);

   // Define locals.
   private bool disposed = false;
   private SafeFileHandle safeHandle; 
   private long bufferSize;
   private int upperWord;

   public DisposableStreamResource(string filename)
   {
      if (filename == null)
         throw new ArgumentNullException("The filename cannot be null.");
      else if (filename == "")
         throw new ArgumentException("The filename cannot be an empty string.");

      IntPtr handle = CreateFile(filename, GENERIC_READ, FILE_SHARE_READ,
                                 IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL,
                                 IntPtr.Zero);
      if (handle != INVALID_HANDLE_VALUE)
         safeHandle = new SafeFileHandle(handle, true);
      else
         throw new FileNotFoundException(String.Format("Cannot open '{0}'", filename));

      // Get file size.
      bufferSize = GetFileSize(safeHandle, out upperWord); 
      if (bufferSize == INVALID_FILE_SIZE)
         bufferSize = -1;
      else if (upperWord > 0) 
         bufferSize = (((long)upperWord) << 32) + bufferSize;
   }

   public long Size 
   { get { return bufferSize; } }

   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }           

   protected virtual void Dispose(bool disposing)
   {
      if (disposed) return;

      // Dispose of managed resources here.
      if (disposing)
         safeHandle.Dispose();

      // Dispose of any unmanaged resources not wrapped in safe handles.

      disposed = true;
   }  
}
```

## Using a safe handle to implement the dispose pattern for a derived class

The following example illustrates the dispose pattern for a derived class, `DisposableStreamResource2`, that inherits from the `DisposableStreamResource` class presented in the previous example. The class adds an additional method, `WriteFileInfo`, and uses a [SafeFileHandle](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles.SafeFileHandle) object to wrap the handle of the writable file. 

```cs
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

public class DisposableStreamResource2 : DisposableStreamResource
{
   // Define additional constants.
   protected const uint GENERIC_WRITE = 0x40000000; 
   protected const uint OPEN_ALWAYS = 4;

   // Define additional APIs.
   [DllImport("kernel32.dll")]   
   protected static extern bool WriteFile(
                                SafeFileHandle safeHandle, string lpBuffer, 
                                int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
                                IntPtr lpOverlapped);

   // Define locals.
   private bool disposed = false;
   private string filename;
   private bool created = false;
   private SafeFileHandle safeHandle;

   public DisposableStreamResource2(string filename) : base(filename)
   {
      this.filename = filename;
   }

   public void WriteFileInfo()
   { 
      if (! created) {
         IntPtr hFile = CreateFile(@".\FileInfo.txt", GENERIC_WRITE, 0, 
                                   IntPtr.Zero, OPEN_ALWAYS, 
                                   FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
         if (hFile != INVALID_HANDLE_VALUE)
            safeHandle = new SafeFileHandle(hFile, true);
         else
            throw new IOException("Unable to create output file.");

         created = true;
      }

      string output = String.Format("{0}: {1:N0} bytes\n", filename, Size);
      int bytesWritten;
      bool result = WriteFile(safeHandle, output, output.Length, out bytesWritten, IntPtr.Zero);                                     
   }

   protected new virtual void Dispose(bool disposing)
   {
      if (disposed) return;

      // Release any managed resources here.
      if (disposing)
         safeHandle.Dispose();

      disposed = true;

      // Release any unmanaged resources not wrapped by safe handles here.

      // Call the base class implementation.
      base.Dispose(true);
   }
}
```

## See Also

[SuppressFinalize](https://docs.microsoft.com/dotnet/core/api/System.GC#System_GC_SuppressFinalize_System_Object_)

[IDisposable](https://docs.microsoft.com/dotnet/core/api/System.IDisposable)

[IDisposable.Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose)

[Microsoft.Win32.SafeHandles](https://docs.microsoft.com/dotnet/core/api/Microsoft.Win32.SafeHandles)

[System.Runtime.InteropServices.SafeHandle](https://docs.microsoft.com/dotnet/core/api/System.Runtime.InteropServices.SafeHandle)

[IDisposable.Dispose](https://docs.microsoft.com/dotnet/core/api/System.IDisposable#System_IDisposable_Dispose)

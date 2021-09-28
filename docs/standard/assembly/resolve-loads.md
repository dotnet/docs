---
title: Resolve assembly loads
description: This article describes the .NET AppDomain.AssemblyResolve event. Use this event for applications that require control over assembly loading.
ms.date: 12/15/2020
helpviewer_keywords:
  - "assemblies [.NET], resolving loads"
  - "application domains, loading assemblies"
  - "resolving assembly loads"
  - "assemblies [.NET], loading"
  - "application domains, resolving assembly loads"
ms.assetid: 5099e549-f4fd-49fb-a290-549edd456c6a
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
---

# Resolve assembly loads

.NET provides the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event for applications that require greater control over assembly loading. By handling this event, your application can load an assembly into the load context from outside the normal probing paths, select which of several assembly versions to load, emit a dynamic assembly and return it, and so on. This topic provides guidance for handling the <xref:System.AppDomain.AssemblyResolve> event.

> [!NOTE]
> For resolving assembly loads in the reflection-only context, use the <xref:System.AppDomain.ReflectionOnlyAssemblyResolve?displayProperty=nameWithType> event instead.

## How the AssemblyResolve event works

When you register a handler for the <xref:System.AppDomain.AssemblyResolve> event, the handler is invoked whenever the runtime fails to bind to an assembly by name. For example, calling the following methods from user code can cause the <xref:System.AppDomain.AssemblyResolve> event to be raised:

- An <xref:System.AppDomain.Load%2A?displayProperty=nameWithType> method overload or <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method overload whose first argument is a string that represents the display name of the assembly to load (that is, the string returned by the <xref:System.Reflection.Assembly.FullName%2A?displayProperty=nameWithType> property).

- An <xref:System.AppDomain.Load%2A?displayProperty=nameWithType> method overload or <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method overload whose first argument is an <xref:System.Reflection.AssemblyName> object that identifies the assembly to load.

- An <xref:System.Reflection.Assembly.LoadWithPartialName%2A?displayProperty=nameWithType> method overload.

- An <xref:System.AppDomain.CreateInstance%2A?displayProperty=nameWithType> or <xref:System.AppDomain.CreateInstanceAndUnwrap%2A?displayProperty=nameWithType> method overload that instantiates an object in another application domain.

## What the event handler does

The handler for the <xref:System.AppDomain.AssemblyResolve> event receives the display name of the assembly to be loaded, in the <xref:System.ResolveEventArgs.Name%2A?displayProperty=nameWithType> property. If the handler does not recognize the assembly name, it returns `null` (C#), `Nothing` (Visual Basic), or `nullptr` (Visual C++).

If the handler recognizes the assembly name, it can load and return an assembly that satisfies the request. The following list describes some sample scenarios.

- If the handler knows the location of a version of the assembly, it can load the assembly by using the <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.LoadFile%2A?displayProperty=nameWithType> method, and can return the loaded assembly if successful.

- If the handler has access to a database of assemblies stored as byte arrays, it can load a byte array by using one of the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method overloads that take a byte array.

- The handler can generate a dynamic assembly and return it.

> [!NOTE]
> The handler must load the assembly into the load-from context, into the load context, or without context. If the handler loads the assembly into the reflection-only context by using the <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A?displayProperty=nameWithType> or the <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom%2A?displayProperty=nameWithType> method, the load attempt that raised the <xref:System.AppDomain.AssemblyResolve> event fails.

It is the responsibility of the event handler to return a suitable assembly. The handler can parse the display name of the requested assembly by passing the <xref:System.ResolveEventArgs.Name%2A?displayProperty=nameWithType> property value to the <xref:System.Reflection.AssemblyName.%23ctor%28System.String%29> constructor. Beginning with the .NET Framework 4, the handler can use the <xref:System.ResolveEventArgs.RequestingAssembly%2A?displayProperty=nameWithType> property to determine whether the current request is a dependency of another assembly. This information can help identify an assembly that will satisfy the dependency.

The event handler can return a different version of the assembly than the version that was requested.

In most cases, the assembly that is returned by the handler appears in the load context, regardless of the context the handler loads it into. For example, if the handler uses the <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> method to load an assembly into the load-from context, the assembly appears in the load context when the handler returns it. However, in the following case the assembly appears without context when the handler returns it:

- The handler loads an assembly without context.

- The <xref:System.ResolveEventArgs.RequestingAssembly%2A?displayProperty=nameWithType> property is not null.

- The requesting assembly (that is, the assembly that is returned by the <xref:System.ResolveEventArgs.RequestingAssembly%2A?displayProperty=nameWithType> property) was loaded without context.

For information about contexts, see the <xref:System.Reflection.Assembly.LoadFrom%28System.String%29?displayProperty=nameWithType> method overload.

Multiple versions of the same assembly can be loaded into the same application domain. This practice is not recommended, because it can lead to type assignment problems. See [Best practices for assembly loading](../../framework/deployment/best-practices-for-assembly-loading.md).

## What the event handler should not do

The primary rule for handling the <xref:System.AppDomain.AssemblyResolve> event is that you should not try to return an assembly you do not recognize. When you write the handler, you should know which assemblies might cause the event to be raised. Your handler should return null for other assemblies.

> [!IMPORTANT]
> Beginning with the .NET Framework 4, the <xref:System.AppDomain.AssemblyResolve> event is raised for satellite assemblies. This change affects an event handler that was written for an earlier version of the .NET Framework, if the handler tries to resolve all assembly load requests. Event handlers that ignore assemblies they do not recognize are not affected by this change: They return `null`, and normal fallback mechanisms are followed.

When loading an assembly, the event handler must not use any of the <xref:System.AppDomain.Load%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method overloads that can cause the <xref:System.AppDomain.AssemblyResolve> event to be raised recursively, because this can lead to a stack overflow. (See the list provided earlier in this topic.) This happens even if you provide exception handling for the load request, because no exception is thrown until all event handlers have returned. Thus, the following code results in a stack overflow if `MyAssembly` is not found:

```csharp
using System;
using System.Reflection;

class BadExample
{
    static void Main()
    {
        AppDomain ad = AppDomain.CreateDomain("Test");
        ad.AssemblyResolve += MyHandler;

        try
        {
            object obj = ad.CreateInstanceAndUnwrap(
                "MyAssembly, version=1.2.3.4, culture=neutral, publicKeyToken=null",
                "MyType");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static Assembly MyHandler(object source, ResolveEventArgs e)
    {
        Console.WriteLine("Resolving {0}", e.Name);
        // DO NOT DO THIS: This causes a StackOverflowException
        return Assembly.Load(e.Name);
    }
}

/* This example produces output similar to the following:

Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
...
Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null

Process is terminated due to StackOverflowException.
 */
```

```vb
Imports System.Reflection

Class BadExample

    Shared Sub Main()

        Dim ad As AppDomain = AppDomain.CreateDomain("Test")
        AddHandler ad.AssemblyResolve, AddressOf MyHandler

        Try
            Dim obj As object = ad.CreateInstanceAndUnwrap(
                "MyAssembly, version=1.2.3.4, culture=neutral, publicKeyToken=null",
                "MyType")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Shared Function MyHandler(ByVal source As Object, _
                              ByVal e As ResolveEventArgs) As Assembly
        Console.WriteLine("Resolving {0}", e.Name)
        // DO NOT DO THIS: This causes a StackOverflowException
        Return Assembly.Load(e.Name)
    End Function
End Class

' This example produces output similar to the following:
'
'Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
'Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
'...
'Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
'Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
'
'Process is terminated due to StackOverflowException.
```

```cpp
using namespace System;
using namespace System::Reflection;

ref class Example
{
internal:
    static Assembly^ MyHandler(Object^ source, ResolveEventArgs^ e)
    {
        Console::WriteLine("Resolving {0}", e->Name);
        // DO NOT DO THIS: This causes a StackOverflowException
        return Assembly::Load(e->Name);
    }
};

void main()
{
    AppDomain^ ad = AppDomain::CreateDomain("Test");
    ad->AssemblyResolve += gcnew ResolveEventHandler(&Example::MyHandler);

    try
    {
        Object^ obj = ad->CreateInstanceAndUnwrap(
            "MyAssembly, version=1.2.3.4, culture=neutral, publicKeyToken=null",
            "MyType");
    }
    catch (Exception^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}

/* This example produces output similar to the following:

Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
...
Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
Resolving MyAssembly, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null

Process is terminated due to StackOverflowException.
*/
```

### The correct way to handle AssemblyResolve

When resolving assemblies from the <xref:System.AppDomain.AssemblyResolve> event handler, a <xref:System.StackOverflowException> will eventually be thrown if the handler uses the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> or <xref:System.AppDomain.Load%2A?displayProperty=nameWithType> method calls. Instead, use <xref:System.Reflection.Assembly.LoadFile%2A> or <xref:System.Reflection.Assembly.LoadFrom%2A> methods, as they do not raise the `AssemblyResolve` event.

Imagine that `MyAssembly.dll` is located near the executing assembly, in a known location, it can be resolved using `Assembly.LoadFile` given the path to the assembly.

```csharp
using System;
using System.IO;
using System.Reflection;

class CorrectExample
{
    static void Main()
    {
        AppDomain ad = AppDomain.CreateDomain("Test");
        ad.AssemblyResolve += MyHandler;

        try
        {
            object obj = ad.CreateInstanceAndUnwrap(
                "MyAssembly, version=1.2.3.4, culture=neutral, publicKeyToken=null",
                "MyType");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static Assembly MyHandler(object source, ResolveEventArgs e)
    {
        Console.WriteLine("Resolving {0}", e.Name);

        var path = Path.GetFullPath("../../MyAssembly.dll");
        return Assembly.LoadFile(path);
     }
}
```

```vb
Imports System.IO
Imports System.Reflection

Class CorrectExample

    Shared Sub Main()

        Dim ad As AppDomain = AppDomain.CreateDomain("Test")
        AddHandler ad.AssemblyResolve, AddressOf MyHandler

        Try
            Dim obj As Object = ad.CreateInstanceAndUnwrap(
                "MyAssembly, version=1.2.3.4, culture=neutral, publicKeyToken=null",
                "MyType")
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Shared Function MyHandler(ByVal source As Object,
                              ByVal e As ResolveEventArgs) As Assembly
        Console.WriteLine("Resolving {0}", e.Name)

        Dim fullPath = Path.GetFullPath("../../MyAssembly.dll")
        Return Assembly.LoadFile(fullPath)
    End Function
End Class
```

```cpp
using namespace System;
using namespace System::IO;
using namespace System::Reflection;

ref class Example
{
internal:
    static Assembly^ MyHandler(Object^ source, ResolveEventArgs^ e)
    {
        Console::WriteLine("Resolving {0}", e->Name);

        String^ fullPath = Path::GetFullPath("../../MyAssembly.dll");
        return Assembly::LoadFile(fullPath);
    }
};

void main()
{
    AppDomain^ ad = AppDomain::CreateDomain("Test");
    ad->AssemblyResolve += gcnew ResolveEventHandler(&Example::MyHandler);

    try
    {
        Object^ obj = ad->CreateInstanceAndUnwrap(
            "MyAssembly, version=1.2.3.4, culture=neutral, publicKeyToken=null",
            "MyType");
    }
    catch (Exception^ ex)
    {
        Console::WriteLine(ex->Message);
    }
}
```

## See also

- [Best practices for assembly loading](../../framework/deployment/best-practices-for-assembly-loading.md)
- [Use application domains](../../framework/app-domains/use.md)

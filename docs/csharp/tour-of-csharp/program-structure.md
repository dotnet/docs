---
title: Program Structure | .NET Core
description: Program Structure
keywords: .NET .NET Core
author: Bill Wagner
manager: wpickett
ms.date: 08/10/2016
ms.topic: article
ms.prod: csharp
ms.technology: .net-core-technologies
ms.assetid: 984f0314-507f-47a0-af56-9011243f5e65

ms.devlang: dotnet
---

# Program Structure

The key organizational concepts in C# are ***programs***, ***namespaces***, ***types***, ***members***, and ***assemblies***. C# programs consist of one or more source files. Programs declare types, which contain members and can be organized into namespaces. Classes and interfaces are examples of types. Fields, methods, properties, and events are examples of members. When C# programs are compiled, they are physically packaged into assemblies. Assemblies typically have the file extension .exe or .dll, depending on whether they implement ***applications*** or ***libraries***, respectively.
The example

```csharp
using System;
namespace Acme.Collections
{
    public class Stack
    {
        Entry top;
        public void Push(object data) 
		{
			top = new Entry(top, data);
		}
		
		public object Pop() 
		{
			if (top == null)
			{
				throw new InvalidOperationException();
			}
			object result = top.data;
			top = top.next;
			return result;
		}

		class Entry
		{
			public Entry next;
			public object data;
			public Entry(Entry next, object data) 
			{
				this.next = next;
				this.data = data;
			}
		}
	}
}
```

declares a class named `Stack` in a namespace called `Acme.Collections`. The fully qualified name of this class is `Acme.Collections.Stack`. The class contains several members: a field named `top`, two methods named `Push` and `Pop`, and a nested class named `Entry`. The `Entry` class further contains three members: a field named `next`, a field named `data`, and a constructor. Assuming that the source code of the example is stored in the file `acme.cs`, the command line

```
csc /t:library acme.cs
```

compiles the example as a library (code without a `Main` entry point) and produces an assembly named `acme.dll`.
Assemblies contain executable code in the form of Intermediate Language (IL) instructions, and symbolic information in the form of metadata. Before it is executed, the IL code in an assembly is automatically converted to processor-specific code by the Just-In-Time (JIT) compiler of .NET Common Language Runtime.
Because an assembly is a self-describing unit of functionality containing both code and metadata, there is no need for `#include` directives and header files in C#. The public types and members contained in a particular assembly are made available in a C# program simply by referencing that assembly when compiling the program. For example, this program uses the `Acme.Collections.Stack` class from the `acme.dll` assembly:

```csharp
using System;
using Acme.Collections;
class Test
{
    static void Main() 
	{
        Stack s = new Stack();
        s.Push(1);
        s.Push(10);
        s.Push(100);
        Console.WriteLine(s.Pop());
        Console.WriteLine(s.Pop());
        Console.WriteLine(s.Pop());
	}
}
```

If the program is stored in the file `example.cs`, when `example.cs` is compiled, the acme.dll assembly can be referenced using the compiler’s /r option:

```
csc /r:acme.dll example.cs
```

This creates an executable assembly named `example.exe`, which, when run, produces the output:

```
100
10
1
```

C# permits the source text of a program to be stored in several source files. When a multi-file C# program is compiled, all of the source files are processed together, and the source files can freely reference each other—conceptually, it is as if all the source files were concatenated into one large file before being processed. Forward declarations are never needed in C# because, with very few exceptions, declaration order is insignificant. C# does not limit a source file to declaring only one public type nor does it require the name of the source file to match a type declared in the source file.

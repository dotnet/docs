---
title: System.TypeInitializationException class
description: Learn about the System.TypeInitializationException class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
  - FSharp
ms.topic: article
---
# System.TypeInitializationException class

[!INCLUDE [context](includes/context.md)]

When a class initializer fails to initialize a type, a <xref:System.TypeInitializationException> is created and passed a reference to the exception thrown by the type's class initializer. The <xref:System.Exception.InnerException> property of <xref:System.TypeInitializationException> holds the underlying exception.

Typically, the <xref:System.TypeInitializationException> exception reflects a catastrophic condition (the runtime is unable to instantiate a type) that prevents an application from continuing. Most commonly, the <xref:System.TypeInitializationException> is thrown in response to some change in the executing environment of the application. Consequently, other than possibly for troubleshooting debug code, the exception should not be handled in a `try`/`catch` block. Instead, the cause of the exception should be investigated and eliminated.

<xref:System.TypeInitializationException> uses the HRESULT `COR_E_TYPEINITIALIZATION`, which has the value 0x80131534.

For a list of initial property values for an instance of <xref:System.TypeInitializationException>, see the <xref:System.TypeInitializationException.%23ctor%2A> constructors.

The following sections describe some of the situations in which a <xref:System.TypeInitializationException> exception is thrown.

## Static constructors

A static constructor, if one exists, is called automatically by the runtime before creating a new instance of a type. Static constructors can be explicitly defined by a developer. If a static constructor is not explicitly defined, compilers automatically create one to initialize any `static` (in C# or F#) or `Shared` (in Visual Basic) members of the type. For more information on static constructors, see [Static Constructors](../../csharp/programming-guide/classes-and-structs/static-constructors.md).

Most commonly, a <xref:System.TypeInitializationException> exception is thrown when a static constructor is unable to instantiate a type. The <xref:System.Exception.InnerException> property indicates why the static constructor was unable to instantiate the type. Some of the more common causes of a <xref:System.TypeInitializationException> exception are:

- An unhandled exception in a static constructor

   If an exception is thrown in a static constructor, that exception is wrapped in a <xref:System.TypeInitializationException> exception, and the type cannot be instantiated.

   What often makes this exception difficult to troubleshoot is that static constructors are not always explicitly defined in source code. A static constructor exists in a type if:

  - It has been explicitly defined as a member of a type.

  - The type has  `static` (in C# or F#) or `Shared` (in Visual Basic) variables that are declared and initialized in a single statement. In this case, the language compiler generates a static constructor for the type. You can inspect it by using a utility such as [IL Disassembler](../../framework/tools/ildasm-exe-il-disassembler.md). For instance, when the C# and VB compilers compile the following example, they generate the IL for a static constructor that is similar to this:

   ```il
   .method private specialname rtspecialname static
           void  .cctor() cil managed
   {
     // Code size       12 (0xc)
     .maxstack  8
     IL_0000:  ldc.i4.3
     IL_0001:  newobj     instance void TestClass::.ctor(int32)
     IL_0006:  stsfld     class TestClass Example::test
     IL_000b:  ret
   } // end of method Example::.cctor
   ```

   The following example shows a <xref:System.TypeInitializationException> exception thrown by a compiler-generated static constructor. The `Example` class includes a `static` (in C#) or `Shared` (in Visual Basic) field of type `TestClass` that is instantiated by passing a value of 3 to its class constructor. That value, however, is illegal; only values of 0 or 1 are permitted. As a result, the `TestClass` class constructor throws an <xref:System.ArgumentOutOfRangeException>. Since this exception is not handled, it is wrapped in a <xref:System.TypeInitializationException> exception.

   :::code language="csharp" source="./snippets/System/TypeInitializationException/Overview/csharp/ctorException1.cs" id="Snippet3":::
   :::code language="vb" source="./snippets/System/TypeInitializationException/Overview/vb/CtorException1.vb" id="Snippet3":::

   Note that the exception message displays information about the <xref:System.Exception.InnerException> property.

- A missing assembly or data file

   A common cause of a <xref:System.TypeInitializationException> exception is that an assembly or data file that was present in an application's development and test environments is missing from its runtime environment. For example, you can compile the following example to an assembly named Missing1a.dll by using this command-line syntax:

   ```csharp
   csc -t:library Missing1a.cs
   ```

   ```fsharp
   fsc --target:library Missing1a.fs
   ```

   ```vb
   vbc Missing1a.vb -t:library
   ```

   :::code language="csharp" source="./snippets/System/TypeInitializationException/Overview/csharp/Missing1a.cs" id="Snippet1":::
   :::code language="fsharp" source="./snippets/System/TypeInitializationException/Overview/fsharp/Missing1a.fs" id="Snippet1":::
   :::code language="vb" source="./snippets/System/TypeInitializationException/Overview/vb/Missing1a.vb" id="Snippet1":::

   You can then compile the following example to an executable named Missing1.exe by including a reference to Missing1a.dll:

   ```csharp
   csc Missing1.cs /r:Missing1a.dll
   ```

   ```vb
   vbc Missing1.vb /r:Missing1a.dll
   ```

   However, if you rename, move, or delete Missing1a.dll and run the example, it throws a <xref:System.TypeInitializationException> exception and displays the output shown in the example. Note that the exception message includes information about the <xref:System.Exception.InnerException> property. In this case,  the inner exception is a <xref:System.IO.FileNotFoundException> that is thrown because the runtime cannot find the dependent assembly.

   :::code language="csharp" source="./snippets/System/TypeInitializationException/Overview/csharp/Missing1.cs" id="Snippet2":::
   :::code language="fsharp" source="./snippets/System/TypeInitializationException/Overview/fsharp/Missing1.fs" id="Snippet2":::
   :::code language="vb" source="./snippets/System/TypeInitializationException/Overview/vb/Missing1.vb" id="Snippet2":::

   > [!NOTE]
   > In this example, a <xref:System.TypeInitializationException> exception was thrown because an assembly could not be loaded. The exception can also be thrown if a static constructor attempts to open a data file, such as a configuration file, an XML file, or a file containing serialized data, that it cannot find.

## Regular expression match timeout values

You can set the default timeout value for a regular expression pattern matching operation on a per-application domain basis. The timeout is defined by a specifying a <xref:System.TimeSpan> value for the "REGEX_DEFAULT_MATCH_TIMEOUT" property to the  <xref:System.AppDomain.SetData%2A?displayProperty=nameWithType> method. The time interval must be a valid <xref:System.TimeSpan> object that is greater than zero and less than approximately 24 days. If these requirements are not met, the attempt to set the default timeout value throws an <xref:System.ArgumentOutOfRangeException>, which in turn is wrapped in a <xref:System.TypeInitializationException> exception.

The following example shows the <xref:System.TypeInitializationException> that is thrown when the value assigned to the "REGEX_DEFAULT_MATCH_TIMEOUT" property is invalid. To eliminate the exception, set the"REGEX_DEFAULT_MATCH_TIMEOUT" property to a  <xref:System.TimeSpan> value that is greater than zero and less than approximately 24 days.

:::code language="csharp" source="./snippets/System/TypeInitializationException/Overview/csharp/Regex1.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/TypeInitializationException/Overview/fsharp/Regex1.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/TypeInitializationException/Overview/vb/Regex1.vb" id="Snippet4":::

## Calendars and cultural data

If you attempt to instantiate a calendar but the runtime is unable to instantiate the <xref:System.Globalization.CultureInfo> object that corresponds to that calendar, it throws a <xref:System.TypeInitializationException> exception. This exception can be thrown by the following calendar class constructors:

- The parameterless constructor of the <xref:System.Globalization.JapaneseCalendar> class.
- The parameterless constructor of the <xref:System.Globalization.KoreanCalendar> class.
- The parameterless constructor of the <xref:System.Globalization.TaiwanCalendar> class.

Since cultural data for these cultures should be available on all systems, you should rarely, if ever, encounter this exception.

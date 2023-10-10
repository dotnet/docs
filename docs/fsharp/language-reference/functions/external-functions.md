---
title: External Functions
description: Learn about the F# language support for calling functions in native code.
ms.date: 05/16/2016
---
# External Functions

This topic describes F# language support for calling functions in native code.

## Syntax

```fsharp
[<DllImport( arguments )>]
extern declaration
```

## Remarks

In the previous syntax, *arguments* represents arguments that are supplied to the `System.Runtime.InteropServices.DllImportAttribute` attribute. The first argument is a string that represents the name of the DLL that contains this function, without the .dll extension. Additional arguments can be supplied for any of the public properties of the `System.Runtime.InteropServices.DllImportAttribute` class, such as the calling convention.

Assume you have a native C++ DLL that contains the following exported function.

```cpp
#include <stdio.h>
extern "C" void __declspec(dllexport) HelloWorld()
{
    printf("Hello world, invoked by F#!\n");
}
```

You can call this function from F# by using the following code.

```fsharp
open System.Runtime.InteropServices

module InteropWithNative =
    [<DllImport(@"C:\bin\nativedll", CallingConvention = CallingConvention.Cdecl)>]
    extern void HelloWorld()

InteropWithNative.HelloWorld()
```

Interoperability with native code is referred to as *platform invoke* and is a feature of the CLR. For more information, see [Interoperating with Unmanaged Code](../../../framework/interop/index.md). The information in that section is applicable to F#.

### Defining Parameters in External Functions

When declaring external functions with return values or parameters you use a syntax similar to C. You have the option to use the managed (where the CLR will perform some automatic conversions between native and .NET types) and unmanaged declarations which may offer better performance in some circumstances. Take the example of the Windows function [GetBinaryTypeW](/windows/win32/api/winbase/nf-winbase-getbinarytypew). It can be declared in two different ways:

```fs
// Using automatic marshaling of managed types
[<DllImport("kernel32.dll", 
    CallingConvention = CallingConvention.StdCall, 
    CharSet = CharSet.Unicode, 
    ExactSpelling = true)>]
extern bool GetBinaryTypeW([<MarshalAs(UnmanagedType.LPWStr)>] string lpApplicationName, uint& lpBinaryType);
```

`MarshalAs(UnmanagedType.LPWStr)` instructs the CLR to perform an automatic conversion between a .NET `string` and Windows native string representation when the function is called. `uint&` declares a `uint` that will be passed `byref` i.e. as a managed pointer. To obtain a managed pointer you use the address of `&` operator.

Alternately, you may wish to manage the marshalling of data types manually and declare the external functions using only [unmanaged types](../../../csharp/language-reference/builtin-types/unmanaged-types.md).

```fs
// Using unmanaged types
[<DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)>]
extern int GetBinaryTypeW(nativeint lpApplicationName, uint* lpBinaryType);
```

You could use<xref:System.Runtime.InteropServices.Marshal.StringToHGlobalUni%2A?displayProperty=nameWithType> to convert a .NET string to native format and receive a pointer (`nativeint`) to it that could be supplied to `lpApplicationName`.

To obtain a pointer to an integer you would use the pointer of `&&` operator or the [`fixed`](../language-reference/fixed.md) keyword.

## See also

- [Functions](index.md)

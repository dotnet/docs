---
title: Type marshaling - .NET
description: Learn how .NET marshals your types to a native representation.
ms.date: 01/18/2019
---

# Type marshaling

**Marshaling** is the process of transforming types when they need to cross between managed and native code.

Marshaling is needed because the types in the managed and unmanaged code are different. In managed code, for instance, you have a `String`, while in the unmanaged world strings can be Unicode ("wide"), non-Unicode, null-terminated, ASCII, etc. By default, the P/Invoke subsystem tries to do the right thing based on the default behavior, described on this article. However, for those situations where you need extra control, you can employ the [MarshalAs](xref:System.Runtime.InteropServices.MarshalAsAttribute) attribute to specify what is the expected type on the unmanaged side. For instance, if you want the string to be sent as a null-terminated ANSI string, you could do it like this:

```csharp
[DllImport("somenativelibrary.dll")]
static extern int MethodA([MarshalAs(UnmanagedType.LPStr)] string parameter);
```

## Default rules for marshaling common types

Generally, the runtime tries to do the "right thing" when marshaling to require the least amount of work from you. The following tables describe how each type is marshaled by default when used in a parameter or field. The C99/C++11 fixed-width integer and character types are used to ensure that the following table is correct for all platforms. You can use any native type that has the same alignment and size requirements as these types.

This first table describes the mappings for various types for whom the marshaling is the same for both P/Invoke and field marshaling.

| .NET Type | Native Type  |
|-----------|-------------------------|
| `byte`    | `uint8_t`               |
| `sbyte`   | `int8_t`                |
| `short`   | `int16_t`               |
| `ushort`  | `uint16_t`              |
| `int`     | `int32_t`               |
| `uint`    | `uint32_t`              |
| `long`    | `int64_t`               |
| `ulong`   | `uint64_t`              |
| `char`    | Either `char` or `char16_t` depending on the `CharSet` of the P/Invoke or structure. See the [charset documentation](charset.md). |
| `string`  | Either `char*` or `char16_t*` depending on the `CharSet` of the P/Invoke or structure. See the [charset documentation](charset.md). |
| `System.IntPtr` | `intptr_t`        |
| `System.UIntPtr` | `uintptr_t`      |
| .NET Pointer types (ex. `void*`)  | `void*` |
| Type derived from `System.Runtime.InteropServices.SafeHandle` | `void*` |
| Type derived from `System.Runtime.InteropServices.CriticalHandle` | `void*`          |
| `bool`    | Win32 `BOOL` type       |
| `decimal` | COM `DECIMAL` struct |
| .NET Delegate | Native function pointer |
| `System.DateTime` | Win32 `DATE` type |
| `System.Guid` | Win32 `GUID` type |

A few categories of marshaling have different defaults if you're marshaling as a parameter or structure.

| .NET Type | Native Type (Parameter) | Native Type (Field) |
|-----------|-------------------------|---------------------|
| .NET array | A pointer to the start of an array of native representations of the array elements. | Not allowed without a `[MarshalAs]` attribute|
| A class with a `LayoutKind` of `Sequential` or `Explicit` | A pointer to the native representation of the class | The native representation of the class |

The following table includes the default marshaling rules that are Windows-only. On non-Windows platforms, you cannot marshal these types.

| .NET Type | Native Type (Parameter) | Native Type (Field) |
|-----------|-------------------------|---------------------|
| `object`  | `VARIANT`               | `IUnknown*`         |
| `System.Array` | COM interface | Not allowed without a `[MarshalAs]` attribute |
| `System.ArgIterator` | `va_list` | Not allowed |
| `System.Collections.IEnumerator` | `IEnumVARIANT*` | Not allowed |
| `System.Collections.IEnumerable` | `IDispatch*` | Not allowed |
| `System.DateTimeOffset` | `int64_t` representing the number of ticks since midnight on January 1, 1601 || `int64_t` representing the number of ticks since midnight on January 1, 1601 |

Some types can only be marshaled as parameters and not as fields. These types are listed in the following table:

| .NET Type | Native Type (Parameter Only) |
|-----------|------------------------------|
| `System.Text.StringBuilder` | Either `char*` or `char16_t*` depending on the `CharSet` of the P/Invoke.  See the [charset documentation](charset.md). |
| `System.ArgIterator` | `va_list` (on Windows x86/x64/arm64 only) |
| `System.Runtime.InteropServices.ArrayWithOffset` | `void*` |
| `System.Runtime.InteropServices.HandleRef` | `void*` |

If these defaults don't do exactly what you want, you can customize how parameters are marshaled. The [parameter marshaling](customize-parameter-marshaling.md) article walks you through how to customize how different parameter types are marshaled.

## Default marshaling in COM scenarios

When you are calling methods on COM objects in .NET, the .NET runtime changes the default marshaling rules to match common COM semantics. The following table lists the rules that .NET runtimes uses in COM scenarios:

| .NET Type | Native Type (COM method calls) |
|-----------|--------------------------------|
| `bool`    | `VARIANT_BOOL`                 |
| `StringBuilder` | `LPWSTR`                 |
| `string`  | `BSTR`                         |
| Delegate types | `_Delegate*` in .NET Framework. Disallowed in .NET Core. |
| `System.Drawing.Color` | `OLECOLOR`        |
| .NET array | `SAFEARRAY`                   |
| `string[]` | `SAFEARRAY` of `BSTR`s        |

## Marshaling classes and structs

Another aspect of type marshaling is how to pass in a struct to an unmanaged method. For instance, some of the unmanaged methods require a struct as a parameter. In these cases, you need to create a corresponding struct or a class in managed part of the world to use it as a parameter. However, just defining the class isn't enough, you also need to instruct the marshaler how to map fields in the class to the unmanaged struct. Here the `StructLayout` attribute becomes useful.

```csharp
[DllImport("kernel32.dll")]
static extern void GetSystemTime(SystemTime systemTime);

[StructLayout(LayoutKind.Sequential)]
class SystemTime {
    public ushort Year;
    public ushort Month;
    public ushort DayOfWeek;
    public ushort Day;
    public ushort Hour;
    public ushort Minute;
    public ushort Second;
    public ushort Milsecond;
}

public static void Main(string[] args) {
    SystemTime st = new SystemTime();
    GetSystemTime(st);
    Console.WriteLine(st.Year);
}
```

The previous code shows a simple example of calling into `GetSystemTime()` function. The interesting bit is on line 4. The attribute specifies that the fields of the class should be mapped sequentially to the struct on the other (unmanaged) side. This means that the naming of the fields isn't important, only their order is important, as it needs to correspond to the unmanaged struct, shown in the following example:

```c
typedef struct _SYSTEMTIME {
  WORD wYear;
  WORD wMonth;
  WORD wDayOfWeek;
  WORD wDay;
  WORD wHour;
  WORD wMinute;
  WORD wSecond;
  WORD wMilliseconds;
} SYSTEMTIME, *PSYSTEMTIME;
```

Sometimes the default marshaling for your structure doesn't do what you need. The [Customizing structure marshaling](./customize-struct-marshaling.md) article teaches you how to customize how your structure is marshaled.

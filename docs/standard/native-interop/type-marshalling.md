---
title: Type marshalling
description: Learn how .NET marshals your types to a native representation.
author: jkoritzinsky
ms.author: jekoritz
ms.date: 11/28/2018
---

# Type marshalling

**Marshalling** is the process of transforming types when they need to cross between managed and native code.

Marshalling is needed because the types in the managed and unmanaged code are different. In managed code, for instance, you have a `String`, while in the unmanaged world strings can be Unicode ("wide"), non-Unicode, null-terminated, ASCII, etc. By default, the P/Invoke subsystem will try to do the Right Thing based on the default behavior, which you can see on [MSDN](../../framework/interop/default-marshaling-behavior.md). However, for those situations where you need extra control, you can employ the `MarshalAs` attribute to specify what is the expected type on the unmanaged side. For instance, if we want the string to be sent as a null-terminated ANSI string, we could do it like this:

```csharp
[DllImport("somenativelibrary.dll")]
static extern int MethodA([MarshalAs(UnmanagedType.LPStr)] string parameter);
```

## Default rules for marshalling common types

Generally, the runtime tries to do the "Right Thing" when marshalling to require the least amount of work from you. The tables below describe how each type is marshalled by default when used in a parameter or field. We use the C99/C++11 fixed width integer and character types to ensure that the table below is correct for all platforms. You can use any native type that has the same alignment and size requirements as these types.

This first table describes the mappings for various types for whom the marshalling is the same for both P/Invoke and field marshalling.

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
| `char`    | Either `char` or `char16_t` depending on the `CharSet` of the P/Invoke or structure. |
| `string`  | Either `char*` or `char16_t*` depending on the `CharSet` of the P/Invoke or structure. |
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

A few categories of marshalling have different defaults if you are marshalling as a parameter or structure.

| .NET Type | Native Type (Parameter) | Native Type (Field) |
|-----------|-------------------------|---------------------|
| .NET array | A pointer to the start of an array of native representations of the array elements. | Not allowed without a `[MarshalAs]` attribute|
| A class with a `LayoutKind` of `Sequential` or `Explicit` | A pointer to the native representation of the class | The native representation of the class |

The following table includes the default marshalling rules that are Windows-only. On non-Windows platforms, you cannot marshal these types.

| .NET Type | Native Type (Parameter) | Native Type (Field) |
|-----------|-------------------------|---------------------|
| `object`  | `VARIANT`               | `IUnknown*`         |
| `System.Array` | COM interface | Not allowed without a `[MarshalAs]` attribute |
| `System.ArgIterator` | `va_list` | Not allowed |
| `System.Collections.IEnumerator` | `IEnumVariant` | Not allowed |
| `System.DateTimeOffset` | `int64_t` representing the number of ticks since midnight on January 1, 1601 || `int64_t` representing the number of ticks since midnight on January 1, 1601 |

Some types can only be marshalled as parameters and not as fields. These types are listed below

| .NET Type | Native Type (Parameter Only) |
|-----------|------------------------------|
| `System.Text.StringBuilder` | Either `char*` or `char16_t*` depending on the `CharSet` of the P/Invoke. |
| `System.ArgIterator` | `va_list` (on Windows x86/x64/arm64 only) |
| `System.Runtime.InteropServices.ArrayWithOffset` | `void*` |
| `System.Runtime.InteropServices.HandleRef` | `void*` |


## Marshalling classes and structs

Another aspect of type marshalling is how to pass in a struct to an unmanaged method. For instance, some of the unmanaged methods require a struct as a parameter. In these cases, we need to create a corresponding struct or a class in managed part of the world to use it as a parameter. However, just defining the class isn't enough, we also need to instruct the marshaler how to map fields in the class to the unmanaged struct. Here the `StructLayout` attribute becomes useful.

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

The example above shows off a simple example of calling into `GetSystemTime()` function. The interesting bit is on line 4. The attribute specifies that the fields of the class should be mapped sequentially to the struct on the other (unmanaged) side. This means that the naming of the fields isn't important, only their order is important, as it needs to correspond to the unmanaged struct, shown below:

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
} SYSTEMTIME, *PSYSTEMTIME*;
```

We already saw the Linux and macOS example for this structure in the previous example. It is shown again below.

```csharp
[StructLayout(LayoutKind.Sequential)]
public class StatClass {
        public uint DeviceID;
        public uint InodeNumber;
        public uint Mode;
        public uint HardLinks;
        public uint UserID;
        public uint GroupID;
        public uint SpecialDeviceID;
        public ulong Size;
        public ulong BlockSize;
        public uint Blocks;
        public long TimeLastAccess;
        public long TimeLastModification;
        public long TimeLastStatusChange;
}
```

The `StatClass` class represents a structure that is returned by the `stat` system call on UNIX systems. It represents information about a given file. The class above is the stat struct representation in managed code. Again, the fields in the class have to be in the same order as the native struct (you can find these by perusing man pages on your favorite UNIX implementation) and they have to be of the same underlying type.

### Customizing Struct Marshalling

Sometimes the default marshalling rules for fields in a structure aren't exactly what you need. The .NET runtimes provide a few extension points for you to customize how your struct is marshalled to native code.

#### Customizing Boolean Marshalling

Native code has many different boolean representations; on Windows alone there are three ways to represent boolean values. The runtime doesn't know the native definition of your structure, so the best it can do is make a guess on how to marshal your boolean values. The .NET runtime provides a way to indicate how to marshal your boolean field. See the examples below for how to marshal your .NET `bool` to different native boolean types:

Boolean values default to marshalling as a native 4-byte Win32 [`BOOL`](https://docs.microsoft.com/windows/desktop/winprog/windows-data-types#BOOL) value, shown below:

```csharp
public struct WinBool
{
    public bool b;
}
```

```cpp
struct WinBool
{
    public BOOL b;
};
```

If you want to be explicit, you can use the <xref:System.Runtime.InteropServices.UnmanagedType.Bool?displayProperty=nameWithType> value to get the same behavior as above:

```csharp
public struct WinBool
{
    [MarshalAs(UnmanagedType.Bool)]
    public bool b;
}
```

```cpp
struct WinBool
{
    public BOOL b;
};
```

Using the `UmanagedType.U1` or `UnmanagedType.I1` values below, you can tell the runtime to marshal the `b` field as a 1-byte native `bool` type.

```csharp
public struct CBool
{
    [MarshalAs(UnmanagedType.U1)]
    public bool b;
}
```

```cpp
struct CBool
{
    public bool b;
};
```

When on Windows, you can use the <xref:System.Runtime.InteropServices.UnmanagedType.VariantBool?displayProperty=nameWithType> value to tell the runtime to marshal your boolean value to a 2-byte `VARIANT_BOOL` value.

```csharp
public struct VariantBool
{
    [MarshalAs(UnmanagedType.VariantBool)]
    public bool b;
}
```

```cpp
struct VariantBool
{
    public VARIANT_BOOL b;
};
```

> [!NOTE]
> `VARIANT_BOOL` is different than most bool types in that `VARIANT_TRUE = -1` and `VARIANT_FALSE = 0`. Additionally, all values that aren't equal to `VARIANT_TRUE` are considered false.

#### Customizing Array Marshalling

.NET also includes a few ways to customize array marshalling.

By default, .NET marshals arrays as a pointer to a contiguous list of the elements:

```csharp
public struct DefaultArray
{
    public int[] values;
}
```

```cpp
struct DefaultArray
{
    int* values;
};
```

If you are interfacing with COM APIs, you may have to marshal your arrays as `SAFEARRAY*`s. You can use the <xref:System.Runtime.InteropServices.MarshalAsAttribute?displayProperty=nameWithType> and the <xref:System.Runtime.InteropServices.UnmanagedType.SafeArray?displayProperty=nameWithType> value to tell the runtime to marshal your array as a `SAFEARRAY*`.

```csharp
public struct SafeArrayExample
{
    [MarshalAs(UnmanagedType.SafeArray)]
    public int[] values;
}
```

```cpp
struct SafeArrayExample
{
    SAFEARRAY* values;
};
```

If you need to customize what type of element is in your `SAFEARRAY`, then you can use the <xref:System.Runtime.InteropServices.MarshalAsAttribute.SafeArraySubType?displayProperty=nameWithType> and <xref:System.Runtime.InteropServices.MarshalAsAttribute.SafeArrayUserDefinedSubType?displayProperty=nameWithType> fields to customize the exact element type of the `SAFEARRAY`.

If you need to marshal the array in-place, you can use the <xref:System.Runtime.InteropServices.UnmanagedType.ByValArray?displayProperty=nameWithType> value to tell the marshaler to marshal the array in-place. When using this marshalling, you also must supply a value to the <xref:System.Runtime.InteropServices.MarshalAsAttribute.SizeConst?displayProperty=nameWithType> field  for the number of elements in the array so the runtime can correctly allocate space for the structure.

```csharp
public struct InPlaceArray
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public int[] values;
}
```

```cpp
struct InPlaceArray
{
    int values[4];
};
```

> [!NOTE]
> .NET doesn't support marshalling a variable length array field as a C99 Flexible Array Member.

#### Customizing String Marshalling
.NET also provides a wide variety of customizations for marshalling string fields.

By default, .NET marshals a string as a pointer to a null-terminated string. The encoding depends on the value of the <xref:System.Runtime.InteropServices.StructLayoutAttribute.CharSet?displayProperty=nameWithType> field in the <xref:System.Runtime.InteropServices.StructLayoutAttribute?displayProperty=nameWithType>. If no attribute is specified, the encoding defaults to an ANSI encoding.

```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct DefaultString
{
    public string str;
}
```

```cpp
struct DefaultString
{
    char* str;
};
```

```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DefaultString
{
    public string str;
}
```

```cpp
struct DefaultString
{
    char16_t* str; // Could also be wchar_t* on Windows.
};
```

If you need to use different encodings for different fields or just prefer to be more explicit in your struct definition, you can use the <xref:System.Runtime.InteropServices.UnmanagedType.LPStr?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.UnmanagedType.LPWStr?displayProperty=nameWithType> values on a <xref:System.Runtime.InteropServices.MarshalAsAttribute?displayProperty=nameWithType> attribute.

```csharp
public struct AnsiString
{
    [MarshalAs(UnmanagedType.LPStr)]
    public string str;
}
```

```cpp
struct AnsiString
{
    char* str;
};
```

```csharp
public struct UnicodeString
{
    [MarshalAs(UnmanagedType.LPWStr)]
    public string str;
}
```

```cpp
struct UnicodeString
{
    char16_t* str; // Could also be wchar_t* on Windows.
};
```

If you want to marshal your strings using the UTF-8 encoding, you can use the <xref:System.Runtime.InteropServices.UnmanagedType.LPUTF8Str?displayProperty=nameWithType> value in your <xref:System.Runtime.InteropServices.MarshalAsAttribute>.


```csharp
public struct UTF8String
{
    [MarshalAs(UnmanagedType.LPUTF8Str)]
    public string str;
}
```

```cpp
struct UTF8String
{
    char* str;
};
```

> [!NOTE]
> Using <xref:System.Runtime.InteropServices.UnmanagedType.LPUTF8Str?displayProperty=nameWithType> requires either .NET Framework 4.7+ or .NET Core 1.1+. It isn't available in .NET Standard 2.0.

If you are working with COM APIs, you may need to marshal your string as a `BSTR`. Using the <xref:System.Runtime.InteropServices.UnmanagedType.BStr?displayProperty=nameWithType> value, you can marshal your string as a `BSTR`.

```csharp
public struct BString
{
    [MarshalAs(UnmanagedType.BStr)]
    public string str;
}
```

```cpp
struct BString
{
    BSTR str;
};
```

When using a WinRT-based API, you may need to marshal your string as an `HSTRING`.  Using the <xref:System.Runtime.InteropServices.UnmanagedType.HString?displayProperty=nameWithType> value, you can marshal your string as a `HSTRING`.

```csharp
public struct HString
{
    [MarshalAs(UnmanagedType.HString)]
    public string str;
}
```

```cpp
struct BString
{
    HSTRING str;
};
```

In the case that your API requires you to pass the string in-place in the structure, you can use the <xref:System.Runtime.InteropServices.UnmanagedType.ByValTStr?displayProperty=nameWithType> value. Do note that the encoding for a string marshalled by `ByValTStr` is determined from the `CharSet` attribute. Additionally, it requires that a string length is passed by the <xref:System.Runtime.InteropServices.MarshalAsAttribute.SizeConst?displayProperty=nameWithType> field.

```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct DefaultString
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
    public string str;
}
```

```cpp
struct DefaultString
{
    char str[4];
};
```

```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DefaultString
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
    public string str;
}
```

```cpp
struct DefaultString
{
    char16_t str[4]; // Could also be wchar_t[4] on Windows.
};
```

#### Customizing Decimal Marshalling

If you are working on Windows, you might encounter some APIs that use the native [`CY` or `CURRENCY`](https://docs.microsoft.com/windows/desktop/api/wtypes/ns-wtypes-tagcy) structure. By default, the .NET `decimal` type marshals to the native [`DECIMAL`](https://docs.microsoft.com/windows/desktop/api/wtypes/ns-wtypes-tagdec) structure. However, you can use a <xref:System.Runtime.InteropServices.MarshalAsAttribute> with the <xref:System.Runtime.InteropServices.UnmanagedType.Currency?displayProperty=nameWithType> value to instruct the marshaler to convert your `decimal` value to a native `CY` value.


```csharp
public struct Currency
{
    [MarshalAs(UnmanagedType.Currency)]
    public decimal dec;
}
```

```cpp
struct Currency
{
    CY dec;
};
```

#### Marshalling `System.Object`s

On Windows, you can marshal `object`-typed fields to native code. You can marshal these fields to one of three types, [`VARIANT`](https://docs.microsoft.com/windows/desktop/api/oaidl/ns-oaidl-tagvariant), [`IUnknown*`](https://docs.microsoft.com/windows/desktop/api/unknwn/nn-unknwn-iunknown), or [`IDispatch*`](https://docs.microsoft.com/windows/desktop/api/oaidl/nn-oaidl-idispatch). By default, an `object`-typed field will be marshalled to an `IUnknown*` that wraps the object.

```csharp
public struct ObjectDefault
{
    public object obj;
}
```

```cpp
struct ObjectDefault
{
    IUnknown* obj;
};
```

If you want to marshal your object field to an `IDispatch*`, add a <xref:System.Runtime.InteropServices.MarshalAsAttribute> with the <xref:System.Runtime.InteropServices.UnmanagedType.IDispatch?displayProperty=nameWithType> value.

```csharp
public struct ObjectDispatch
{
    [MarshalAs(UnmanagedType.IDispatch)]
    public object obj;
}
```

```cpp
struct ObjectDispatch
{
    IDispatch* obj;
};
```

If you want to marshal it as a `VARIANT`, add a <xref:System.Runtime.InteropServices.MarshalAsAttribute> with the <xref:System.Runtime.InteropServices.UnmanagedType.Struct?displayProperty=nameWithType> value.

```csharp
public struct ObjectVariant
{
    [MarshalAs(UnmanagedType.Struct)]
    public object obj;
}
```

```cpp
struct ObjectVariant
{
    VARIANT obj;
};
```

The table below describes how different runtime types of the `obj` field map to the various types stored in a `VARIANT`.

| .NET Type | VARIANT Type | | .NET Type | VARIANT Type |
|------------|--------------|-|----------|--------------|
|  `byte`  | `VT_UI1` |     | `System.Runtime.InteropServices.BStrWrapper` | `VT_BSTR` |
| `sbyte`  | `VT_I1`  |     | `object`  | `VT_DISPATCH` |
| `short`  | `VT_I2`  |     | `System.Runtime.InteropServices.UnknownWrapper` | `VT_UNKNOWN` |
| `ushort` | `VT_UI2` |     | `System.Runtime.InteropServices.DispatchWrapper` | `VT_DISPATCH` |
| `int`    | `VT_I4`  |     | `System.Reflection.Missing` | `VT_ERROR` |
| `uint`   | `VT_UI4` |     | `(object)null` | `VT_EMPTY` |
| `long`   | `VT_I8`  |     | `bool` | `VT_BOOL` |
| `ulong`  | `VT_UI8` |     | `System.DateTime` | `VT_DATE` |
| `float`  | `VT_R4`  |     | `decimal` | `VT_DECIMAL` |
| `double` | `VT_R8`  |     | `System.Runtime.InteropServices.CurrencyWrapper` | `VT_CURRENCY` |
| `char`   | `VT_UI2` |     | `System.DBNull` | `VT_NULL` |
| `string` | `VT_BSTR`|
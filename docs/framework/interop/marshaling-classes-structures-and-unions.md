---
title: "Marshaling Classes, Structures, and Unions"
description: Review how to marshal classes, structures, and unions. View samples of marshaling classes, structures with nested structures, arrays of structures, and unions.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "data marshaling, classes"
  - "marshaling, unions"
  - "marshaling, structures"
  - "marshaling, samples"
  - "data marshaling, structures"
  - "platform invoke, marshaling data"
  - "marshaling, classes"
  - "data marshaling, unions"
  - "data marshaling, samples"
  - "data marshaling, platform invoke"
  - "marshaling, platform invoke"
ms.assetid: 027832a2-9b43-4fd9-9b45-7f4196261a4e
---
# Marshaling Classes, Structures, and Unions

Classes and structures are similar in the .NET Framework. Both can have fields, properties, and events. They can also have static and nonstatic methods. One notable difference is that structures are value types and classes are reference types.

The following table lists marshaling options for classes, structures, and unions; describes their usage; and provides a link to the corresponding platform invoke sample.

|Type|Description|Sample|
|----------|-----------------|------------|
|Class by value.|Passes a class with integer members as an In/Out parameter, like the managed case.|[SysTime sample](#systime-sample)|
|Structure by value.|Passes structures as In parameters.|[Structures sample](#structures-sample)|
|Structure by reference.|Passes structures as In/Out parameters.|[OSInfo sample](/previous-versions/dotnet/netframework-4.0/795sy883(v=vs.100))|
|Structure with nested structures (flattened).|Passes a class that represents a structure with nested structures in the unmanaged function. The structure is flattened to one big structure in the managed prototype.|[FindFile sample](#findfile-sample)|
|Structure with a pointer to another structure.|Passes a structure that contains a pointer to a second structure as a member.|[Structures Sample](#structures-sample)|
|Array of structures with integers by value.|Passes an array of structures that contain only integers as an In/Out parameter. Members of the array can be changed.|[Arrays Sample](marshaling-different-types-of-arrays.md)|
|Array of structures with integers and strings by reference.|Passes an array of structures that contain integers and strings as an Out parameter. The called function allocates memory for the array.|[OutArrayOfStructs Sample](#outarrayofstructs-sample)|
|Unions with value types.|Passes unions with value types (integer and double).|[Unions sample](#unions-sample)|
|Unions with mixed types.|Passes unions with mixed types (integer and string).|[Unions sample](#unions-sample)|
|Struct with platform-specific layout.|Passes a type with native-packing definitions.|[Platform sample](#platform-sample)|
|Null values in structure.|Passes a null reference (**Nothing** in Visual Basic) instead of a reference to a value type.|[HandleRef sample](/previous-versions/dotnet/netframework-3.0/hc662t8k(v=vs.85))|

## Structures sample

This sample demonstrates how to pass a structure that points to a second structure, pass a structure with an embedded structure, and pass a structure with an embedded array.  
  
The Structs sample uses the following unmanaged functions, shown with their original function declaration:

- **TestStructInStruct** exported from PinvokeLib.dll.

    ```cpp
    int TestStructInStruct(MYPERSON2* pPerson2);
    ```

- **TestStructInStruct3** exported from PinvokeLib.dll.

    ```cpp
    void TestStructInStruct3(MYPERSON3 person3);
    ```

- **TestArrayInStruct** exported from PinvokeLib.dll.

    ```cpp
    void TestArrayInStruct(MYARRAYSTRUCT* pStruct);
    ```

[PinvokeLib.dll](marshaling-data-with-platform-invoke.md#pinvokelibdll) is a custom unmanaged library that contains implementations for the previously listed functions and four structures: **MYPERSON**, **MYPERSON2**, **MYPERSON3**, and **MYARRAYSTRUCT**. These structures contain the following elements:

```cpp
typedef struct _MYPERSON
{
   char* first;
   char* last;
} MYPERSON, *LP_MYPERSON;

typedef struct _MYPERSON2
{
   MYPERSON* person;
   int age;
} MYPERSON2, *LP_MYPERSON2;

typedef struct _MYPERSON3
{
   MYPERSON person;
   int age;
} MYPERSON3;

typedef struct _MYARRAYSTRUCT
{
   bool flag;
   int vals[ 3 ];
} MYARRAYSTRUCT;
```

The managed `MyPerson`, `MyPerson2`, `MyPerson3`, and `MyArrayStruct` structures have the following characteristic:

- `MyPerson` contains only string members. The [CharSet](specifying-a-character-set.md) field sets the strings to ANSI format when passed to the unmanaged function.

- `MyPerson2` contains an **IntPtr** to the `MyPerson` structure. The **IntPtr** type replaces the original pointer to the unmanaged structure because .NET Framework applications do not use pointers unless the code is marked **unsafe**.

- `MyPerson3` contains `MyPerson` as an embedded structure. A structure embedded within another structure can be flattened by placing the elements of the embedded structure directly into the main structure, or it can be left as an embedded structure, as is done in this sample.

- `MyArrayStruct` contains an array of integers. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute sets the <xref:System.Runtime.InteropServices.UnmanagedType> enumeration value to **ByValArray**, which is used to indicate the number of elements in the array.

For all structures in this sample, the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute is applied to ensure that the members are arranged in memory sequentially, in the order in which they appear.

The `NativeMethods` class contains managed prototypes for the `TestStructInStruct`, `TestStructInStruct3`, and `TestArrayInStruct` methods called by the `App` class. Each prototype declares a single parameter, as follows:

- `TestStructInStruct` declares a reference to type `MyPerson2` as its parameter.

- `TestStructInStruct3` declares type `MyPerson3` as its parameter and passes the parameter by value.

- `TestArrayInStruct` declares a reference to type `MyArrayStruct` as its parameter.

Structures as arguments to methods are passed by value unless the parameter contains the **ref** (**ByRef** in Visual Basic) keyword. For example, the `TestStructInStruct` method passes a reference (the value of an address) to an object of type `MyPerson2` to unmanaged code. To manipulate the structure that `MyPerson2` points to, the sample creates a buffer of a specified size and returns its address by combining the <xref:System.Runtime.InteropServices.Marshal.AllocCoTaskMem%2A?displayProperty=nameWithType> and <xref:System.Runtime.InteropServices.Marshal.SizeOf%2A?displayProperty=nameWithType> methods. Next, the sample copies the content of the managed structure to the unmanaged buffer. Finally, the sample uses the <xref:System.Runtime.InteropServices.Marshal.PtrToStructure%2A?displayProperty=nameWithType> method to marshal data from the unmanaged buffer to a managed object and the <xref:System.Runtime.InteropServices.Marshal.FreeCoTaskMem%2A?displayProperty=nameWithType> method to free the unmanaged block of memory.

### Declaring Prototypes

[!code-cpp[Conceptual.Interop.Marshaling#23](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/structures.cpp#23)]
[!code-csharp[Conceptual.Interop.Marshaling#23](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/structures.cs#23)]
[!code-vb[Conceptual.Interop.Marshaling#23](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/structures.vb#23)]

### Calling Functions

[!code-cpp[Conceptual.Interop.Marshaling#24](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/structures.cpp#24)]
[!code-csharp[Conceptual.Interop.Marshaling#24](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/structures.cs#24)]
[!code-vb[Conceptual.Interop.Marshaling#24](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/structures.vb#24)]

## FindFile sample

This sample demonstrates how to pass a structure that contains a second, embedded structure to an unmanaged function. It also demonstrates how to use the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to declare a fixed-length array within the structure. In this sample, the embedded structure elements are added to the parent structure. For a sample of an embedded structure that is not flattened, see [Structures Sample](/previous-versions/dotnet/netframework-4.0/eadtsekz(v=vs.100)).

The FindFile sample uses the following unmanaged function, shown with its original function declaration:

- **FindFirstFile** exported from Kernel32.dll.

    ```cpp
    HANDLE FindFirstFile(LPCTSTR lpFileName, LPWIN32_FIND_DATA lpFindFileData);
    ```

The original structure passed to the function contains the following elements:

```cpp
typedef struct _WIN32_FIND_DATA
{
  DWORD    dwFileAttributes;
  FILETIME ftCreationTime;
  FILETIME ftLastAccessTime;
  FILETIME ftLastWriteTime;
  DWORD    nFileSizeHigh;
  DWORD    nFileSizeLow;
  DWORD    dwReserved0;
  DWORD    dwReserved1;
  TCHAR    cFileName[ MAX_PATH ];
  TCHAR    cAlternateFileName[ 14 ];
} WIN32_FIND_DATA, *PWIN32_FIND_DATA;
```

In this sample, the `FindData` class contains a corresponding data member for each element of the original structure and the embedded structure. In place of two original character buffers, the class substitutes strings. **MarshalAsAttribute** sets the <xref:System.Runtime.InteropServices.UnmanagedType> enumeration to **ByValTStr**, which is used to identify the inline, fixed-length character arrays that appear within the unmanaged structures.

The `NativeMethods` class contains a managed prototype of the `FindFirstFile` method, which passes the `FindData` class as a parameter. The parameter must be declared with the <xref:System.Runtime.InteropServices.InAttribute> and <xref:System.Runtime.InteropServices.OutAttribute> attributes because classes, which are reference types, are passed as In parameters by default.

### Declaring Prototypes

[!code-cpp[Conceptual.Interop.Marshaling#17](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/findfile.cpp#17)]
[!code-csharp[Conceptual.Interop.Marshaling#17](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/findfile.cs#17)]
[!code-vb[Conceptual.Interop.Marshaling#17](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/findfile.vb#17)]

### Calling Functions

[!code-cpp[Conceptual.Interop.Marshaling#18](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/findfile.cpp#18)]
[!code-csharp[Conceptual.Interop.Marshaling#18](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/findfile.cs#18)]
 [!code-vb[Conceptual.Interop.Marshaling#18](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/findfile.vb#18)]

## Unions sample

This sample demonstrates how to pass structures containing only value types, and structures containing a value type and a string as parameters to an unmanaged function expecting a union. A union represents a memory location that can be shared by two or more variables.

The Unions sample uses the following unmanaged function, shown with its original function declaration:

- **TestUnion** exported from PinvokeLib.dll.

    ```cpp
    void TestUnion(MYUNION u, int type);
    ```

[PinvokeLib.dll](marshaling-data-with-platform-invoke.md#pinvokelibdll) is a custom unmanaged library that contains an implementation for the previously listed function and two unions, **MYUNION** and **MYUNION2**. The unions contain the following elements:

```cpp
union MYUNION
{
    int number;
    double d;
}

union MYUNION2
{
    int i;
    char str[128];
};
```

In managed code, unions are defined as structures. The `MyUnion` structure contains two value types as its members: an integer and a double. The <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute is set to control the precise position of each data member. The <xref:System.Runtime.InteropServices.FieldOffsetAttribute> attribute provides the physical position of fields within the unmanaged representation of a union. Notice that both members have the same offset values, so the members can define the same piece of memory.

`MyUnion2_1` and `MyUnion2_2` contain a value type (integer) and a string, respectively. In managed code, value types and reference types are not permitted to overlap. This sample uses method overloading to enable the caller to use both types when calling the same unmanaged function. The layout of `MyUnion2_1` is explicit and has a precise offset value. In contrast, `MyUnion2_2` has a sequential layout, because explicit layouts are not permitted with reference types. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute sets the <xref:System.Runtime.InteropServices.UnmanagedType> enumeration to **ByValTStr**, which is used to identify the inline, fixed-length character arrays that appear within the unmanaged representation of the union.

The `NativeMethods` class contains the prototypes for the `TestUnion` and `TestUnion2` methods. `TestUnion2` is overloaded to declare `MyUnion2_1` or `MyUnion2_2` as parameters.

### Declaring Prototypes

[!code-cpp[Conceptual.Interop.Marshaling#28](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/unions.cpp#28)]
[!code-csharp[Conceptual.Interop.Marshaling#28](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/unions.cs#28)]
[!code-vb[Conceptual.Interop.Marshaling#28](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/unions.vb#28)]

### Calling Functions

[!code-cpp[Conceptual.Interop.Marshaling#29](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/unions.cpp#29)]
[!code-csharp[Conceptual.Interop.Marshaling#29](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/unions.cs#29)]
[!code-vb[Conceptual.Interop.Marshaling#29](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/unions.vb#29)]

## Platform sample

In some scenarios, `struct` and `union` layouts can differ depending on the targeted platform. For example, consider the [`STRRET`](/windows/win32/api/shtypes/ns-shtypes-strret) type when defined in a COM scenario:

```c++
#include <pshpack8.h> /* Defines the packing of the struct */
typedef struct _STRRET
    {
    UINT uType;
    /* [switch_is][switch_type] */ union
        {
        /* [case()][string] */ LPWSTR pOleStr;
        /* [case()] */ UINT uOffset;
        /* [case()] */ char cStr[ 260 ];
        }  DUMMYUNIONNAME;
    }  STRRET;
#include <poppack.h>
```

The above `struct` is declared with Windows' headers that influence the memory layout of the type. When defined in a managed environment, these layout details are needed to properly interoperate with native code.

The correct managed definition of this type in a 32-bit process is:

``` CSharp
[StructLayout(LayoutKind.Explicit, Size = 264)]
public struct STRRET_32
{
    [FieldOffset(0)]
    public uint uType;

    [FieldOffset(4)]
    public IntPtr pOleStr;

    [FieldOffset(4)]
    public uint uOffset;

    [FieldOffset(4)]
    public IntPtr cStr;
}
```

On a 64-bit process, the size *and* field offsets are different. The correct layout is:

``` CSharp
[StructLayout(LayoutKind.Explicit, Size = 272)]
public struct STRRET_64
{
    [FieldOffset(0)]
    public uint uType;

    [FieldOffset(8)]
    public IntPtr pOleStr;

    [FieldOffset(8)]
    public uint uOffset;

    [FieldOffset(8)]
    public IntPtr cStr;
}
```

Failure to properly consider the native layout in an interop scenario can result in random crashes or worse, incorrect computations.

By default, .NET assemblies can run in both a 32-bit and 64-bit version of the .NET runtime. The app must wait until run time to decide which of the previous definitions to use.

The following code snippet shows an example of how to choose between the 32-bit and 64-bit definition at run time.

```csharp
if (IntPtr.Size == 8)
{
    // Use the STRRET_64 definition
}
else
{
    Debug.Assert(IntPtr.Size == 4);
    // Use the STRRET_32 definition
}
```

## SysTime sample

This sample demonstrates how to pass a pointer to a class to an unmanaged function that expects a pointer to a structure.

The SysTime sample uses the following unmanaged function, shown with its original function declaration:

- **GetSystemTime** exported from Kernel32.dll.

    ```cpp
    VOID GetSystemTime(LPSYSTEMTIME lpSystemTime);
    ```

The original structure passed to the function contains the following elements:

```cpp
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

In this sample, the `SystemTime` class contains the elements of the original structure represented as class members. The <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute is set to ensure that the members are arranged in memory sequentially, in the order in which they appear.

The `NativeMethods` class contains a managed prototype of the `GetSystemTime` method, which passes the `SystemTime` class as an In/Out parameter by default. The parameter must be declared with the <xref:System.Runtime.InteropServices.InAttribute> and <xref:System.Runtime.InteropServices.OutAttribute> attributes because classes, which are reference types, are passed as In parameters by default. For the caller to receive the results, these [directional attributes](/previous-versions/dotnet/netframework-4.0/77e6taeh(v=vs.100)) must be applied explicitly. The `App` class creates a new instance of the `SystemTime` class and accesses its data fields.

### Code Samples

[!code-cpp[Conceptual.Interop.Marshaling#25](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/systime.cpp#25)]
[!code-csharp[Conceptual.Interop.Marshaling#25](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/systime.cs#25)]
[!code-vb[Conceptual.Interop.Marshaling#25](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/systime.vb#25)]

## OutArrayOfStructs sample

This sample shows how to pass an array of structures that contains integers and strings as Out parameters to an unmanaged function.

This sample demonstrates how to call a native function by using the <xref:System.Runtime.InteropServices.Marshal> class and by using unsafe code.

This sample uses a wrapper functions and platform invokes defined in [PinvokeLib.dll](marshaling-data-with-platform-invoke.md#pinvokelibdll), also provided in the source files. It uses the `TestOutArrayOfStructs` function and the `MYSTRSTRUCT2` structure. The structure contains the following elements:

```cpp
typedef struct _MYSTRSTRUCT2
{
   char* buffer;
   UINT size;
} MYSTRSTRUCT2;
```

The `MyStruct` class contains a string object of ANSI characters. The <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet> field specifies ANSI format. `MyUnsafeStruct`, is a structure containing an <xref:System.IntPtr> type instead of a string.

The `NativeMethods` class contains the overloaded `TestOutArrayOfStructs` prototype method. If a method declares a pointer as a parameter, the class should be marked with the `unsafe` keyword. Because Visual Basic cannot use unsafe code, the overloaded method, unsafe modifier, and the `MyUnsafeStruct` structure are unnecessary.

The `App` class implements the `UsingMarshaling` method, which performs all the tasks necessary to pass the array. The array is marked with the `out` (`ByRef` in Visual Basic) keyword to indicate that data passes from callee to caller. The implementation uses the following <xref:System.Runtime.InteropServices.Marshal> class methods:

- <xref:System.Runtime.InteropServices.Marshal.PtrToStructure%2A> to marshal data from the unmanaged buffer to a managed object.

- <xref:System.Runtime.InteropServices.Marshal.DestroyStructure%2A> to release the memory reserved for strings in the structure.

- <xref:System.Runtime.InteropServices.Marshal.FreeCoTaskMem%2A> to release the memory reserved for the array.

As previously mentioned, C# allows unsafe code and Visual Basic does not. In the C# sample, `UsingUnsafePointer` is an alternative method implementation that uses pointers instead of the <xref:System.Runtime.InteropServices.Marshal> class to pass back the array containing the `MyUnsafeStruct` structure.

### Declaring Prototypes

[!code-cpp[Conceptual.Interop.Marshaling#20](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/outarrayofstructs.cpp#20)]
[!code-csharp[Conceptual.Interop.Marshaling#20](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/outarrayofstructs.cs#20)]
[!code-vb[Conceptual.Interop.Marshaling#20](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/outarrayofstructs.vb#20)]

### Calling Functions

[!code-cpp[Conceptual.Interop.Marshaling#21](~/samples/snippets/cpp/VS_Snippets_CLR/conceptual.interop.marshaling/cpp/outarrayofstructs.cpp#21)]
[!code-csharp[Conceptual.Interop.Marshaling#21](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.interop.marshaling/cs/outarrayofstructs.cs#21)]
[!code-vb[Conceptual.Interop.Marshaling#21](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interop.marshaling/vb/outarrayofstructs.vb#21)]

## See also

- [Marshaling Data with Platform Invoke](marshaling-data-with-platform-invoke.md)
- [Marshaling Strings](marshaling-strings.md)
- [Marshaling Different Types of Arrays](marshaling-different-types-of-arrays.md)

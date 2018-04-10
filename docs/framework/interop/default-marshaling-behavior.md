---
title: "Default Marshaling Behavior"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "interop marshaling, default"
  - "interoperation with unmanaged code, marshaling"
  - "marshaling behavior"
ms.assetid: c0a9bcdf-3df8-4db3-b1b6-abbdb2af809a
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Default Marshaling Behavior
Interop marshaling operates on rules that dictate how data associated with method parameters behaves as it passes between managed and unmanaged memory. These built-in rules control such marshaling activities as data type transformations, whether a callee can change data passed to it and return those changes to the caller, and under which circumstances the marshaler provides performance optimizations.  
  
 This section identifies the default behavioral characteristics of the interop marshaling service. It presents detailed information on marshaling arrays, Boolean types, char types, delegates, classes, objects, strings, and structures.  
  
> [!NOTE]
>  Marshaling of generic types is not supported. For more information see, [Interoperating Using Generic Types](https://msdn.microsoft.com/library/26b88e03-085b-4b53-94ba-a5a9c709ce58(v=vs.100)).  
  
## Memory management with the interop marshaler  
 The interop marshaler always attempts to free memory allocated by unmanaged code. This behavior complies with COM memory management rules, but differs from the rules that govern native C++.  
  
 Confusion can arise if you anticipate native C++ behavior (no memory freeing) when using platform invoke, which automatically frees memory for pointers. For example, calling the following unmanaged method from a C++ DLL does not automatically free any memory.  
  
### Unmanaged signature  
  
```  
BSTR MethodOne (BSTR b) {  
     return b;  
}  
```  
  
 However, if you define the method as a platform invoke prototype, replace each **BSTR** type with a <xref:System.String> type, and call `MethodOne`, the common language runtime attempts to free `b` twice. You can change the marshaling behavior by using <xref:System.IntPtr> types rather than **String** types.  
  
 The runtime always uses the **CoTaskMemFree** method to free memory. If the memory you are working with was not allocated with the **CoTaskMemAlloc** method, you must use an **IntPtr** and free the memory manually using the appropriate method. Similarly, you can avoid automatic memory freeing in situations where memory should never be freed, such as when using the **GetCommandLine** function from Kernel32.dll, which returns a pointer to kernel memory. For details on manually freeing memory, see the [Buffers Sample](http://msdn.microsoft.com/library/e30d36e8-d7c4-4936-916a-8fdbe4d9ffd5(v=vs.100)).  
  
## Default marshaling for classes  
 Classes can be marshaled only by COM interop and are always marshaled as interfaces. In some cases the interface used to marshal the class is known as the class interface. For information about overriding the class interface with an interface of your choice, see [Introducing the class interface](com-callable-wrapper.md#introducing-the-class-interface).  
  
### Passing Classes to COM  
 When a managed class is passed to COM, the interop marshaler automatically wraps the class with a COM proxy and passes the class interface produced by the proxy to the COM method call. The proxy then delegates all calls on the class interface back to the managed object. The proxy also exposes other interfaces that are not explicitly implemented by the class. The proxy automatically implements interfaces such as **IUnknown** and **IDispatch** on behalf of the class.  
  
### Passing Classes to .NET Code  
 Coclasses are not typically used as method arguments in COM. Instead, a default interface is usually passed in place of the coclass.  
  
 When an interface is passed into managed code, the interop marshaler is responsible for wrapping the interface with the proper wrapper and passing the wrapper to the managed method. Determining which wrapper to use can be difficult. Every instance of a COM object has a single, unique wrapper, no matter how many interfaces the object implements. For example, a single COM object that implements five distinct interfaces has only one wrapper. The same wrapper exposes all five interfaces. If two instances of the COM object are created, then two instances of the wrapper are created.  
  
 For the wrapper to maintain the same type throughout its lifetime, the interop marshaler must identify the correct wrapper the first time an interface exposed by the object is passed through the marshaler. The marshaler identifies the object by looking at one of the interfaces the object implements.  
  
 For example, the marshaler determines that the class wrapper should be used to wrap the interface that was passed into managed code. When the interface is first passed through the marshaler, the marshaler checks whether the interface is coming from a known object. This check occurs in two situations:  
  
-   An interface is being implemented by another managed object that was passed to COM elsewhere. The marshaler can readily identify interfaces exposed by managed objects and is able to match the interface with the managed object that provides the implementation. The managed object is then passed to the method and no wrapper is needed.  
  
-   An object that has already been wrapped is implementing the interface. To determine whether this is the case, the marshaler queries the object for its **IUnknown** interface and compares the returned interface to the interfaces of other objects that are already wrapped. If the interface is the same as that of another wrapper, the objects have the same identity and the existing wrapper is passed to the method.  
  
 If an interface is not from a known object, the marshaler does the following:  
  
1.  The marshaler queries the object for the **IProvideClassInfo2** interface. If provided, the marshaler uses the CLSID returned from **IProvideClassInfo2.GetGUID** to identify the coclass providing the interface. With the CLSID, the marshaler can locate the wrapper from the registry if the assembly has previously been registered.  
  
2.  The marshaler queries the interface for the **IProvideClassInfo** interface. If provided, the marshaler uses the **ITypeInfo** returned from **IProvideClassInfo.GetClassinfo** to determine the CLSID of the class exposing the interface. The marshaler can use the CLSID to locate the metadata for the wrapper.  
  
3.  If the marshaler still cannot identify the class, it wraps the interface with a generic wrapper class called **System.__ComObject**.  
  
## Default marshaling for delegates  
 A managed delegate is marshaled as a COM interface or as a function pointer, based on the calling mechanism:  
  
-   For platform invoke, a delegate is marshaled as an unmanaged function pointer by default.  
  
-   For COM interop, a delegate is marshaled as a COM interface of type **_Delegate** by default. The **_Delegate** interface is defined in the Mscorlib.tlb type library and contains the <xref:System.Delegate.DynamicInvoke%2A?displayProperty=nameWithType> method, which enables you to call the method that the delegate references.  
  
 The following table shows the marshaling options for the managed delegate data type. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal delegates.  
  
|Enumeration type|Description of unmanaged format|  
|----------------------|-------------------------------------|  
|**UnmanagedType.FunctionPtr**|An unmanaged function pointer.|  
|**UnmanagedType.Interface**|An interface of type **_Delegate**, as defined in Mscorlib.tlb.|  
  
 Consider the following example code in which the methods of `DelegateTestInterface` are exported to a COM type library. Notice that only delegates marked with the **ref** (or **ByRef**) keyword are passed as In/Out parameters.  
  
```csharp  
using System;  
using System.Runtime.InteropServices;  
  
public interface DelegateTest {  
void m1(Delegate d);  
void m2([MarshalAs(UnmanagedType.Interface)] Delegate d);     
void m3([MarshalAs(UnmanagedType.Interface)] ref Delegate d);    
void m4([MarshalAs(UnmanagedType.FunctionPtr)] Delegate d);   
void m5([MarshalAs(UnmanagedType.FunctionPtr)] ref Delegate d);     
}  
```  
  
### Type library representation  
  
```  
importlib("mscorlib.tlb");  
interface DelegateTest : IDispatch {  
[id(…)] HRESULT m1([in] _Delegate* d);  
[id(…)] HRESULT m2([in] _Delegate* d);  
[id(…)] HRESULT m3([in, out] _Delegate** d);  
[id()] HRESULT m4([in] int d);  
[id()] HRESULT m5([in, out] int *d);  
   };  
```  
  
 A function pointer can be dereferenced, just as any other unmanaged function pointer can be dereferenced.  
  
> [!NOTE]
>  A reference to the function pointer to a managed delegate held by unmanaged code does not prevent the common language runtime from performing garbage collection on the managed object.  
  
 For example, the following code is incorrect because the reference to the `cb` object, passed to the `SetChangeHandler` method, does not keep `cb` alive beyond the life of the `Test` method. Once the `cb` object is garbage collected, the function pointer passed to `SetChangeHandler` is no longer valid.  
  
```csharp  
public class ExternalAPI {  
   [DllImport("External.dll")]  
   public static extern void SetChangeHandler(  
      [MarshalAs(UnmanagedType.FunctionPtr)]ChangeDelegate d);  
}  
public delegate bool ChangeDelegate([MarshalAs(UnmanagedType.LPWStr) string S);  
public class CallBackClass {  
   public bool OnChange(string S){ return true;}  
}  
internal class DelegateTest {  
   public static void Test() {  
      CallBackClass cb = new CallBackClass();  
      // Caution: The following reference on the cb object does not keep the   
      // object from being garbage collected after the Main method   
      // executes.  
      ExternalAPI.SetChangeHandler(new ChangeDelegate(cb.OnChange));     
   }  
}  
```  
  
 To compensate for unexpected garbage collection, the caller must ensure that the `cb` object is kept alive as long as the unmanaged function pointer is in use. Optionally, you can have the unmanaged code notify the managed code when the function pointer is no longer needed, as the following example shows.  
  
```csharp  
internal class DelegateTest {  
   CallBackClass cb;  
   // Called before ever using the callback function.  
   public static void SetChangeHandler() {  
      cb = new CallBackClass();  
      ExternalAPI.SetChangeHandler(new ChangeDelegate(cb.OnChange));  
   }  
   // Called after using the callback function for the last time.  
   public static void RemoveChangeHandler() {  
      // The cb object can be collected now. The unmanaged code is   
      // finished with the callback function.  
      cb = null;  
   }  
}  
```  
  
## Default marshaling for value types  
 Most value types, such as integers and floating-point numbers, are [blittable](blittable-and-non-blittable-types.md) and do not require marshaling. Other [non-blittable](blittable-and-non-blittable-types.md) types have dissimilar representations in managed and unmanaged memory and do require marshaling. Still other types require explicit formatting across the interoperation boundary.  
  
 This topic provides the follow information on formatted value types:  
  
-   [Value Types Used in Platform Invoke](#cpcondefaultmarshalingforvaluetypesanchor2)  
  
-   [Value Types Used in COM Interop](#cpcondefaultmarshalingforvaluetypesanchor3)  
  
 In addition to describing formatted types, this topic identifies [System Value Types](#cpcondefaultmarshalingforvaluetypesanchor1) that have unusual marshaling behavior.  
  
 A formatted type is a complex type that contains information that explicitly controls the layout of its members in memory. The member layout information is provided using the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute. The layout can be one of the following <xref:System.Runtime.InteropServices.LayoutKind> enumeration values:  
  
-   **LayoutKind.Automatic**  
  
     Indicates that the common language runtime is free to reorder the members of the type for efficiency. However, when a value type is passed to unmanaged code, the layout of the members is predictable. An attempt to marshal such a structure automatically causes an exception.  
  
-   **LayoutKind.Sequential**  
  
     Indicates that the members of the type are to be laid out in unmanaged memory in the same order in which they appear in the managed type definition.  
  
-   **LayoutKind.Explicit**  
  
     Indicates that the members are laid out according to the <xref:System.Runtime.InteropServices.FieldOffsetAttribute> supplied with each field.  
  
<a name="cpcondefaultmarshalingforvaluetypesanchor2"></a>   
### Value Types Used in Platform Invoke  
 In the following example the `Point` and `Rect` types provide member layout information using the **StructLayoutAttribute**.  
  
```vb  
Imports System.Runtime.InteropServices  
<StructLayout(LayoutKind.Sequential)> Public Structure Point  
   Public x As Integer  
   Public y As Integer  
End Structure  
<StructLayout(LayoutKind.Explicit)> Public Structure Rect  
   <FieldOffset(0)> Public left As Integer  
   <FieldOffset(4)> Public top As Integer  
   <FieldOffset(8)> Public right As Integer  
   <FieldOffset(12)> Public bottom As Integer  
End Structure  
```  
  
```csharp  
using System.Runtime.InteropServices;  
[StructLayout(LayoutKind.Sequential)]  
public struct Point {  
   public int x;  
   public int y;  
}     
  
[StructLayout(LayoutKind.Explicit)]  
public struct Rect {  
   [FieldOffset(0)] public int left;  
   [FieldOffset(4)] public int top;  
   [FieldOffset(8)] public int right;  
   [FieldOffset(12)] public int bottom;  
}  
```  
  
 When marshaled to unmanaged code, these formatted types are marshaled as C-style structures. This provides an easy way of calling an unmanaged API that has structure arguments. For example, the `POINT` and `RECT` structures can be passed to the Microsoft Win32 API **PtInRect** function as follows:  
  
```  
BOOL PtInRect(const RECT *lprc, POINT pt);  
```  
  
 You can pass structures using the following platform invoke definition:  
  
```vb  
Class Win32API      
   Declare Auto Function PtInRect Lib "User32.dll" _  
    (ByRef r As Rect, p As Point) As Boolean  
End Class  
```  
  
```csharp  
class Win32API {  
   [DllImport("User32.dll")]  
   public static extern Bool PtInRect(ref Rect r, Point p);  
}  
```  
  
 The `Rect` value type must be passed by reference because the unmanaged API is expecting a pointer to a `RECT` to be passed to the function. The `Point` value type is passed by value because the unmanaged API expects the `POINT` to be passed on the stack. This subtle difference is very important. References are passed to unmanaged code as pointers. Values are passed to unmanaged code on the stack.  
  
> [!NOTE]
>  When a formatted type is marshaled as a structure, only the fields within the type are accessible. If the type has methods, properties, or events, they are inaccessible from unmanaged code.  
  
 Classes can also be marshaled to unmanaged code as C-style structures, provided they have fixed member layout. The member layout information for a class is also provided with the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute. The main difference between value types with fixed layout and classes with fixed layout is the way in which they are marshaled to unmanaged code. Value types are passed by value (on the stack) and consequently any changes made to the members of the type by the callee are not seen by the caller. Reference types are passed by reference (a reference to the type is passed on the stack); consequently, all changes made to blittable-type members of a type by the callee are seen by the caller.  
  
> [!NOTE]
>  If a reference type has members of non-blittable types, conversion is required twice: the first time when an argument is passed to the unmanaged side and the second time on return from the call. Due to this added overhead, In/Out parameters must be explicitly applied to an argument if the caller wants to see changes made by the callee.  
  
 In the following example, the `SystemTime` class has sequential member layout and can be passed to the Win32 API **GetSystemTime** function.  
  
```vb  
<StructLayout(LayoutKind.Sequential)> Public Class SystemTime  
   Public wYear As System.UInt16  
   Public wMonth As System.UInt16  
   Public wDayOfWeek As System.UInt16  
   Public wDay As System.UInt16  
   Public wHour As System.UInt16  
   Public wMinute As System.UInt16  
   Public wSecond As System.UInt16  
   Public wMilliseconds As System.UInt16  
End Class  
```  
  
```csharp  
[StructLayout(LayoutKind.Sequential)]  
   public class SystemTime {  
   public ushort wYear;   
   public ushort wMonth;  
   public ushort wDayOfWeek;   
   public ushort wDay;   
   public ushort wHour;   
   public ushort wMinute;   
   public ushort wSecond;   
   public ushort wMilliseconds;   
}  
```  
  
 The **GetSystemTime** function is defined as follows:  
  
```  
void GetSystemTime(SYSTEMTIME* SystemTime);  
```  
  
 The equivalent platform invoke definition for **GetSystemTime** is as follows:  
  
```vb  
Public Class Win32  
   Declare Auto Sub GetSystemTime Lib "Kernel32.dll" (ByVal sysTime _  
   As SystemTime)  
End Class  
```  
  
```csharp  
class Win32API {  
   [DllImport("Kernel32.dll", CharSet=CharSet.Auto)]  
   public static extern void GetSystemTime(SystemTime st);  
}  
```  
  
 Notice that the `SystemTime` argument is not typed as a reference argument because `SystemTime` is a class, not a value type. Unlike value types, classes are always passed by reference.  
  
 The following code example shows a different `Point` class that has a method called `SetXY`. Because the type has sequential layout, it can be passed to unmanaged code and marshaled as a structure. However, the `SetXY` member is not callable from unmanaged code, even though the object is passed by reference.  
  
```vb  
<StructLayout(LayoutKind.Sequential)> Public Class Point  
   Private x, y As Integer  
   Public Sub SetXY(x As Integer, y As Integer)  
      Me.x = x  
      Me.y = y  
   End Sub  
End Class  
```  
  
```csharp  
[StructLayout(LayoutKind.Sequential)]  
public class Point {  
   int x, y;  
   public void SetXY(int x, int y){   
      this.x = x;  
      this.y = y;  
   }  
}  
```  
  
<a name="cpcondefaultmarshalingforvaluetypesanchor3"></a>   
### Value Types Used in COM Interop  
 Formatted types can also be passed to COM interop method calls. In fact, when exported to a type library, value types are automatically converted to structures. As the following example shows, the `Point` value type becomes a type definition (typedef) with the name `Point`. All references to the `Point` value type elsewhere in the type library are replaced with the `Point` typedef.  
  
 **Type library representation**  
  
```  
typedef struct tagPoint {  
   int x;  
   int y;  
} Point;  
interface _Graphics {  
   …  
   HRESULT SetPoint ([in] Point p)  
   HRESULT SetPointRef ([in,out] Point *p)  
   HRESULT GetPoint ([out,retval] Point *p)  
}  
```  
  
 The same rules used to marshal values and references to platform invoke calls are used when marshaling through COM interfaces. For example, when an instance of the `Point` value type is passed from the .NET Framework to COM, the `Point` is passed by value. If the `Point` value type is passed by reference, a pointer to a `Point` is passed on the stack. The interop marshaler does not support higher levels of indirection (**Point \*\***) in either direction.  
  
> [!NOTE]
>  Structures having the <xref:System.Runtime.InteropServices.LayoutKind> enumeration value set to **Explicit** cannot be used in COM interop because the exported type library cannot express an explicit layout.  
  
<a name="cpcondefaultmarshalingforvaluetypesanchor1"></a>   
### System Value Types  
 The <xref:System> namespace has several value types that represent the boxed form of the runtime primitive types. For example, the value type <xref:System.Int32?displayProperty=nameWithType> structure represents the boxed form of **ELEMENT_TYPE_I4**. Instead of marshaling these types as structures, as other formatted types are, you marshal them in the same way as the primitive types they box. **System.Int32** is therefore marshaled as **ELEMENT_TYPE_I4** instead of as a structure containing a single member of type **long**. The following table contains a list of the value types in the **System** namespace that are boxed representations of primitive types.  
  
|System value type|Element type|  
|-----------------------|------------------|  
|<xref:System.Boolean?displayProperty=nameWithType>|**ELEMENT_TYPE_BOOLEAN**|  
|<xref:System.SByte?displayProperty=nameWithType>|**ELEMENT_TYPE_I1**|  
|<xref:System.Byte?displayProperty=nameWithType>|**ELEMENT_TYPE_UI1**|  
|<xref:System.Char?displayProperty=nameWithType>|**ELEMENT_TYPE_CHAR**|  
|<xref:System.Int16?displayProperty=nameWithType>|**ELEMENT_TYPE_I2**|  
|<xref:System.UInt16?displayProperty=nameWithType>|**ELEMENT_TYPE_U2**|  
|<xref:System.Int32?displayProperty=nameWithType>|**ELEMENT_TYPE_I4**|  
|<xref:System.UInt32?displayProperty=nameWithType>|**ELEMENT_TYPE_U4**|  
|<xref:System.Int64?displayProperty=nameWithType>|**ELEMENT_TYPE_I8**|  
|<xref:System.UInt64?displayProperty=nameWithType>|**ELEMENT_TYPE_U8**|  
|<xref:System.Single?displayProperty=nameWithType>|**ELEMENT_TYPE_R4**|  
|<xref:System.Double?displayProperty=nameWithType>|**ELEMENT_TYPE_R8**|  
|<xref:System.String?displayProperty=nameWithType>|**ELEMENT_TYPE_STRING**|  
|<xref:System.IntPtr?displayProperty=nameWithType>|**ELEMENT_TYPE_I**|  
|<xref:System.UIntPtr?displayProperty=nameWithType>|**ELEMENT_TYPE_U**|  
  
 Some other value types in the **System** namespace are handled differently. Because the unmanaged code already has well-established formats for these types, the marshaler has special rules for marshaling them. The following table lists the special value types in the **System** namespace, as well as the unmanaged type they are marshaled to.  
  
|System value type|IDL type|  
|-----------------------|--------------|  
|<xref:System.DateTime?displayProperty=nameWithType>|**DATE**|  
|<xref:System.Decimal?displayProperty=nameWithType>|**DECIMAL**|  
|<xref:System.Guid?displayProperty=nameWithType>|**GUID**|  
|<xref:System.Drawing.Color?displayProperty=nameWithType>|**OLE_COLOR**|  
  
 The following code shows the definition of the unmanaged types **DATE**, **GUID**, **DECIMAL**, and **OLE_COLOR** in the Stdole2 type library.  
  
#### Type library representation  
  
```  
typedef double DATE;  
typedef DWORD OLE_COLOR;  
  
typedef struct tagDEC {  
    USHORT    wReserved;  
    BYTE      scale;  
    BYTE      sign;  
    ULONG     Hi32;  
    ULONGLONG Lo64;  
} DECIMAL;  
  
typedef struct tagGUID {  
    DWORD Data1;  
    WORD  Data2;  
    WORD  Data3;  
    BYTE  Data4[ 8 ];  
} GUID;  
```  
  
 The following code shows the corresponding definitions in the managed `IValueTypes` interface.  
  
```vb  
Public Interface IValueTypes  
   Sub M1(d As System.DateTime)  
   Sub M2(d As System.Guid)  
   Sub M3(d As System.Decimal)  
   Sub M4(d As System.Drawing.Color)  
End Interface  
```  
  
```csharp  
public interface IValueTypes {  
   void M1(System.DateTime d);  
   void M2(System.Guid d);  
   void M3(System.Decimal d);  
   void M4(System.Drawing.Color d);  
}  
```  
  
#### Type library representation  
  
```  
[…]  
interface IValueTypes : IDispatch {  
   HRESULT M1([in] DATE d);  
   HRESULT M2([in] GUID d);  
   HRESULT M3([in] DECIMAL d);  
   HRESULT M4([in] OLE_COLOR d);  
};  
```  
  
## See Also  
 [Blittable and Non-Blittable Types](blittable-and-non-blittable-types.md)  
 [Copying and Pinning](copying-and-pinning.md)  
 [Default Marshaling for Arrays](default-marshaling-for-arrays.md)  
 [Default Marshaling for Objects](default-marshaling-for-objects.md)  
 [Default Marshaling for Strings](default-marshaling-for-strings.md)

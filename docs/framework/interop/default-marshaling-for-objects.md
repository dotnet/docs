---
title: "Default Marshaling for Objects"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "objects, interop marshaling"
  - "interop marshaling, objects"
ms.assetid: c2ef0284-b061-4e12-b6d3-6a502b9cc558
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Default Marshaling for Objects
Parameters and fields typed as <xref:System.Object?displayProperty=nameWithType> can be exposed to unmanaged code as one of the following types:  
  
-   A variant when the object is a parameter.  
  
-   An interface when the object is a structure field.  
  
 Only COM interop supports marshaling for object types. The default behavior is to marshal objects to COM variants. These rules apply only to the type **Object** and do not apply to strongly typed objects that derive from the **Object** class.  
  
 This topic provides the following additional information about marshaling object types:  
  
-   [Marshaling Options](#cpcondefaultmarshalingforobjectsanchor7)  
  
-   [Marshaling Object to Interface](#cpcondefaultmarshalingforobjectsanchor2)  
  
-   [Marshaling Object to Variant](#cpcondefaultmarshalingforobjectsanchor3)  
  
-   [Marshaling Variant to Object](#cpcondefaultmarshalingforobjectsanchor4)  
  
-   [Marshaling ByRef Variants](#cpcondefaultmarshalingforobjectsanchor6)  
  
<a name="cpcondefaultmarshalingforobjectsanchor7"></a>   
## Marshaling Options  
 The following table shows the marshaling options for the **Object** data type. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal objects.  
  
|Enumeration type|Description of unmanaged format|  
|----------------------|-------------------------------------|  
|**UnmanagedType.Struct**<br /><br /> (default for parameters)|A COM-style variant.|  
|**UnmanagedType.Interface**|An **IDispatch** interface, if possible; otherwise, an **IUnknown** interface.|  
|**UnmanagedType.IUnknown**<br /><br /> (default for fields)|An **IUnknown** interface.|  
|**UnmanagedType.IDispatch**|An **IDispatch** interface.|  
  
 The following example shows the managed interface definition for `MarshalObject`.  
  
```vb  
Interface MarshalObject  
   Sub SetVariant(o As Object)  
   Sub SetVariantRef(ByRef o As Object)  
   Function GetVariant() As Object  
  
   Sub SetIDispatch( <MarshalAs(UnmanagedType.IDispatch)> o As Object)  
   Sub SetIDispatchRef(ByRef <MarshalAs(UnmanagedType.IDispatch)> o _  
      As Object)  
   Function GetIDispatch() As <MarshalAs(UnmanagedType.IDispatch)> Object  
   Sub SetIUnknown( <MarshalAs(UnmanagedType.IUnknown)> o As Object)  
   Sub SetIUnknownRef(ByRef <MarshalAs(UnmanagedType.IUnknown)> o _  
      As Object)  
   Function GetIUnknown() As <MarshalAs(UnmanagedType.IUnknown)> Object  
End Interface  
```  
  
```csharp  
interface MarshalObject {  
   void SetVariant(Object o);  
   void SetVariantRef(ref Object o);  
   Object GetVariant();  
  
   void SetIDispatch ([MarshalAs(UnmanagedType.IDispatch)]Object o);  
   void SetIDispatchRef([MarshalAs(UnmanagedType.IDispatch)]ref Object o);  
   [MarshalAs(UnmanagedType.IDispatch)] Object GetIDispatch();  
   void SetIUnknown ([MarshalAs(UnmanagedType.IUnknown)]Object o);  
   void SetIUnknownRef([MarshalAs(UnmanagedType.IUnknown)]ref Object o);  
   [MarshalAs(UnmanagedType.IUnknown)] Object GetIUnknown();  
}  
```  
  
 The following code exports the `MarshalObject` interface to a type library.  
  
```  
interface MarshalObject {  
   HRESULT SetVariant([in] VARIANT o);  
   HRESULT SetVariantRef([in,out] VARIANT *o);  
   HRESULT GetVariant([out,retval] VARIANT *o)   
   HRESULT SetIDispatch([in] IDispatch *o);  
   HRESULT SetIDispatchRef([in,out] IDispatch **o);  
   HRESULT GetIDispatch([out,retval] IDispatch **o)   
   HRESULT SetIUnknown([in] IUnknown *o);  
   HRESULT SetIUnknownRef([in,out] IUnknown **o);  
   HRESULT GetIUnknown([out,retval] IUnknown **o)   
}  
```  
  
> [!NOTE]
>  The interop marshaler automatically frees any allocated object inside the variant after the call.  
  
 The following example shows a formatted value type.  
  
```vb  
Public Structure ObjectHolder  
   Dim o1 As Object  
   <MarshalAs(UnmanagedType.IDispatch)> Public o2 As Object  
End Structure  
```  
  
```csharp  
public struct ObjectHolder {  
   Object o1;  
   [MarshalAs(UnmanagedType.IDispatch)]public Object o2;  
}  
```  
  
 The following code exports the formatted type to a type library.  
  
```  
struct ObjectHolder {  
   VARIANT o1;  
   IDispatch *o2;  
}  
```  
  
<a name="cpcondefaultmarshalingforobjectsanchor2"></a>   
## Marshaling Object to Interface  
 When an object is exposed to COM as an interface, that interface is the class interface for the managed type <xref:System.Object> (the **_Object** interface). This interface is typed as an **IDispatch** (<xref:System.Runtime.InteropServices.UnmanagedType>) or an **IUnknown** (**UnmanagedType.IUnknown**) in the resulting type library. COM clients can dynamically invoke the members of the managed class or any members implemented by its derived classes through the **_Object** interface. The client can also call **QueryInterface** to obtain any other interface explicitly implemented by the managed type.  
  
<a name="cpcondefaultmarshalingforobjectsanchor3"></a>   
## Marshaling Object to Variant  
 When an object is marshaled to a variant, the internal variant type is determined at run time, based on the following rules:  
  
-   If the object reference is null (**Nothing** in Visual Basic), the object is marshaled to a variant of type **VT_EMPTY**.  
  
-   If the object is an instance of any type listed in the following table, the resulting variant type is determined by the rules built into the marshaler and shown in the table.  
  
-   Other objects that need to explicitly control the marshaling behavior can implement the <xref:System.IConvertible> interface. In that case, the variant type is determined by the type code returned from the <xref:System.IConvertible.GetTypeCode%2A?displayProperty=nameWithType> method. Otherwise, the object is marshaled as a variant of type **VT_UNKNOWN**.  
  
### Marshaling System Types to Variant  
 The following table shows managed object types and their corresponding COM variant types. These types are converted only when the signature of the method being called is of type <xref:System.Object?displayProperty=nameWithType>.  
  
|Object type|COM variant type|  
|-----------------|----------------------|  
|Null object reference (**Nothing** in Visual Basic).|**VT_EMPTY**|  
|<xref:System.DBNull?displayProperty=nameWithType>|**VT_NULL**|  
|<xref:System.Runtime.InteropServices.ErrorWrapper?displayProperty=nameWithType>|**VT_ERROR**|  
|<xref:System.Reflection.Missing?displayProperty=nameWithType>|**VT_ERROR** with **E_PARAMNOTFOUND**|  
|<xref:System.Runtime.InteropServices.DispatchWrapper?displayProperty=nameWithType>|**VT_DISPATCH**|  
|<xref:System.Runtime.InteropServices.UnknownWrapper?displayProperty=nameWithType>|**VT_UNKNOWN**|  
|<xref:System.Runtime.InteropServices.CurrencyWrapper?displayProperty=nameWithType>|**VT_CY**|  
|<xref:System.Boolean?displayProperty=nameWithType>|**VT_BOOL**|  
|<xref:System.SByte?displayProperty=nameWithType>|**VT_I1**|  
|<xref:System.Byte?displayProperty=nameWithType>|**VT_UI1**|  
|<xref:System.Int16?displayProperty=nameWithType>|**VT_I2**|  
|<xref:System.UInt16?displayProperty=nameWithType>|**VT_UI2**|  
|<xref:System.Int32?displayProperty=nameWithType>|**VT_I4**|  
|<xref:System.UInt32?displayProperty=nameWithType>|**VT_UI4**|  
|<xref:System.Int64?displayProperty=nameWithType>|**VT_I8**|  
|<xref:System.UInt64?displayProperty=nameWithType>|**VT_UI8**|  
|<xref:System.Single?displayProperty=nameWithType>|**VT_R4**|  
|<xref:System.Double?displayProperty=nameWithType>|**VT_R8**|  
|<xref:System.Decimal?displayProperty=nameWithType>|**VT_DECIMAL**|  
|<xref:System.DateTime?displayProperty=nameWithType>|**VT_DATE**|  
|<xref:System.String?displayProperty=nameWithType>|**VT_BSTR**|  
|<xref:System.IntPtr?displayProperty=nameWithType>|**VT_INT**|  
|<xref:System.UIntPtr?displayProperty=nameWithType>|**VT_UINT**|  
|<xref:System.Array?displayProperty=nameWithType>|**VT_ARRAY**|  
  
 Using the `MarshalObject` interface defined in the previous example, the following code example demonstrates how to pass various types of variants to a COM server.  
  
```vb  
Dim mo As New MarshalObject()  
mo.SetVariant(Nothing)         ' Marshal as variant of type VT_EMPTY.  
mo.SetVariant(System.DBNull.Value) ' Marshal as variant of type VT_NULL.  
mo.SetVariant(CInt(27))        ' Marshal as variant of type VT_I2.  
mo.SetVariant(CLng(27))        ' Marshal as variant of type VT_I4.  
mo.SetVariant(CSng(27.0))      ' Marshal as variant of type VT_R4.  
mo.SetVariant(CDbl(27.0))      ' Marshal as variant of type VT_R8.  
```  
  
```csharp  
MarshalObject mo = new MarshalObject();  
mo.SetVariant(null);            // Marshal as variant of type VT_EMPTY.  
mo.SetVariant(System.DBNull.Value); // Marshal as variant of type VT_NULL.  
mo.SetVariant((int)27);          // Marshal as variant of type VT_I2.  
mo.SetVariant((long)27);          // Marshal as variant of type VT_I4.  
mo.SetVariant((single)27.0);   // Marshal as variant of type VT_R4.  
mo.SetVariant((double)27.0);   // Marshal as variant of type VT_R8.  
```  
  
 COM types that do not have corresponding managed types can be marshaled using wrapper classes such as <xref:System.Runtime.InteropServices.ErrorWrapper>, <xref:System.Runtime.InteropServices.DispatchWrapper>, <xref:System.Runtime.InteropServices.UnknownWrapper>, and <xref:System.Runtime.InteropServices.CurrencyWrapper>. The following code example demonstrates how to use these wrappers to pass various types of variants to a COM server.  
  
```vb  
Imports System.Runtime.InteropServices  
' Pass inew as a variant of type VT_UNKNOWN interface.  
mo.SetVariant(New UnknownWrapper(inew))  
' Pass inew as a variant of type VT_DISPATCH interface.  
mo.SetVariant(New DispatchWrapper(inew))  
' Pass a value as a variant of type VT_ERROR interface.  
mo.SetVariant(New ErrorWrapper(&H80054002))  
' Pass a value as a variant of type VT_CURRENCY interface.  
mo.SetVariant(New CurrencyWrapper(New Decimal(5.25)))  
```  
  
```csharp  
using System.Runtime.InteropServices;  
// Pass inew as a variant of type VT_UNKNOWN interface.  
mo.SetVariant(new UnknownWrapper(inew));  
// Pass inew as a variant of type VT_DISPATCH interface.  
mo.SetVariant(new DispatchWrapper(inew));  
// Pass a value as a variant of type VT_ERROR interface.  
mo.SetVariant(new ErrorWrapper(0x80054002));  
// Pass a value as a variant of type VT_CURRENCY interface.  
mo.SetVariant(new CurrencyWrapper(new Decimal(5.25)));  
```  
  
 The wrapper classes are defined in the <xref:System.Runtime.InteropServices> namespace.  
  
### Marshaling the IConvertible Interface to Variant  
 Types other than those listed in the previous section can control how they are marshaled by implementing the <xref:System.IConvertible> interface. If the object implements the **IConvertible** interface, the COM variant type is determined at run time by the value of the <xref:System.TypeCode> enumeration returned from the <xref:System.IConvertible.GetTypeCode%2A?displayProperty=nameWithType> method.  
  
 The following table shows the possible values for the **TypeCode** enumeration and the corresponding COM variant type for each value.  
  
|TypeCode|COM variant type|  
|--------------|----------------------|  
|**TypeCode.Empty**|**VT_EMPTY**|  
|**TypeCode.Object**|**VT_UNKNOWN**|  
|**TypeCode.DBNull**|**VT_NULL**|  
|**TypeCode.Boolean**|**VT_BOOL**|  
|**TypeCode.Char**|**VT_UI2**|  
|**TypeCode.Sbyte**|**VT_I1**|  
|**TypeCode.Byte**|**VT_UI1**|  
|**TypeCode.Int16**|**VT_I2**|  
|**TypeCode.UInt16**|**VT_UI2**|  
|**TypeCode.Int32**|**VT_I4**|  
|**TypeCode.UInt32**|**VT_UI4**|  
|**TypeCode.Int64**|**VT_I8**|  
|**TypeCode.UInt64**|**VT_UI8**|  
|**TypeCode.Single**|**VT_R4**|  
|**TypeCode.Double**|**VT_R8**|  
|**TypeCode.Decimal**|**VT_DECIMAL**|  
|**TypeCode.DateTime**|**VT_DATE**|  
|**TypeCode.String**|**VT_BSTR**|  
|Not supported.|**VT_INT**|  
|Not supported.|**VT_UINT**|  
|Not supported.|**VT_ARRAY**|  
|Not supported.|**VT_RECORD**|  
|Not supported.|**VT_CY**|  
|Not supported.|**VT_VARIANT**|  
  
 The value of the COM variant is determined by calling the **IConvertible.To** *Type* interface, where **To** *Type* is the conversion routine that corresponds to the type that was returned from **IConvertible.GetTypeCode**. For example, an object that returns **TypeCode.Double** from **IConvertible.GetTypeCode** is marshaled as a COM variant of type **VT_R8**. You can obtain the value of the variant (stored in the **dblVal** field of the COM variant) by casting to the **IConvertible** interface and calling the <xref:System.IConvertible.ToDouble%2A> method.  
  
<a name="cpcondefaultmarshalingforobjectsanchor4"></a>   
## Marshaling Variant to Object  
 When marshaling a variant to an object, the type, and sometimes the value, of the marshaled variant determines the type of object produced. The following table identifies each variant type and the corresponding object type that the marshaler creates when a variant is passed from COM to the .NET Framework.  
  
|COM variant type|Object type|  
|----------------------|-----------------|  
|**VT_EMPTY**|Null object reference (**Nothing** in Visual Basic).|  
|**VT_NULL**|<xref:System.DBNull?displayProperty=nameWithType>|  
|**VT_DISPATCH**|**System.__ComObject** or null if (pdispVal == null)|  
|**VT_UNKNOWN**|**System.__ComObject** or null if (punkVal == null)|  
|**VT_ERROR**|<xref:System.UInt32?displayProperty=nameWithType>|  
|**VT_BOOL**|<xref:System.Boolean?displayProperty=nameWithType>|  
|**VT_I1**|<xref:System.SByte?displayProperty=nameWithType>|  
|**VT_UI1**|<xref:System.Byte?displayProperty=nameWithType>|  
|**VT_I2**|<xref:System.Int16?displayProperty=nameWithType>|  
|**VT_UI2**|<xref:System.UInt16?displayProperty=nameWithType>|  
|**VT_I4**|<xref:System.Int32?displayProperty=nameWithType>|  
|**VT_UI4**|<xref:System.UInt32?displayProperty=nameWithType>|  
|**VT_I8**|<xref:System.Int64?displayProperty=nameWithType>|  
|**VT_UI8**|<xref:System.UInt64?displayProperty=nameWithType>|  
|**VT_R4**|<xref:System.Single?displayProperty=nameWithType>|  
|**VT_R8**|<xref:System.Double?displayProperty=nameWithType>|  
|**VT_DECIMAL**|<xref:System.Decimal?displayProperty=nameWithType>|  
|**VT_DATE**|<xref:System.DateTime?displayProperty=nameWithType>|  
|**VT_BSTR**|<xref:System.String?displayProperty=nameWithType>|  
|**VT_INT**|<xref:System.Int32?displayProperty=nameWithType>|  
|**VT_UINT**|<xref:System.UInt32?displayProperty=nameWithType>|  
|**VT_ARRAY** &#124; **VT_\***|<xref:System.Array?displayProperty=nameWithType>|  
|**VT_CY**|<xref:System.Decimal?displayProperty=nameWithType>|  
|**VT_RECORD**|Corresponding boxed value type.|  
|**VT_VARIANT**|Not supported.|  
  
 Variant types passed from COM to managed code and then back to COM might not retain the same variant type for the duration of the call. Consider what happens when a variant of type **VT_DISPATCH** is passed from COM to the .NET Framework. During marshaling, the variant is converted to a <xref:System.Object?displayProperty=nameWithType>. If the **Object** is then passed back to COM, it is marshaled back to a variant of type **VT_UNKNOWN**. There is no guarantee that the variant produced when an object is marshaled from managed code to COM will be the same type as the variant initially used to produce the object.  
  
<a name="cpcondefaultmarshalingforobjectsanchor6"></a>   
## Marshaling ByRef Variants  
 Although variants themselves can be passed by value or by reference, the **VT_BYREF** flag can also be used with any variant type to indicate that the contents of the variant are being passed by reference instead of by value. The difference between marshaling variants by reference and marshaling a variant with the **VT_BYREF** flag set can be confusing. The following illustration clarifies the differences.  
  
 ![Variant passed on the stack](./media/interopvariant.gif "interopvariant")  
Variants passed by value and by reference  
  
 **Default behavior for marshaling objects and variants by value**  
  
-   When passing objects from managed code to COM, the contents of the object are copied into a new variant created by the marshaler, using the rules defined in [Marshaling Object to Variant](#cpcondefaultmarshalingforobjectsanchor3). Changes made to the variant on the unmanaged side are not propagated back to the original object on return from the call.  
  
-   When passing variants from COM to managed code, the contents of the variant are copied to a newly created object, using the rules defined in [Marshaling Variant to Object](#cpcondefaultmarshalingforobjectsanchor4). Changes made to the object on the managed side are not propagated back to the original variant on return from the call.  
  
 **Default behavior for marshaling objects and variants by reference**  
  
 To propagate changes back to the caller, the parameters must be passed by reference. For example, you can use the **ref** keyword in C# (or **ByRef** in Visual Basic managed code) to pass parameters by reference. In COM, reference parameters are passed using a pointer such as a **variant \***.  
  
-   When passing an object to COM by reference, the marshaler creates a new variant and copies the contents of the object reference into the variant before the call is made. The variant is passed to the unmanaged function where the user is free to change the contents of the variant. On return from the call, any changes made to the variant on the unmanaged side are propagated back to the original object. If the type of the variant differs from the type of the variant passed to the call, then the changes are propagated back to an object of a different type. That is, the type of the object passed into the call can differ from the type of the object returned from the call.  
  
-   When passing a variant to managed code by reference, the marshaler creates a new object and copies the contents of the variant into the object before making the call. A reference to the object is passed to the managed function, where the user is free to change the object. On return from the call, any changes made to the referenced object are propagated back to the original variant. If the type of the object differs from the type of the object passed in to the call, the type of the original variant is changed and the value is propagated back into the variant. Again, the type of the variant passed into the call can differ from the type of the variant returned from the call.  
  
 **Default behavior for marshaling a variant with the VT_BYREF flag set**  
  
-   A variant being passed to managed code by value can have the **VT_BYREF** flag set to indicate that the variant contains a reference instead of a value. In this case, the variant is still marshaled to an object because the variant is being passed by value. The marshaler automatically dereferences the contents of the variant and copies it into a newly created object before making the call. The object is then passed into the managed function; however, on return from the call, the object is not propagated back into the original variant. Changes made to the managed object are lost.  
  
    > [!CAUTION]
    >  There is no way to change the value of a variant passed by value, even if the variant has the **VT_BYREF** flag set.  
  
-   A variant being passed to managed code by reference can also have the **VT_BYREF** flag set to indicate that the variant contains another reference. If it does, the variant is marshaled to a **ref** object because the variant is being passed by reference. The marshaler automatically dereferences the contents of the variant and copies it into a newly created object before making the call. On return from the call, the value of the object is propagated back to the reference within the original variant only if the object is the same type as the object passed in. That is, propagation does not change the type of a variant with the **VT_BYREF** flag set. If the type of the object is changed during the call, an <xref:System.InvalidCastException> occurs on return from the call.  
  
 The following table summarizes the propagation rules for variants and objects.  
  
|From|To|Changes propagated back|  
|----------|--------|-----------------------------|  
|**Variant**  *v*|**Object**  *o*|Never|  
|**Object**  *o*|**Variant**  *v*|Never|  
|**Variant**   ***\****  *pv*|**Ref Object**  *o*|Always|  
|**Ref object**  *o*|**Variant**   ***\****  *pv*|Always|  
|**Variant**  *v* **(VT_BYREF** *&#124;* **VT_\*)**|**Object**  *o*|Never|  
|**Variant**  *v* **(VT_BYREF** *&#124;* **VT_)**|**Ref Object**  *o*|Only if the type has not changed.|  
  
## See Also  
 [Default Marshaling Behavior](default-marshaling-behavior.md)  
 [Blittable and Non-Blittable Types](blittable-and-non-blittable-types.md)  
 [Directional Attributes](https://msdn.microsoft.com/library/241ac5b5-928e-4969-8f58-1dbc048f9ea2(v=vs.100))  
 [Copying and Pinning](copying-and-pinning.md)

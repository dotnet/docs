---
title: "Default Marshaling for Arrays"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "interop marshaling, arrays"
  - "arrays, interop marshaling"
ms.assetid: 8a3cca8b-dd94-4e3d-ad9a-9ee7590654bc
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Default Marshaling for Arrays
In an application consisting entirely of managed code, the common language runtime passes array types as In/Out parameters. In contrast, the interop marshaler passes an array as In parameters by default.  
  
 With [pinning optimization](copying-and-pinning.md), a blittable array can appear to operate as an In/Out parameter when interacting with objects in the same apartment. However, if you later export the code to a type library used to generate the cross-machine proxy, and that library is used to marshal your calls across apartments, the calls can revert to true In parameter behavior.  
  
 Arrays are complex by nature, and the distinctions between managed and unmanaged arrays warrant more information than other non-blittable types. This topic provides the following information on marshaling arrays:  
  
-   [Managed Arrays](#cpcondefaultmarshalingforarraysanchor1)  
  
-   [Unmanaged Arrays](#cpcondefaultmarshalingforarraysanchor2)  
  
-   [Passing Array Parameters to .NET Code](#cpcondefaultmarshalingforarraysanchor3)  
  
-   [Passing Arrays to COM](#cpcondefaultmarshalingforarraysanchor4)  
  
<a name="cpcondefaultmarshalingforarraysanchor1"></a>   
## Managed Arrays  
 Managed array types can vary; however, the <xref:System.Array?displayProperty=nameWithType> class is the base class of all array types. The **System.Array** class has properties for determining the rank, length, and lower and upper bounds of an array, as well as methods for accessing, sorting, searching, copying, and creating arrays.  
  
 These array types are dynamic and do not have a corresponding static type defined in the base class library. It is convenient to think of each combination of element type and rank as a distinct type of array. Therefore, a one-dimensional array of integers is of a different type than a one-dimensional array of double types. Similarly a two-dimensional array of integers is different from a one-dimensional array of integers. The bounds of the array are not considered when comparing types.  
  
 As the following table shows, any instance of a managed array must be of a specific element type, rank, and lower bound.  
  
|Managed array type|Element type|Rank|Lower bound|Signature notation|  
|------------------------|------------------|----------|-----------------|------------------------|  
|**ELEMENT_TYPE_ARRAY**|Specified by type.|Specified by rank.|Optionally specified by bounds.|*type* **[** *n*,*m* **]**|  
|**ELEMENT_TYPE_CLASS**|Unknown|Unknown|Unknown|**System.Array**|  
|**ELEMENT_TYPE_SZARRAY**|Specified by type.|1|0|*type* **[** *n* **]**|  
  
<a name="cpcondefaultmarshalingforarraysanchor2"></a>   
## Unmanaged Arrays  
 Unmanaged arrays are either COM-style safe arrays or C-style arrays with fixed or variable length. Safe arrays are self-describing arrays that carry the type, rank, and bounds of the associated array data. C-style arrays are one-dimensional typed arrays with a fixed lower bound of 0. The marshaling service has limited support for both types of arrays.  
  
<a name="cpcondefaultmarshalingforarraysanchor3"></a>   
## Passing Array Parameters to .NET Code  
 Both C-style arrays and safe arrays can be passed to .NET code from unmanaged code as either a safe array or a C-style array. The following table shows the unmanaged type value and the imported type.  
  
|Unmanaged type|Imported type|  
|--------------------|-------------------|  
|**SafeArray(** *Type* **)**|**ELEMENT_TYPE_SZARRAY** **\<** *ConvertedType* **>**<br /><br /> Rank = 1, lower bound = 0. Size is known only if provided in the managed signature. Safe arrays that are not rank = 1 or lower bound = 0 cannot be marshaled as **SZARRAY**.|  
|*Type*  **[]**|**ELEMENT_TYPE_SZARRAY** **\<** *ConvertedType* **>**<br /><br /> Rank = 1, lower bound = 0. Size is known only if provided in the managed signature.|  
  
### Safe Arrays  
 When a safe array is imported from a type library to a .NET assembly, the array is converted to a one-dimensional array of a known type (such as **int**). The same type conversion rules that apply to parameters also apply to array elements. For example, a safe array of **BSTR** types becomes a managed array of strings and a safe array of variants becomes a managed array of objects. The **SAFEARRAY** element type is captured from the type library and saved in the **SAFEARRAY** value of the <xref:System.Runtime.InteropServices.UnmanagedType> enumeration.  
  
 Because the rank and bounds of the safe array cannot be determined from the type library, the rank is assumed to equal 1 and the lower bound is assumed to equal 0. The rank and bounds must be defined in the managed signature produced by the [Type Library Importer (Tlbimp.exe)](../tools/tlbimp-exe-type-library-importer.md). If the rank passed to the method at run time differs, a <xref:System.Runtime.InteropServices.SafeArrayRankMismatchException> is thrown. If the type of the array passed at run time differs, a <xref:System.Runtime.InteropServices.SafeArrayTypeMismatchException> is thrown. The following example shows safe arrays in managed and unmanaged code.  
  
 **Unmanaged signature**  
  
```  
HRESULT New1([in] SAFEARRAY( int ) ar);  
HRESULT New2([in] SAFEARRAY( DATE ) ar);  
HRESULT New3([in, out] SAFEARRAY( BSTR ) *ar);  
```  
  
 **Managed signature**  
  
```vb  
Sub New1(<MarshalAs(UnmanagedType.SafeArray, SafeArraySubType:=VT_I4)> _  
   ar() As Integer)  
Sub New2(<MarshalAs(UnmanagedType.SafeArray, SafeArraySubType:=VT_DATE)> _   
   ar() As DateTime)  
Sub New3(ByRef <MarshalAs(UnmanagedType.SafeArray, SafeArraySubType:=VT_BSTR)> _   
   ar() As String)  
```  
  
```csharp  
void New1([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VT_I4)] int[] ar) ;  
void New2([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VT_DATE)]   
   DateTime[] ar);  
void New3([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType=VT_BSTR)]   
   ref String[] ar);  
```  
  
 Multidimensional, or nonzero-bound safe arrays, can be marshaled into managed code if the method signature produced by Tlbimp.exe is modified to indicate an element type of **ELEMENT_TYPE_ARRAY** instead of **ELEMENT_TYPE_SZARRAY**. Alternatively, you can use the **/sysarray** switch with Tlbimp.exe to import all arrays as <xref:System.Array?displayProperty=nameWithType> objects. In cases where the array being passed is known to be multidimensional, you can edit the Microsoft intermediate language (MSIL) code produced by Tlbimp.exe and then recompile it. For details about how to modify MSIL code, see [Customizing Runtime Callable Wrappers](https://msdn.microsoft.com/library/4652beaf-77d0-4f37-9687-ca193288c0be(v=vs.100)).  
  
### C-Style Arrays  
 When a C-style array is imported from a type library to a .NET assembly, the array is converted to **ELEMENT_TYPE_SZARRAY**.  
  
 The array element type is determined from the type library and preserved during the import. The same conversion rules that apply to parameters also apply to array elements. For example, an array of **LPStr** types becomes an array of **String** types. Tlbimp.exe captures the array element type and applies the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to the parameter.  
  
 The array rank is assumed to equal 1. If the rank is greater than 1, the array is marshaled as a one-dimensional array in column-major order. The lower bound always equals 0.  
  
 Type libraries can contain arrays of fixed or variable length. Tlbimp.exe can import only fixed-length arrays from type libraries because type libraries lack the information needed to marshal variable-length arrays. With fixed-length arrays, the size is imported from the type library and captured in the **MarshalAsAttribute** that is applied to the parameter.  
  
 You must manually define type libraries containing variable-length arrays, as shown in the following example.  
  
 **Unmanaged signature**  
  
```  
HRESULT New1(int ar[10]);  
HRESULT New2(double ar[10][20]);  
HRESULT New3(LPWStr ar[10]);  
```  
  
 **Managed signature**  
  
```vb  
Sub New1(<MarshalAs(UnmanagedType.LPArray, SizeConst=10)> _  
   ar() As Integer)  
Sub New2(<MarshalAs(UnmanagedType.LPArray, SizeConst=200)> _  
   ar() As Double)  
Sub New2(<MarshalAs(UnmanagedType.LPArray, _  
   ArraySubType=UnmanagedType.LPWStr, SizeConst=10)> _  
   ar() As String)  
```  
  
```csharp  
void New1([MarshalAs(UnmanagedType.LPArray, SizeConst=10)] int[] ar);  
void New2([MarshalAs(UnmanagedType.LPArray, SizeConst=200)] double[] ar);  
void New2([MarshalAs(UnmanagedType.LPArray,   
   ArraySubType=UnmanagedType.LPWStr, SizeConst=10)] String[] ar);  
```  
  
 Although you can apply the **size_is** or **length_is** attributes to an array in Interface Definition Language (IDL) source to convey the size to a client, the Microsoft Interface Definition Language (MIDL) compiler does not propagate that information to the type library. Without knowing the size, the interop marshaling service cannot marshal the array elements. Consequently, variable-length arrays are imported as reference arguments. For example:  
  
 **Unmanaged signature**  
  
```  
HRESULT New1(int ar[]);  
HRESULT New2(int ArSize, [size_is(ArSize)] double ar[]);  
HRESULT New3(int ElemCnt, [length_is(ElemCnt)] LPStr ar[]);  
```  
  
 **Managed signature**  
  
```vb  
Sub New1(ByRef ar As Integer)  
Sub New2(ByRef ar As Double)  
Sub New3(ByRef ar As String)  
```  
  
```csharp  
void New1(ref int ar);    
void New2(ref double ar);    
void New3(ref String ar);   
```  
  
 You can provide the marshaler with the array size by editing the Microsoft intermediate language (MSIL) code produced by Tlbimp.exe and then recompiling it. For details about how to modify MSIL code, see [Customizing Runtime Callable Wrappers](https://msdn.microsoft.com/library/4652beaf-77d0-4f37-9687-ca193288c0be(v=vs.100)). To indicate the number of elements in the array, apply the <xref:System.Runtime.InteropServices.MarshalAsAttribute> type to the array parameter of the managed method definition in one of the following ways:  
  
-   Identify another parameter that contains the number of elements in the array. The parameters are identified by position, starting with the first parameter as number 0.     
  
    ```vb  
    Sub [New](ElemCnt As Integer, _  
       \<MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> _  
       ar() As Integer)  
    ```  
  
    ```csharp  
    void New(  
       int ElemCnt,   
       [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] int[] ar );  
    ```  
  
-   Define the size of the array as a constant. For example:  
  
    ```vb  
    Sub [New](\<MarshalAs(UnmanagedType.LPArray, SizeConst:=128)> _  
       ar() As Integer)  
    ```  
  
    ```csharp  
    void New(  
       [MarshalAs(UnmanagedType.LPArray, SizeConst=128)] int[] ar );  
    ```  
  
 When marshaling arrays from unmanaged code to managed code, the marshaler checks the **MarshalAsAttribute** associated with the parameter to determine the array size. If the array size is not specified, only one element is marshaled.  
  
> [!NOTE]
>  The **MarshalAsAttribute** has no effect on marshaling managed arrays to unmanaged code. In that direction, the array size is determined by examination. There is no way to marshal a subset of a managed array.  
  
 The interop marshaler uses the **CoTaskMemAlloc** and **CoTaskMemFree** methods to allocate and retrieve memory. Memory allocation performed by unmanaged code must also use these methods.  
  
<a name="cpcondefaultmarshalingforarraysanchor4"></a>   
## Passing Arrays to COM  
 All managed array types can be passed to unmanaged code from managed code. Depending on the managed type and the attributes applied to it, the array can be accessed as a safe array or a C-style array, as shown in the following table.  
  
|Managed array type|Exported as|  
|------------------------|-----------------|  
|**ELEMENT_TYPE_SZARRAY** **\<** *type* **>**|<xref:System.Runtime.InteropServices.UnmanagedType> **.SafeArray(** *type* **)**<br /><br /> **UnmanagedType.LPArray**<br /><br /> Type is provided in the signature. Rank is always 1, lower bound is always 0. Size is always known at run time.|  
|**ELEMENT_TYPE_ARRAY** **\<** *type* **>** **\<** *rank* **>**[**\<** *bounds* **>**]|**UnmanagedType.SafeArray(** *type* **)**<br /><br /> **UnmanagedType.LPArray**<br /><br /> Type, rank, bounds are provided in the signature. Size is always known at run time.|  
|**ELEMENT_TYPE_CLASS** **\<**<xref:System.Array?displayProperty=nameWithType>**>**|**UT_Interface**<br /><br /> **UnmanagedType.SafeArray(** *type* **)**<br /><br /> Type, rank, bounds, and size are always known at run time.|  
  
 There is a limitation in OLE Automation relating to arrays of structures that contain LPSTR or LPWSTR.  Therefore, **String** fields have to be marshaled as **UnmanagedType.BSTR**. Otherwise, an exception will be thrown.  
  
### ELEMENT_TYPE_SZARRAY  
 When a method containing an **ELEMENT_TYPE_SZARRAY** parameter (one-dimensional array) is exported from a .NET assembly to a type library, the array parameter is converted to a **SAFEARRAY** of a given type. The same conversion rules apply to the array element types. The contents of the managed array are automatically copied from managed memory into the **SAFEARRAY**. For example:  
  
#### Managed signature  
  
```vb  
Sub [New](ar() As Long)  
Sub [New](ar() As String)  
```  
  
```csharp  
void New(long[] ar );  
void New(String[] ar );  
```  
  
#### Unmanaged signature  
  
```  
HRESULT New([in] SAFEARRAY( long ) ar);   
HRESULT New([in] SAFEARRAY( BSTR ) ar);  
```  
  
 The rank of the safe arrays is always 1 and the lower bound is always 0. The size is determined at run time by the size of the managed array being passed.  
  
 The array can also be marshaled as a C-style array by using the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute. For example:  
  
#### Managed signature  
  
```vb  
Sub [New](<MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> _  
   ar() As Long, size as Integer)  
Sub [New](<MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=1)> _  
   ar() As String, size as Integer)  
Sub [New](<MarshalAs(UnmanagedType.LPArray, _  
   ArraySubType= UnmanagedType.LPStr, SizeParamIndex:=1)> _  
   ar() As String, size as Integer)  
```  
  
```csharp  
void New([MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)]   
   long [] ar, int size );  
void New([MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)]   
   String [] ar, int size );  
void New([MarshalAs(UnmanagedType.LPArray, ArraySubType=   
   UnmanagedType.LPStr, SizeParamIndex=1)]   
   String [] ar, int size );  
```  
  
#### Unmanaged signature  
  
```  
HRESULT New(long ar[]);   
HRESULT New(BSTR ar[]);   
HRESULT New(LPStr ar[]);  
```  
  
 Although the marshaler has the length information needed to marshal the array, the array length is usually passed as a separate argument to convey the length to the callee.  
  
### ELEMENT_TYPE_ARRAY  
 When a method containing an **ELEMENT_TYPE_ARRAY** parameter is exported from a .NET assembly to a type library, the array parameter is converted to a **SAFEARRAY** of a given type. The contents of the managed array are automatically copied from managed memory into the **SAFEARRAY**. For example:  
  
#### Managed signature  
  
```vb  
Sub [New](ar(,) As Long)  
Sub [New](ar(,) As String)  
```  
  
```csharp  
void New( long [,] ar );  
void New( String [,] ar );  
```  
  
#### Unmanaged signature  
  
```  
HRESULT New([in] SAFEARRAY( long ) ar);   
HRESULT New([in] SAFEARRAY( BSTR ) ar);  
```  
  
 The rank, size, and bounds of the safe arrays are determined at run time by the characteristics of the managed array.  
  
 The array can also be marshaled as a C-style array by applying the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute. For example:  
  
#### Managed signature  
  
```vb  
Sub [New](<MarshalAs(UnmanagedType.LPARRAY, SizeParamIndex:=1)> _  
   ar(,) As Long, size As Integer)  
Sub [New](<MarshalAs(UnmanagedType.LPARRAY, _  
   ArraySubType:=UnmanagedType.LPStr, SizeParamIndex:=1)> _  
   ar(,) As String, size As Integer)  
```  
  
```csharp  
void New([MarshalAs(UnmanagedType.LPARRAY, SizeParamIndex=1)]   
   long [,] ar, int size );  
void New([MarshalAs(UnmanagedType.LPARRAY,   
   ArraySubType= UnmanagedType.LPStr, SizeParamIndex=1)]   
   String [,] ar, int size );  
```  
  
#### Unmanaged signature  
  
```  
HRESULT New(long ar[]);   
HRESULT New(LPStr ar[]);  
```  
  
 Nested arrays cannot be marshaled. For example, the following signature generates an error when exported with the [Type Library Exporter (Tlbexp.exe)](../tools/tlbexp-exe-type-library-exporter.md).  
  
#### Managed signature  
  
```vb  
Sub [New](ar()()() As Long)  
```  
  
```csharp  
void New(long [][][] ar );  
```  
  
### ELEMENT_TYPE_CLASS \<System.Array>  
 When a method containing a <xref:System.Array?displayProperty=nameWithType> parameter is exported from a .NET assembly to a type library, the array parameter is converted to an **_Array** interface. The contents of the managed array are accessible only through the methods and properties of the **_Array** interface. **System.Array** can also be marshaled as a **SAFEARRAY** by using the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute. When marshaled as a safe array, the array elements are marshaled as variants. For example:  
  
#### Managed signature  
  
```vb  
Sub New1( ar As System.Array )  
Sub New2( <MarshalAs(UnmanagedType.Safe array)> ar As System.Array )  
```  
  
```csharp  
void New1( System.Array ar );  
void New2( [MarshalAs(UnmanagedType.Safe array)] System.Array ar );  
```  
  
#### Unmanaged signature  
  
```  
HRESULT New([in] _Array *ar);   
HRESULT New([in] SAFEARRAY(VARIANT) ar);  
```  
  
### Arrays within Structures  
 Unmanaged structures can contain embedded arrays. By default, these embedded array fields are marshaled as a SAFEARRAY. In the following example, `s1` is an embedded array that is allocated directly within the structure itself.  
  
#### Unmanaged representation  
  
```  
struct MyStruct {  
    short s1[128];  
}  
```  
  
 Arrays can be marshaled as <xref:System.Runtime.InteropServices.UnmanagedType>, which requires you to set the <xref:System.Runtime.InteropServices.MarshalAsAttribute> field. The size can be set only as a constant. The following code shows the corresponding managed definition of `MyStruct`.  
  
```vb  
Public Structure <StructLayout(LayoutKind.Sequential)> MyStruct  
   Public <MarshalAs(UnmanagedType.ByValArray, SizeConst := 128)> _  
     s1() As Short  
End Structure  
```  
  
```csharp  
[StructLayout(LayoutKind.Sequential)]  
public struct MyStruct {  
   [MarshalAs(UnmanagedType.ByValArray, SizeConst=128)] public short[] s1;  
}  
```  
  
## See Also  
 [Default Marshaling Behavior](default-marshaling-behavior.md)  
 [Blittable and Non-Blittable Types](blittable-and-non-blittable-types.md)  
 [Directional Attributes](https://msdn.microsoft.com/library/241ac5b5-928e-4969-8f58-1dbc048f9ea2(v=vs.100))  
 [Copying and Pinning](copying-and-pinning.md)

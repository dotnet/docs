---
title: "How to: Create Wrappers Manually"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "wrappers, creating manually"
ms.assetid: cc2a70d8-6a58-4071-a8cf-ce28c018c09b
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create Wrappers Manually
If you decide to declare COM types manually in managed source code, the best place to start is with an existing Interface Definition Language (IDL) file or type library. When you do not have the IDL file or cannot generate a type library file, you can simulate the COM types by creating managed declarations and exporting the resulting assembly to a type library.  
  
### To simulate COM types from managed source  
  
1.  Declare the types in a language that is compliant with the Common Language Specification (CLS) and compile the file.  
  
2.  Export the assembly containing the types with the [Type Library Exporter (Tlbexp.exe)](../tools/tlbexp-exe-type-library-exporter.md).  
  
3.  Use the exported COM type library as a basis for declaring COM-oriented managed types.  
  
### To create a runtime callable wrapper (RCW)  
  
1.  Assuming that you have an IDL file or type library file, decide which classes and interfaces you want to include in the custom RCW. You can exclude any types that you do not intend to use directly or indirectly in your application.  
  
2.  Create a source file in a CLS-compliant language and declare the types. See [Type Library to Assembly Conversion Summary](https://msdn.microsoft.com/library/bf3f90c5-4770-4ab8-895c-3ba1055cc958(v=vs.100)) for a complete description of the import conversion process. Effectively, when you create a custom RCW, you are manually performing the type conversion activity provided by the [Type Library Importer (Tlbimp.exe)](../tools/tlbimp-exe-type-library-importer.md). The example in the next section shows types in an IDL or type library file and their corresponding types in C# code.  
  
3.  When the declarations are complete, compile the file as you compile any other managed source code.  
  
4.  As with the types imported with Tlbimp.exe, some require additional information, which you can add directly to your code. For details, see [How to: Edit Interop Assemblies](https://msdn.microsoft.com/library/16aacb20-2269-42bf-a812-b6a7df17e277(v=vs.100)).  
  
## Example  
 The following code shows an example of the `ISATest` interface and `SATest` class in IDL and the corresponding types in C# source code.  
  
 **IDL or type library file**  
  
```  
 [  
object,  
uuid(40A8C65D-2448-447A-B786-64682CBEF133),  
dual,  
helpstring("ISATest Interface"),  
pointer_default(unique)  
 ]  
interface ISATest : IDispatch  
 {  
[id(1), helpstring("method InSArray")]   
HRESULT InSArray([in] SAFEARRAY(int) *ppsa, [out,retval] int *pSum);  
 };  
 [  
uuid(116CCA1E-7E39-4515-9849-90790DA6431E),  
helpstring("SATest Class")  
 ]  
coclass SATest  
 {  
  [default] interface ISATest;  
 };  
```  
  
 **Wrapper in managed source code**  
  
```csharp  
using System;  
using System.Runtime.InteropServices;  
using System.Runtime.CompilerServices;  
  
[assembly:Guid("E4A992B8-6F5C-442C-96E7-C4778924C753")]  
[assembly:ImportedFromTypeLib("SAServerLib")]  
namespace SAServer  
{  
 [ComImport]  
 [Guid("40A8C65D-2448-447A-B786-64682CBEF133")]  
 [TypeLibType(TypeLibTypeFlags.FLicensed)]  
 public interface ISATest  
 {  
  [DispId(1)]  
  //[MethodImpl(MethodImplOptions.InternalCall,  
  // MethodCodeType=MethodCodeType.Runtime)]  
  int InSArray( [MarshalAs(UnmanagedType.SafeArray,  
      SafeArraySubType=VarEnum.VT_I4)] ref int[] param );  
 }   
 [ComImport]  
 [Guid("116CCA1E-7E39-4515-9849-90790DA6431E")]  
 [ClassInterface(ClassInterfaceType.None)]  
 [TypeLibType(TypeLibTypeFlags.FCanCreate)]  
 public class SATest : ISATest  
 {  
  [DispId(1)]  
  [MethodImpl(MethodImplOptions.InternalCall,   
  MethodCodeType=MethodCodeType.Runtime)]  
  extern int ISATest.InSArray( [MarshalAs(UnmanagedType.SafeArray,   
  SafeArraySubType=VarEnum.VT_I4)] ref int[] param );  
 }  
}  
```  
  
## See Also  
 [Customizing Runtime Callable Wrappers](https://msdn.microsoft.com/library/4652beaf-77d0-4f37-9687-ca193288c0be(v=vs.100))  
 [COM Data Types](https://msdn.microsoft.com/library/f93ae35d-a416-4218-8700-c8218cc90061(v=vs.100))  
 [How to: Edit Interop Assemblies](https://msdn.microsoft.com/library/16aacb20-2269-42bf-a812-b6a7df17e277(v=vs.100))  
 [Type Library to Assembly Conversion Summary](https://msdn.microsoft.com/library/bf3f90c5-4770-4ab8-895c-3ba1055cc958(v=vs.100))  
 [Tlbimp.exe (Type Library Importer)](../tools/tlbimp-exe-type-library-importer.md)  
 [Tlbexp.exe (Type Library Exporter)](../tools/tlbexp-exe-type-library-exporter.md)

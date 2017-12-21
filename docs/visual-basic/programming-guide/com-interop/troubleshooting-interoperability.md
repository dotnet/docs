---
title: "Troubleshooting Interoperability (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "interop, deploying assemblies"
  - "assemblies [Visual Basic]"
  - "interop, installing assemblies that share components"
  - "COM objects, troubleshooting"
  - "interop, sharing components"
  - "troubleshooting interoperability [Visual Basic]"
  - "interoperability, troubleshooting"
  - "COM interop [Visual Basic], troubleshooting"
  - "assemblies [Visual Basic], deploying"
  - "troubleshooting Visual Basic, interoperability"
  - "interop assemblies"
  - "interoperability, sharing components"
  - "shared components, using with assemblies"
ms.assetid: b324cc1e-b03c-4f39-aea6-6a6d5bfd0e37
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# Troubleshooting Interoperability (Visual Basic)
When you interoperate between COM and the managed code of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)], you may encounter one or more of the following common issues.  
  
##  <a name="vbconinteroperabilitymarshalinganchor1"></a> Interop Marshaling  
 At times, you may have to use data types that are not part of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)]. Interop assemblies handle most of the work for COM objects, but you may have to control the data types that are used when managed objects are exposed to COM. For example, structures in class libraries must specify the `BStr` unmanaged type on strings sent to COM objects created by Visual Basic 6.0 and earlier versions. In such cases, you can use the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to cause managed types to be exposed as unmanaged types.  
  
##  <a name="vbconinteroperabilitymarshalinganchor2"></a> Exporting Fixed-Length Strings to Unmanaged Code  
 In Visual Basic 6.0 and earlier versions, strings are exported to COM objects as sequences of bytes without a null termination character. For compatibility with other languages, Visual Basic .NET includes a termination character when exporting strings. The best way to address this incompatibility is to export strings that lack the termination character as arrays of `Byte` or `Char`.  
  
##  <a name="vbconinteroperabilitymarshalinganchor3"></a> Exporting Inheritance Hierarchies  
 Managed class hierarchies flatten out when exposed as COM objects. For example, if you define a base class with a member, and then inherit the base class in a derived class that is exposed as a COM object, clients that use the derived class in the COM object will not be able to use the inherited members. Base class members can be accessed from COM objects only as instances of a base class, and then only if the base class is also created as a COM object.  
  
## Overloaded Methods  
 Although you can create overloaded methods with [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], they are not supported by COM. When a class that contains overloaded methods is exposed as a COM object, new method names are generated for the overloaded methods.  
  
 For example, consider a class that has two overloads of the `Synch` method. When the class is exposed as a COM object, the new generated method names could be `Synch` and `Synch_2`.  
  
 The renaming can cause two problems for consumers of the COM object.  
  
1.  Clients might not expect the generated method names.  
  
2.  The generated method names in the class exposed as a COM object can change when new overloads are added to the class or its base class. This can cause versioning problems.  
  
 To solve both problems, give each method a unique name, instead of using overloading, when you develop objects that will be exposed as COM objects.  
  
##  <a name="vbconinteroperabilitymarshalinganchor4"></a> Use of COM Objects Through Interop Assemblies  
 You use interop assemblies almost as if they are managed code replacements for the COM objects they represent. However, because they are wrappers and not actual COM objects, there are some differences between using interop assemblies and standard assemblies. These areas of difference include the exposure of classes, and data types for parameters and return values.  
  
##  <a name="vbconinteroperabilitymarshalinganchor5"></a> Classes Exposed as Both Interfaces and Classes  
 Unlike classes in standard assemblies, COM classes are exposed in interop assemblies as both an interface and a class that represents the COM class. The interface's name is identical to that of the COM class. The name of the interop class is the same as that of the original COM class, but with the word "Class" appended. For example, suppose you have a project with a reference to an interop assembly for a COM object. If the COM class is named `MyComClass`, IntelliSense and the Object Browser show an interface named `MyComClass` and a class named `MyComClassClass`.  
  
##  <a name="vbconinteroperabilitymarshalinganchor6"></a> Creating Instances of a .NET Framework Class  
 Generally, you create an instance of a [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] class using the `New` statement with a class name. Having a COM class represented by an interop assembly is the one case in which you can use the `New` statement with an interface. Unless you are using the COM class with an `Inherits` statement, you can use the interface just as you would a class. The following code demonstrates how to create a `Command` object in a project that has a reference to the Microsoft ActiveX Data Objects 2.8 Library COM object:  
  
 [!code-vb[VbVbalrInterop#20](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/troubleshooting-interoperability_1.vb)]  
  
 However, if you are using the COM class as the base for a derived class, you must use the interop class that represents the COM class, as in the following code:  
  
 [!code-vb[VbVbalrInterop#21](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/troubleshooting-interoperability_2.vb)]  
  
> [!NOTE]
>  Interop assemblies implicitly implement interfaces that represent COM classes. You should not try to use the `Implements` statement to implement these interfaces or an error will result.  
  
##  <a name="vbconinteroperabilitymarshalinganchor7"></a> Data Types for Parameters and Return Values  
 Unlike members of standard assemblies, interop assembly members may have data types that differ from those used in the  original object declaration. Although interop assemblies implicitly convert COM types to compatible common language runtime types, you should pay attention to the data types that are used by both sides to prevent runtime errors. For example, in COM objects created in Visual Basic 6.0 and earlier versions, values of type `Integer` assume the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] equivalent type, `Short`. It is recommended that you use the Object Browser to examine the characteristics of imported members before you use them.  
  
##  <a name="vbconinteroperabilitymarshalinganchor8"></a> Module level COM methods  
 Most COM objects are used by creating an instance of a COM class using the `New` keyword and then calling methods of the object. One exception to this rule involves COM objects that contain `AppObj` or `GlobalMultiUse` COM classes. Such classes resemble module level methods in Visual Basic .NET classes. Visual Basic 6.0 and earlier versions implicitly create instances of such objects for you the first time that you call one of their methods. For example, in Visual Basic 6.0 you can add a reference to the Microsoft DAO 3.6 Object Library and call the `DBEngine` method without first creating an instance:  
  
```vb  
Dim db As DAO.Database  
' Open the database.  
Set db = DBEngine.OpenDatabase("C:\nwind.mdb")  
' Use the database object.  
```  
  
 Visual Basic .NET requires that you always create instances of COM objects before you can use their methods. To use these methods in Visual Basic, declare a variable of the desired class and use the new keyword to assign the object to the object variable. The `Shared` keyword can be used when you want to make sure that only one instance of the class is created.  
  
 [!code-vb[VbVbalrInterop#23](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/troubleshooting-interoperability_3.vb)]  
  
##  <a name="vbconinteroperabilitymarshalinganchor9"></a> Unhandled Errors in Event Handlers  
 One common interop problem involves errors in event handlers that handle events raised by COM objects. Such errors are ignored unless you specifically check for errors using `On Error` or `Try...Catch...Finally` statements. For example, the following example is from a Visual Basic .NET project that has a reference to the Microsoft ActiveX Data Objects 2.8 Library COM object.  
  
 [!code-vb[VbVbalrInterop#24](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/troubleshooting-interoperability_4.vb)]  
  
 This example raises an error as expected. However, if you try the same example without the `Try...Catch...Finally` block, the error is ignored as if you used the `OnError Resume Next` statement. Without error handling, the division by zero silently fails. Because such errors never raise unhandled exception errors, it is important that you use some form of exception handling in event handlers that handle events from COM objects.  
  
### Understanding COM interop errors  
 Without error handling, interop calls often generate errors that provide little information. Whenever possible, use structured error handling to provide more information about problems when they occur. This can be especially helpful when you debug applications. For example:  
  
 [!code-vb[VbVbalrInterop#25](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/troubleshooting-interoperability_5.vb)]  
  
 You can find information such as the error description, HRESULT, and the source of COM errors by examining the contents of the exception object.  
  
##  <a name="vbconinteroperabilitymarshalinganchor10"></a> ActiveX Control Issues  
 Most ActiveX controls that work with Visual Basic 6.0 work with Visual Basic .NET without trouble. The main exceptions are container controls, or controls that visually contain other controls. Some examples of older controls that do not work correctly with [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] are as follows:  
  
-   Microsoft Forms 2.0 Frame control  
  
-   Up-Down control, also known as the spin control  
  
-   Sheridan Tab Control  
  
 There are only a few workarounds for unsupported ActiveX control problems. You can migrate existing controls to [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] if you own the original source code. Otherwise, you can check with software vendors for updated .NET-compatible versions of controls to replace unsupported ActiveX controls.  
  
##  <a name="vbconinteroperabilitymarshalinganchor11"></a> Passing ReadOnly Properties of Controls ByRef  
 Visual Basic .NET sometimes raises COM errors such as, "Error 0x800A017F CTL_E_SETNOTSUPPORTED", when you pass `ReadOnly` properties of some older ActiveX controls as `ByRef` parameters to other procedures. Similar procedure calls from Visual Basic 6.0 do not raise an error, and the parameters are treated as if you passed them by value. The Visual Basic .NET error message indicates that you are trying to change a property that does not have a property `Set` procedure.  
  
 If you have access to the procedure being called, you can prevent this error by using the `ByVal` keyword to declare parameters that accept `ReadOnly` properties. For example:  
  
 [!code-vb[VbVbalrInterop#26](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/troubleshooting-interoperability_6.vb)]  
  
 If you do not have access to the source code for the procedure being called, you can force the property to be passed by value by adding an extra set of brackets around the calling procedure. For example, in a project that has a reference to the Microsoft ActiveX Data Objects 2.8 Library COM object, you can use:  
  
 [!code-vb[VbVbalrInterop#27](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/troubleshooting-interoperability_7.vb)]  
  
##  <a name="vbconinteroperabilitymarshalinganchor12"></a> Deploying Assemblies That Expose Interop  
 Deploying assemblies that expose COM interfaces presents some unique challenges. For example, a potential problem occurs when separate applications reference the same COM assembly. This situation is common when a new version of an assembly is installed and another application is still using the old version of the assembly. If you uninstall an assembly that shares a DLL, you can unintentionally make it unavailable to the other assemblies.  
  
 To avoid this problem, you should install shared assemblies to the Global Assembly Cache (GAC) and use a MergeModule for the component. If you cannot install the application in the GAC, it should be installed to CommonFilesFolder in a version-specific subdirectory.  
  
 Assemblies that are not shared should be located side by side in the directory with the calling application.  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 [Tlbimp.exe (Type Library Importer)](../../../framework/tools/tlbimp-exe-type-library-importer.md)  
 [Tlbexp.exe (Type Library Exporter)](http://msdn.microsoft.com/library/a487d61b-d166-467b-a7ca-d8b52fbff42d)  
 [Walkthrough: Implementing Inheritance with COM Objects](../../../visual-basic/programming-guide/com-interop/walkthrough-implementing-inheritance-with-com-objects.md)  
 [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md)  
 [Global Assembly Cache](../../../framework/app-domains/gac.md)

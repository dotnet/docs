---
title: "Common Attributes (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 11fe4894-1bf9-4525-a36b-cddcd3a5d22b
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Common Attributes (Visual Basic)
This topic describes the attributes that are most commonly used in Visual Basic programs.  
  
-   [Global Attributes](#Global)  
  
-   [Obsolete Attribute](#Obsolete)  
  
-   [Conditional Attribute](#Conditional)  
  
-   [Caller Info Attributes](#CallerInfo)  
  
-   [Visual Basic Attributes](#VB)  
  
##  <a name="Global"></a> Global Attributes  
 Most attributes are applied to specific language elements such as classes or methods; however, some attributes are global—they apply to an entire assembly or module. For example, the <xref:System.Reflection.AssemblyVersionAttribute> attribute can be used to embed version information into an assembly, like this:  
  
```vb  
<Assembly: AssemblyVersion("1.0.0.0")>  
```  
  
 Global attributes appear in the source code after any top-level `Imports` statements and before any type, module, or namespace declarations. Global attributes can appear in multiple source files, but the files must be compiled in a single compilation pass. For Visual Basic projects, global attributes are generally put in the AssemblyInfo.vb file (the file is created automatically when you create a project in Visual Studio).  
  
 Assembly attributes are values that provide information about an assembly. They fall into the following categories:  
  
-   Assembly identity attributes  
  
-   Informational attributes  
  
-   Assembly manifest attributes  
  
### Assembly Identity Attributes  
 Three attributes (with a strong name, if applicable) determine the identity of an assembly: name, version, and culture. These attributes form the full name of the assembly and are required when you reference it in code. You can set an assembly's version and culture using attributes. However, the name value is set by the compiler, the Visual Studio IDE in the [Assembly Information Dialog Box](/visualstudio/ide/reference/assembly-information-dialog-box), or the Assembly Linker (Al.exe) when the assembly is created, based on the file that contains the assembly manifest. The <xref:System.Reflection.AssemblyFlagsAttribute> attribute specifies whether multiple copies of the assembly can coexist.  
  
 The following table shows the identity attributes.  
  
|Attribute|Purpose|  
|---------------|-------------|  
|<xref:System.Reflection.AssemblyName>|Fully describes the identity of an assembly.|  
|<xref:System.Reflection.AssemblyVersionAttribute>|Specifies the version of an assembly.|  
|<xref:System.Reflection.AssemblyCultureAttribute>|Specifies which culture the assembly supports.|  
|<xref:System.Reflection.AssemblyFlagsAttribute>|Specifies whether an assembly supports side-by-side execution on the same computer, in the same process, or in the same application domain.|  
  
### Informational Attributes  
 You can use informational attributes to provide additional company or product information for an assembly. The following table shows the informational attributes defined in the <xref:System.Reflection?displayProperty=nameWithType> namespace.  
  
|Attribute|Purpose|  
|---------------|-------------|  
|<xref:System.Reflection.AssemblyProductAttribute>|Defines a custom attribute that specifies a product name for an assembly manifest.|  
|<xref:System.Reflection.AssemblyTrademarkAttribute>|Defines a custom attribute that specifies a trademark for an assembly manifest.|  
|<xref:System.Reflection.AssemblyInformationalVersionAttribute>|Defines a custom attribute that specifies an informational version for an assembly manifest.|  
|<xref:System.Reflection.AssemblyCompanyAttribute>|Defines a custom attribute that specifies a company name for an assembly manifest.|  
|<xref:System.Reflection.AssemblyCopyrightAttribute>|Defines a custom attribute that specifies a copyright for an assembly manifest.|  
|<xref:System.Reflection.AssemblyFileVersionAttribute>|Instructs the compiler to use a specific version number for the Win32 file version resource.|  
|<xref:System.CLSCompliantAttribute>|Indicates whether the assembly is compliant with the Common Language Specification (CLS).|  
  
### Assembly Manifest Attributes  
 You can use assembly manifest attributes to provide information in the assembly manifest. This includes title, description, default alias, and configuration. The following table shows the assembly manifest attributes defined in the <xref:System.Reflection?displayProperty=nameWithType> namespace.  
  
|Attribute|Purpose|  
|---------------|-------------|  
|<xref:System.Reflection.AssemblyTitleAttribute>|Defines a custom attribute that specifies an assembly title for an assembly manifest.|  
|<xref:System.Reflection.AssemblyDescriptionAttribute>|Defines a custom attribute that specifies an assembly description for an assembly manifest.|  
|<xref:System.Reflection.AssemblyConfigurationAttribute>|Defines a custom attribute that specifies an assembly configuration (such as retail or debug) for an assembly manifest.|  
|<xref:System.Reflection.AssemblyDefaultAliasAttribute>|Defines a friendly default alias for an assembly manifest|  
  
##  <a name="Obsolete"></a> Obsolete Attribute  
 The `Obsolete` attribute marks a program entity as one that is no longer recommended for use. Each use of an entity marked obsolete will subsequently generate a warning or an error, depending on how the attribute is configured. For example:  
  
```vb  
<System.Obsolete("use class B")>   
Class A  
    Sub Method()  
    End Sub  
End Class  
  
Class B  
    <System.Obsolete("use NewMethod", True)>   
    Sub OldMethod()  
    End Sub  
  
    Sub NewMethod()  
    End Sub  
End Class  
```  
  
 In this example the `Obsolete` attribute is applied to class `A` and to method `B.OldMethod`. Because the second argument of the attribute constructor applied to `B.OldMethod` is set to `true`, this method will cause a compiler error, whereas using class `A` will just produce a warning. Calling `B.NewMethod`, however, produces no warning or error.  
  
 The string provided as the first argument to attribute constructor will be displayed as part of the warning or error. For example, when you use it with the previous definitions, the following code generates two warnings and one error:  
  
```vb  
' Generates 2 warnings:  
' Dim a As New A  
' Generate no errors or warnings:  
  
Dim b As New B  
b.NewMethod()  
  
' Generates an error, terminating compilation:  
' b.OldMethod()  
```  
  
 Two warnings for class `A` are generated: one for the declaration of the class reference, and one for the class constructor.  
  
 The `Obsolete` attribute can be used without arguments, but including an explanation of why the item is obsolete and what to use instead is recommended.  
  
 The `Obsolete` attribute is a single-use attribute and can be applied to any entity that allows attributes. `Obsolete` is an alias for <xref:System.ObsoleteAttribute>.  
  
##  <a name="Conditional"></a> Conditional Attribute  
 The `Conditional` attribute makes the execution of a method dependent on a preprocessing identifier. The `Conditional` attribute is an alias for <xref:System.Diagnostics.ConditionalAttribute>, and can be applied to a method or an attribute class.  
  
 In this example, `Conditional` is applied to a method to enable or disable the display of program-specific diagnostic information:  
  
```vb  
#Const TRACE_ON = True  
Imports System  
Imports System.Diagnostics  
Module TestConditionalAttribute  
    Public Class Trace  
        <Conditional("TRACE_ON")>   
        Public Shared Sub Msg(ByVal msg As String)  
            Console.WriteLine(msg)  
        End Sub  
  
    End Class  
  
    Sub Main()  
        Trace.Msg("Now in Main...")  
        Console.WriteLine("Done.")  
    End Sub  
End Module  
```  
  
 If the `TRACE_ON` identifier is not defined, no trace output will be displayed.  
  
 The `Conditional` attribute is often used with the `DEBUG` identifier to enable trace and logging features for debug builds but not in release builds, like this:  
  
```vb  
<Conditional("DEBUG")>   
Shared Sub DebugMethod()  
  
End Sub  
```  
  
 When a method marked as conditional is called, the presence or absence of the specified preprocessing symbol determines whether the call is included or omitted. If the symbol is defined, the call is included; otherwise, the call is omitted. Using `Conditional` is a cleaner, more elegant, and less error-prone alternative to enclosing methods inside `#if…#endif` blocks, like this:  
  
```vb  
#If DEBUG Then  
    Sub ConditionalMethod()  
    End Sub  
#End If  
```  
  
 A conditional method must be a method in a class or struct declaration and must not have a return value.  
  
### Using Multiple Identifiers  
 If a method has multiple `Conditional` attributes, a call to the method is included if at least one of the conditional symbols is defined (in other words, the symbols are logically linked together by using the OR operator). In this example, the presence of either `A` or `B` will result in a method call:  
  
```vb  
<Conditional("A"), Conditional("B")>   
Shared Sub DoIfAorB()  
  
End Sub  
```  
  
 To achieve the effect of logically linking symbols by using the AND operator, you can define serial conditional methods. For example, the second method below will execute only if both `A` and `B` are defined:  
  
```vb  
<Conditional("A")>   
Shared Sub DoIfA()  
    DoIfAandB()  
End Sub  
  
<Conditional("B")>   
Shared Sub DoIfAandB()  
    ' Code to execute when both A and B are defined...  
End Sub  
```  
  
### Using Conditional with Attribute Classes  
 The `Conditional` attribute can also be applied to an attribute class definition. In this example, the custom attribute `Documentation` will only add information to the metadata if DEBUG is defined.  
  
```vb  
<Conditional("DEBUG")>   
Public Class Documentation  
    Inherits System.Attribute  
    Private text As String  
    Sub New(ByVal doc_text As String)  
        text = doc_text  
    End Sub  
End Class  
  
Class SampleClass  
    ' This attribute will only be included if DEBUG is defined.  
    <Documentation("This method displays an integer.")>   
    Shared Sub DoWork(ByVal i As Integer)  
        System.Console.WriteLine(i)  
    End Sub  
End Class  
```  
  
##  <a name="CallerInfo"></a> Caller Info Attributes  
 By using Caller Info attributes, you can obtain information about the caller to a method. You can obtain the file path of the source code, the line number in the source code, and the member name of the caller.  
  
 To obtain member caller information, you use attributes that are applied to optional parameters. Each optional parameter specifies a default value. The following table lists the Caller Info attributes that are defined in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace:  
  
|Attribute|Description|Type|  
|---|---|---|  
|<xref:System.Runtime.CompilerServices.CallerFilePathAttribute>|Full path of the source file that contains the caller. This is the path at compile time.|`String`|  
|<xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>|Line number in the source file from which the method is called.|`Integer`|  
|<xref:System.Runtime.CompilerServices.CallerMemberNameAttribute>|Method name or property name of the caller. For more information, see [Caller Information (Visual Basic)](../../../../visual-basic/programming-guide/concepts/caller-information.md).|`String`|  
  
 For more information about the Caller Info attributes, see [Caller Information (Visual Basic)](../../../../visual-basic/programming-guide/concepts/caller-information.md).  
  
##  <a name="VB"></a> Visual Basic Attributes  
 The following table lists the attributes that are specific to Visual Basic.  
  
|Attribute|Purpose|  
|---------------|-------------|  
|<xref:Microsoft.VisualBasic.ComClassAttribute>|Indicates to the compiler that the class should be exposed as a COM object.|  
|<xref:Microsoft.VisualBasic.HideModuleNameAttribute>|Allows module members to be accessed using only the qualification needed for the module.|  
|<xref:Microsoft.VisualBasic.VBFixedStringAttribute>|Specifies the size of a fixed-length string in a structure for use with file input and output functions.|  
|<xref:Microsoft.VisualBasic.VBFixedArrayAttribute>|Specifies the size of a fixed array in a structure for use with file input and output functions.|  
  
### COMClassAttribute  
 Use `COMClassAttribute` to simplify the process of creating COM components from Visual Basic. COM objects are considerably different from .NET Framework assemblies, and without `COMClassAttribute`, you need to follow a number of steps to generate a COM object from Visual Basic. For classes marked with `COMClassAttribute`, the compiler performs many of these steps automatically.  
  
### HideModuleNameAttribute  
 Use `HideModuleNameAttribute` to allow module members to be accessed by using only the qualification needed for the module.  
  
### VBFixedStringAttribute  
 Use `VBFixedStringAttribute` to force Visual Basic to create a fixed-length string. Strings are of variable length by default, and this attribute is useful when storing strings to files. The following code demonstrates this:  
  
```vb  
Structure Worker  
    ' The runtime uses VBFixedString to determine   
    ' if the field should be written out as a fixed size.  
    <VBFixedString(10)> Public LastName As String  
    <VBFixedString(7)> Public Title As String  
    <VBFixedString(2)> Public Rank As String  
End Structure  
```  
  
### VBFixedArrayAttribute  
 Use `VBFixedArrayAttribute` to declare arrays that are fixed in size. Like Visual Basic strings, arrays are of variable length by default. This attribute is useful when serializing or writing data to files.  
  
## See Also  
 <xref:System.Reflection>  
 <xref:System.Attribute>  
 [Visual Basic Programming Guide](../../../../visual-basic/programming-guide/index.md)  
 [Attributes](../../../../standard/attributes/index.md)  
 [Reflection (Visual Basic)](../../../../visual-basic/programming-guide/concepts/reflection.md)  
 [Accessing Attributes by Using Reflection (Visual Basic)](../../../../visual-basic/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection.md)

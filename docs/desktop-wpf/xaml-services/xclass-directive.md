---
title: "x:Class Directive"
ms.date: "03/30/2017"
f1_keywords: 
  - "x:Class"
  - "xClass"
  - "Class"
helpviewer_keywords: 
  - "Class attribute in XAML [XAML Services]"
  - "XAML [XAML Services], x:Class attribute"
  - "x:Class attribute [XAML Services]"
ms.assetid: bc4a3d8e-76e2-423e-a5d1-159a023e82ec
---
# x:Class Directive
Configures XAML markup compilation to join partial classes between markup and code-behind. The code partial class is defined in a separate code file in a Common Language Specification (CLS) language, whereas the markup partial class is typically created by code generation during XAML compilation.  
  
## XAML Attribute Usage  
  
```xaml  
<object x:Class="namespace.classname"...>  
  ...  
</object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`namespace`|Optional. Specifies a CLR namespace that contains the partial class identified by `classname`. If `namespace` is specified, a dot (.) separates `namespace` and `classname`. See Remarks.|  
|`classname`|Required. Specifies the CLR name of the partial class that connects the loaded XAML and your code-behind for that XAML.|  
  
## Dependencies  
 `x:Class` can only be specified on the root element of a XAML production. `x:Class` is invalid on any object that has a parent in the XAML production. For more information, see [\[MS-XAML\] Section 4.3.1.6](https://docs.microsoft.com/previous-versions/msp-n-p/ff650760(v=pandp.10)).  
  
## Remarks  
 The `namespace` value may contain additional dots to organize related namespaces into name hierarchies, which is a common technique in .NET Framework programming. Only the last dot in a string of `x:Class` values is interpreted to separate `namespace` and `classname.` The class that is used as `x:Class` cannot be a nested class. Nested classes are not allowed because determining the meaning of dots for `x:Class` strings is ambiguous if nested classes are permitted.  
  
 In existing programming models that use `x:Class`, `x:Class` is optional in the sense that it is entirely valid to have a XAML page that has no code-behind. However, that capability interacts with the build actions as implemented by frameworks that use XAML. `x:Class` capability is also influenced by the roles that various classifications of XAML-specified content have in an application model and in the corresponding build actions. If your XAML declares event-handling attribute values or instantiates custom elements where the defining classes are in the code-behind class, you have to provide the `x:Class` directive reference (or [x:Subclass](xsubclass-directive.md)) to the appropriate class for code-behind.  
  
 The value of the `x:Class` directive must be a string that specifies the fully qualified name of a class but without any assembly information (equivalent to the <xref:System.Type.FullName%2A?displayProperty=nameWithType>). For simple applications, you can omit CLR namespace information if the code-behind is also structured in that manner (code definition starts at the class level).  
  
 The code-behind file for a page or application definition must be within a code file that is included as part of the project that produces a compiled application and involves markup compilation. You must follow name rules for CLR classes. For more information, see [Framework Design Guidelines](../../../api/index.md). By default, the code-behind class must be `public`; however, you can define it at a different access level by using the [x:ClassModifier Directive](xclassmodifier-directive.md).  
  
 This interpretation of the `x:Class` attribute applies only to a CLR-based XAML implementation, in particular to .NET Framework XAML Services. Other XAML implementations that are not based on CLR and that do not use .NET Framework XAML Services might use a different resolution formula for connecting XAML markup and backing run-time code. For more information about more general interpretations of `x:Class`, see [\[MS-XAML\]](https://docs.microsoft.com/previous-versions/msp-n-p/ff650760(v=pandp.10)).  
  
 At a certain level of architecture, the meaning of `x:Class` is undefined in .NET Framework XAML Services. This is because .NET Framework XAML Services does not specify the programming model by which XAML markup and backing code are connected. Additional uses of the `x:Class` directive might be implemented by specific frameworks that use programming models or application models to define how to connect XAML markup and CLR-based code-behind. Each framework can have its own build actions that enable some of the behavior or specific components that must be included in the build environment. Within a framework, build actions can also vary depending on the specific CLR language that is used for the code-behind.  
  
## x:Class in the WPF Programming Model  
 In WPF applications and the WPF application model, `x:Class` can be declared as an attribute for any element that is the root of a XAML file and is being compiled (where the XAML is included in a WPF application project with `Page` build action), or for the <xref:System.Windows.Application> root in the application definition of a compiled WPF application. Declaring `x:Class` on an element other than a page root or application root, or on a WPF XAML file that is not compiled, causes a compile-time error under the .NET Framework 3.0 and .NET Framework 3.5 WPF XAML compiler. For information about other aspects of `x:Class` handling in WPF, see [Code-Behind and XAML in WPF](../../framework/wpf/advanced/code-behind-and-xaml-in-wpf.md).  
  
## x:Class for Windows Workflow Foundation  
 For Windows Workflow Foundation, `x:Class` names the class of a custom activity composed entirely in XAML, or names the partial class of the XAML page for  an activity designer with code-behind.  
  
## Silverlight Usage Notes  
 `x:Class` for Silverlight is documented separately. For more information, see [XAML Namespace (x:) Language Features (Silverlight)](https://docs.microsoft.com/previous-versions/windows/silverlight/dotnet-windows-silverlight/cc188995(v=vs.95)).  
  
## See also

- [x:Subclass Directive](xsubclass-directive.md)
- [XAML and Custom Classes for WPF](../../framework/wpf/advanced/xaml-and-custom-classes-for-wpf.md)
- [x:ClassModifier Directive](xclassmodifier-directive.md)
- [Types Migrated from WPF to System.Xaml](types-migrated-from-wpf-to-system.md)

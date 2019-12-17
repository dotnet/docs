---
title: "x:Code Intrinsic XAML Type"
ms.date: "03/30/2017"
f1_keywords: 
  - "Code"
  - "x:Code"
  - "xCode"
helpviewer_keywords: 
  - "Code directive in XAML [XAML Services]"
  - "x:Code XAML directive element [XAML Services]"
  - "XAML [XAML Services], x:Code directive element"
ms.assetid: 87986b13-1a2e-4830-ae36-15f9dc5629e8
---
# x:Code Intrinsic XAML Type
Allows placement of code within a XAML production. Such code can either be compiled by any XAML processor implementation that compiles XAML, or left in the XAML production for later uses such as interpretation by a runtime.  
  
## XAML Object Element Usage  
  
```xaml  
<x:Code>  
   // code instructions, usually enclosed by CDATA...  
</x:Code>  
```  
  
## Remarks  
 The code within the `x:Code` XAML directive element is still interpreted within the general XML namespace and the XAML namespaces provided. Therefore, it is usually necessary to enclose the code used for `x:Code` inside a `CDATA` segment.  
  
 `x:Code` is not permitted for all possible deployment mechanisms of a XAML production. In specific frameworks (for example WPF) the code must be compiled. In other frameworks, `x:Code` usage might be generally disallowed.  
  
 For frameworks that permit managed `x:Code` content, the correct language compiler to use for `x:Code` content is determined by settings and targets of the containing project that is used to compile the application.  
  
## WPF Usage Notes  
 Code declared within `x:Code` for WPF has several notable limitations:  
  
- The `x:Code` directive element must be an immediate child element of the root element of the XAML production.  
  
- [x:Class Directive](xclass-directive.md) must be provided on the parent root element.  
  
- The code placed within `x:Code` will be treated by compilation to be within the scope of the partial class that is already being created for that XAML page. Therefore all code you define must be members or variables of that partial class.  
  
- You cannot define additional classes, other than by nesting a class inside the partial class (nesting is allowed, but it is not typical because nested classes cannot be referenced in XAML). CLR namespaces other than the namespace that is used for the existing partial class cannot be defined or added to.  
  
- References to code entities outside the partial class CLR namespace must all be fully qualified. If members being declared are overrides to the partial class overridable members, this must be specified with the language-specific override keyword. If members declared in `x:Code` scope conflict with members of the partial class created out of the XAML, in such a way that the compiler reports the conflict, the XAML file cannot compile or load.  
  
## See also

- [x:Class Directive](xclass-directive.md)
- [Code-Behind and XAML in WPF](../../framework/wpf/advanced/code-behind-and-xaml-in-wpf.md)
- [XAML Overview (WPF)](../fundamentals/xaml.md)

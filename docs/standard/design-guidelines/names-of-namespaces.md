---
title: "Names of Namespaces"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "names [.NET Framework], conflicts"
  - "names [.NET Framework], namespaces"
  - "type names, conflicts"
  - "namespaces [.NET Framework], names"
  - "names [.NET Framework], type names"
ms.assetid: a49058d2-0276-43a7-9502-04adddf857b2
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Names of Namespaces
As with other naming guidelines, the goal when naming namespaces is creating sufficient clarity for the programmer using the framework to immediately know what the content of the namespace is likely to be. The following template specifies the general rule for naming namespaces:  
  
 `<Company>.(<Product>|<Technology>)[.<Feature>][.<Subnamespace>]`  
  
 The following are examples:  
  
 `Fabrikam.Math`  
 `Litware.Security`  
  
 **✓ DO** prefix namespace names with a company name to prevent namespaces from different companies from having the same name.  
  
 **✓ DO** use a stable, version-independent product name at the second level of a namespace name.  
  
 **X DO NOT** use organizational hierarchies as the basis for names in namespace hierarchies, because group names within corporations tend to be short-lived. Organize the hierarchy of namespaces around groups of related technologies.  
  
 **✓ DO** use PascalCasing, and separate namespace components with periods (e.g., `Microsoft.Office.PowerPoint`). If your brand employs nontraditional casing, you should follow the casing defined by your brand, even if it deviates from normal namespace casing.  
  
 **✓ CONSIDER** using plural namespace names where appropriate.  
  
 For example, use `System.Collections` instead of `System.Collection`. Brand names and acronyms are exceptions to this rule, however. For example, use `System.IO` instead of `System.IOs`.  
  
 **X DO NOT** use the same name for a namespace and a type in that namespace.  
  
 For example, do not use `Debug` as a namespace name and then also provide a class named `Debug` in the same namespace. Several compilers require such types to be fully qualified.  
  
### Namespaces and Type Name Conflicts  
 **X DO NOT** introduce generic type names such as `Element`, `Node`, `Log`, and `Message`.  
  
 There is a very high probability that doing so will lead to type name conflicts in common scenarios. You should qualify the generic type names (`FormElement`, `XmlNode`, `EventLog`, `SoapMessage`).  
  
 There are specific guidelines for avoiding type name conflicts for different categories of namespaces.  
  
-   **Application model namespaces**  
  
     Namespaces belonging to a single application model are very often used together, but they are almost never used with namespaces of other application models. For example, the <xref:System.Windows.Forms?displayProperty=nameWithType> namespace is very rarely used together with the <xref:System.Web.UI?displayProperty=nameWithType> namespace. The following is a list of well-known application model namespace groups:  
  
     `System.Windows*`   
     `System.Web.UI*`  
  
     **X DO NOT** give the same name to types in namespaces within a single application model.  
  
     For example, do not add a type named `Page` to the <xref:System.Web.UI.Adapters?displayProperty=nameWithType> namespace, because the <xref:System.Web.UI?displayProperty=nameWithType> namespace already contains a type named `Page`.  
  
-   **Infrastructure namespaces**  
  
     This group contains namespaces that are rarely imported during development of common applications. For example, `.Design` namespaces are mainly used when developing programming tools. Avoiding conflicts with types in these namespaces is not critical.  
  
-   **Core namespaces**  
  
     Core namespaces include all `System` namespaces, excluding namespaces of the application models and the Infrastructure namespaces. Core namespaces include, among others, `System`, `System.IO`, `System.Xml`, and `System.Net`.  
  
     **X DO NOT** give types names that would conflict with any type in the Core namespaces.  
  
     For example, never use `Stream` as a type name. It would conflict with <xref:System.IO.Stream?displayProperty=nameWithType>, a very commonly used type.  
  
-   **Technology namespace groups**  
  
     This category includes all namespaces with the same first two namespace nodes `(<Company>.<Technology>*`), such as `Microsoft.Build.Utilities` and `Microsoft.Build.Tasks`. It is important that types belonging to a single technology do not conflict with each other.  
  
     **X DO NOT** assign type names that would conflict with other types within a single technology.  
  
     **X DO NOT** introduce type name conflicts between types in technology namespaces and an application model namespace (unless the technology is not intended to be used with the application model).  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Naming Guidelines](../../../docs/standard/design-guidelines/naming-guidelines.md)

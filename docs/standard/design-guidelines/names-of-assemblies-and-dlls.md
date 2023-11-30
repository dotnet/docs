---
title: "Names of Assemblies and DLLs"
description: Learn guidelines for naming assemblies and dynamic-link libraries (DLLs). An assembly can span one or more files, but it usually maps one-to-one with a DLL.
ms.date: "10/22/2008"
helpviewer_keywords:
  - "names [.NET Framework], DLLs"
  - "names [.NET Framework], assemblies"
  - "assemblies [.NET Framework], names"
  - "DLLs, names"
ms.assetid: e800b610-31b4-4949-9c14-cb60e9f254be
---
# Names of Assemblies and DLLs

[!INCLUDE [not-current](includes/not-current.md)]

An assembly is the unit of deployment and identity for managed code programs. Although assemblies can span one or more files, typically an assembly maps one-to-one with a DLL. Therefore, this section describes only DLL naming conventions, which then can be mapped to assembly naming conventions.

 ✔️ DO choose names for your assembly DLLs that suggest large chunks of functionality, such as System.Data.

 Assembly and DLL names don’t have to correspond to namespace names, but it is reasonable to follow the namespace name when naming assemblies. A good rule of thumb is to name the DLL based on the common prefix of the namespaces contained in the assembly. For example, an assembly with two namespaces, `MyCompany.MyTechnology.FirstFeature` and `MyCompany.MyTechnology.SecondFeature`, could be called `MyCompany.MyTechnology.dll`.

 ✔️ CONSIDER naming DLLs according to the following pattern:

 `<Company>.<Component>.dll`

 where `<Component>` contains one or more dot-separated clauses. For example:

 `Litware.Controls.dll`.

 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*

 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*

## See also

- [Framework Design Guidelines](index.md)
- [Naming Guidelines](naming-guidelines.md)

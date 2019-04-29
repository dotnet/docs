---
title: "Reference required to assembly '<assemblyidentity>' containing type '<typename>', but a suitable reference could not be found due to ambiguity between projects '<projectname1>' and '<projectname2>'"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30969"
  - "vbc30969"
helpviewer_keywords: 
  - "BC30969"
ms.assetid: 1b29dbc5-8268-45fe-bfc2-b2070a5c845c
---
# Reference required to assembly '\<assemblyidentity>' containing type '\<typename>', but a suitable reference could not be found due to ambiguity between projects '\<projectname1>' and '\<projectname2>'
An expression uses a type, such as a class, structure, interface, enumeration, or delegate, that is defined outside your project. However, you have project references to more than one assembly defining that type.  
  
 The cited projects produce assemblies with the same name. Therefore, the compiler cannot determine which assembly to use for the type you are accessing.  
  
 To access a type defined in another assembly, the Visual Basic compiler must have a reference to that assembly. This must be a single, unambiguous reference that does not cause circular references among projects.  
  
 **Error ID:** BC30969  
  
## To correct this error  
  
1. Determine which project produces the best assembly for your project to reference. For this decision, you might use criteria such as ease of file access and frequency of updates.  
  
2. In your project properties, add a reference to the file that contains the assembly that defines the type you are using.  
  
## See also

- [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)
- [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)

- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
- [Troubleshooting Broken References](/visualstudio/ide/troubleshooting-broken-references)

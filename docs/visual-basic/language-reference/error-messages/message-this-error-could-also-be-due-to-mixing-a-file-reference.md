---
title: "<message> This error could also be due to mixing a file reference with a project reference to assembly '<assemblyname>'"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30971"
  - "vbc30971"
helpviewer_keywords: 
  - "BC30971"
ms.assetid: 75d2e8b5-2fdc-4623-8b32-cba805dab7db
---
# \<message> This error could also be due to mixing a file reference with a project reference to assembly '\<assemblyname>'
\<message> This error could also be due to mixing a file reference with a project reference to assembly '\<assemblyname>. In this case, try replacing the file reference to '\<assemblyfilename>' in project '\<projectname1>' with a project reference to '\<projectname2>'.  
  
 Code in your project accesses a member of another project, but the configuration of your solution does not allow the Visual Basic compiler to resolve the reference.  
  
 To access a type defined in another assembly, the Visual Basic compiler must have a reference to that assembly. This must be a single, unambiguous reference that does not cause circular references among projects.  
  
 **Error ID:** BC30971  
  
## To correct this error  
  
1.  Determine which project produces the best assembly for your project to reference. For this decision, you might use criteria such as ease of file access and frequency of updates.  
  
2.  In your project properties, add a reference to the project that contains the assembly that defines the type you are using.  
  
## See also

- [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)
- [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)

- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
- [Troubleshooting Broken References](/visualstudio/ide/troubleshooting-broken-references)

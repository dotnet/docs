---
title: "How to: Share an Assembly with Other Applications (Visual Basic)"
ms.date: 07/20/2015
ms.assetid: 5388aedc-cb42-4622-8b70-8e701eee057a
---
# How to: Share an Assembly with Other Applications (Visual Basic)
Assemblies can be private or shared: by default, most simple programs consist of a private assembly because they are not intended to be used by other applications.  
  
 In order to share an assembly with other applications, it must be placed in the [Global Assembly Cache](../../../../framework/app-domains/gac.md) (GAC).  
  
### Sharing an assembly  
  
1. Create your assembly. For more information, see [Creating Assemblies](../../../../standard/assembly/create.md).  
  
2. Assign a strong name to your assembly. For more information, see [How to: Sign an Assembly with a Strong Name](../../../../standard/assembly/sign-strong-name.md).  
  
3. Assign version information to your assembly. For more information, see [Assembly Versioning](../../../../standard/assembly/versioning.md).  
  
4. Add your assembly to the Global Assembly Cache. For more information, see [How to: Install an Assembly into the Global Assembly Cache](../../../../standard/assembly/install-into-gac.md).  
  
5. Access the types contained in the assembly from the other applications. For more information, see [How to: Reference a Strong-Named Assembly](../../../../standard/assembly/reference-strong-named.md).  
  
## See also

- [Programming Concepts](../../../../visual-basic/programming-guide/concepts/index.md)
- [Assemblies in .NET](../../../../standard/assembly/index.md)
- [Programming with Assemblies](../../../../standard/assembly/program.md)

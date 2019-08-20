---
title: "How to: Share an assembly with other applications"
ms.date: 08/19/2019
ms.assetid: c30e972b-1693-4e05-b115-c31831fdf9f2
---
# How to: Share an assembly with other applications
Assemblies can be private or shared: by default, most simple programs consist of a private assembly because they are not intended to be used by other applications.  

In order to share an assembly with other applications, it must be placed in the [Global Assembly Cache (GAC)](../../framework/app-domains/gac.md).  
  
To share an assembly:
  
1. Create your assembly. For more information, see [Create assemblies](create.md).  
  
2. Assign a strong name to your assembly. For more information, see [How to: Sign an assembly with a strong name](sign-strong-name.md).  
  
3. Assign version information to your assembly. For more information, see [Assembly versioning](versioning.md).  
  
4. Add your assembly to the Global Assembly Cache. For more information, see [How to: Install an assembly into the Global Assembly Cache](install-into-gac.md).  
  
5. Access the types contained in the assembly from other applications. For more information, see [How to: Reference a strong-named assembly](reference-strong-named.md).  
  
## See also

- [C# programming guide](../../csharp/programming-guide/index.md)
- [Programming concepts (Visual Basic)](../../../../visual-basic/programming-guide/concepts/index.md)
- [Program with assemblies](program.md)

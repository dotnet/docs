---
title: "How to: Share an assembly with other applications"
ms.date: 08/19/2019
ms.assetid: c30e972b-1693-4e05-b115-c31831fdf9f2
---
# How to: Share an assembly with other applications
Assemblies can be private or shared: by default, most simple programs consist of a private assembly because they are not intended to be used by other applications.  

In order to share an assembly with other applications, it must be placed in the [global assembly cache (GAC)](gac.md).  
  
To share an assembly:
  
1. Create your assembly. For more information, see [Create assemblies](../../standard/assembly/create.md).  
  
2. Assign a strong name to your assembly. For more information, see [How to: Sign an assembly with a strong name](../../standard/assembly/sign-strong-name.md).  
  
3. Assign version information to your assembly. For more information, see [Assembly versioning](../../standard/assembly/versioning.md).  
  
4. Add your assembly to the global assembly cache. For more information, see [How to: Install an assembly into the global assembly cache](install-assembly-into-gac.md).  
  
5. Access the types contained in the assembly from other applications. For more information, see [How to: Reference a strong-named assembly](../../standard/assembly/reference-strong-named.md).  
  
## See also

- [C# programming guide](../../../api/index.md)
- [Programming concepts (Visual Basic)](../../../api/index.md)
- [Program with assemblies](../../standard/assembly/program.md)

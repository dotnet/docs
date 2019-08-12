---
title: "How to: Share an Assembly with Other Applications (C#)"
ms.date: 07/20/2015
ms.assetid: c30e972b-1693-4e05-b115-c31831fdf9f2
---
# How to: Share an Assembly with Other Applications (C#)
Assemblies can be private or shared: by default, most simple programs consist of a private assembly because they are not intended to be used by other applications.  
  
 In order to share an assembly with other applications, it must be placed in the [Global Assembly Cache](../../../../framework/app-domains/gac.md) (GAC).  
  
### Sharing an assembly  
  
1. Create your assembly. For more information, see [Creating Assemblies](../../../../standard/assembly/create-assemblies.md).  
  
2. Assign a strong name to your assembly. For more information, see [How to: Sign an Assembly with a Strong Name](../../../../standard/assembly/how-to-sign-an-assembly-with-a-strong-name.md).  
  
3. Assign version information to your assembly. For more information, see [Assembly Versioning](../../../../standard/assembly/assembly-versioning.md).  
  
4. Add your assembly to the Global Assembly Cache. For more information, see [How to: Install an Assembly into the Global Assembly Cache](../../../../standard/assembly/how-to-install-an-assembly-into-the-gac.md).  
  
5. Access the types contained in the assembly from the other applications. For more information, see [How to: Reference a Strong-Named Assembly](../../../../standard/assembly/how-to-reference-a-strong-named-assembly.md).  
  
## See also

- [C# Programming Guide](../../../../csharp/programming-guide/index.md)
- [Programming with Assemblies](../../../../standard/assembly/programming-with-assemblies.md)

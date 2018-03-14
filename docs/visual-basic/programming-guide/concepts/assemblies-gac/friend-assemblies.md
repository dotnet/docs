---
title: "Friend Assemblies (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9b3d5716-e6e4-47a7-a3e9-084d7fba5c28
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
---
# Friend Assemblies (Visual Basic)
A *friend assembly* is an assembly that can access another assembly's [Friend](../../../../visual-basic/language-reference/modifiers/friend.md) types and members. If you identify an assembly as a friend assembly, you no longer have to mark types and members as public in order for them to be accessed by other assemblies. This is especially convenient in the following scenarios:  
  
-   During unit testing, when test code runs in a separate assembly but requires access to members in the assembly being tested that are marked as `Friend`.  
  
-   When you are developing a class library and additions to the library are contained in separate assemblies but require access to members in existing assemblies that are marked as `Friend`.  
  
## Remarks  
 You can use the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute to identify one or more friend assemblies for a given assembly. The following example uses the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute in assembly A and specifies assembly `AssemblyB` as a friend assembly. This gives assembly `AssemblyB` access to all types and members in assembly A that are marked as `Friend`.  
  
> [!NOTE]
>  When you compile an assembly (assembly `AssemblyB`) that will access internal types or internal members of another assembly (assembly *A*), you must explicitly specify the name of the output file (.exe or .dll) by using the **/out** compiler option. This is required because the compiler has not yet generated the name for the assembly it is building at the time it is binding to external references. For more information, see [/out (Visual Basic)](../../../../visual-basic/reference/command-line-compiler/out.md).  
  
```vb  
Imports System.Runtime.CompilerServices  
Imports System  
<Assembly: InternalsVisibleTo("AssemblyB")>   
  
' Friend class.  
Friend Class FriendClass  
    Public Sub Test()  
        Console.WriteLine("Sample Class")  
    End Sub  
End Class  
  
' Public class with a Friend method.  
Public Class ClassWithFriendMethod  
    Friend Sub Test()  
        Console.WriteLine("Sample Method")  
    End Sub  
End Class  
```  
  
 Only assemblies that you explicitly specify as friends can access `Friend` types and members. For example, if assembly B is a friend of assembly A and assembly C references assembly B, C does not have access to `Friend` types in A.  
  
 The compiler performs some basic validation of the friend assembly name passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute. If assembly *A* declares *B* as a friend assembly, the validation rules are as follows:  
  
-   If assembly *A* is strong named, assembly *B* must also be strong named. The friend assembly name that is passed to the attribute must consist of the assembly name and the public key of the strong-name key that is used to sign assembly *B*.  
  
     The friend assembly name that is passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute cannot be the strong name of assembly *B*: do not include the assembly version, culture, architecture, or public key token.  
  
-   If assembly *A* is not strong named, the friend assembly name should consist of only the assembly name. For more information, see [How to: Create Unsigned Friend Assemblies (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/how-to-create-unsigned-friend-assemblies.md).  
  
-   If assembly *B* is strong named, you must specify the strong-name key for assembly *B* by using the project setting or the command-line `/keyfile` compiler option. For more information, see [How to: Create Signed Friend Assemblies (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/how-to-create-signed-friend-assemblies.md).  
  
 The <xref:System.Security.Permissions.StrongNameIdentityPermission> class also provides the ability to share types, with the following differences:  
  
-   <xref:System.Security.Permissions.StrongNameIdentityPermission> applies to an individual type, while a friend assembly applies to the whole assembly.  
  
-   If there are hundreds of types in assembly *A* that you want to share with assembly *B*, you have to add <xref:System.Security.Permissions.StrongNameIdentityPermission> to all of them. If you use a friend assembly, you only need to declare the friend relationship once.  
  
-   If you use <xref:System.Security.Permissions.StrongNameIdentityPermission>, the types you want to share have to be declared as public. If you use a friend assembly, the shared types are declared as `Friend`.  
  
 For information about how to access an assembly's `Friend` types and methods from a module file (a file with the .netmodule extension), see [/moduleassemblyname (Visual Basic)](../../../../visual-basic/reference/command-line-compiler/moduleassemblyname.md).  
  
## See Also  
 <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>  
 <xref:System.Security.Permissions.StrongNameIdentityPermission>  
 [How to: Create Unsigned Friend Assemblies (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/how-to-create-unsigned-friend-assemblies.md)  
 [How to: Create Signed Friend Assemblies (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/how-to-create-signed-friend-assemblies.md)  
 [Assemblies and the Global Assembly Cache (Visual Basic)](../../../../visual-basic/programming-guide/concepts/assemblies-gac/index.md)  
 [Programming Concepts](../../../../visual-basic/programming-guide/concepts/index.md)

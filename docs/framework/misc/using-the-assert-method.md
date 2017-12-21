---
title: "Using the Assert Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "granting permissions, overriding security checks"
  - "code access security, overriding security checks"
  - "overriding security checks"
  - "security [.NET Framework], overriding security checks"
  - "security [.NET Framework], assertions"
  - "asserted permissions"
  - "Assert method"
  - "caller security checks"
  - "permissions [.NET Framework], overriding security checks"
  - "permissions [.NET Framework], assertions"
ms.assetid: 1e40f4d3-fb7d-4f19-b334-b6076d469ea9
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the Assert Method
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 <xref:System.Security.CodeAccessPermission.Assert%2A> is a method that can be called on code access permission classes and on the <xref:System.Security.PermissionSet> class. You can use **Assert** to enable your code (and downstream callers) to perform actions that your code has permission to do but its callers might not have permission to do. A security assertion changes the normal process that the runtime performs during a security check. When you assert a permission, it tells the security system not to check the callers of your code for the asserted permission.  
  
> [!CAUTION]
>  Use assertions carefully because they can open security holes and undermine the runtime's mechanism for enforcing security restrictions.  
  
 Assertions are useful in situations in which a library calls into unmanaged code or makes a call that requires a permission that is not obviously related to the library's intended use. For example, all managed code that calls into unmanaged code must have **SecurityPermission** with the **UnmanagedCode** flag specified. Code that does not originate from the local computer, such as code that is downloaded from the local intranet, will not be granted this permission by default. Therefore, in order for code that is downloaded from the local intranet to be able to call a library that uses unmanaged code, it must have the permission asserted by the library. Additionally, some libraries might make calls that are unseen to callers and require special permissions.  
  
 You can also use assertions in situations in which your code accesses a resource in a way that is completely hidden from callers. For example, suppose your library acquires information from a database, but in the process also reads information from the computer registry. Because developers using your library do not have access to your source, they have no way of knowing that their code requires **RegistryPermission** in order to use your code. In this case, if you decide that it is not reasonable or necessary to require that callers of your code have permission to access the registry, you can assert permission for reading the registry. In this situation, it is appropriate for the library to assert the permission so that callers without **RegistryPermission** can use the library.  
  
 The assertion affects the stack walk only if the asserted permission and a permission demanded by a downstream caller are of the same type and if the demanded permission is a subset of the asserted permission. For example, if you assert **FileIOPermission** to read all files on the C drive, and a downstream demand is made for **FileIOPermission** to read files in C:\Temp, the assertion could affect the stack walk; however, if the demand was for **FileIOPermission** to write to the C drive, the assertion would have no effect.  
  
 To perform assertions, your code must be granted both the permission you are asserting and the <xref:System.Security.Permissions.SecurityPermission> that represents the right to make assertions. Although you could assert a permission that your code has not been granted, the assertion would be pointless because the security check would fail before the assertion could cause it to succeed.  
  
 The following illustration shows what happens when you use **Assert**. Assume that the following statements are true about assemblies A, B, C, E, and F, and two permissions, P1 and P1A:  
  
-   P1A represents the right to read .txt files on the C drive.  
  
-   P1 represents the right to read all files on the C drive.  
  
-   P1A and P1 are both **FileIOPermission** types, and P1A is a subset of P1.  
  
-   Assemblies E and F have been granted P1A permission.  
  
-   Assembly C has been granted P1 permission.  
  
-   Assemblies A and B have been granted neither P1 nor P1A permissions.  
  
-   Method A is contained in assembly A, method B is contained in assembly B, and so on.  
  
 ![](../../../docs/framework/misc/media/assert.gif "assert")  
Using Assert  
  
 In this scenario, method A calls B, B calls C, C calls E, and E calls F. Method C asserts permission to read files on the C drive (permission P1), and method E demands permission to read .txt files on the C drive (permission P1A). When the demand in F is encountered at run time, a stack walk is performed to check the permissions of all callers of F, starting with E. E has been granted P1A permission, so the stack walk proceeds to examine the permissions of C, where C's assertion is discovered. Because the demanded permission (P1A) is a subset of the asserted permission (P1), the stack walk stops and the security check automatically succeeds. It does not matter that assemblies A and B have not been granted permission P1A. By asserting P1, method C ensures that its callers can access the resource protected by P1, even if the callers have not been granted permission to access that resource.  
  
 If you design a class library and a class accesses a protected resource, you should, in most cases, make a security demand requiring that the callers of the class have the appropriate permission. If the class then performs an operation for which you know most of its callers will not have permission, and if you are willing to take the responsibility for letting these callers call your code, you can assert the permission by calling the **Assert** method on a permission object that represents the operation the code is performing. Using **Assert** in this way lets callers that normally could not do so call your code. Therefore, if you assert a permission, you should be sure to perform appropriate security checks beforehand to prevent your component from being misused.  
  
 For example, suppose your highly trusted library class has a method that deletes files. It accesses the file by calling an unmanaged Win32 function. A caller invokes your code's **Delete** method, passing in the name of the file to be deleted, C:\Test.txt. Within the **Delete** method, your code creates a <xref:System.Security.Permissions.FileIOPermission> object representing write access to C:\Test.txt. (Write access is required to delete a file.) Your code then invokes an imperative security check by calling the **FileIOPermission** object's **Demand** method. If one of the callers in the call stack does not have this permission, a <xref:System.Security.SecurityException> is thrown. If no exception is thrown, you know that all callers have the right to access C:\Test.txt. Because you believe that most of your callers will not have permission to access unmanaged code, your code then creates a <xref:System.Security.Permissions.SecurityPermission> object that represents the right to call unmanaged code and calls the object's **Assert** method. Finally, it calls the unmanaged Win32 function to delete C:\Text.txt and returns control to the caller.  
  
> [!CAUTION]
>  You must be sure that your code does not use assertions in situations where your code can be used by other code to access a resource that is protected by the permission you are asserting. For example, in code that writes to a file whose name is specified by the caller as a parameter, you would not assert the **FileIOPermission** for writing to files because your code would be open to misuse by a third party.  
  
 When you use the imperative security syntax, calling the **Assert** method on multiple permissions in the same method causes a security exception to be thrown. Instead, you should create a **PermissionSet** object, pass it the individual permissions you want to invoke, and then call the **Assert** method on the **PermissionSet** object. You can call the **Assert** method more than once when you use the declarative security syntax.  
  
 The following example shows declarative syntax for overriding security checks using the **Assert** method. Notice that the **FileIOPermissionAttribute** syntax takes two values: a <xref:System.Security.Permissions.SecurityAction> enumeration and the location of the file or directory to which permission is to be granted. The call to **Assert** causes demands for access to `C:\Log.txt` to succeed, even though callers are not checked for permission to access the file.  
  
```vb  
Option Explicit  
Option Strict  
  
Imports System  
Imports System.IO  
Imports System.Security.Permissions  
  
Namespace LogUtil  
   Public Class Log  
      Public Sub New()  
  
      End Sub  
  
     <FileIOPermission(SecurityAction.Assert, All := "C:\Log.txt")> Public Sub   
      MakeLog()  
         Dim TextStream As New StreamWriter("C:\Log.txt")  
         TextStream.WriteLine("This  Log was created on {0}", DateTime.Now) '  
         TextStream.Close()  
      End Sub  
   End Class  
End Namespace  
```  
  
```csharp  
namespace LogUtil  
{  
   using System;  
   using System.IO;  
   using System.Security.Permissions;  
  
   public class Log  
   {  
      public Log()  
      {      
      }     
      [FileIOPermission(SecurityAction.Assert, All = @"C:\Log.txt")]  
      public void MakeLog()  
      {     
         StreamWriter TextStream = new StreamWriter(@"C:\Log.txt");  
         TextStream.WriteLine("This  Log was created on {0}", DateTime.Now);  
         TextStream.Close();  
      }  
   }  
}   
```  
  
 The following code fragments show imperative syntax for overriding security checks using the **Assert** method. In this example, an instance of the **FileIOPermission** object is declared. Its constructor is passed **FileIOPermissionAccess.AllAccess** to define the type of access allowed, followed by a string describing the file's location. Once the **FileIOPermission** object is defined, you only need to call its **Assert** method to override the security check.  
  
```vb  
Option Explicit  
Option Strict  
Imports System  
Imports System.IO  
Imports System.Security.Permissions  
Namespace LogUtil  
   Public Class Log  
      Public Sub New()  
      End Sub 'New  
  
      Public Sub MakeLog()  
         Dim FilePermission As New FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\Log.txt")  
         FilePermission.Assert()  
         Dim TextStream As New StreamWriter("C:\Log.txt")  
         TextStream.WriteLine("This  Log was created on {0}", DateTime.Now)  
         TextStream.Close()  
      End Sub  
   End Class  
End Namespace  
```  
  
```csharp  
namespace LogUtil  
{  
   using System;  
   using System.IO;  
   using System.Security.Permissions;  
  
   public class Log  
   {  
      public Log()  
      {      
      }     
      public void MakeLog()  
      {  
         FileIOPermission FilePermission = new FileIOPermission(FileIOPermissionAccess.AllAccess,@"C:\Log.txt");   
         FilePermission.Assert();  
         StreamWriter TextStream = new StreamWriter(@"C:\Log.txt");  
         TextStream.WriteLine("This  Log was created on {0}", DateTime.Now);  
         TextStream.Close();  
      }  
   }  
}  
```  
  
## See Also  
 <xref:System.Security.PermissionSet>  
 <xref:System.Security.Permissions.SecurityPermission>  
 <xref:System.Security.Permissions.FileIOPermission>  
 <xref:System.Security.Permissions.SecurityAction>  
 [Attributes](../../../docs/standard/attributes/index.md)  
 [Code Access Security](../../../docs/framework/misc/code-access-security.md)

---
title: "Code Access Security Basics"
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
  - "security [.NET Framework], code access security"
ms.assetid: 4eaa6535-d9fe-41a1-91d8-b437cfc16921
caps.latest.revision: 21
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Code Access Security Basics
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 Every application that targets the common language runtime (that is, every managed application) must interact with the runtime's security system. When a managed application is loaded, its host automatically grants it a set of permissions. These permissions are determined by the host's local security settings or by the sandbox the application is in. Depending on these permissions, the application either runs properly or generates a security exception.  
  
 The default host for desktop applications allows code to run in full trust. Therefore, if your application targets the desktop, it has an unrestricted permission set. Other hosts or sandboxes provide a limited permission set for applications. Because the permission set can change from host to host, you must design your application to use only the permissions that your target host allows.  
  
 You must be familiar with the following code access security concepts in order to write effective applications that target the common language runtime:  
  
-   **Type-safe code**: Type-safe code is code that accesses types only in well-defined, allowable ways. For example, given a valid object reference, type-safe code can access memory at fixed offsets that correspond to actual field members. If the code accesses memory at arbitrary offsets outside the range of memory that belongs to that object's publicly exposed fields, it is not type-safe. To enable code to benefit from code access security, you must use a compiler that generates verifiably type-safe code. For more information, see the [Writing Verifiably Type-Safe Code](#typesafe_code) section later in this topic.  
  
-   **Imperative and declarative syntax**: Code that targets the common language runtime can interact with the security system by requesting permissions, demanding that callers have specified permissions, and overriding certain security settings (given enough privileges). You use two forms of syntax to programmatically interact with the .NET Framework security system: declarative syntax and imperative syntax. Declarative calls are performed using attributes; imperative calls are performed using new instances of classes within your code. Some calls can be performed only imperatively, others can be performed only declaratively, and some calls can be performed in either manner.  
  
-   **Secure class libraries**: A secure class library uses security demands to ensure that the library's callers have permission to access the resources that the library exposes. For example, a secure class library might have a method for creating files that would demand that its callers have permissions to create files. The .NET Framework consists of secure class libraries. You should be aware of the permissions required to access any library that your code uses. For more information, see the [Using Secure Class Libraries](#secure_library) section later in this topic.  
  
-   **Transparent code**: Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], in addition to identifying specific permissions, you must also determine whether your code should run as security-transparent. Security-transparent code cannot call types or members that are identified as security-critical. This rule applies to full-trust applications as well as partially trusted applications. For more information, see [Security-Transparent Code](../../../docs/framework/misc/security-transparent-code.md).  
  
<a name="typesafe_code"></a>   
## Writing Verifiably Type-Safe Code  
 Just-in-time (JIT) compilation performs a verification process that examines code and tries to determine whether the code is type-safe. Code that is proven during verification to be type-safe is called *verifiably type-safe code*. Code can be type-safe, yet might not be verifiably type-safe because of the limitations of the verification process or of the compiler. Not all languages are type-safe, and some language compilers, such as Microsoft Visual C++, cannot generate verifiably type-safe managed code. To determine whether the language compiler you use generates verifiably type-safe code, consult the compiler's documentation. If you use a language compiler that generates verifiably type-safe code only when you avoid certain language constructs, you might want to use the [PEVerify tool](../../../docs/framework/tools/peverify-exe-peverify-tool.md) to determine whether your code is verifiably type-safe.  
  
 Code that is not verifiably type-safe can attempt to execute if security policy allows the code to bypass verification. However, because type safety is an essential part of the runtime's mechanism for isolating assemblies, security cannot be reliably enforced if code violates the rules of type safety. By default, code that is not type-safe is allowed to run only if it originates from the local computer. Therefore, mobile code should be type-safe.  
  
<a name="secure_library"></a>   
## Using Secure Class Libraries  
 If your code requests and is granted the permissions required by the class library, it will be allowed to access the library and the resources that the library exposes will be protected from unauthorized access. If your code does not have the appropriate permissions, it will not be allowed to access the class library, and malicious code will not be able to use your code to indirectly access protected resources. Other code that calls your code must also have permission to access the library. If it does not, your code will be restricted from running as well.  
  
 Code access security does not eliminate the possibility of human error in writing code. However, if your application uses secure class libraries to access protected resources, the security risk for application code is decreased, because class libraries are closely scrutinized for potential security problems.  
  
## Declarative Security  
 Declarative security syntax uses [attributes](../../../docs/standard/attributes/index.md) to place security information into the [metadata](../../../docs/standard/metadata-and-self-describing-components.md) of your code. Attributes can be placed at the assembly, class, or member level, to indicate the type of request, demand, or override you want to use. Requests are used in applications that target the common language runtime to inform the runtime security system about the permissions that your application needs or does not want. Demands and overrides are used in libraries to help protect resources from callers or to override default security behavior.  
  
> [!NOTE]
>  In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], there have been important changes to the .NET Framework security model and terminology. For more information about these changes, see [Security Changes](../../../docs/framework/security/security-changes.md).  
  
 In order to use declarative security calls, you must initialize the state data of the permission object so that it represents the particular form of permission you need. Every built-in permission has an attribute that is passed a <xref:System.Security.Permissions.SecurityAction> enumeration to describe the type of security operation you want to perform. However, permissions also accept their own parameters that are exclusive to them.  
  
 The following code fragment shows declarative syntax for requesting that your code's callers have a custom permission called `MyPermission`. This permission is a hypothetical custom permission and does not exist in the .NET Framework. In this example, the declarative call is placed directly before the class definition, specifying that this permission be applied to the class level. The attribute is passed a **SecurityAction.Demand** structure to specify that callers must have this permission in order to run.  
  
```vb  
<MyPermission(SecurityAction.Demand, Unrestricted = True)> Public Class MyClass1  
  
   Public Sub New()  
      'The constructor is protected by the security call.  
   End Sub  
  
   Public Sub MyMethod()  
      'This method is protected by the security call.  
   End Sub  
  
   Public Sub YourMethod()  
      'This method is protected by the security call.  
   End Sub  
End Class  
```  
  
```csharp  
[MyPermission(SecurityAction.Demand, Unrestricted = true)]  
public class MyClass  
{  
   public MyClass()  
   {  
      //The constructor is protected by the security call.  
   }  
  
   public void MyMethod()  
   {  
      //This method is protected by the security call.  
   }  
  
   public void YourMethod()  
   {  
      //This method is protected by the security call.  
   }  
}  
```  
  
## Imperative Security  
 Imperative security syntax issues a security call by creating a new instance of the permission object you want to invoke. You can use imperative syntax to perform demands and overrides, but not requests.  
  
 Before you make the security call, you must initialize the state data of the permission object so that it represents the particular form of the permission you need. For example, when creating a <xref:System.Security.Permissions.FileIOPermission> object, you can use the constructor to initialize the **FileIOPermission** object so that it represents either unrestricted access to all files or no access to files. Or, you can use a different **FileIOPermission** object, passing parameters that indicate the type of access you want the object to represent (that is, read, append, or write) and what files you want the object to protect.  
  
 In addition to using imperative security syntax to invoke a single security object, you can use it to initialize a group of permissions in a permission set. For example, this technique is the only way to reliably perform [assert](../../../docs/framework/misc/using-the-assert-method.md) calls on multiple permissions in one method. Use the <xref:System.Security.PermissionSet> and <xref:System.Security.NamedPermissionSet> classes to create a group of permissions and then call the appropriate method to invoke the desired security call.  
  
 You can use imperative syntax to perform demands and overrides, but not requests. You might use imperative syntax for demands and overrides instead of declarative syntax when information that you need in order to initialize the permission state becomes known only at run time. For example, if you want to ensure that callers have permission to read a certain file, but you do not know the name of that file until run time, use an imperative demand. You might also choose to use imperative checks instead of declarative checks when you need to determine at run time whether a condition holds and, based on the result of the test, make a security demand (or not).  
  
 The following code fragment shows imperative syntax for requesting that your code's callers have a custom permission called `MyPermission`. This permission is a hypothetical custom permission and does not exist in the .NET Framework. A new instance of `MyPermision` is created in `MyMethod`, guarding only this method with the security call.  
  
```vb  
Public Class MyClass1  
  
   Public Sub New()  
  
   End Sub  
  
   Public Sub MyMethod()  
      'MyPermission is demanded using imperative syntax.  
      Dim Perm As New MyPermission()  
      Perm.Demand()  
      'This method is protected by the security call.  
   End Sub  
  
   Public Sub YourMethod()  
      'YourMethod 'This method is not protected by the security call.  
   End Sub  
End Class  
```  
  
```csharp  
public class MyClass {  
   public MyClass(){  
  
   }  
  
   public void MyMethod() {  
       //MyPermission is demanded using imperative syntax.  
       MyPermission Perm = new MyPermission();  
       Perm.Demand();  
       //This method is protected by the security call.  
   }  
  
   public void YourMethod() {  
       //This method is not protected by the security call.  
   }  
}  
```  
  
## Using Managed Wrapper Classes  
 Most applications and components (except secure libraries) should not directly call unmanaged code. There are several reasons for this. If code calls unmanaged code directly, it will not be allowed to run in many circumstances because code must be granted a high level of trust to call native code. If policy is modified to allow such an application to run, it can significantly weaken the security of the system, leaving the application free to perform almost any operation.  
  
 Additionally, code that has permission to access unmanaged code can probably perform almost any operation by calling into an unmanaged API. For example, code that has permission to call unmanaged code does not need <xref:System.Security.Permissions.FileIOPermission> to access a file; it can just call an unmanaged (Win32) file API directly, bypassing the managed file API that requires **FileIOPermission**. If managed code has permission to call into unmanaged code and does call directly into unmanaged code, the security system will be unable to reliably enforce security restrictions, since the runtime cannot enforce such restrictions on unmanaged code.  
  
 If you want your application to perform an operation that requires accessing unmanaged code, it should do so through a trusted managed class that wraps the required functionality (if such a class exists). Do not create a wrapper class yourself if one already exists in a secure class library. The wrapper class, which must be granted a high degree of trust to be allowed to make the call into unmanaged code, is responsible for demanding that its callers have the appropriate permissions. If you use the wrapper class, your code only needs to request and be granted the permissions that the wrapper class demands.  
  
## See Also  
 <xref:System.Security.PermissionSet>  
 <xref:System.Security.Permissions.FileIOPermission>  
 <xref:System.Security.NamedPermissionSet>  
 <xref:System.Security.Permissions.SecurityAction>  
 [Assert](../../../docs/framework/misc/using-the-assert-method.md)  
 [Code Access Security](../../../docs/framework/misc/code-access-security.md)  
 [Code Access Security Basics](../../../docs/framework/misc/code-access-security-basics.md)  
 [Attributes](../../../docs/standard/attributes/index.md)  
 [Metadata and Self-Describing Components](../../../docs/standard/metadata-and-self-describing-components.md)

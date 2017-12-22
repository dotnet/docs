---
title: "How to: Run Partially Trusted Code in a Sandbox"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "partially trusted code"
  - "sandboxing"
  - "partial trust"
  - "restricted security environment"
  - "code security, sandboxing"
ms.assetid: d1ad722b-5b49-4040-bff3-431b94bb8095
caps.latest.revision: 27
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Run Partially Trusted Code in a Sandbox
[!INCLUDE[net_security_note](../../../includes/net-security-note-md.md)]  
  
 Sandboxing is the practice of running code in a restricted security environment, which limits the access permissions granted to the code. For example, if you have a managed library from a source you do not completely trust, you should not run it as fully trusted. Instead, you should place the code in a sandbox that limits its permissions to those that you expect it to need (for example, <xref:System.Security.Permissions.SecurityPermissionFlag.Execution> permission).  
  
 You can also use sandboxing to test code you will be distributing that will run in partially trusted environments.  
  
 An <xref:System.AppDomain> is an effective way of providing a sandbox for managed applications. Application domains that are used for running partially trusted code have permissions that define the protected resources that are available when running within that <xref:System.AppDomain>. Code that runs inside the <xref:System.AppDomain> is bound by the permissions associated with the <xref:System.AppDomain> and is allowed to access only the specified resources. The <xref:System.AppDomain> also includes a <xref:System.Security.Policy.StrongName> array that is used to identify assemblies that are to be loaded as fully trusted. This enables the creator of an <xref:System.AppDomain> to start a new sandboxed domain that allows specific helper assemblies to be fully trusted. Another option for loading assemblies as fully trusted is to place them in the global assembly cache; however, that will load assemblies as fully trusted in all application domains created on that computer. The list of strong names supports a per-<xref:System.AppDomain> decision that provides more restrictive determination.  
  
 You can use the <xref:System.AppDomain.CreateDomain%28System.String%2CSystem.Security.Policy.Evidence%2CSystem.AppDomainSetup%2CSystem.Security.PermissionSet%2CSystem.Security.Policy.StrongName%5B%5D%29?displayProperty=nameWithType> method overload to specify the permission set for applications that run in a sandbox. This overload enables you to specify the exact level of code access security you want. Assemblies that are loaded into an <xref:System.AppDomain> by using this overload can either have the specified grant set only, or can be fully trusted. The assembly is granted full trust if it is in the global assembly cache or listed in the `fullTrustAssemblies` (the <xref:System.Security.Policy.StrongName>) array parameter. Only assemblies known to be fully trusted should be added to the `fullTrustAssemblies` list.  
  
 The overload has the following signature:  
  
```  
AppDomain.CreateDomain( string friendlyName,  
                        Evidence securityInfo,  
                        AppDomainSetup info,  
                        PermissionSet grantSet,  
                        params StrongName[] fullTrustAssemblies);  
```  
  
 The parameters for the <xref:System.AppDomain.CreateDomain%28System.String%2CSystem.Security.Policy.Evidence%2CSystem.AppDomainSetup%2CSystem.Security.PermissionSet%2CSystem.Security.Policy.StrongName%5B%5D%29> method overload specify the name of the <xref:System.AppDomain>, the evidence for the <xref:System.AppDomain>, the <xref:System.AppDomainSetup> object that identifies the application base for the sandbox, the permission set to use, and the strong names for fully trusted assemblies.  
  
 For security reasons, the application base specified in the `info` parameter should not be the application base for the hosting application.  
  
 For the `grantSet` parameter, you can specify either a permission set you have explicitly created, or a standard permission set created by the <xref:System.Security.SecurityManager.GetStandardSandbox%2A> method.  
  
 Unlike most <xref:System.AppDomain> loads, the evidence for the <xref:System.AppDomain> (which is provided by the `securityInfo` parameter) is not used to determine the grant set for the partially trusted assemblies. Instead, it is independently specified by the `grantSet` parameter. However, the evidence can be used for other purposes such as determining the isolated storage scope.  
  
### To run an application in a sandbox  
  
1.  Create the permission set to be granted to the untrusted application. The minimum permission you can grant is <xref:System.Security.Permissions.SecurityPermissionFlag.Execution> permission. You can also grant additional permissions you think might be safe for untrusted code; for example, <xref:System.Security.Permissions.IsolatedStorageFilePermission>. The following code creates a new permission set with only <xref:System.Security.Permissions.SecurityPermissionFlag.Execution> permission.  
  
    ```  
    PermissionSet permSet = new PermissionSet(PermissionState.None);  
    permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));  
    ```  
  
     Alternatively, you can use an existing named permission set, such as Internet.  
  
    ```  
    Evidence ev = new Evidence();  
    ev.AddHostEvidence(new Zone(SecurityZone.Internet));  
    PermissionSet internetPS = SecurityManager.GetStandardSandbox(ev);  
    ```  
  
     The <xref:System.Security.SecurityManager.GetStandardSandbox%2A> method returns either an `Internet` permission set or a `LocalIntranet` permission set depending on the zone in the evidence. <xref:System.Security.SecurityManager.GetStandardSandbox%2A> also constructs identity permissions for some of the evidence objects passed as references.  
  
2.  Sign the assembly that contains the hosting class (named `Sandboxer` in this example) that calls the untrusted code. Add the <xref:System.Security.Policy.StrongName> used to sign the assembly to the <xref:System.Security.Policy.StrongName> array of the `fullTrustAssemblies` parameter of the <xref:System.AppDomain.CreateDomain%2A> call. The hosting class must run as fully trusted to enable the execution of the partial-trust code or to offer services to the partial-trust application. This is how you read the <xref:System.Security.Policy.StrongName> of an assembly:  
  
    ```  
    StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();  
    ```  
  
     .NET Framework assemblies such as mscorlib and System.dll do not have to be added to the full-trust list because they are loaded as fully trusted from the global assembly cache.  
  
3.  Initialize the <xref:System.AppDomainSetup> parameter of the <xref:System.AppDomain.CreateDomain%2A> method. With this parameter, you can control many of the settings of the new <xref:System.AppDomain>. The <xref:System.AppDomainSetup.ApplicationBase%2A> property is an important setting, and should be different from the <xref:System.AppDomainSetup.ApplicationBase%2A> property for the <xref:System.AppDomain> of the hosting application. If the <xref:System.AppDomainSetup.ApplicationBase%2A> settings are the same, the partial-trust application can get the hosting application to load (as fully trusted) an exception it defines, thus exploiting it. This is another reason why a catch (exception) is not recommended. Setting the application base of the host differently from the application base of the sandboxed application mitigates the risk of exploits.  
  
    ```  
    AppDomainSetup adSetup = new AppDomainSetup();  
    adSetup.ApplicationBase = Path.GetFullPath(pathToUntrusted);  
    ```  
  
4.  Call the <xref:System.AppDomain.CreateDomain%28System.String%2CSystem.Security.Policy.Evidence%2CSystem.AppDomainSetup%2CSystem.Security.PermissionSet%2CSystem.Security.Policy.StrongName%5B%5D%29> method overload to create the application domain using the parameters we have specified.  
  
     The signature for this method is:  
  
    ```  
    public static AppDomain CreateDomain(string friendlyName,   
        Evidence securityInfo, AppDomainSetup info, PermissionSet grantSet,   
        params StrongName[] fullTrustAssemblies)  
    ```  
  
     Additional information:  
  
    -   This is the only overload of the <xref:System.AppDomain.CreateDomain%2A> method that takes a <xref:System.Security.PermissionSet> as a parameter, and thus the only overload that lets you load an application in a partial-trust setting.  
  
    -   The `evidence` parameter is not used to calculate a permission set; it is used for identification by other features of the .NET Framework.  
  
    -   Setting the <xref:System.AppDomainSetup.ApplicationBase%2A> property of the `info` parameter is mandatory for this overload.  
  
    -   The `fullTrustAssemblies` parameter has the `params` keyword, which means that it is not necessary to create a <xref:System.Security.Policy.StrongName> array. Passing 0, 1, or more strong names as parameters is allowed.  
  
    -   The code to create the application domain is:  
  
    ```  
    AppDomain newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, fullTrustAssembly);  
    ```  
  
5.  Load the code into the sandboxing <xref:System.AppDomain> that you created. This can be done in two ways:  
  
    -   Call the <xref:System.AppDomain.ExecuteAssembly%2A> method for the assembly.  
  
    -   Use the <xref:System.Activator.CreateInstanceFrom%2A> method to create an instance of a class derived from <xref:System.MarshalByRefObject> in the new <xref:System.AppDomain>.  
  
     The second method is preferable, because it makes it easier to pass parameters to the new <xref:System.AppDomain> instance. The <xref:System.Activator.CreateInstanceFrom%2A> method provides two important features:  
  
    -   You can use a code base that points to a location that does not contain your assembly.  
  
    -   You can do the creation under an <xref:System.Security.CodeAccessPermission.Assert%2A> for full-trust (<xref:System.Security.Permissions.PermissionState.Unrestricted?displayProperty=nameWithType>), which enables you to create an instance of a critical class. (This happens whenever your assembly has no transparency markings and is loaded as fully trusted.) Therefore, you have to be careful to create only code that you trust with this function, and we recommend that you create only instances of fully trusted classes in the new application domain.  
  
    ```  
    ObjectHandle handle = Activator.CreateInstanceFrom(  
    newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,  
           typeof(Sandboxer).FullName );  
    ```  
  
     Note that in order to create an instance of a class in a new domain, the class has to extend the <xref:System.MarshalByRefObject> class  
  
    ```  
    class Sandboxer:MarshalByRefObject  
    ```  
  
6.  Unwrap the new domain instance into a reference in this domain. This reference is used to execute the untrusted code.  
  
    ```  
    Sandboxer newDomainInstance = (Sandboxer) handle.Unwrap();  
    ```  
  
7.  Call the `ExecuteUntrustedCode` method in the instance of the `Sandboxer` class you just created.  
  
    ```  
    newDomainInstance.ExecuteUntrustedCode(untrustedAssembly, untrustedClass, entryPoint, parameters);  
    ```  
  
     This call is executed in the sandboxed application domain, which has restricted permissions.  
  
    ```  
    public void ExecuteUntrustedCode(string assemblyName, string typeName, string entryPoint, Object[] parameters)  
        {  
            //Load the MethodInfo for a method in the new assembly. This might be a method you know, or   
            //you can use Assembly.EntryPoint to get to the entry point in an executable.  
            MethodInfo target = Assembly.Load(assemblyName).GetType(typeName).GetMethod(entryPoint);  
            try  
            {  
                // Invoke the method.  
                target.Invoke(null, parameters);  
            }  
            catch (Exception ex)  
            {  
            //When information is obtained from a SecurityException extra information is provided if it is   
            //accessed in full-trust.  
                (new PermissionSet(PermissionState.Unrestricted)).Assert();  
                Console.WriteLine("SecurityException caught:\n{0}", ex.ToString());  
    CodeAccessPermission.RevertAssert();  
                Console.ReadLine();  
            }  
        }  
    ```  
  
     <xref:System.Reflection> is used to get a handle of a method in the partially trusted assembly. The handle can be used to execute code in a safe way with minimum permissions.  
  
     In the previous code, note the <xref:System.Security.PermissionSet.Assert%2A> for the full-trust permission before printing the <xref:System.Security.SecurityException>.  
  
    ```  
    new PermissionSet(PermissionState.Unrestricted)).Assert()  
    ```  
  
     The full-trust assert is used to obtain extended information from the <xref:System.Security.SecurityException>. Without the <xref:System.Security.PermissionSet.Assert%2A>, the <xref:System.Security.SecurityException.ToString%2A> method of <xref:System.Security.SecurityException> will discover that there is partially trusted code on the stack and will restrict the information returned. This could cause security issues if the partial-trust code could read that information, but the risk is mitigated by not granting <xref:System.Security.Permissions.UIPermission>. The full-trust assert should be used sparingly and only when you are sure that you are not allowing partial-trust code to elevate to full trust. As a rule, do not call code you do not trust in the same function and after you called an assert for full trust. It is good practice to always revert the assert when you have finished using it.  
  
## Example  
 The following example implements the procedure in the previous section. In the example, a project named `Sandboxer` in a Visual Studio solution also contains a project named `UntrustedCode`, which implements the class `UntrustedClass`. This scenario assumes that you have downloaded a library assembly containing a method that is expected to return `true` or `false` to indicate whether the number you provided is a Fibonacci number. Instead, the method attempts to read a file from your computer. The following example shows the untrusted code.  
  
```  
using System;  
using System.IO;  
namespace UntrustedCode  
{  
    public class UntrustedClass  
    {  
        // Pretend to be a method checking if a number is a Fibonacci  
        // but which actually attempts to read a file.  
        public static bool IsFibonacci(int number)  
        {  
           File.ReadAllText("C:\\Temp\\file.txt");  
           return false;  
        }  
    }  
}  
```  
  
 The following example shows the `Sandboxer` application code that executes the untrusted code.  
  
```  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.IO;  
using System.Security;  
using System.Security.Policy;  
using System.Security.Permissions;  
using System.Reflection;  
using System.Runtime.Remoting;  
  
//The Sandboxer class needs to derive from MarshalByRefObject so that we can create it in another   
// AppDomain and refer to it from the default AppDomain.  
class Sandboxer : MarshalByRefObject  
{  
    const string pathToUntrusted = @"..\..\..\UntrustedCode\bin\Debug";  
    const string untrustedAssembly = "UntrustedCode";  
    const string untrustedClass = "UntrustedCode.UntrustedClass";  
    const string entryPoint = "IsFibonacci";  
    private static Object[] parameters = { 45 };  
    static void Main()  
    {  
        //Setting the AppDomainSetup. It is very important to set the ApplicationBase to a folder   
        //other than the one in which the sandboxer resides.  
        AppDomainSetup adSetup = new AppDomainSetup();  
        adSetup.ApplicationBase = Path.GetFullPath(pathToUntrusted);  
  
        //Setting the permissions for the AppDomain. We give the permission to execute and to   
        //read/discover the location where the untrusted code is loaded.  
        PermissionSet permSet = new PermissionSet(PermissionState.None);  
        permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));  
  
        //We want the sandboxer assembly's strong name, so that we can add it to the full trust list.  
        StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();  
  
        //Now we have everything we need to create the AppDomain, so let's create it.  
        AppDomain newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, fullTrustAssembly);  
  
        //Use CreateInstanceFrom to load an instance of the Sandboxer class into the  
        //new AppDomain.   
        ObjectHandle handle = Activator.CreateInstanceFrom(  
            newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,  
            typeof(Sandboxer).FullName  
            );  
        //Unwrap the new domain instance into a reference in this domain and use it to execute the   
        //untrusted code.  
        Sandboxer newDomainInstance = (Sandboxer) handle.Unwrap();  
        newDomainInstance.ExecuteUntrustedCode(untrustedAssembly, untrustedClass, entryPoint, parameters);  
    }  
    public void ExecuteUntrustedCode(string assemblyName, string typeName, string entryPoint, Object[] parameters)  
    {  
        //Load the MethodInfo for a method in the new Assembly. This might be a method you know, or   
        //you can use Assembly.EntryPoint to get to the main function in an executable.  
        MethodInfo target = Assembly.Load(assemblyName).GetType(typeName).GetMethod(entryPoint);  
        try  
        {  
            //Now invoke the method.  
            bool retVal = (bool)target.Invoke(null, parameters);  
        }  
        catch (Exception ex)  
        {  
            // When we print informations from a SecurityException extra information can be printed if we are   
            //calling it with a full-trust stack.  
            (new PermissionSet(PermissionState.Unrestricted)).Assert();  
            Console.WriteLine("SecurityException caught:\n{0}", ex.ToString());  
            CodeAccessPermission.RevertAssert();  
            Console.ReadLine();  
        }  
    }  
}  
```  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)

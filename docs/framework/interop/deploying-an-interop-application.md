---
title: "Deploying an Interop Application"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "deploying applications [.NET Framework], interop"
  - "strong-named assemblies, interop applications"
  - "unsigned assemblies"
  - "private assemblies"
  - "exposing COM components to .NET Framework"
  - "interoperation with unmanaged code, deploying applications"
  - "shared assemblies"
  - "COM interop, deploying applications"
  - "interoperation with unmanaged code, exposing COM components"
  - "signed assemblies"
  - "COM interop, exposing COM components"
ms.assetid: ea8a403e-ae03-4faa-9d9b-02179ec72992
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Deploying an Interop Application
An interop application typically includes a .NET client assembly, one or more interop assemblies representing distinct COM type libraries, and one or more registered COM components. Visual Studio and the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] provide tools to import and convert a type library to an interop assembly, as discussed in [Importing a Type Library as an Assembly](importing-a-type-library-as-an-assembly.md). There are two ways to deploy an interop application:  
  
-   By using embedded interop types: Beginning with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], you can instruct the compiler to embed type information from an interop assembly into your executable. The compiler embeds only the type information that your application uses. You do not have to deploy the interop assembly with your application. This is the recommended technique.  
  
-   By deploying interop assemblies: You can create a standard reference to an interop assembly. In this case, the interop assembly must be deployed with your application. If you employ this technique, and you are not using a private COM component, always reference the primary interop assembly (PIA) published by the author of the COM component you intend to incorporate in your managed code. For more information about producing and using primary interop assemblies, see [Primary Interop Assemblies](https://msdn.microsoft.com/library/b977a8be-59a0-40a0-a806-b11ffba5c080(v=vs.100)).  
  
 If you use embedded interop types, deployment is simple and straightforward. There is nothing special you need to do. The rest of this article describes the scenarios for deploying interop assemblies with your application.  
  
## Deploying Interop Assemblies  
 Assemblies can have strong names. A strong-named assembly includes the publisher's public key, which provides a unique identity. Assemblies that are produced by the [Type Library Importer (Tlbimp.exe)](../tools/tlbimp-exe-type-library-importer.md) can be signed by the publisher by using the **/keyfile** option. You can install signed assemblies into the global assembly cache. Unsigned assemblies must be installed on the user's machine as private assemblies.  
  
### Private Assemblies  
 To install an assembly to be used privately, both the application executable and the interop assembly that contains imported COM types must be installed in the same directory structure. The following illustration shows an unsigned interop assembly to be used privately by Client1.exe and Client2.exe, which reside in separate application directories. The interop assembly, which is called LOANLib.dll in this example, is installed twice.  
  
 ![Directory structure and Windows registry](media/comdeployprivate.gif "comdeployprivate")  
Directory structure and registry entries for a private deployment  
  
 All COM components associated with the application must be installed in the Windows registry. If Client1.exe and Client2.exe in the illustration are installed on different computers, you must register the COM components on both computers.  
  
### Shared Assemblies  
 Assemblies that are shared by multiple applications should be installed in a centralized repository called the global assembly cache. .NET clients can access the same copy of the interop assembly, which is signed and installed in the global assembly cache. For more information about producing and using primary interop assemblies, see [Primary Interop Assemblies](https://msdn.microsoft.com/library/b977a8be-59a0-40a0-a806-b11ffba5c080(v=vs.100)).  
  
## See Also  
 [Exposing COM Components to the .NET Framework](exposing-com-components.md)  
 [Importing a Type Library as an Assembly](importing-a-type-library-as-an-assembly.md)  
 [Using COM Types in Managed Code](https://msdn.microsoft.com/library/1a95a8ca-c8b8-4464-90b0-5ee1a1135b66(v=vs.100))  
 [Compiling an Interop Project](compiling-an-interop-project.md)

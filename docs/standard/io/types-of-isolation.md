---
title: "Types of Isolation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "storing data using isolated storage, accessing isolated storage"
  - "storing data using isolated storage, isolation types"
  - "authentication [.NET Framework], isolated storage"
  - "assemblies [.NET Framework], identity"
  - "isolated storage, accessing"
  - "data storage using isolated storage, isolation types"
  - "data storage using isolated storage, accessing isolated storage"
  - "domain identity"
  - "isolated storage, types"
  - "user authentication, isolated storage"
ms.assetid: 14812988-473f-44ae-b75f-fd5c2f21fb7b
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Types of Isolation
Access to isolated storage is always restricted to the user who created it. To implement this type of isolation, the common language runtime uses the same notion of user identity that the operating system recognizes, which is the identity associated with the process in which the code is running when the store is opened. This identity is an authenticated user identity, but impersonation can cause the identity of the current user to change dynamically.  
  
 Access to isolated storage is also restricted according to the identity associated with the application's domain and assembly, or with the assembly alone. The runtime obtains these identities in the following ways:  
  
-   Domain identity represents the evidence of the application, which in the case of a web application might be the full URL. For shell-hosted code, the domain identity might be based on the application directory path. For example, if the executable runs from the path C:\Office\MyApp.exe, the domain identity would be C:\Office\MyApp.exe.  
  
-   Assembly identity is the evidence of the assembly. This might come from a cryptographic digital signature, which can be the assembly's [strong name](../../../docs/framework/app-domains/strong-named-assemblies.md), the software publisher of the assembly, or its URL identity. If an assembly has both a strong name and a software publisher identity, then the software publisher identity is used. If the assembly comes from the Internet and is unsigned, the URL identity is used. For more information about assemblies and strong names, see [Programming with Assemblies](../../../docs/framework/app-domains/programming-with-assemblies.md).  
  
-   Roaming stores move with a user that has a roaming user profile. Files are written to a network directory and are downloaded to any computer the user logs into. For more information about roaming user profiles, see <xref:System.IO.IsolatedStorage.IsolatedStorageScope.Roaming?displayProperty=nameWithType>.  
  
 By combining the concepts of user, domain, and assembly identity, isolated storage can isolate data in the following ways, each of which has its own usage scenarios:  
  
-   [Isolation by user and assembly](#UserAssembly)  
  
-   [Isolation by user, domain, and assembly](#UserDomainAssembly)  
  
 Either of these isolations can be combined with a roaming user profile. For more information, see the section [Isolated Storage and Roaming](#Roaming).  
  
 The following illustration demonstrates how stores are isolated in different scopes.  
  
 ![Isolation by user and assembly](../../../docs/standard/io/media/typesofisolation.gif "typesofisolation")  
Types of isolated storage  
  
 Note that except for roaming stores, isolated storage is always implicitly isolated by computer because it uses the storage facilities that are local to a given computer.  
  
> [!IMPORTANT]
>  Isolated storage is not available for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps. Instead, use the application data classes in the `Windows.Storage` namespaces included in the [!INCLUDE[wrt](../../../includes/wrt-md.md)] API to store local data and files. For more information, see [Application data](/previous-versions/windows/apps/hh464917(v=win.10)) in the Windows Dev Center.  
  
<a name="UserAssembly"></a>   
## Isolation by User and Assembly  
 When the assembly that uses the data store needs to be accessible from any application's domain, isolation by user and assembly is appropriate. Typically, in this situation, isolated storage is used to store data that applies across multiple applications and is not tied to any particular application, such as the user's name or license information. To access storage isolated by user and assembly, code must be trusted to transfer information between applications. Typically, isolation by user and assembly is allowed on intranets but not on the Internet. Calling the static <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A?displayProperty=nameWithType> method and passing in a user and an assembly <xref:System.IO.IsolatedStorage.IsolatedStorageScope> returns storage with this kind of isolation.  
  
 The following code example retrieves a store that is isolated by user and assembly. The store can be accessed through the `isoFile` object.  
  
 [!code-cpp[Conceptual.IsolatedStorage#17](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source11.cpp#17)]
 [!code-csharp[Conceptual.IsolatedStorage#17](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source11.cs#17)]
 [!code-vb[Conceptual.IsolatedStorage#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source11.vb#17)]  
  
 For an example that uses the evidence parameters, see <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%28System.IO.IsolatedStorage.IsolatedStorageScope%2CSystem.Security.Policy.Evidence%2CSystem.Type%2CSystem.Security.Policy.Evidence%2CSystem.Type%29>.  
  
 The <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForAssembly%2A> method is available as a shortcut, as shown in the following code example. This shortcut cannot be used to open stores that are capable of roaming; use <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> in such cases.  
  
 [!code-cpp[Conceptual.IsolatedStorage#18](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source11.cpp#18)]
 [!code-csharp[Conceptual.IsolatedStorage#18](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source11.cs#18)]
 [!code-vb[Conceptual.IsolatedStorage#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source11.vb#18)]  
  
<a name="UserDomainAssembly"></a>   
## Isolation by User, Domain, and Assembly  
 If your application uses a third-party assembly that requires a private data store, you can use isolated storage to store the private data. Isolation by user, domain, and assembly ensures that only code in a given assembly can access the data, and only when the assembly is used by the application that was running when the assembly created the store, and only when the user for whom the store was created runs the application. Isolation by user, domain, and assembly keeps the third-party assembly from leaking data to other applications. This isolation type should be your default choice if you know that you want to use isolated storage but are not sure which type of isolation to use. Calling the static <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> method of <xref:System.IO.IsolatedStorage.IsolatedStorageFile> and passing in a user, domain, and assembly <xref:System.IO.IsolatedStorage.IsolatedStorageScope> returns storage with this kind of isolation.  
  
 The following code example retrieves a store isolated by user, domain, and assembly. The store can be accessed through the `isoFile` object.  
  
 [!code-cpp[Conceptual.IsolatedStorage#14](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source10.cpp#14)]
 [!code-csharp[Conceptual.IsolatedStorage#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source10.cs#14)]
 [!code-vb[Conceptual.IsolatedStorage#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source10.vb#14)]  
  
 Another method is available as a shortcut, as shown in the following code example. This shortcut cannot be used to open stores that are capable of roaming; use <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetStore%2A> in such cases.  
  
 [!code-cpp[Conceptual.IsolatedStorage#15](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source10.cpp#15)]
 [!code-csharp[Conceptual.IsolatedStorage#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source10.cs#15)]
 [!code-vb[Conceptual.IsolatedStorage#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source10.vb#15)]  
  
<a name="Roaming"></a>   
## Isolated Storage and Roaming  
 Roaming user profiles are a Windows feature that enables a user to set up an identity on a network and use that identity to log into any network computer, carrying over all personalized settings. An assembly that uses isolated storage can specify that the user's isolated storage should move with the roaming user profile. Roaming can be used in conjunction with isolation by user and assembly or with isolation by user, domain, and assembly. If a roaming scope is not used, stores will not roam even if a roaming user profile is used.  
  
 The following code example retrieves a roaming store isolated by user and assembly. The store can be accessed through the `isoFile` object.  
  
 [!code-cpp[Conceptual.IsolatedStorage#11](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source9.cpp#11)]
 [!code-csharp[Conceptual.IsolatedStorage#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source9.cs#11)]
 [!code-vb[Conceptual.IsolatedStorage#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source9.vb#11)]  
  
 A domain scope can be added to create a roaming store isolated by user, domain, and application. The following code example demonstrates this.  
  
 [!code-cpp[Conceptual.IsolatedStorage#12](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.isolatedstorage/cpp/source9.cpp#12)]
 [!code-csharp[Conceptual.IsolatedStorage#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source9.cs#12)]
 [!code-vb[Conceptual.IsolatedStorage#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source9.vb#12)]  
  
## See Also  
 <xref:System.IO.IsolatedStorage.IsolatedStorageScope>  
 [Isolated Storage](../../../docs/standard/io/isolated-storage.md)

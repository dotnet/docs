---
title: "Isolated Storage"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "data storage using isolated storage"
  - "stores"
  - "storing data using isolated storage"
  - "isolated storage"
  - "location of isolated storage in file system"
  - "standardizing storage systems"
  - "storing data using isolated storage, when not to use"
  - "code, isolated storage"
  - "isolated storage, options"
  - "data storage using isolated storage, when not to use"
  - "storing data using isolated storage, options"
  - "isolated storage, when not to use"
  - "data storage using isolated storage, options"
  - "isolation"
ms.assetid: aff939d7-9e49-46f2-a8cd-938d3020e94e
caps.latest.revision: 32
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Isolated Storage
<a name="top"></a> For [!INCLUDE[desktop_appname](../../../includes/desktop-appname-md.md)] apps, isolated storage is a data storage mechanism that provides isolation and safety by defining standardized ways of associating code with saved data. Standardization provides other benefits as well. Administrators can use tools designed to manipulate isolated storage to configure file storage space, set security policies, and delete unused data. With isolated storage, your code no longer needs unique paths to specify safe locations in the file system, and data is protected from other applications that only have isolated storage access. Hard-coded information that indicates where an application's storage area is located is unnecessary.  
  
> [!IMPORTANT]
>  Isolated storage is not available for [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps. Instead, use the application data classes in the `Windows.Storage` namespaces included in the [!INCLUDE[wrt](../../../includes/wrt-md.md)] API to store local data and files. For more information, see [Application data](/previous-versions/windows/apps/hh464917(v=win.10)) in the Windows Dev Center.  
  
 This topic contains the following sections:  
  
-   [Data Compartments and Stores](#data_compartments_and_stores)  
  
-   [Quotas for Isolated Storage](#quotas)  
  
-   [Secure Access](#secure_access)  
  
-   [Allowed Usage and Security Risks](#allowed_usage)  
  
-   [Isolated Storage Locations](#isolated_storage_locations)  
  
-   [Creating, Enumerating, and Deleting Isolated Storage](#isolated_storage_tasks)  
  
-   [Scenarios for Isolated Storage](#scenarios_for_isolated_storage)  
  
-   [Related Topics](#related_topics)  
  
-   [Reference](#reference)  
  
<a name="data_compartments_and_stores"></a>   
## Data Compartments and Stores  
 When an application stores data in a file, the file name and storage location must be carefully chosen to minimize the possibility that the storage location will be known to another application and, therefore, will be vulnerable to corruption. Without a standard system in place to manage these problems, developing ad hoc techniques that minimize storage conflicts can be complex, and the results can be unreliable.  
  
 With isolated storage, data is always isolated by user and by assembly. Credentials such as the origin or the strong name of the assembly determine assembly identity. Data can also be isolated by application domain, using similar credentials.  
  
 When you use isolated storage, your application saves data to a unique data compartment that is associated with some aspect of the code's identity, such as its publisher or signature. The data compartment is an abstraction, not a specific storage location; it consists of one or more isolated storage files, called stores, which contain the actual directory locations where data is stored. For example, an application might have a data compartment associated with it, and a directory in the file system would implement the store that actually preserves the data for that application. The data saved in the store can be any kind of data, from user preference information to application state. For the developer, the location of the data compartment is transparent. Stores usually reside on the client, but a server application could use isolated stores to store information by impersonating the user on whose behalf it is functioning. Isolated storage can also store information on a server with a user's roaming profile so that the information will travel with the roaming user.  
  
  
<a name="quotas"></a>   
## Quotas for Isolated Storage  
 A quota is a limit on the amount of isolated storage that can be used. The quota includes bytes of file space as well as the overhead associated with the directory and other information in the store. Isolated storage uses permission quotas, which are storage limits that are set by using <xref:System.Security.Permissions.IsolatedStoragePermission> objects. If you try to write data that exceeds the quota, an <xref:System.IO.IsolatedStorage.IsolatedStorageException> exception is thrown.  Security policy, which can be modified using the .NET Framework Configuration Tool (Mscorcfg.msc), determines which permissions are granted to code. Code that has been granted <xref:System.Security.Permissions.IsolatedStoragePermission> is restricted to using no more storage than the <xref:System.Security.Permissions.IsolatedStoragePermission.UserQuota%2A> property allows. However, because code can bypass permission quotas by presenting different user identities, permission quotas serve as guidelines for how code should behave rather than as a firm limit on code behavior.  
  
 Quotas are not enforced on roaming stores. Because of this, a slightly higher level of permission is required for code to use them. The enumeration values <xref:System.Security.Permissions.IsolatedStorageContainment.AssemblyIsolationByRoamingUser> and <xref:System.Security.Permissions.IsolatedStorageContainment.DomainIsolationByRoamingUser> specify a permission to use isolated storage for a roaming user.  
  
  
<a name="secure_access"></a>   
## Secure Access  
 Using isolated storage enables partially trusted applications to store data in a manner that is controlled by the computer's security policy. This is especially useful for downloaded components that a user might want to run cautiously. Security policy rarely grants this kind of code permission when you access the file system by using standard I/O mechanisms. However, by default, code running from the local computer, a local network, or the Internet is granted the right to use isolated storage.  
  
 Administrators can limit how much isolated storage an application or a user has available, based on an appropriate trust level. In addition, administrators can remove a user's persisted data completely. To create or access isolated storage, code must be granted the appropriate <xref:System.Security.Permissions.IsolatedStorageFilePermission> permission.  
  
 To access isolated storage, code must have all necessary native platform operating system rights. The access control lists (ACLs) that control which users have the rights to use the file system must be satisfied. .NET Framework applications already have operating system rights to access isolated storage unless they perform (platform-specific) impersonation. In this case, the application is responsible for ensuring that the impersonated user identity has the proper operating system rights to access isolated storage. This access provides a convenient way for code that is run or downloaded from the web to read and write to a storage area related to a particular user.  
  
 To control access to isolated storage, the common language runtime uses <xref:System.Security.Permissions.IsolatedStorageFilePermission> objects. Each object has properties that specify the following values:  
  
-   Allowed usage, which indicates the type of access that is allowed. The values are members of the <xref:System.Security.Permissions.IsolatedStorageContainment> enumeration. For more information about these values, see the table in the next section.  
  
-   Storage quota, as discussed in the preceding section.  
  
 The runtime demands <xref:System.Security.Permissions.IsolatedStorageFilePermission> permission when code first attempts to open a store. It decides whether to grant this permisson, based on how much the code is trusted. If the permission is granted, the allowed usage and storage quota values are determined by security policy and by the code's request for <xref:System.Security.Permissions.IsolatedStorageFilePermission>. Security policy is set by using the .NET Framework Configuration Tool (Mscorcfg.msc). All callers in the call stack are checked to ensure that each caller has at least the appropriate allowed usage. The runtime also checks the quota imposed on the code that opened or created the store in which the file is to be saved. If these conditions are satisfied, permission is granted. The quota is checked again every time a file is written to the store.  
  
 Application code is not required to request permission because the common language runtime will grant whatever <xref:System.Security.Permissions.IsolatedStorageFilePermission> is appropriate based on security policy. However, there are good reasons to request specific permissions that your application needs, including <xref:System.Security.Permissions.IsolatedStorageFilePermission>.  
  
  
<a name="allowed_usage"></a>   
## Allowed Usage and Security Risks  
 The allowed usage specified by <xref:System.Security.Permissions.IsolatedStorageFilePermission> determines the degree to which code will be allowed to create and use isolated storage. The following table shows how the allowed usage specified in the permission corresponds to types of isolation and summarizes the security risks associated with each allowed usage.  
  
|Allowed usage|Isolation types|Security impact|  
|-------------------|---------------------|---------------------|  
|<xref:System.Security.Permissions.IsolatedStorageContainment.None>|No isolated storage use is allowed.|There is no security impact.|  
|<xref:System.Security.Permissions.IsolatedStorageContainment.DomainIsolationByUser>|Isolation by user, domain, and assembly. Each assembly has a separate substore within the domain. Stores that use this permission are also implicitly isolated by computer.|This permission level leaves resources open to unauthorized overuse, although enforced quotas make it more difficult. This is called a denial of service attack.|  
|<xref:System.Security.Permissions.IsolatedStorageContainment.DomainIsolationByRoamingUser>|Same as `DomainIsolationByUser`, but store is saved to a location that will roam if roaming user profiles are enabled and quotas are not enforced.|Because quotas must be disabled, storage resources are more vulnerable to a denial of service attack.|  
|<xref:System.Security.Permissions.IsolatedStorageContainment.AssemblyIsolationByUser>|Isolation by user and assembly. Stores that use this permission are also implicitly isolated by computer.|Quotas are enforced at this level to help prevent a denial of service attack. The same assembly in another domain can access this store, opening the possibility that information could be leaked between applications.|  
|<xref:System.Security.Permissions.IsolatedStorageContainment.AssemblyIsolationByRoamingUser>|Same as `AssemblyIsolationByUser`, but store is saved to a location that will roam if roaming user profiles are enabled and quotas are not enforced.|Same as in `AssemblyIsolationByUser`, but without quotas, the risk of a denial of service attack increases.|  
|<xref:System.Security.Permissions.IsolatedStorageContainment.AdministerIsolatedStorageByUser>|Isolation by user. Typically, only administrative or debugging tools use this level of permission.|Access with this permission allows code to view or delete any of a user's isolated storage files or directories (regardless of assembly isolation). Risks include, but are not limited to, leaking information and data loss.|  
|<xref:System.Security.Permissions.IsolatedStorageContainment.UnrestrictedIsolatedStorage>|Isolation by all users, domains, and assemblies. Typically, only administrative or debugging tools use this level of permission.|This permission creates the potential for a total compromise of all isolated stores for all users.|  
  
  
<a name="isolated_storage_locations"></a>   
## Isolated Storage Locations  
 Sometimes it is helpful to verify a change to isolated storage by using the file system of the operating system. You might also want to know the location of isolated storage files. This location is different depending on the operating system. The following table shows the root locations where isolated storage is created on a few common operating systems. Look for Microsoft\IsolatedStorage directories under this root location. You must change folder settings to show hidden files and folders in order to see isolated storage in the file system.  
  
|Operating system|Location in file system|  
|----------------------|-----------------------------|  
|Windows 2000, Windows XP, Windows Server 2003  (upgrade from Windows NT 4.0)|Roaming-enabled stores =<br /><br /> \<SYSTEMROOT>\Profiles\\<user\>\Application Data<br /><br /> Nonroaming stores =<br /><br /> \<SYSTEMROOT>\Profiles\\<user\>\Local Settings\Application Data|  
|Windows 2000  - clean installation (and upgrades from Windows 98 and Windows NT 3.51)|Roaming-enabled stores =<br /><br /> \<SYSTEMDRIVE>\Documents and Settings\\<user\>\Application Data<br /><br /> Nonroaming stores =<br /><br /> \<SYSTEMDRIVE>\Documents and Settings\\<user\>\Local Settings\Application Data|  
|Windows XP, Windows Server 2003 - clean installation (and upgrades from Windows 2000 and Windows 98)|Roaming-enabled stores =<br /><br /> \<SYSTEMDRIVE>\Documents and Settings\\<user\>\Application Data<br /><br /> Nonroaming stores =<br /><br /> \<SYSTEMDRIVE>\Documents and Settings\\<user\>\Local Settings\Application Data|  
|[!INCLUDE[win8](../../../includes/win8-md.md)], Windows 7, Windows Server 2008, Windows Vista|Roaming-enabled stores =<br /><br /> \<SYSTEMDRIVE>\Users\\<user\>\AppData\Roaming<br /><br /> Nonroaming stores =<br /><br /> \<SYSTEMDRIVE>\Users\\<user\>\AppData\Local|  
  
  
<a name="isolated_storage_tasks"></a>   
## Creating, Enumerating, and Deleting Isolated Storage  
 The .NET Framework provides three classes in the <xref:System.IO.IsolatedStorage> namespace to help you perform tasks that involve isolated storage:  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageFile>, derives from <xref:System.IO.IsolatedStorage.IsolatedStorage?displayProperty=nameWithType> and provides basic management of stored assembly and application files. An instance of the <xref:System.IO.IsolatedStorage.IsolatedStorageFile> class represents a single store located in the file system.  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream> derives from <xref:System.IO.FileStream?displayProperty=nameWithType> and provides access to the files in a store.  
  
-   <xref:System.IO.IsolatedStorage.IsolatedStorageScope> is an enumeration that enables you to create and select a store with the appropriate isolation type.  
  
 The isolated storage classes enable you to create, enumerate, and delete isolated storage. The methods for performing these tasks are available through the <xref:System.IO.IsolatedStorage.IsolatedStorageFile> object. Some operations require you to have the <xref:System.Security.Permissions.IsolatedStorageFilePermission> permission that represents the right to administer isolated storage; you might also need to have operating system rights to access the file or directory.  
  
 For a series of examples that demonstrate common isolated storage tasks, see the how-to topics listed in [Related Topics](#related_topics).  
  
  
<a name="scenarios_for_isolated_storage"></a>   
## Scenarios for Isolated Storage  
 Isolated storage is useful in many situations, including these four scenarios:  
  
-   Downloaded controls. Managed code controls downloaded from the Internet are not allowed to write to the hard drive through normal I/O classes, but they can use isolated storage to persist users' settings and application states.  
  
-   Shared component storage. Components that are shared between applications can use isolated storage to provide controlled access to data stores.  
  
-   Server storage. Server applications can use isolated storage to provide individual stores for a large number of users making requests to the application. Because isolated storage is always segregated by user, the server must impersonate the user making the request. In this case, data is isolated based on the identity of the principal, which is the same identity the application uses to distinguish between its users.  
  
-   Roaming. Applications can also use isolated storage with roaming user profiles. This allows a user's isolated stores to roam with the profile.  
  
 You should not use isolated storage in the following situations:  
  
-   To store high-value secrets, such as unencrypted keys or passwords, because isolated storage is not protected from highly trusted code, from unmanaged code, or from trusted users of the computer.  
  
-   To store code.  
  
-   To store configuration and deployment settings, which administrators control. (User preferences are not considered to be configuration settings because administrators do not control them.)  
  
 Many applications use a database to store and isolate data, in which case one or more rows in a database might represent storage for a specific user. You might choose to use isolated storage instead of a database when the number of users is small, when the overhead of using a database is significant, or when no database facility exists. Also, when the application requires storage that is more flexible and complex than what a row in a database provides, isolated storage can provide a viable alternative.  
  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Types of Isolation](../../../docs/standard/io/types-of-isolation.md)|Describes the different types of isolation.|  
|[How to: Obtain Stores for Isolated Storage](../../../docs/standard/io/how-to-obtain-stores-for-isolated-storage.md)|Provides an example of using the <xref:System.IO.IsolatedStorage.IsolatedStorageFile> class to obtain a store isolated by user and assembly.|  
|[How to: Enumerate Stores for Isolated Storage](../../../docs/standard/io/how-to-enumerate-stores-for-isolated-storage.md)|Shows how to use the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.GetEnumerator%2A?displayProperty=nameWithType> method to calculate the size of all isolated storage for the user.|  
|[How to: Delete Stores in Isolated Storage](../../../docs/standard/io/how-to-delete-stores-in-isolated-storage.md)|Shows how to use the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.Remove%2A?displayProperty=nameWithType> method in two different ways to delete isolated stores.|  
|[How to: Anticipate Out-of-Space Conditions with Isolated Storage](../../../docs/standard/io/how-to-anticipate-out-of-space-conditions-with-isolated-storage.md)|Shows how to measure the remaining space in an isolated store.|  
|[How to: Create Files and Directories in Isolated Storage](../../../docs/standard/io/how-to-create-files-and-directories-in-isolated-storage.md)|Provides some examples of creating files and directories in an isolated store.|  
|[How to: Find Existing Files and Directories in Isolated Storage](../../../docs/standard/io/how-to-find-existing-files-and-directories-in-isolated-storage.md)|Demonstrates how to read the directory structure and files in isolated storage.|  
|[How to: Read and Write to Files in Isolated Storage](../../../docs/standard/io/how-to-read-and-write-to-files-in-isolated-storage.md)|Provides an example of writing a string to an isolated storage file and reading it back.|  
|[How to: Delete Files and Directories in Isolated Storage](../../../docs/standard/io/how-to-delete-files-and-directories-in-isolated-storage.md)|Demonstrates how to delete isolated storage files and directories.|  
|[File and Stream I-O](../../../docs/standard/io/index.md)|Explains how you can perform synchronous and asynchronous file and data stream access.|  
  
<a name="reference"></a>   
## Reference  
 <xref:System.IO.IsolatedStorage.IsolatedStorage?displayProperty=nameWithType>  
  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFile?displayProperty=nameWithType>  
  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream?displayProperty=nameWithType>  
  
 <xref:System.IO.IsolatedStorage.IsolatedStorageScope?displayProperty=nameWithType>

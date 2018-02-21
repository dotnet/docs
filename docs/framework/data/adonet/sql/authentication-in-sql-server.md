---
title: "Authentication in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 646ddbf5-dd4e-4285-8e4a-f565f666c5cc
caps.latest.revision: 9
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Authentication in SQL Server
[!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] supports two authentication modes, Windows authentication mode and mixed mode.  
  
-   Windows authentication is the default, and is often referred to as integrated security because this [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] security model is tightly integrated with Windows. Specific Windows user and group accounts are trusted to log in to SQL Server. Windows users who have already been authenticated do not have to present additional credentials.  
  
-   Mixed mode supports authentication both by Windows and by [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)]. User name and password pairs are maintained within [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)].  
  
> [!IMPORTANT]
>  We recommend using Windows authentication wherever possible. Windows authentication uses a series of encrypted messages to authenticate users in [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)]. When [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] logins are used, [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] login names and passwords are passed across the network, which makes them less secure.  
  
 With Windows authentication, users are already logged onto Windows and do not have to log on separately to [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)]. The following `SqlConnection.ConnectionString` specifies Windows authentication without requiring the a user name or password.  
  
```  
"Server=MSSQL1;Database=AdventureWorks;Integrated Security=true;  
```  
  
> [!NOTE]
>  Logins are distinct from database users. You must map logins or Windows groups to database users or roles in a separate operation. You then grant permissions to users or roles to access database objects.  
  
## Authentication Scenarios  
 Windows authentication is usually the best choice in the following situations:  
  
-   There is a domain controller.  
  
-   The application and the database are on the same computer.  
  
-   You are using an instance of [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] Express or LocalDB.  
  
 SQL Server logins are often used in the following situations:  
  
-   If you have a workgroup.  
  
-   Users connect from different, non-trusted domains.  
  
-   Internet applications, such as [!INCLUDE[vstecasp](../../../../../includes/vstecasp-md.md)].  
  
> [!NOTE]
>  Specifying Windows authentication does not disable [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] logins. Use the ALTER LOGIN DISABLE [!INCLUDE[tsql](../../../../../includes/tsql-md.md)] statement to disable highly-privileged [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] logins.  
  
## Login Types  
 [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] supports three types of logins:  
  
-   A local Windows user account or trusted domain account. [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] relies on Windows to authenticate the Windows user accounts.  
  
-   Windows group. Granting access to a Windows group grants access to all Windows user logins that are members of the group.  
  
-   [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] login. [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] stores both the username and a hash of the password in the master database, by using internal authentication methods to verify login attempts.  
  
> [!NOTE]
>  [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] provides logins created from certificates or asymmetric keys that are used only for code signing. They cannot be used to connect to [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)].  
  
## Mixed Mode Authentication  
 If you must use mixed mode authentication, you must create [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] logins, which are stored in SQL Server. You then have to supply the [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] user name and password at run time.  
  
> [!IMPORTANT]
>  [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] installs with a [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] login named `sa` (an abbreviation of "system administrator"). Assign a strong password to the `sa` login and do not use the `sa` login in your application. The `sa` login maps to the `sysadmin` fixed server role, which has irrevocable administrative credentials on the whole server. There are no limits to the potential damage if an attacker gains access as a system administrator. All members of the Windows `BUILTIN\Administrators` group (the local administrator's group) are members of the `sysadmin` role by default, but can be removed from that role.  
  
 [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] provides Windows password policy mechanisms for [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] logins when it is running on [!INCLUDE[winxpsvr](../../../../../includes/winxpsvr-md.md)] or later versions. Password complexity policies are designed to deter brute force attacks by increasing the number of possible passwords. [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] can apply the same complexity and expiration policies used in [!INCLUDE[winxpsvr](../../../../../includes/winxpsvr-md.md)] to passwords used inside [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)].  
  
> [!IMPORTANT]
>  Concatenating connection strings from user input can leave you vulnerable to a connection string injection attack. Use the <xref:System.Data.SqlClient.SqlConnectionStringBuilder> to create syntactically valid connection strings at run time. For more information, see [Connection String Builders](../../../../../docs/framework/data/adonet/connection-string-builders.md).  
  
## External Resources  
 For more information, see the following resources.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Principals](http://msdn.microsoft.com/library/bb543165.aspx) in [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)] Books Online|Describes logins and other security principals in [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)].|  
  
## See Also  
 [Securing ADO.NET Applications](../../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [Application Security Scenarios in SQL Server](../../../../../docs/framework/data/adonet/sql/application-security-scenarios-in-sql-server.md)  
 [Connecting to a Data Source](../../../../../docs/framework/data/adonet/connecting-to-a-data-source.md)  
 [Connection Strings](../../../../../docs/framework/data/adonet/connection-strings.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

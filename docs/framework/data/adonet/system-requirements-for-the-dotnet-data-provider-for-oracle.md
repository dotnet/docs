---
title: "System Requirements for the .NET Framework Data Provider for Oracle"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 054f76b9-1737-43f0-8160-84a00a387217
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# System Requirements for the .NET Framework Data Provider for Oracle
The .NET Framework Data Provider for Oracle requires Microsoft Data Access Components (MDAC) version 2.6 or later. MDAC 2.8 SP1 is recommended.  
  
 You must also have Oracle 8i Release 3 (8.1.7) Client or later installed.  
  
 Oracle Client software prior to version Oracle 9i cannot access UTF16 databases because UTF16 is a new feature in Oracle 9i. To use this feature, you must upgrade your client software to Oracle 9i or later.  
  
## Working with the Data Provider for Oracle and Unicode Data  
 Following is a list of Unicode-related issues that you should consider when working with the .NET Framework Data Provider for Oracle and Oracle client libraries. For more information, see your Oracle documentation.  
  
### Setting the Unicode Value in a Connection String Attribute  
 When working with Oracle, you can use the connection string attribute  
  
```  
Unicode=True   
```  
  
 to initialize the Oracle client libraries in UTF-16 mode. This causes the Oracle client libraries to accept UTF-16 (which is very similar to UCS-2) instead of multi-byte strings. This allows the Data Provider for Oracle to always work with any Oracle code page without additional translation work. This configuration only works if you are using Oracle 9i clients to communicate with an Oracle 9i database with the alternate character set of AL16UTF16. When an Oracle 9i client communicates with an Oracle 9i server, additional resources are required to convert the Unicode **CommandText** values to the appropriate multi-byte character set that the Oracle9i server uses. This can be avoided when you know that you have the safe configuration by adding `Unicode=True` to your connection string.  
  
### Mixing Versions of Oracle Client and Oracle Server  
 Oracle 8i clients cannot access **NCHAR**, **NVARCHAR2**, or **NCLOB** data in Oracle 9i databases when the server's national character set is specified as AL16UTF16 (the default setting for Oracle 9i). Because support for the UTF-16 character set was not introduced until Oracle 9i, Oracle 8i clients cannot read it.  
  
### Working with UTF-8 Data  
 To set the alternate character set, set the Registry Key HKEY_LOCAL_MACHINE\SOFTWARE\ORACLE\HOMEID\NLS_LANG to UTF8. See the Oracle Installation notes on your platform for more information. The default setting is the primary character set of the language from which you are installing the Oracle Client software. Not setting the language to match the national language character set of the database to which you are connecting will cause parameter and column bindings to send or receive data in your primary database character set, not the national character set.  
  
### OracleLob Can Only Update Full Characters.  
 For usability reasons, the <xref:System.Data.OracleClient.OracleLob> object inherits from the .NET Framework Stream class, and provides **ReadByte** and **WriteByte** methods. It also implements methods, such as **CopyTo** and **Erase**, that work on sections of Oracle **LOB** objects. In contrast, Oracle client software provides a number of APIs to work with character **LOB**s (**CLOB** and **NCLOB**). However, these APIs work on full characters only. Because of this difference, the Data Provider for Oracle implements support for **Read** and **ReadByte** to work with UTF-16 data in a byte-wise manner. However, the other methods of the **OracleLob** object only allow full-character operations.  
  
## See Also  
 [Oracle and ADO.NET](../../../../docs/framework/data/adonet/oracle-and-adonet.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

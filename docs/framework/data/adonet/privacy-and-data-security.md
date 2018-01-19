---
title: "Privacy and Data Security"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 46fa5839-adf7-4c7c-bce3-71e941fa7de9
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Privacy and Data Security
Safeguarding and managing sensitive information in an ADO.NET application is dependent upon the underlying products and technologies used to create it. ADO.NET does not directly provide services for securing or encrypting data.  
  
## Cryptography and Hash Codes  
 The classes in the .NET Framework <xref:System.Security.Cryptography> namespace can be used from your ADO.NET applications to prevent data from being read or modified by unauthorized third parties. Some classes are wrappers for the unmanaged Microsoft CryptoAPI, while others are managed implementations. The [Cryptographic Services](http://msdn.microsoft.com/library/68a1e844-c63c-44af-9247-f6716eb23781) topic provides an overview of cryptography in the .NET Framework, describes how cryptograph is implemented, and how you can perform specific cryptographic tasks.  
  
 Unlike cryptography, which allows data to be encrypted and then decrypted, hashing data is a one-way process. Hashing data is useful when you want to prevent tampering by checking that data has not been altered: given identical input strings, hashing algorithms always produce identical short output values that can easily be compared. [Ensuring Data Integrity with Hash Codes](../../../../docs/standard/security/ensuring-data-integrity-with-hash-codes.md) describes how you can generate and verify hash values.  
  
## Encrypting Configuration Files  
 Protecting access to your data source is one of the most important goals when securing an application. A connection string presents a potential vulnerability if it is not secured. Connection strings saved in configuration files are stored in standard XML files for which the .NET Framework has defined a common set of elements. Protected configuration enables you to encrypt sensitive information in a configuration file. Although primarily designed for ASP.NET applications, protected configuration can also be used to encrypt configuration file sections in Windows applications. For more information, see [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md).  
  
## Securing String Values in Memory  
 If a <xref:System.String> object contains sensitive information, such as a password, credit card number, or personal data, there is a risk that the information could be revealed after it is used because the application cannot delete the data from computer memory.  
  
 A <xref:System.String> is immutable; its value cannot be modified once it has been created. Changes that appear to modify the string value actually create a new instance of a <xref:System.String> object in memory, storing the data as plain text. In addition, it is not possible to predict when the string instances will be deleted from memory. Memory reclamation with strings is not deterministic with .NET garbage collection. You should avoid using the <xref:System.String> and <xref:System.Text.StringBuilder> classes if your data is truly sensitive.  
  
 The <xref:System.Security.SecureString> class provides methods for encrypting text using the Data Protection API (DPAPI) in memory. The string is then deleted from memory when it is no longer needed. There is no `ToString` method to quickly read the contents of a <xref:System.Security.SecureString>. You can initialize a new instance of `SecureString` with no value or by passing it a pointer to an array of <xref:System.Char> objects. You can then use the various methods of the class to work with the string. For more information, download the [SecureString Sample Application](http://go.microsoft.com/fwlink/?LinkId=120418), which demonstrates how to use the `SecureString` class from.  
  
## See Also  
 [Securing ADO.NET Applications](../../../../docs/framework/data/adonet/securing-ado-net-applications.md)  
 [SQL Server Security](../../../../docs/framework/data/adonet/sql/sql-server-security.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)

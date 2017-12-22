---
title: "How to: Add or Remove Access Control List Entries"
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
  - "ACEs [.NET Framework]"
  - "ACLs [.NET Framework]"
  - "access control entries [.NET Framework]"
  - "I/O [.NET Framework], access control list entries"
  - "access control lists [.NET Framework]"
ms.assetid: 53758b39-bd9b-4640-bb04-cad5ed8d0abf
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Add or Remove Access Control List Entries
To add or remove Access Control List (ACL) entries to or from a file, the <xref:System.Security.AccessControl.FileSecurity> or <xref:System.Security.AccessControl.DirectorySecurity> object must be obtained from the file or directory, modified, and then applied back to the file or directory.  
  
### To add or remove an ACL entry from a File  
  
1.  Call the <xref:System.IO.File.GetAccessControl%2A> method to get a <xref:System.Security.AccessControl.FileSecurity> object that contains the current ACL entries of a file.  
  
2.  Add or remove ACL entries from the <xref:System.Security.AccessControl.FileSecurity> object returned from step 1.  
  
3.  Pass the <xref:System.Security.AccessControl.FileSecurity> object to the <xref:System.IO.File.SetAccessControl%2A> method to apply the changes.  
  
### To add or remove an ACL entry from a Directory  
  
1.  Call the <xref:System.IO.Directory.GetAccessControl%2A> method to get a <xref:System.Security.AccessControl.DirectorySecurity> object that contains the current ACL entries of a directory.  
  
2.  Add or remove ACL entries from the <xref:System.Security.AccessControl.DirectorySecurity> object returned from step 1.  
  
3.  Pass the <xref:System.Security.AccessControl.DirectorySecurity> object to the <xref:System.IO.Directory.SetAccessControl%2A> method to apply the changes.  
  
## Example  
 [!code-cpp[IO.File.GetAccessControl-SetAccessControl#1](../../../samples/snippets/cpp/VS_Snippets_CLR/IO.File.GetAccessControl-SetAccessControl/cpp/sample.cpp#1)]
 [!code-csharp[IO.File.GetAccessControl-SetAccessControl#1](../../../samples/snippets/csharp/VS_Snippets_CLR/IO.File.GetAccessControl-SetAccessControl/CS/sample.cs#1)]
 [!code-vb[IO.File.GetAccessControl-SetAccessControl#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/IO.File.GetAccessControl-SetAccessControl/VB/sample.vb#1)]  
  
## Compiling the Code  
 You must supply a valid user or group account to run this example. This example uses a <xref:System.IO.File> object; however, the same procedure is used for the <xref:System.IO.FileInfo>, <xref:System.IO.Directory>, and <xref:System.IO.DirectoryInfo> classes.

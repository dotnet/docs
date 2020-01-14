---
title: "How to: Add or remove Access Control List entries (.NET Framework only)"
ms.date: "01/14/2019"
ms.technology: dotnet-standard
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
---
# How to: Add or remove Access Control List entries (.NET Framework only)
To add or remove Access Control List (ACL) entries to or from a file or directory, get the <xref:System.Security.AccessControl.FileSecurity> or <xref:System.Security.AccessControl.DirectorySecurity> object from the file or directory. Modify the object, and then apply it back to the file or directory.  
  
## Add or remove an ACL entry from a file  
  
1. Call the <xref:System.IO.File.GetAccessControl%2A?displayProperty=nameWithType> method to get a <xref:System.Security.AccessControl.FileSecurity> object that contains the current ACL entries of a file.  
  
2. Add or remove ACL entries from the <xref:System.Security.AccessControl.FileSecurity> object returned from step 1.  
  
3. To apply the changes, pass the <xref:System.Security.AccessControl.FileSecurity> object to the <xref:System.IO.File.SetAccessControl%2A?displayProperty=nameWithType> method.  
  
## Add or remove an ACL entry from a directory  
  
1. Call the <xref:System.IO.Directory.GetAccessControl%2A?displayProperty=nameWithType> method to get a <xref:System.Security.AccessControl.DirectorySecurity> object that contains the current ACL entries of a directory.  
  
2. Add or remove ACL entries from the <xref:System.Security.AccessControl.DirectorySecurity> object returned from step 1.  
  
3. To apply the changes, pass the <xref:System.Security.AccessControl.DirectorySecurity> object to the <xref:System.IO.Directory.SetAccessControl%2A?displayProperty=nameWithType> method.  
  
## Example  
 You must use a valid user or group account to run this example. The example uses a <xref:System.IO.File> object. Use the same procedure for the <xref:System.IO.FileInfo>, <xref:System.IO.Directory>, and <xref:System.IO.DirectoryInfo> classes.

 [!code-csharp[IO.File.GetAccessControl-SetAccessControl#1](../../../samples/snippets/csharp/VS_Snippets_CLR/IO.File.GetAccessControl-SetAccessControl/CS/sample.cs#1)]
 [!code-vb[IO.File.GetAccessControl-SetAccessControl#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/IO.File.GetAccessControl-SetAccessControl/VB/sample.vb#1)]  

---
description: "Learn more about: How to: Add or remove Access Control List entries"
title: "How to: Add or remove Access Control List entries"
ms.date: 06/07/2024
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "ACEs"
  - "ACLs"
  - "access control entries"
  - "I/O, access control list entries"
  - "access control lists"
---
# How to: Add or remove access control list entries

To add or remove access control list (ACL) entries from a file or directory, get the <xref:System.Security.AccessControl.FileSecurity> or <xref:System.Security.AccessControl.DirectorySecurity> object from the file or directory. Modify the object, and then apply it back to the file or directory.

## From a file

1. Call the <xref:System.IO.FileSystemAclExtensions.GetAccessControl(System.IO.FileInfo)?displayProperty=nameWithType> (or, for .NET Framework apps, <xref:System.IO.FileInfo.GetAccessControl%2A?displayProperty=nameWithType>) method to get a <xref:System.Security.AccessControl.FileSecurity> object that contains the current ACL entries of a file.

2. Add or remove ACL entries from the <xref:System.Security.AccessControl.FileSecurity> object obtained in step 1.

3. To apply the changes, pass the <xref:System.Security.AccessControl.FileSecurity> object to the <xref:System.IO.FileSystemAclExtensions.SetAccessControl(System.IO.FileInfo,System.Security.AccessControl.FileSecurity)?displayProperty=nameWithType> (or, for .NET Framework apps, <xref:System.IO.FileInfo.SetAccessControl%2A?displayProperty=nameWithType>) method.

## From a directory

1. Call the <xref:System.IO.FileSystemAclExtensions.GetAccessControl(System.IO.DirectoryInfo)?displayProperty=nameWithType> (or, for .NET Framework apps, <xref:System.IO.DirectoryInfo.GetAccessControl%2A?displayProperty=nameWithType>) method to get a <xref:System.Security.AccessControl.DirectorySecurity> object that contains the current ACL entries of a directory.

2. Add or remove ACL entries from the <xref:System.Security.AccessControl.DirectorySecurity> object obtained in step 1.

3. To apply the changes, pass the <xref:System.Security.AccessControl.DirectorySecurity> object to the <xref:System.IO.FileSystemAclExtensions.SetAccessControl(System.IO.DirectoryInfo,System.Security.AccessControl.DirectorySecurity)?displayProperty=nameWithType> (or, for .NET Framework apps, <xref:System.IO.DirectoryInfo.SetAccessControl%2A?displayProperty=nameWithType>) method.

## Example

You must specify a valid user or group account to run this example. The example uses a <xref:System.IO.FileInfo> object. Use the same procedure for the <xref:System.IO.DirectoryInfo> class.

[!code-csharp[IO.File.GetAccessControl-SetAccessControl#1](./snippets/add-remove-acls/csharp/sample.cs#1)]
[!code-vb[IO.File.GetAccessControl-SetAccessControl#1](./snippets/add-remove-acls/vb/sample.vb#1)]

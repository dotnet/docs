---
title: "LINQ and File Directories (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 159fd5c3-3926-4071-ae78-d8e423287eb7
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# LINQ and File Directories (Visual Basic)
Many file system operations are essentially queries and are therefore well-suited to the LINQ approach.  
  
 Note that the queries in this section are non-destructive. They are not used to change the contents of the original files or folders. This follows the rule that queries should not cause any side-effects. In general, any code (including queries that perform create / update / delete operators) that modifies source data should be kept separate from the code that just queries the data.  
  
 This section contains the following topics:  
  
 [How to: Query for Files with a Specified Attribute or Name (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-query-for-files-with-a-specified-attribute-or-name.md)  
 Shows how to search for files by examining one or more properties of its <xref:System.IO.FileInfo> object.  
  
 [How to: Group Files by Extension (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-group-files-by-extension-linq.md)  
 Shows how to return groups of <xref:System.IO.FileInfo> object based on their file name extension.  
  
 [How to: Query for the Total Number of Bytes in a Set of Folders (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-query-for-the-total-number-of-bytes-in-a-set-of-folders.md)  
 Shows how to return the total number of bytes in all the files in a specified directory tree.  
  
 [How to: Compare the Contents of Two Folders (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-compare-the-contents-of-two-folders-linq.md)s  
 Shows how to return all the files that are present in two specified folders, and also all the files that are present in one folder but not the other.  
  
 [How to: Query for the Largest File or Files in a Directory Tree (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-query-for-the-largest-file-or-files-in-a-directory-tree.md)  
 Shows how to return the largest or smallest file, or a specified number of files, in a directory tree.  
  
 [How to: Query for Duplicate Files in a Directory Tree (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-query-for-duplicate-files-in-a-directory-tree-linq.md)  
 Shows how to group for all file names that occur in more than one location in a specified directory tree. Also shows how to perform more complex comparisons based on a custom comparer.  
  
 [How to: Query the Contents of Files in a Folder (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-query-the-contents-of-files-in-a-folder-linq.md)  
 Shows how to iterate through folders in a tree, open each file, and query the file's contents.  
  
## Comments  
 There is some complexity involved in creating a data source that accurately represents the contents of the file system and handles exceptions gracefully. The examples in this section create a snapshot collection of <xref:System.IO.FileInfo> objects that represents all the files under a specified root folder and all its subfolders. The actual state of each <xref:System.IO.FileInfo> may change in the time between when you begin and end executing a query. For example, you can create a list of <xref:System.IO.FileInfo> objects to use as a data source. If you try to access the `Length` property in a query, the <xref:System.IO.FileInfo> object will try to access the file system to update the value of `Length`. If the file no longer exists, you will get a <xref:System.IO.FileNotFoundException> in your query, even though you are not querying the file system directly. Some queries in this section use a separate method that consumes these particular exceptions in certain cases. Another option is to keep your data source updated dynamically by using the <xref:System.IO.FileSystemWatcher>.  
  
## See Also  
 [LINQ to Objects (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-objects.md)

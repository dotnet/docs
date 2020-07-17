---
title: "LINQ and file directories (C#)"
ms.date: 07/20/2015
ms.assetid: b66c55e4-0f72-44e5-b086-519f9962335c
---
# LINQ and file directories (C#)

Many file system operations are essentially queries and are therefore well suited to the LINQ approach.  
  
 The queries in this section are non-destructive. They are not used to change the contents of the original files or folders. This follows the rule that queries should not cause any side-effects. In general, any code (including queries that perform create / update / delete operators) that modifies source data should be kept separate from the code that just queries the data.  
  
 This section contains the following topics:  
  
 [How to query for files with a specified attribute or name (C#)](./how-to-query-for-files-with-a-specified-attribute-or-name.md)\
 Shows how to search for files by examining one or more properties of its <xref:System.IO.FileInfo> object.  
  
 [How to group files by extension (LINQ) (C#)](./how-to-group-files-by-extension-linq.md)\
 Shows how to return groups of <xref:System.IO.FileInfo> object based on their file name extension.  
  
 [How to query for the total number of bytes in a set of folders (LINQ) (C#)](./how-to-query-for-the-total-number-of-bytes-in-a-set-of-folders-linq.md)\
 Shows how to return the total number of bytes in all the files in a specified directory tree.  
  
 [How to compare the contents of two folders (LINQ) (C#)](./how-to-compare-the-contents-of-two-folders-linq.md)s  
 Shows how to return all the files that are present in two specified folders, and also all the files that are present in one folder but not the other.  
  
 [How to query for the largest file or files in a directory tree (LINQ) (C#)](./how-to-query-for-the-largest-file-or-files-in-a-directory-tree-linq.md)\
 Shows how to return the largest or smallest file, or a specified number of files, in a directory tree.  
  
 [How to query for duplicate files in a directory tree (LINQ) (C#)](./how-to-query-for-duplicate-files-in-a-directory-tree-linq.md)\
 Shows how to group for all file names that occur in more than one location in a specified directory tree. Also shows how to perform more complex comparisons based on a custom comparer.  
  
 [How to query the contents of files in a folder (LINQ) (C#)](./how-to-query-the-contents-of-files-in-a-folder-lin.md)\
 Shows how to iterate through folders in a tree, open each file, and query the file's contents.  
  
## Comments  
 There is some complexity involved in creating a data source that accurately represents the contents of the file system and handles exceptions gracefully. The examples in this section create a snapshot collection of <xref:System.IO.FileInfo> objects that represents all the files under a specified root folder and all its subfolders. The actual state of each <xref:System.IO.FileInfo> may change in the time between when you begin and end executing a query. For example, you can create a list of <xref:System.IO.FileInfo> objects to use as a data source. If you try to access the `Length` property in a query, the <xref:System.IO.FileInfo> object will try to access the file system to update the value of `Length`. If the file no longer exists, you will get a <xref:System.IO.FileNotFoundException> in your query, even though you are not querying the file system directly. Some queries in this section use a separate method that consumes these particular exceptions in certain cases. Another option is to keep your data source updated dynamically by using the <xref:System.IO.FileSystemWatcher>.  
  
## See also

- [LINQ to Objects (C#)](./linq-to-objects.md)

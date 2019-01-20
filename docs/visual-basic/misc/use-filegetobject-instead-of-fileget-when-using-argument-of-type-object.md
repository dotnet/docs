---
title: "Use 'FileGetObject' instead of 'FileGet' when using argument of type 'Object'"
ms.date: 07/20/2015
ms.assetid: 090b8088-895a-482a-9362-606596bac304
---
# Use 'FileGetObject' instead of 'FileGet' when using argument of type 'Object'
The `FileGet` method includes an argument of type `Object`. `FileGetObject` should be used in place of `FileGet` to avoid ambiguities.  
  
 Notice that the functionality offered by `My.Computer.Filesystem` offers greater ease of use and performance than either `FileGet` or `FileGetObject`.  
  
## To correct this error  
  
1.  Replace `FileGet` with `FileGetObject`.  
  
2.  Cast the `Object` argument to a more specific type.  
  
## See also
   
 [My.Computer.FileSystem](xref:Microsoft.VisualBasic.FileIO.FileSystem)

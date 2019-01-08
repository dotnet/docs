---
title: "Use 'FilePutObject' instead of 'FilePut' when using argument of type 'Object'"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrUseFilePutObject"
ms.assetid: d207b9b7-5898-4c13-8b03-9feefac5f726
---
# Use 'FilePutObject' instead of 'FilePut' when using argument of type 'Object'
The `FilePut` method includes an argument of type `Object`. `FilePutObject` should be used in place of `FilePut` to avoid ambiguities.  
  
## To correct this error  
  
-   Replace `FilePut` with `FilePutObject`.  
  
-   Cast the `Object` argument to a more specific type.  
  
-   Use the functionality available in the `My.Computer.FileSystem` object.  
  
## See Also  
   
 [My.Computer.FileSystem](xref:Microsoft.VisualBasic.FileIO.FileSystem)  
 [My.Computer.FileSystem.WriteAllBytes](xref:Microsoft.VisualBasic.MyServices.FileSystemProxy.WriteAllBytes%2A)

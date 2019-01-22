---
title: "Clipboard format is not valid"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrID460"
ms.assetid: 71a4a045-65bb-417d-b3bd-99a9fa3c53f6
---
# Clipboard format is not valid
The specified Clipboard format is incompatible with the method being executed. Among the possible causes for this error are:  
  
-   Using the Clipboard's `GetText` or `SetText` method with a Clipboard format other than `vbCFText` or `vbCFLink`.  
  
-   Using the Clipboard's `GetData` or `SetData` method with a Clipboard format other than `vbCFBitmap`, `vbCFDIB`, or `vbCFMetafile`.  
  
-   Using the `GetData` or `SetData` methods of a `DataObject` with a Clipboard format in the range reserved by Microsoft Windows for registered formats (&HC000-&HFFFF), when that Clipboard format has not been registered with Microsoft Windows.  
  
## To correct this error  
  
-   Remove the invalid format and specify a valid one.  
  
## See also
 [Clipboard: Adding Other Formats](/cpp/mfc/clipboard-adding-other-formats)

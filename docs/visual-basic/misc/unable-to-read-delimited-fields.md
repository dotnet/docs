---
title: "Unable to read delimited fields because a double quote is not a legal delimiter when EscapeQuotes is set to True"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrTextFieldParser_IllegalDelimiter"
ms.assetid: ab8a0c3a-b89c-4617-9e31-7e81f5dca433
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Unable to read delimited fields because a double quote is not a legal delimiter when EscapeQuotes is set to True
The `TextFieldParser` cannot read from the file because a quotation mark (") has been supplied as the delimiter and `EscapeQuotes` is set to `True`.  
  
## To correct this error  
  
-   Set `EscapeQuotes` to `False`.  
  
## See Also  
 [TextFieldParser.SetDelimiters Method](http://msdn.microsoft.com/library/21fa40ec-5866-4d0e-9fd9-c708a190dcc9)  
 [TextFieldParser.Delimiters Property](http://msdn.microsoft.com/library/4eb18f4d-3011-40a9-b668-be93eed0444f)  
 [How to: Read From Comma-Delimited Text Files](../../visual-basic/developing-apps/programming/drives-directories-files/how-to-read-from-comma-delimited-text-files.md)  
 [TextFieldParser Object](../../visual-basic/language-reference/objects/textfieldparser-object.md)

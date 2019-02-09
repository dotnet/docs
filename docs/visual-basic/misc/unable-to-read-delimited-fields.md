---
title: "Unable to read delimited fields because a double quote is not a legal delimiter when EscapeQuotes is set to True"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrTextFieldParser_IllegalDelimiter"
ms.assetid: ab8a0c3a-b89c-4617-9e31-7e81f5dca433
---
# Unable to read delimited fields because a double quote is not a legal delimiter when EscapeQuotes is set to True
The `TextFieldParser` cannot read from the file because a quotation mark (") has been supplied as the delimiter and `EscapeQuotes` is set to `True`.  
  
## To correct this error  
  
-   Set `EscapeQuotes` to `False`.  
  
## See also

- [TextFieldParser.SetDelimiters Method](xref:Microsoft.VisualBasic.FileIO.TextFieldParser.SetDelimiters%2A)
- [TextFieldParser.Delimiters Property](xref:Microsoft.VisualBasic.FileIO.TextFieldParser.Delimiters%2A)
- [How to: Read From Comma-Delimited Text Files](../../visual-basic/developing-apps/programming/drives-directories-files/how-to-read-from-comma-delimited-text-files.md)
- [TextFieldParser Object](../../visual-basic/language-reference/objects/textfieldparser-object.md)

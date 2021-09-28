---
description: "Learn more about: All field widths, except the last element, must be greater than zero"
title: "All field widths, except the last element, must be greater than zero"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrTextFieldParser_FieldWidthsMustPositive"
ms.assetid: 41d8c661-a749-4c89-be56-905c6e7c3c9d
---
# All field widths, except the last element, must be greater than zero

All field widths, except the last element, must be greater than zero. A field width less than or equal to zero in the last element indicates the last field is of variable length.  
  
 The operation has failed because a field width other than the last element is set to zero or less. A field width less than or equal to zero can be used as the last element to indicate that the last field is of variable length, but it cannot be used as any other element.  
  
## To correct this error  
  
- Set the field width to the correct length.  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.SetFieldWidths%2A?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.FieldWidths>
- [How to: Read From Fixed-width Text Files](../developing-apps/programming/drives-directories-files/how-to-read-from-fixed-width-text-files.md)
- [TextFieldParser Object](../language-reference/objects/textfieldparser-object.md)

---
description: "Learn more about: A double quote is not a valid comment token for delimited fields where HasFieldsEnclosedInQuotes is set to True"
title: "A double quote is not a valid comment token for delimited fields where HasFieldsEnclosedInQuotes is set to True"
ms.date: 03/03/2026
f1_keywords: 
  - "vbrTextFieldParser_InvalidComment"
ms.assetid: 636d4b81-00ba-4cfd-98f7-4d57036f494d
ai-usage: ai-assisted
---
# A double quote is not a valid comment token for delimited fields where HasFieldsEnclosedInQuotes is set to True

A quotation mark has been supplied as a comment token for the `TextFieldParser`, but `HasFieldsEnclosedInQuotes` is set to `True`.

## To correct this error

- Remove or replace the double-quote in `TextFieldParser.CommentTokens` with a different comment token that doesn't conflict with quoted fields.
- Set `HasFieldsEnclosedInQuotes` to `False` if your delimited file doesn't use quoted fields.

## See also

- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.CommentTokens%2A>
- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.SetDelimiters%2A>
- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.Delimiters%2A>
- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser.HasFieldsEnclosedInQuotes%2A>
- <xref:Microsoft.VisualBasic.FileIO.TextFieldParser>
- [How to: Read From Comma-Delimited Text Files](../../developing-apps/programming/drives-directories-files/how-to-read-from-comma-delimited-text-files.md)

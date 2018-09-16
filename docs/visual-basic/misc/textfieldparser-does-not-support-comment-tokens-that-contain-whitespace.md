---
title: "TextFieldParser does not support comment tokens that contain white space"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrTextFieldParser_WhitespaceInToken"
ms.assetid: 55107656-270e-4bbb-841a-478904df8e07
---
# TextFieldParser does not support comment tokens that contain white space
A comment token that contains white space has been supplied. The `TextFieldParser` does not support comment tokens that contain white space unless the white space occurs at the beginning of the token. White space occurring at the beginning of a token is ignored.  
  
## To correct this error  
  
-   Supply a correct comment token.  
  
## See also

- [TextFieldParser.CommentTokens Property](xref:Microsoft.VisualBasic.FileIO.TextFieldParser.CommentTokens%2A)  
- [Parsing Text Files with the TextFieldParser Object](../../visual-basic/developing-apps/programming/drives-directories-files/parsing-text-files-with-the-textfieldparser-object.md)  
- [TextFieldParser Object](../../visual-basic/language-reference/objects/textfieldparser-object.md)

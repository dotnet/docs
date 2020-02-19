---
title: "<see>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "see XML tag"
  - "<see> XML tag"
ms.assetid: 7e18f60b-ef4a-4678-a797-5eb918635ca9
---
# \<see> (Visual Basic)
Specifies a link to another member.  
  
## Syntax  
  
```xml  
<see cref="member"/>  
```  
  
## Parameters  
 `member`  
 A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. `member` must appear within double quotation marks (" ").  
  
## Remarks  
 Use the `<see>` tag to specify a link from within text. Use [\<seealso>](../../../visual-basic/language-reference/xmldoc/seealso.md) to indicate text that you might want to appear in a "See Also" section.  
  
 Compile with [-doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<see>` tag in the `UpdateRecord` remarks section to refer to the `DoesRecordExist` method.  
  
 [!code-vb[VbVbcnXmlDocComments#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#6)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)

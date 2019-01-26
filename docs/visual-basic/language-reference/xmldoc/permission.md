---
title: "&lt;permission&gt; (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<permission> XML tag"
  - "permission XML tag"
ms.assetid: 0edf0500-5cd7-49c0-9255-64c48f972b77
---
# &lt;permission&gt; (Visual Basic)
Specifies a required permission for the member.  
  
## Syntax  
  
```xml  
<permission cref="member">description</permission>  
```  
  
#### Parameters  
 `member`  
 A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and translates `member` to the canonical element name in the output XML. Enclose `member` in quotation marks (" ").  
  
 `description`  
 A description of the access to the member.  
  
## Remarks  
 Use the `<permission>` tag to document the access of a member. Use the <xref:System.Security.PermissionSet> class to specify access to a member.  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<permission>` tag to describe that the <xref:System.Security.Permissions.FileIOPermission> is required by the `ReadFile` method.  
  
 [!code-vb[VbVbcnXmlDocComments#7](../../../visual-basic/language-reference/xmldoc/codesnippet/VisualBasic/permission_1.vb)]  
  
## See also
- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)

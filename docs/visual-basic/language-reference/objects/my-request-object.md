---
title: "My.Request Object (Visual Basic)"
ms.date: 07/20/2015
f1_keywords: 
  - "My.MyWebExtension.Request"
  - "My.Request"
helpviewer_keywords: 
  - "My.Request object"
ms.assetid: 93d5f0e2-6b60-4a2c-8652-d90216f6ad10
---
# My.Request Object
Gets the <xref:System.Web.HttpRequest> object for the requested page.  
  
## Remarks  
 The `My.Request` object contains information about the current HTTP request.  
  
 The `My.Request` object is available only for ASP.NET applications.  
  
## Example  
 The following example gets the header collection from the `My.Request` object and uses the `My.Response` object to write it to the ASP.NET page.  
  
 [!code-aspx-vb[VbVbalrMyWeb#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyWeb/VB/Default.aspx#1)]  
  
## See also

- <xref:System.Web.HttpRequest>
- [My.Response Object](../../../visual-basic/language-reference/objects/my-response-object.md)

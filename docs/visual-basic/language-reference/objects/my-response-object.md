---
title: "My.Response Object"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "My.MyWebExtension.Response"
  - "My.Response"
helpviewer_keywords: 
  - "My.Response object"
ms.assetid: 626359bc-3165-40b4-bfaf-2c610e26eb5b
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# My.Response Object
Gets the <xref:System.Web.HttpResponse> object associated with the <xref:System.Web.UI.Page>. This object allows you to send HTTP response data to a client and contains information about that response.  
  
## Remarks  
 The `My.Response` object contains the current <xref:System.Web.HttpResponse> object associated with the page.  
  
 The `My.Response` object is only available for [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] applications.  
  
## Example  
 The following example gets the header collection from the `My.Request` object and uses the `My.Response` object to write it to the ASP.NET page.  
  
 [!code-vb[VbVbalrMyWeb#1](../../../visual-basic/language-reference/objects/codesnippet/VisualBasic/my-response-object_1.aspx)]  
  
## See Also  
 <xref:System.Web.HttpResponse>  
 [My.Request Object](../../../visual-basic/language-reference/objects/my-request-object.md)

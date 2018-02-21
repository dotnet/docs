---
title: "Properties on Windows Forms Controls That Support Accessibility Guidelines"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Forms, accessibility properties of controls"
  - "accessibility [Windows Forms], Windows Forms control properties"
ms.assetid: ad3567a6-313b-4708-9e15-f487a831f049
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Properties on Windows Forms Controls That Support Accessibility Guidelines
Controls on the standard toolbox for Windows Forms support many of the accessibility guidelines, including exposing the keyboard focus and exposing the screen elements.  
  
## Planning Ahead for Accessibility  
 The controls' properties can be used to support other accessibility guidelines as shown in the following table. Additionally, you should use menus to provide access to program features.  
  
|Control Property|Considerations for Accessibility|  
|----------------------|--------------------------------------|  
|AccessibleDescription|The description is reported to accessibility aids such as screen readers. Accessibility aids are specialized programs and devices that help people with disabilities use computers more effectively.|  
|AccessibleName|The name that will be reported to the accessibility aids.|  
|AccessibleRole|Describes the use of the element in the user interface.|  
|TabIndex|Creates a sensible navigational path through the form. It is important for controls without intrinsic labels, such as text boxes, to have their associated label immediately precede them in the tab order.|  
|Text|Use the "&" character to create access keys. Using access keys is part of providing documented keyboard access to features.|  
|Font Size|If the font size is not adjustable, then it should be set to 10 points or larger. Once the form's font size is set, all the controls added to the form thereafter will have the same size.|  
|Forecolor|If this property is set to the default, then the user's color preferences will be used on the form.|  
|Backcolor|If this property is set to the default, then the user's color preferences will be used on the form.|  
|BackgroundImage|Leave this property blank to make text more readable.|  
  
## See Also  
 [Walkthrough: Creating an Accessible Windows-based Application](../../../../docs/framework/winforms/advanced/walkthrough-creating-an-accessible-windows-based-application.md)

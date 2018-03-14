---
title: "Display of Asian Characters with the ImeMode Property"
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
  - "Asian languages [Windows Forms], displaying with ImeMode"
  - "Chinese characters [Windows Forms], displaying with ImeMode"
  - "IME mode"
  - "Japanese characters [Windows Forms], displaying with ImeMode"
  - "international applications [Windows Forms], character display"
  - "international characters"
  - "Korean characters"
  - "Asian languages"
  - "Input Method Editor (IME), mode"
  - "localization [Windows Forms], character sets"
  - "globalization [Windows Forms], character sets"
ms.assetid: c60ae399-0dab-4f07-9dea-6dbfb15ec0ae
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Display of Asian Characters with the ImeMode Property
The <xref:System.Windows.Forms.Control.ImeMode%2A> property is used by forms and controls to force a specific mode for an input method editor (IME). The IME is an essential component for writing Chinese, Japanese, and Korean scripts, since these writing systems have more characters than can be encoded for a regular keyboard. For example, you may want to allow only ASCII characters in a particular text box. In such a case you can set the <xref:System.Windows.Forms.Control.ImeMode%2A> property to <xref:System.Windows.Forms.ImeMode> and users will only be able to enter ASCII characters for that particular text box. The default value of the <xref:System.Windows.Forms.Control.ImeMode%2A> property is <xref:System.Windows.Forms.ImeMode>, so if you set the property for a form, all controls on the form will inherit that setting. For more information, see <xref:System.Windows.Forms.Control.ImeMode%2A>
) and <xref:System.Windows.Forms.ImeMode>.  
  
## See Also  
 [Globalizing Windows Forms](../../../../docs/framework/winforms/advanced/globalizing-windows-forms.md)

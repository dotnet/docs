---
title: "Providing Accessibility Information for Controls on a Windows Form"
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
  - "Windows Forms controls, accessibility"
  - "controls [Windows Forms], accessibility"
  - "accessibility [Windows Forms], Windows Forms controls"
ms.assetid: 887dee6f-5059-4d57-957d-7c6fcd4acb10
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Providing Accessibility Information for Controls on a Windows Form
Accessibility aids are specialized programs and devices that help people with disabilities use computers more effectively. Examples include screen readers for people who are blind and voice input utilities for people who provide verbal commands instead of using the mouse or keyboard. These accessibility aids interact with the accessibility properties exposed by Windows Forms controls. These properties are:  
  
-   **AccessibilityObject**  
  
-   **AccessibleDefaultActionDescription**  
  
-   **AccessibleDescription**  
  
-   **AccessibleName**  
  
-   **AccessibleRole**  
  
## AccessibilityObject Property  
 This read-only property contains an <xref:System.Windows.Forms.AccessibleObject> instance. The **AccessibleObject** implements the <xref:Accessibility.IAccessible> interface, which provides information about the control's description, screen location, navigational abilities, and value. The designer sets this value when the control is added to the form.  
  
## AccessibleDefaultActionDescription Property  
 This string describes the action of the control. It does not appear in the Properties window and may only be set in code. The following example sets this property for a button control:  
  
```  
' Visual Basic  
Button1.AccessibleDefaultActionDescription = _  
   "Closes the application."  
  
// C#  
Button1.AccessibleDefaultActionDescription =   
   "Closes the application.";  
  
// C++  
button1->AccessibleDefaultActionDescription =  
   "Closes the application.";  
```  
  
## AccessibleDescription Property  
 This string describes the control. It may be set in the Properties window, or in code as follows:  
  
```  
' Visual Basic  
Button1.AccessibleDescription = "A button with text 'Exit'."  
  
// C#  
Button1.AccessibleDescription = "A button with text 'Exit'";  
  
// C++  
button1->AccessibleDescription = "A button with text 'Exit'";  
```  
  
## AccessibleName Property  
 This is the name of a control reported to accessibility aids. It may be set in the Properties window, or in code as follows:  
  
```  
' Visual Basic  
Button1.AccessibleName = "Order"  
  
// C#  
Button1.AccessibleName = "Order";  
  
// C++  
button1->AccessibleName = "Order";  
```  
  
## AccessibleRole Property  
 This property, which contains an <xref:System.Windows.Forms.AccessibleRole> enumeration, describes the user interface role of the control. A new control has the value set to `Default`. This would mean that by default, a **Button** control acts as a **Button**. You may want to reset this property if a control has another role. For example, you may be using a **PictureBox** control as a **Chart**, and you may want accessibility aids to report the role as a **Chart**, not as a **PictureBox**. You may also want to specify this property for custom controls you have developed. This property may be set in the Properties window, or in code as follows:  
  
```  
' Visual Basic  
PictureBox1.AccessibleRole = AccessibleRole.Chart  
  
// C#  
PictureBox1.AccessibleRole = AccessibleRole.Chart;  
  
// C++  
pictureBox1->AccessibleRole = AccessibleRole::Chart;  
```  
  
## See Also  
 <xref:System.Windows.Forms.AccessibleObject>  
 <xref:System.Windows.Forms.Control.AccessibilityObject%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Control.AccessibleDefaultActionDescription%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Control.AccessibleDescription%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Control.AccessibleName%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Control.AccessibleRole%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.AccessibleRole>

---
title: "How to: Check Connection Status in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Web connections [Visual Basic]"
  - "IsAvailable property [Visual Basic], about IsAvailable"
  - "connections [Visual Basic], checking status"
  - "connection status [Visual Basic]"
ms.assetid: 4d9ee8ab-9a6f-4279-ace4-b75afc976a74
---
# How to: Check Connection Status in Visual Basic

The <xref:Microsoft.VisualBasic.Devices.Network.IsAvailable> property can be used to determine whether the computer has a working network or Internet connection.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To check whether a computer has a working connection  
  
- Determine whether the `IsAvailable` property is `True` or `False`. The following code checks the property's status and reports it:  
  
     [!code-vb[VbResourceTasks#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbResourceTasks/VB/Class1.vb#3)]  
  
     This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Connectivity and Networking**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## See also

- <xref:Microsoft.VisualBasic.Devices.Network?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Devices.Network.IsAvailable>

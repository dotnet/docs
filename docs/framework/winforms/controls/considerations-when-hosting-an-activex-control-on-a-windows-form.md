---
title: "Considerations When Hosting an ActiveX Control on a Windows Form"
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
  - "Windows Forms controls, ActiveX controls"
  - "ActiveX controls [Windows Forms], hosting"
  - "Windows Forms, ActiveX controls"
  - "Windows Forms, hosting ActiveX controls"
  - "ActiveX controls [Windows Forms], adding"
ms.assetid: 2509302d-a74e-484f-9890-2acdbfa67a68
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Considerations When Hosting an ActiveX Control on a Windows Form
Although Windows Forms have been optimized to host Windows Forms controls, you can still use ActiveX controls. Keep the following considerations in mind when planning an application that uses ActiveX controls:  
  
-   **Security** The common language runtime has been enhanced with regard to code access security. Applications featuring Windows Forms can run in a fully trusted environment without issue and in a semi-trusted environment with most of the functionality accessible. Windows Forms controls can be hosted in a browser with no complications. However, ActiveX controls on Windows Forms cannot take advantage of these security enhancements. Running an ActiveX control requires unmanaged code permission, which is set with the <xref:System.Security.Permissions.SecurityPermissionAttribute.UnmanagedCode%2A?displayProperty=nameWithType> property. For more information about security and unmanaged code permission, see <xref:System.Security.Permissions.SecurityPermissionAttribute>.  
  
-   **Total Cost of Ownership** ActiveX controls added to a Windows Form are deployed with that Windows Form in their entirety, which can add significantly to the size of the file(s) created. Additionally, using ActiveX controls on Windows Forms requires writing to the registry. This is more invasive to a user's computer than Windows Forms controls, which do not require this.  
  
    > [!NOTE]
    >  Working with an ActiveX control requires the use of a COM interop wrapper. For more information, see [COM Interoperability in Visual Basic and Visual C#](~/docs/visual-basic/programming-guide/com-interop/com-interoperability-in-net-framework-applications.md).  
  
    > [!NOTE]
    >  If the name of a member of the ActiveX control matches a name defined in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], then the ActiveX Control Importer will prefix the member name with **Ctl** when it creates the <xref:System.Windows.Forms.AxHost> derived class. For example, if your ActiveX control has a member named **Layout**, it is renamed **CtlLayout** in the AxHost-derived class because the **Layout** event is defined within the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)].  
  
## See Also  
 [How to: Add ActiveX Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-activex-controls-to-windows-forms.md)  
 [Code Access Security](../../../../docs/framework/misc/code-access-security.md)  
 [Controls and Programmable Objects Compared in Various Languages and Libraries](http://msdn.microsoft.com/library/021f2a1b-8247-4348-a5ad-e1d9ab23004b)  
 [Putting Controls on Windows Forms](../../../../docs/framework/winforms/controls/putting-controls-on-windows-forms.md)  
 [Windows Forms Controls](../../../../docs/framework/winforms/controls/index.md)

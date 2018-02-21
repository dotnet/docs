---
title: "More Secure Printing in Windows Forms"
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
  - "Windows Forms, printing"
  - "PrintingPermission class [Windows Forms], Windows Forms security"
  - "printing [Windows Forms], security"
  - "security [Windows Forms], printing"
ms.assetid: 48fd36ac-872f-4de0-902a-e52969cd4367
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# More Secure Printing in Windows Forms
Windows Forms applications frequently include printing abilities. The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] uses the <xref:System.Drawing.Printing.PrintingPermission> class to control access to printing capabilities and the associated <xref:System.Drawing.Printing.PrintingPermissionLevel> enumeration value to indicate the level of access. By default, printing is enabled by default in the Local Intranet and Internet zones; however, the level of access is restricted in both zones. Whether your application can print, requires user interaction, or cannot print depends upon the permission value granted to the application. By default, the Local Intranet zone receives <xref:System.Drawing.Printing.PrintingPermissionLevel.DefaultPrinting> access and the Intranet zone receives <xref:System.Drawing.Printing.PrintingPermissionLevel.SafePrinting> access.  
  
 The following table shows the functionality available at each printing permission level.  
  
|PrintingPermissionLevel|Description|  
|-----------------------------|-----------------|  
|<xref:System.Drawing.Printing.PrintingPermissionLevel.AllPrinting>|Provides full access to all installed printers.|  
|<xref:System.Drawing.Printing.PrintingPermissionLevel.DefaultPrinting>|Enables programmatic printing to the default printer and safer printing through a restrictive printing dialog box. <xref:System.Drawing.Printing.PrintingPermissionLevel.DefaultPrinting> is a subset of <xref:System.Drawing.Printing.PrintingPermissionLevel.AllPrinting>.|  
|<xref:System.Drawing.Printing.PrintingPermissionLevel.SafePrinting>|Provides printing only from a more-restricted dialog box. <xref:System.Drawing.Printing.PrintingPermissionLevel.SafePrinting> is a subset of <xref:System.Drawing.Printing.PrintingPermissionLevel.DefaultPrinting>.|  
|<xref:System.Drawing.Printing.PrintingPermissionLevel.NoPrinting>|Prevents access to printers. <xref:System.Drawing.Printing.PrintingPermissionLevel.NoPrinting> is a subset of <xref:System.Drawing.Printing.PrintingPermissionLevel.SafePrinting>.|  
  
## See Also  
 [More Secure File and Data Access in Windows Forms](../../../docs/framework/winforms/more-secure-file-and-data-access-in-windows-forms.md)  
 [Additional Security Considerations in Windows Forms](../../../docs/framework/winforms/additional-security-considerations-in-windows-forms.md)  
 [Security in Windows Forms Overview](../../../docs/framework/winforms/security-in-windows-forms-overview.md)  
 [Windows Forms Security](../../../docs/framework/winforms/windows-forms-security.md)

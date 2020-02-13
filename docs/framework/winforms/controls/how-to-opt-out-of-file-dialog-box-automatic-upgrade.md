---
title: "How To: Opt Out of File Dialog Box Automatic Upgrade"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "OpenFileDialog [Windows Forms], opt out of automatic upgrade"
  - "file dialog box [Windows Forms], opt out of automatic upgrade"
  - "Windows Vista file dialog box [Windows Forms], opt out of automatic upgrade"
  - "SaveFileDialog [Windows Forms], opt out of automatic upgrade"
  - "AutoUpgradeEnabled property"
ms.assetid: 522e482e-cc01-48b1-8d59-9617dc2c4ac1
---
# How To: Opt Out of File Dialog Box Automatic Upgrade
When the <xref:System.Windows.Forms.OpenFileDialog> and <xref:System.Windows.Forms.SaveFileDialog> classes are used in an application, their appearance and behavior depend on the version of Windows the application is running on. When an application that was created on the .NET Framework 2.0 or earlier is displayed on Windows Vista, <xref:System.Windows.Forms.OpenFileDialog> and <xref:System.Windows.Forms.SaveFileDialog> are automatically displayed with the Windows Vista appearance and behavior. Starting in the .NET Framework 3.0, you can opt out of the automatic upgrade to display the <xref:System.Windows.Forms.OpenFileDialog> and <xref:System.Windows.Forms.SaveFileDialog> with a Windows XP-style appearance and behavior.  
  
### To opt out of file dialog box automatic upgrade  
  
1. Set the <xref:System.Windows.Forms.FileDialog.AutoUpgradeEnabled%2A> property of <xref:System.Windows.Forms.OpenFileDialog> or <xref:System.Windows.Forms.SaveFileDialog> to `false` before you display the dialog box.  
  
## See also

- <xref:System.Windows.Forms.FileDialog>

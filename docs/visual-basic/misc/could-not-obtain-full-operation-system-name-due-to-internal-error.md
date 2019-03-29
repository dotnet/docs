---
title: "Could not obtain full operation system name due to internal error"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrDiagnosticInfo_FullOSName"
ms.assetid: f69da02b-eb9a-4284-bb9e-3025517ae6c1
---
# Could not obtain full operation system name due to internal error
Could not obtain full operation system name due to internal error. This might be caused by WMI not existing on the current machine.  
  
 A call to the `My.Computer.Info.OSFullName` property failed. A possible cause for this failure is if Windows Management Instrumentation (WMI) is not installed on the current computer.  
  
## To correct this error  
  
1.  Add a `Try...Catch` block around the call to the `My.Computer.Info.OSFullName` property.  
  
2.  For more information about WMI and how to install it, go to  and search for "Windows Management Instrumentation Core".  
  
## See also

- [My.Computer.Info.OSFullName](xref:Microsoft.VisualBasic.Devices.ComputerInfo.OSFullName)
- [Handling and throwing exceptions in .NET](../../standard/exceptions/index.md)
- [Try...Catch...Finally Statement](../../visual-basic/language-reference/statements/try-catch-finally-statement.md)

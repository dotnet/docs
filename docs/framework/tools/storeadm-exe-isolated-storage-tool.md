---
title: "Storeadm.exe (Isolated Storage Tool)"
description: Read about Storeadm.exe, the Isolated Storage tool. This tool lists or removes all existing stores for the current user.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Storeadm.exe"
  - "listing stores for current user"
  - "Isolated Storage tool"
  - "stores, current user"
  - "removing stores"
ms.assetid: b81202b8-d91d-4b23-9c53-4a112f74a44a
---
# Storeadm.exe (Isolated Storage Tool)

The Isolated Storage tool lists or removes all existing stores for the current user.  
  
 This tool is automatically installed with Visual Studio. To run the tool, use [Visual Studio Developer Command Prompt or Visual Studio Developer PowerShell](/visualstudio/ide/reference/command-prompt-powershell).
  
 At the command prompt, type the following:  
  
## Syntax  
  
```console  
storeadm [/list][/machine][/remove][/roaming][/quiet]  
```  
  
## Parameters  
  
|Option|Description|  
|------------|-----------------|  
|**/h**[**elp**]|Displays command syntax and options for the tool.|  
|**/list**|Displays all existing stores for the current user. This includes the stores for all applications or assemblies executed by this user.|  
|**/machine**|Selects the machine store. Use this option with the **/list** or **/remove** option to specify that the action should apply to the machine store.<br /><br /> New in the .NET Framework 2.0|  
|**/quiet**|Specifies quiet mode; suppresses informational output so that only error messages appear.|  
|**/remove**|Permanently removes all existing stores for the current user.|  
|**/roaming**|Selects the roaming store. Use this option with the **/list** or **/remove** options to specify that the action should apply to the roaming store.|  
|**/?**|Displays command syntax and options for the tool.|  
  
## Remarks  

 Running Storeadm.exe from the command line without specifying any options displays the syntax and options for the tool.  
  
 The **/list** and **/remove** options are typically used one at a time; however, if two or more options are specified they will be performed in the order in which they appear on the command line.  
  
 Applications have a choice of saving to one of two stores for a user or to the machine store:  
  
- The local store exists in a location that is guaranteed not to roam, even if user data roaming is enabled for the user.  
  
- The roaming store exists in a location that is able to roam, but can only do so if roaming is enabled for the user via Windows administration.  
  
- The machine store is common to all users on a machine and is stored under a common directory on that machine.
  
Whether roaming is actually enabled for the user does not affect the administration of Storeadm.exe. Running the tool without any options applies all actions to the local store. Running the tool with the **/roaming** option applies all actions to the store that is able to roam. Running the tool with the **/machine** option applies all actions to the machine store.  
  
## See also

- [Tools](index.md)
- [Isolated Storage](../../standard/io/isolated-storage.md)
- [Developer command-line shells](/visualstudio/ide/reference/command-prompt-powershell)

---
title: "Developer Command Prompt for Visual Studio"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "command prompt, Windows SDK"
  - "Visual Studio command prompt"
  - "command prompt, Visual Studio"
  - "SDK command prompt"
  - "tools [.NET Framework], setting environment variables"
  - "environment variables, setting for tools"
  - "developer command prompt"
ms.assetid: 94fcf524-9045-4993-bfb2-e2d8bad44219
caps.latest.revision: 45
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Developer Command Prompt for Visual Studio
The Developer Command Prompt for Visual Studio automatically sets the environment variables that enable you to easily use .NET Framework tools. The Developer Command Prompt is installed with full or community editions of Visual Studio. It is not installed with the Express versions of Visual Studio.  
  
<a name="find"></a>   
## Searching for the Command Prompt on your machine  
 You may see multiple command prompts, depending on the version of Visual Studio and any additional SDKs you've installed. For example, 64-bit versions of Visual Studio provide both 32-bit and 64-bit command prompts. (The 32-bit and 64-bit versions of most tools are identical; however, a few tools make changes specific to 32-bit and 64-bit environments.) If the steps below don't work, you can try [Manually locating the files on your machine](#alternative) or [Running command prompt from inside Visual Studio](#visualstudio).  
  
 **In Windows 10**  
  
1.  Open the **Start** menu, by pressing the Windows logo key ![Windows logo](../../../docs/framework/get-started/media/windowskeyboardlogo.png "Windowskeyboardlogo") on your keyboard for example.  
  
2.  On the **Start** menu, enter `dev`. This will bring a list of installed apps that match your search pattern. If you're looking for a different command prompt, try entering a different search term such as `prompt`.  
  
3.  Choose the **Developer Command Prompt** (or the command prompt you want to use).  
  
 **In Windows 8.1**  
  
1.  Go to the **Start** screen, by pressing the Windows logo key ![Windows logo](../../../docs/framework/get-started/media/windowskeyboardlogo.png "Windowskeyboardlogo") on your keyboard for example.  
  
2.  On the **Start** screen, press `CTRL + TAB` to open the **Apps** list and then enter `V`. This will bring a list that includes all installed Visual Studio command prompts.  
  
3.  Choose the **Developer Command Prompt** (or the command prompt you want to use).  
  
 **In Windows 8**  
  
1.  Go to the **Start** screen, by pressing the Windows logo key ![Windows logo](../../../docs/framework/get-started/media/windowskeyboardlogo.png "Windowskeyboardlogo") on your keyboard for example.  
  
2.  On the **Start** screen, press the Windows logo key ![Windows logo](../../../docs/framework/get-started/media/windowskeyboardlogo.png "Windowskeyboardlogo") `+ Z`.  
  
3.  Choose the **Apps view** icon at the bottom of the screen and then enter `V`. This will bring a list that includes all installed Visual Studio command prompts.  
  
4.  Choose the **Developer Command Prompt** (or the command prompt you want to use).  
  
 **In Windows 7**  
  
1.  Choose **Start**, expand **All Programs**, and then expand **Microsoft Visual Studio**.  
  
2.  Depending on the version of Visual Studio you have installed, choose  **Visual Studio Tools**, **Visual Studio Command Prompt**, or the command prompt you want to use.  
  
 If you have the [Windows SDK](http://msdn.microsoft.com/windows/desktop/aa904949) or [Windows Phone SDK](https://dev.windowsphone.com/downloadsdk) installed, you may see additional command prompts for ARM, x86, or x64 architectures. Check the documentation for the individual tools to determine which version of the command prompt you should use.  
  
<a name="alternative"></a>   
## Manually locating the files on your machine  
  Usually, the shortcuts for the command prompts you have installed will be placed at the **Start Menu** folder for Visual Studio, such as in C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Visual Studio 2015\Visual Studio Tools.    But if for some reason, searching for the command prompt doesn't yield the expected results, you can try to manually locate the shortcut on your machine in order to use it.   Try searching for the name of the command prompt file such as VsDevCmd.bat or go to the Tools folder such as C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools (path will change according to your Visual Studio version and installation location).  
  
<a name="visualstudio"></a>   
## Running command prompt from inside Visual Studio  
 For easier access, you can add the Visual Studio Developer Command Prompt  or any other command prompt to the Tools menu on Visual Studio, by adding it to the external tools list. This is how you can accomplish that:  
  
1.  Open Visual Studio.  
  
2.  Select the **Tools** menu and choose **External Tools...**.  
  
3.  On the **External Tools** dialog box, choose the **Add** button. A new entry appears  
  
4.  Enter a **Title** for your new menu item such as `Command Prompt`.  
  
5.  In the **Command** field, specify the file you want to launch such as `%comspec%` or `C:\Windows\System32\cmd.exe` .  
  
6.  In the **Arguments** field, specify where to find the specific command prompt you want to use such as `/k "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat"` (this will launch the Developer Command Prompt installed with [!INCLUDE[vs_dev14](../../../includes/vs-dev14-md.md)]). This value needs to be changed according to your Visual Studio version and installation location.  
  
7.  Choose a value for the **Initial directory** field such as **Project Directory** .  
  
8.  Choose the **OK** button.  
  
 After that, the new menu item is added and you can access the command prompt from the **Tools** menu.  
  
## See Also  
 [Tools](../../../docs/framework/tools/index.md)  
 [Managing External Tools](/visualstudio/ide/managing-external-tools)

---
title: Fix .NET Framework 'This application could not be started'
description: Learn what to do if you see a 'This application could not be started' dialog box when running a .NET Framework application.
ms.date: 07/10/2025
---
# "This application could not be started" error when running a .NET Framework application

When you attempt to run a .NET Framework application, you may receive the "This application could not be started" error message. When the cause of this error is that an application can't find .NET Framework, due to .NET Framework being corrupted, use this article to try to solve that problem.

:::image type="content" source="media/application-not-started/app-could-not-be-started.png" alt-text="This application could not be started dialog box.":::

If you still can't run the application after completing all the steps in this article, then the issue might be caused by a corrupted file system, missing dependencies, or a problem with the application. In that case, you can **try contacting the app publisher** or post a question to [Microsoft Q&A](/answers/tags/828/developer-technologies) for more help.

## Understand the problem

This error means that a specific application can't be started. The name of the program is the first part of the title bar before the message "This application could not be started," as highlighted in the following figure:

:::image type="content" source="media/application-not-started/app-could-not-be-started-details.png" alt-text="This application could not be started dialog box with the executable name highlighted.":::

In the previous figure, the name of the executable that caused this error is `mt.exe`. Try searching for more information about the executable causing your problem.

## How to fix the error

To address this issue so that you can run your application, do the following:

1. Download the [.NET Framework Repair Tool (NetFxRepairTool.exe)](https://www.microsoft.com/download/details.aspx?id=30135). The tool runs automatically when the download completes.

1. If the .NET Framework Repair Tool recommends any other action, such as those shown in the following figure, select **Next**.

   :::image type="content" source="media/application-not-started/repair-tool-recommended-changes.png" alt-text="Repair tool recommended changes.":::

1. The .NET Framework Repair Tools displays a dialog box shown in the following figure to indicate that changes are complete. Leave the dialog box open while you to try rerun your application. This succeeds if the .NET Framework Repair Tool corrected a corrupted .NET Framework installation.

   :::image type="content" source="media/application-not-started/repair-tool-changes-complete.png" alt-text="Repair tool changes complete.":::

1. If your application runs successfully, select the **Finish** button. Otherwise, select the **Next** button.

1. If you selected the **Next** button, the .NET Framework Repair Tool displays a dialog box like the following. Select the **Finish** button to send diagnostic information to Microsoft.

   :::image type="content" source="media/application-not-started/repair-tool-no-resolution.png" alt-text="Unable to resolve the problem with the repair tool.":::

1. If you still can't run the application, install the latest version of .NET Framework that's supported by your version of Windows. For more information, see [Install .NET Framework on Windows and Windows Server](on-windows-and-server.md).

1. Attempt to launch the application.

## See also

- [.NET Framework System Requirements](../get-started/system-requirements.md)
- [.NET Framework installation guide](index.md)
- [Troubleshoot blocked .NET Framework installations and uninstallations](troubleshoot-blocked-installations-and-uninstallations.md)

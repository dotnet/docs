---
title: Fix .NET Framework 'This application could not be started'
description: Learn what to do if you see a 'This application could not be started' dialog box when running a .NET Framework application.
ms.date: 02/13/2023
---
# "This application could not be started" error when running a .NET Framework application

When you attempt to run a .NET Framework application, you may receive the "This application could not be started" error message. When this error is caused by an installed version of .NET Framework not being detected, or by .NET Framework being corrupted, use this article to try to solve that problem.

:::image type="content" source="media/application-not-started/app-could-not-be-started.png" alt-text="This application could not be started dialog box.":::

If you still can't run the application after completing all the steps in this article, then the issue may be caused by some other reason, like a corrupted file system, missing dependencies, or a problem with the application. In that case, you can try contacting the app publisher or post a question to [Microsoft Support Community](https://answers.microsoft.com/) or [Microsoft Q&A](/answers/tags/97/dotnet) for more help.

## How to fix the error

To address this issue so that you can run your application, do the following:

1. Download the [.NET Framework Repair Tool (NetFxRepairTool.exe)](https://www.microsoft.com/download/details.aspx?id=30135). The tool runs automatically when the download completes.

1. If the .NET Framework Repair Tool recommends any additional action, such as those shown in the following figure, select **Next**.

   :::image type="content" source="media/application-not-started/repair-tool-recommended-changes.png" alt-text="Repair tool recommended changes.":::

1. The .NET Framework Repair Tools displays a dialog box shown in the following figure to indicate that changes are complete. Leave the dialog box open while you to try rerun your application. This should succeed if the .NET Framework Repair Tool has identified and corrected a corrupted .NET Framework installation.

   :::image type="content" source="media/application-not-started/repair-tool-changes-complete.png" alt-text="Repair tool changes complete.":::

1. If your application runs successfully, select the **Finish** button. Otherwise, select the **Next** button.

1. If you selected the **Next** button, the .NET Framework Repair Tool displays a dialog box like the following. Select the **Finish** button to send diagnostic information to Microsoft.

   :::image type="content" source="media/application-not-started/repair-tool-no-resolution.png" alt-text="Unable to resolve the problem with the repair tool.":::

1. If you still cannot run the application, install the latest version of .NET Framework that's supported by your version of Windows, as shown in the following table.

   |Windows version|.NET Framework installation|
   |---|---|
   |Windows 10 Anniversary Update and later versions|[.NET Framework 4.8 Runtime](https://dotnet.microsoft.com/download/dotnet-framework/net48)|
   |Windows 10, Windows 10 November Update|[.NET Framework 4.6.2](https://dotnet.microsoft.com/download/dotnet-framework/net462)|
   |Windows 8.1|[.NET Framework 4.8 Runtime](https://dotnet.microsoft.com/download/dotnet-framework/net48)|
   |Windows 8|[.NET Framework 4.6.1](https://dotnet.microsoft.com/download/dotnet-framework/net461)|
   |Windows 7 SP1|[.NET Framework 4.8 Runtime](https://dotnet.microsoft.com/download/dotnet-framework/net48)|
   |Windows Vista SP2|[.NET Framework 4.6](https://dotnet.microsoft.com/download/dotnet-framework/net46)|

   > [!NOTE]
   > .NET Framework 4.8 is preinstalled on Windows 11 and Windows 10 May 2019 Update and later versions.

1. Attempt to launch the application.

1. In some cases, you may see a dialog box like the following, which asks you to install .NET Framework 3.5. Select **Download and install this feature** to install .NET Framework 3.5, then launch the application again.

   :::image type="content" source="media/application-not-started/install-3-5.png" alt-text="Windows Features dialog box suggesting to install .NET Framework 3.5.":::

## See also

- [.NET Framework System Requirements](../get-started/system-requirements.md)
- [.NET Framework installation guide](index.md)
- [Troubleshoot blocked .NET Framework installations and uninstallations](troubleshoot-blocked-installations-and-uninstallations.md)

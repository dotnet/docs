# Installation the .NET Framework 3.5 on Windows 10

You may need the .NET Framework 3.5 to run an application on Windows 10. You can use the following instructions to help you. You can also use these instructions for earlier Windows versions.

## Install the .NET Framework 3.5 on Demand

You may see the following configuration dialog if you try to run an application that requires the .NET Framework 3.5. Choose **Install this feature** to enable the .NET Framework 3.5. This option requires an Internet connection.

![.NET Framework Installation Dialog](./media/dotnet-framework-installation-dialog.jpeg)

## Enable the .NET Framework 3.5 in Control Panel

You can enable the .NET Framework 3.5 through the Windows Control Panel. This option requires an Internet connection.

1. Press the Windows key Windows ![Windows logo](https://i-msdn.sec.s-msft.com/dynimg/IC721376.jpeg) on your keyboard, type Windows Features, and press Enter. This brings up the **Turn Windows features on or off** dialog box.
2. Select the **.NET Framework 3.5 (includes .NET 2.0 and 3.0)** check box, press OK, and reboot your computer if prompted.

![Installing .NET with the control panel](./media/dotnet-control-panel.png)

You do not need to select the child items for Windows Communication Foundation (WCF) HTTP activation unless you are a developer or server administrator that requires this functionality.

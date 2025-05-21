---
title: Managed debuggers - .NET Core
description: An overview of the Visual Studio and Visual Studio Code managed debuggers.
ms.date: 08/05/2019
ms.topic: article
---
# .NET Core managed debuggers

Debuggers allow programs to be paused or executed step-by-step. When paused, the current state of the process can be viewed. By stepping through key sections, you gain understanding of your code and why it produces the result that it does.

Microsoft provides debuggers for managed code in **Visual Studio** and **Visual Studio Code**.

## Visual Studio managed debugger

**Visual Studio** is an integrated development environment with the most comprehensive debugger available. Visual Studio is an excellent choice for developers working on Windows.

- [Tutorial - Debugging a .NET Core application on Windows with Visual Studio](../tutorials/debugging-with-visual-studio.md)
- [Debug ASP.NET Core apps in Visual Studio](/visualstudio/debugger/how-to-enable-debugging-for-aspnet-applications#debug-aspnet-core-apps)

While Visual Studio is a Windows application, it can also be used to debug Linux apps running remotely, in WSL, or in Docker containers:

- [Remotely debug a .NET Core app on Linux](/visualstudio/debugger/remote-debugging-dotnet-core-linux-with-ssh)
- [Debug a .NET Core app in WSL2](/visualstudio/debugger/debug-dotnet-core-in-wsl-2)
- [Debug a .NET Core app in a Docker container](/visualstudio/containers/edit-and-refresh)

## Visual Studio Code managed debugger

**Visual Studio Code** is a lightweight cross-platform code editor. It uses the same .NET Core debugger implementation as Visual Studio, but with a simplified user interface.

- [Tutorial - Debugging a .NET Core application with Visual Studio Code](../tutorials/debugging-with-visual-studio-code.md)
- [Debugging in Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)

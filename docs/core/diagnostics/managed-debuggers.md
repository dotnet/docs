---
title: Managed debuggers - .NET Core
description: An overview of the Visual Studio and Visual Studio Code managed debuggers.
ms.date: 08/05/2019
---
# .NET Core managed debuggers

Debuggers allow programs to be paused or executed step-by-step. When paused, the current state of the process can be viewed. By stepping through key sections, you gain understanding of your code and why it produces the result that it does.

Microsoft provides debuggers for managed code in **Visual Studio** and **Visual Studio Code**.

## Visual Studio managed debugger

**Visual Studio** is an integrated development environment with the most comprehensive debugger available. Visual Studio is an excellent choice for developers working on Windows.

- [Tutorial - Debugging a .NET Core application on Windows with Visual Studio](../tutorials/debugging-with-visual-studio.md)

While Visual Studio is a Windows application, it can still be used to debug Linux and macOS apps remotely.

- [Debugging a .NET Core application on Linux/OSX with Visual Studio](https://github.com/Microsoft/MIEngine/wiki/Offroad-Debugging-of-.NET-Core-on-Linux---OSX-from-Visual-Studio)

 Debugging ASP.NET Core apps require slightly different instructions.

- [Debug ASP.NET Core apps in Visual Studio](/visualstudio/debugger/how-to-enable-debugging-for-aspnet-applications#debug-aspnet-core-apps)

## Visual Studio Code managed debugger

**Visual Studio Code** is a lightweight cross-platform code editor. It uses the same .NET Core debugger implementation as Visual Studio, but with a simplified user interface.

- [Tutorial - Debugging a .NET Core application with Visual Studio Code](../tutorials/with-visual-studio-code.md#debug)
- [Debugging in Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)

---
title: Test Windows desktop apps with MSTest UI Automation
description: Learn how to launch and test unpackaged Win32, Windows Forms, and WPF applications with MSTest.Windows.UIAutomation.
author: Evangelink
ms.author: amauryleve
ms.date: 10/01/2026
dev_langs:
  - "csharp"
  - "vb"
ai-usage: ai-generated
---

# Test Windows desktop apps with MSTest UI Automation

The preview [`MSTest.Windows.UIAutomation`](https://github.com/microsoft/testfx/tree/main/src/TestFramework/TestFramework.Windows.UIAutomation) package integrates MSTest lifecycle management with the built-in Windows UI Automation API. Use it to launch an unpackaged full-trust desktop application, find one of its windows as an <xref:System.Windows.Automation.AutomationElement>, and stop the application after each test.

The package supports Win32, Windows Forms, and WPF applications in an interactive Windows session. It doesn't provide MSIX, UWP, or WinUI activation, elevated-process automation, a headless desktop, locators, automatic waits, screenshots, or a multi-window object model.

> [!IMPORTANT]
> This feature requires MSTest 4.5 preview packages and a Windows-specific target framework.

## Enable Windows UI Automation

With MSTest.Sdk, set `EnableWindowsUIAutomation` to `true`:

```xml
<Project Sdk="MSTest.Sdk/4.5.0">
  <PropertyGroup>
    <TargetFramework>net8.0-windows</TargetFramework>
    <EnableWindowsUIAutomation>true</EnableWindowsUIAutomation>
  </PropertyGroup>
</Project>
```

MSTest.Sdk adds the matching `MSTest.Windows.UIAutomation` package. Without MSTest.Sdk, reference `MSTest.Windows.UIAutomation`, `MSTest.TestFramework`, and `MSTest.TestAdapter` at matching MSTest versions. Reference a compatible `Microsoft.NET.Test.Sdk` version separately because it follows the VSTest version line.

For a Windows-targeted project that restores or builds on Linux or macOS, set `EnableWindowsTargeting` to `true`.

## Choose a base class

Derive from one of these classes:

- `ApplicationTest` starts the application before each test and stops it during disposal. Override `CreateProcessStartInfo` to identify the executable.
- `WindowTest` also waits for a window and exposes it through `MainWindow`.

Declare `STATestClass` directly on every concrete test class because MSTest test-class attributes aren't inherited:

:::code language="csharp" source="./snippets/unit-testing-mstest-ui-automation/csharp/UIAutomationExample/MyAppTests.cs" id="WindowTestClass":::

:::code language="vb" source="./snippets/unit-testing-mstest-ui-automation/vb/UIAutomationExample/MyAppTests.vb" id="WindowTestClass":::

Use `MainWindow` in your test methods to query or invoke Windows UI Automation patterns. The package uses the UIA2 `System.Windows.Automation` API. You can layer another library, such as FlaUI, over the exposed `AutomationElement` when you need richer element interaction.

## Customize startup and window discovery

Override these members when the defaults don't fit your application:

- `ApplicationShutdownTimeout` controls how long the base class waits for graceful shutdown and forced termination. The default is five seconds.
- `WindowDiscoveryTimeout` controls how long `WindowTest` waits for a window. The default is 10 seconds.
- `FindWindow` selects a window for applications that use a launcher process, show a splash screen, or create multiple top-level windows.
- `StopApplication` shuts down an application when the selected window belongs to a process other than the process that `CreateProcessStartInfo` launched.

The base classes observe `TestContext.CancellationToken` during startup and window discovery. `WindowTest` fails when the application exits before a window appears or when discovery reaches its timeout.

## Understand lifecycle behavior

`ApplicationTest` starts one application process for each test invocation. `WindowTest` discovers the window after the process starts. After the test and its cleanup methods finish, MSTest disposes the base class, requests a graceful close through the main window, and terminates the process tree if the application doesn't exit within the configured timeout.

For parameterized tests and retries, each invocation receives its own application lifecycle.

## See also

- [MSTest overview](unit-testing-mstest-intro.md)
- [Test execution and control](unit-testing-mstest-writing-tests-controlling-execution.md)
- [Test UWP and WinUI 3 apps with MSTest and MTP](unit-testing-mstest-winui.md)
- [Windows UI Automation overview](/dotnet/framework/ui-automation/ui-automation-overview)

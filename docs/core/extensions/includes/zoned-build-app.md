---
author: IEvangelist
ms.author: dapine
ms.date: 09/13/2021
ms.topic: include
---

:::zone target="docs" pivot="visualstudio"

To build the application from Visual Studio, select <kbd>F6</kbd> or select the **Build** > **Build Solution** menu option.

:::zone-end
:::zone target="docs" pivot="vscode"

To build the application from Visual Studio Code, open the integrated terminal window and run the `dotnet build` command from the working directory.

```dotnetcli
dotnet build
```

For more information on the .NET CLI build command, see [`dotnet build`](../../tools/dotnet-build.md).

:::zone-end
:::zone target="docs" pivot="cli"

To build the application from the .NET CLI, run the `dotnet build` command from the working directory.

```dotnetcli
dotnet build <path/to/project.csproj>
```

Specify your `<path/to/project.csproj>` value, which is the path to the project file to build. For more information on the .NET CLI build command, see [`dotnet build`](../../tools/dotnet-build.md).

:::zone-end

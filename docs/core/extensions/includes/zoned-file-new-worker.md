---
author: IEvangelist
ms.author: dapine
ms.date: 06/02/2021
ms.topic: include
---

## Create a new project

:::zone target="docs" pivot="visualstudio"

To create a new Worker Service project with Visual Studio, select **File** > **New** > **Project...**. From the **Create a new project** dialog search for "Worker Service", and select Worker Service template. Enter the desired project name, select an appropriate location, and select **Next**. On the **Additional information** page, for the **Target Framework** select `.NET 5.0`, and check the **Enable Docker** option to enable docker support. Select the desired **Docker OS**.

:::zone-end
:::zone target="docs" pivot="vscode"

To create a new Worker Service project with Visual Studio Code, you can run .NET CLI commands from the integrated terminal. For more information, see [Visual Studio Code: Integrated Terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).

Open the integrated terminal, and run the `dotnet new` command, and replace the `<Project.Name>` with your desired project name.

```dotnetcli
dotnet new worker --name <Project.Name>
```

For more information on the .NET CLI new worker service project command, see [dotnet new worker](../../tools/dotnet-new-sdk-templates.md#web-others).

:::zone-end
:::zone target="docs" pivot="cli"

To create a new Worker Service project with the .NET CLI, open your favorite terminal in a working directory. Run the `dotnet new` command, and replace the `<Project.Name>` with your desired project name.

```dotnetcli
dotnet new worker --name <Project.Name>
```

For more information on the .NET CLI new worker service project command, see [dotnet new worker](../../tools/dotnet-new-sdk-templates.md#web-others).

:::zone-end

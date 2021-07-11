---
author: IEvangelist
ms.author: dapine
ms.date: 06/01/2021
ms.topic: include
---

## Create a new project

To create a new Worker Service project with Visual Studio, you'd select **File** > **New** > **Project...**. From the **Create a new project** dialog search for "Worker Service", and select Worker Service template. If you'd rather use the .NET CLI, open your favorite terminal in a working directory. Run the `dotnet new` command, and replace the `<Project.Name>` with your desired project name.

```dotnetcli
dotnet new worker --name <Project.Name>
```

For more information on the .NET CLI new worker service project command, see [dotnet new worker](../../tools/dotnet-new-sdk-templates.md#web-others).

> [!TIP]
> If you're using Visual Studio Code, you can run .NET CLI commands from the integrated terminal. For more information, see [Visual Studio Code: Integrated Terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).

---
ms.date: 09/25/2025
ms.topic: include
---

`PROJECT | SOLUTION | FILE`

The project or solution or C# (file-based app) file to clean. If a file isn't specified, MSBuild searches the current directory for a project or solution.

- `PROJECT` is the path and filename of a C#, F#, or Visual Basic project file, or the path to a directory that contains a C#, F#, or Visual Basic project file.

- `SOLUTION` is the path and filename of a solution file (*.sln* or *.slnx* extension), or the path to a directory that contains a solution file.

- `FILE` is an argument added in .NET 10. The path and filename of a file-based app. File-based apps are contained within a single file that is built and run without a corresponding project (*.csproj*) file. For more information, see [Build file-based C# apps](/dotnet/csharp/fundamentals/tutorials/file-based-programs).
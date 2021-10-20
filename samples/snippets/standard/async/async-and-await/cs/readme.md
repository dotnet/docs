---
languages:
- csharp
products:
- dotnet-core
- windows
page_type: sample
name: "Async Sample: Asynchronous Programming with Async and Await in C#"
urlFragment: "async-and-await-cs"
description: "A .NET Core WPF application that contains the example method from Asynchronous Progamming with Async and Await in C#."
---
# Async programming with async and await in C\#

This sample is a WPF application written in C# that contains the example method from [Task asynchronous programming model](../../../../../../docs/csharp/programming-guide/concepts/async/task-asynchronous-programming-model.md). The article gives an overview of asynchronous programming, including when to use it and how to write an async method. This sample contains an async function that is used as an illustration.

[async](../../../../../../docs/csharp/language-reference/keywords/async.md) and [await](../../../../../../docs/csharp/language-reference/operators/await.md) provide all the advantages of traditional asynchronous programming, but with much less effort from the developer. The compiler does the difficult work that the developer used to do, yet the code retains a logical structure that resembles synchronous code.

The example async function in this sample (named `GetStringAsync`) uses an [HttpClient](/dotnet/api/system.net.http.httpclient) method to download the contents of a website.

The code for the *MainWindow.xaml.cs* file from this sample is included in the article.

## Sample prerequisites

This sample is written in C# and targets .NET Core 3.1 running on Windows. It requires the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1).

## Building the sample

To download and run the sample, follow these steps:

1. Download and unzip the sample.

2. In Visual Studio (2019 or later):

    1. On the menu bar, choose **File** > **Open** > **Project/Solution**.

    2. Navigate to the folder that holds the unzipped sample code, and open the c# project (.csproj) file.

    3. Choose the <kbd>F5</kbd> key to run with debugging, or <kbd>Ctrl</kbd>+<kbd>F5</kbd> keys to run the project without debugging.

3. From the command line:

   1. Navigate to the folder that holds the unzipped sample code.

   2. At the command line, type `dotnet run`.

## More information

- <https://docs.microsoft.com/dotnet/csharp/programming-guide/concepts/async/>

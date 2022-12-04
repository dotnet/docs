---
languages:
- vb
products:
- dotnet-core
- windows
page_type: sample
name: "Async Sample: Asynchronous Programming with Async and Await"
urlFragment: "async-and-await-vb"
description: "A .NET Core WPF application that contains the example method from Asynchronous Programming with Async and Await in Visual Basic."
---
# Async Sample: Asynchronous Programming with Async and Await in Visual Basic

This sample is a WPF application that contains the example method from [Asynchronous Programming with Async and Await in Visual Basic](https://learn.microsoft.com/dotnet/visual-basic/programming-guide/concepts/async/). The topic gives an overview of asynchronous programming, including when to use it and how to write an Async method. This sample contains an Async function that is used as an illustration.

[Async](https://learn.microsoft.com/dotnet/visual-basic/language-reference/modifiers/async) and [Await](https://learn.microsoft.com/dotnet/visual-basic/language-reference/operators/await-operator) provide all the advantages of traditional asynchronous programming, but with much less effort from the developer. The compiler does the difficult work that the developer used to do, yet the code retains a logical structure that resembles synchronous code.

The example Async function in this sample (named `GetStringAsync`) uses an [HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient) method to download the contents of a website.

The code for the *MainWindow.xaml.vb* file from this sample is included in the article.

## Sample prerequisites

This sample is written in Visual Basic and targets .NET Core 3.1 running on Windows. It requires the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1).

## Building the sample

To download and run the sample, follow these steps:

1. Download and unzip the sample.

2. In Visual Studio (2019 or later):

    1. On the menu bar, choose **File** > **Open** > **Project/Solution**.

    2. Navigate to the folder that holds the unzipped sample code, and open the Visual Basic project (*.vbproj*) file.

    3. Choose the <kbd>F5</kbd> key, or <kbd>Ctrl</kbd>+<kbd>F5</kbd> keys, to run the project.

3. From the command line:

    1. Navigate to the folder that holds the unzipped sample code.

    2. At the command line, type `dotnet run`.

## More information

- <https://learn.microsoft.com/dotnet/visual-basic/programming-guide/concepts/async/index>

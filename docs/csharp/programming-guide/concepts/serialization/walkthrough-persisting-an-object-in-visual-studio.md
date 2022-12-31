---
title: "Walkthrough: Persisting an Object using C#"
description: This example creates a basic Loan object in C# and persists its data to a file, then creates a new object with data from the file.
ms.date: 12/30/2022
---
# Walkthrough: Persist an object using C\#

You can use JSON serialization to persist an object's data between instances, which enables you to store values and retrieve them the next time that the object is instantiated.

In this walkthrough, you'll create a basic `Loan` object and persist its data to a JSON file. You'll then retrieve the data from the file when you re-create the object.

> [!IMPORTANT]
> This example creates a new file if the file does not already exist. If an application must create a file, that application must have `Create` permission for the folder. Permissions are set by using access control lists. If the file already exists, the application needs only `Write` permission, a lesser permission. Where possible, it's more secure to create the file during deployment and only grant `Read` permissions to a single file (instead of `Create` permissions for a folder). Also, it's more secure to write data to user folders than to the root folder or the *Program Files* folder.

> [!IMPORTANT]
> This example stores data in a JSON file. You should not store sensitive data, such as passwords or credit-card information, in a JSON file.

## Prerequisites

- To build and run, install the [.NET SDK](https://dotnet.microsoft.com/download).
- Install your favorite code editor, if you haven't already.

  > [!TIP]
  > Need to install a code editor? Try [Visual Studio](https://visualstudio.com/downloads)!

You can examine the sample code online [at the .NET samples GitHub repository](https://github.com/dotnet/samples/tree/main/csharp/serialization).

## Define the loan type

The first step is to create a `Loan` class and a console application that uses the class:

1. Create a new application. At a command prompt, enter `dotnet new console -o serialization` to create a new console application in a subdirectory named `serialization`.
1. Open the application in your editor, and add a new class named `Loan.cs`.
1. Add the following code to your `Loan` class:

   [!code-csharp[Loan class definition](../../../../../samples/snippets/csharp/serialization/Loan.cs#1)]

## Instantiate a loan object

1. Open *Program.cs* and add the following code:

   [!code-csharp[Create a loan object](../../../../../samples/snippets/csharp/serialization/Program.cs#1)]

2. Add an event handler for the `PropertyChanged` event, and a few lines to modify the `Loan` object and display the changes. You can see the additions in the following code:

   [!code-csharp[Listening for the PropertyChanged event](../../../../../samples/snippets/csharp/serialization/Program.cs#2)]

At this point, you can run the code and see the current output:

```console
New customer value: Henry Clay
7.5
7.1
```

Running this application repeatedly always writes the same values. A new `Loan` object is created every time you run the program. In the real world, interest rates change periodically, but not necessarily every time that the application is run. Serialization code means you preserve the most recent interest rate between instances of the application. In the next step, you'll do just that by adding serialization to the `Loan` class.

## Use serialization to persist the object

To serialize an object using <xref:System.Text.Json?displayProperty=fullName> serialization, you don't need to add any special attributes to the type. By default, all public properties are serialized and all fields are ignored. However, you can annotate properties to ignore or specify that fields should be included.

The following code adds a `TimeLastLoaded` property and marks it with the <xref:System.Text.Json.Serialization.JsonIgnoreAttribute> attribute to exclude it from serialization:

[!code-csharp[Disable serialization for an auto-implemented property](../../../../../samples/snippets/csharp/serialization/Loan.cs#2)]

1. To serialize the class and write it to a file, you use the <xref:System.IO?displayProperty=fullName> and <xref:System.Text.Json?displayProperty=fullName> namespaces. To avoid typing the fully qualified names, you can add references to the necessary namespaces as shown in the following code:

   [!code-csharp[Adding namespaces for serialization](../../../../../samples/snippets/csharp/serialization/Program.cs#3)]

2. Add code to deserialize the object from the file when the object is created. Add a constant to the class for the serialized data's file name as shown in the following code:

   [!code-csharp[Define the name of the saved file](../../../../../samples/snippets/csharp/serialization/Program.cs#4)]

   Next, add the following code after the line that creates the `TestLoan` object. This code first checks that the file exists. If it exists, it reads the text from the file, and then deserialize it using the <xref:System.Text.Json.JsonSerializer.Deserialize%60%601(System.String,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> method.

   [!code-csharp[Read from a file if it exists](../../../../../samples/snippets/csharp/serialization/Program.cs#5)]

3. Next, add code to serialize the class to a file using the <xref:System.Text.Json.JsonSerializer.Serialize%60%601(%60%600,System.Text.Json.JsonSerializerOptions)?displayProperty=nameWithType> method. Add the following code to the end of the file:

   [!code-csharp[Save the existing Loan object](../../../../../samples/snippets/csharp/serialization/Program.cs#6)]

At this point, you can again build and run the application. The first time it runs, notice that the interest rates starts at 7.5, and then changes to 7.1. Close the application and then run it again. Now, the application prints the message that it has read the saved file, and the interest rate is 7.1 even before the code that changes it.

## See also

- [Serialization (C#)](index.md)
- [C# Programming Guide](../../index.md)
- [How to serialize and deserialize JSON in .NET](../../../../standard/serialization/system-text-json/how-to.md)

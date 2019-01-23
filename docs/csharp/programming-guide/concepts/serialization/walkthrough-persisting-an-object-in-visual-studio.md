---
title: "Walkthrough: Persisting an Object using C#"
ms.date: 04/26/2018
---
# Walkthrough: persisting an object using C# #

You can use serialization to persist an object's data between instances, which enables you to store values and retrieve them the next time that the object is instantiated.

In this walkthrough, you will create a basic `Loan` object and persist its data to a file. You will then retrieve the data from the file when you re-create the object.

> [!IMPORTANT]
> This example creates a new file if the file does not already exist. If an application must create a file, that application must have `Create` permission for the folder. Permissions are set by using access control lists. If the file already exists, the application needs only `Write` permission, a lesser permission. Where possible, it's more secure to create the file during deployment and only grant `Read` permissions to a single file (instead of Create permissions for a folder). Also, it's more secure to write data to user folders than to the root folder or the Program Files folder.

> [!IMPORTANT]
> This example stores data in a binary format file. These formats should not be used for sensitive data, such as passwords or credit-card information.

## Prerequisites

* To build and run, install the [.NET Core SDK](https://www.microsoft.com/net/core).

* Install your favorite code editor, if you haven't already.

> [!TIP]
> Need to install a code editor? Try [Visual Studio](https://visualstudio.com/downloads)!

* The example requires C# 7.3. See [Select the C# language version](../../../language-reference/configure-language-version.md) 

You can examine the sample code online [at the .NET samples GitHub repository](https://github.com/dotnet/samples/tree/master/csharp/serialization).

## Creating the loan object

The first step is to create a `Loan` class and a console application that uses the class:

1. Create a new application. Type `dotnet new console -o serialization` to
create a new console application in a subdirectory named `serialization`.
1. Open the application in your editor, and add a new class named `Loan.cs`.
1. Add the following code to your `Loan` class:

[!code-csharp[Loan class definition](../../../../../samples/csharp/serialization/Loan.cs#1)]

You will also have to create an application that uses the `Loan` class.

## Serialize the loan object

1. Open `Program.cs`. Add the following code:

[!code-csharp[Create a loan object](../../../../../samples/csharp/serialization/Program.cs#1)]

Add an event handler for the `PropertyChanged` event, and a few lines to modify the `Loan` object and display the changes. You can see the additions in the following code:

[!code-csharp[Listening for the PropertyChanged event](../../../../../samples/csharp/serialization/Program.cs#2)]

At this point, you can run the code, and see the current output:

```console
New customer value: Henry Clay
7.5
7.1
```

Running this application repeatedly always writes the same values. A new Loan object is created every time you run the program. In the real world, interest rates change periodically, but not necessarily every time that the application is run. Serialization code means you preserve the most recent interest rate between instances of the application. In the next step, you will do just that by adding serialization to the Loan class.

## Using Serialization to Persist the Object

In order to persist the values for the Loan class, you must first mark the class with the `Serializable` attribute. Add the following code above the Loan class definition:

[!code-csharp[Loan class definition](../../../../../samples/csharp/serialization/Loan.cs#2)]

The <xref:System.SerializableAttribute> tells the compiler that everything in the class can be persisted to a file. Because the `PropertyChanged` event does not represent part of the object graph that should be stored, it should not be serialized. Doing so would serialize all objects that are attached to that event. You can add the <xref:System.NonSerializedAttribute> to the field declaration for the `PropertyChanged` event handler.

[!code-csharp[Disable serialization for the event handler](../../../../../samples/csharp/serialization/Loan.cs#3)]

Beginning with C# 7.3, you can attach attributes to the backing field of an auto-implemented property using the `field` target value. The following code adds a `TimeLastLoaded` property and marks it as not serializable:

[!code-csharp[Disable serialization for an auto-implemented property](../../../../../samples/csharp/serialization/Loan.cs#4)]

The next step is to add the serialization code to the LoanApp application. In order to serialize the class and write it to a file, you use the <xref:System.IO> and <xref:System.Runtime.Serialization.Formatters.Binary> namespaces. To avoid typing the fully qualified names, you can add references to the necessary namespaces as shown in the following code:

[!code-csharp[Adding namespaces for serialization](../../../../../samples/csharp/serialization/Program.cs#3)]

The next step is to add code to deserialize the object from the file when the object is created. Add a constant to the class for the serialized data's file name as shown in the following code:

[!code-csharp[Define the name of the saved file](../../../../../samples/csharp/serialization/Program.cs#4)]

Next, add the following code after the line that creates the `TestLoan` object:

[!code-csharp[Read from a file if it exists](../../../../../samples/csharp/serialization/Program.cs#5)]

You first must check that the file exists. If it exists, create a <xref:System.IO.Stream> class to read the binary file and a <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> class to translate the file. You also need to convert from the stream type to the Loan object type.

Next you must add code to serialize the class to a file. Add the following code after the existing code in the `Main` method:

[!code-csharp[Save the existing Loan object](../../../../../samples/csharp/serialization/Program.cs#6)]

At this point, you can again build and run the application. The first time it runs, notice that the interest rates starts at 7.5, and then changes to 7.1. Close the application and then run it again. Now, the application prints the message that it has read the saved file, and the interest rate is 7.1 even before the code that changes it.

## See also

- [Serialization (C#)](index.md)
- [C# Programming Guide](../..//index.md)

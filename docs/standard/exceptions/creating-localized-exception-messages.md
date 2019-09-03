---
title: How to: create custom exceptions and localized exception messages
description: The article demonstrates how to create custom exceptions and localized exception messages
author: Youssef1313
ms.date: 09/02/2019
---
# How to: create custom exceptions and localized exception messages

Written by [Youssef Victor](https://github.com/Youssef1313).

## Create custom exceptions
The .NET Framework contains many different exceptions that are likely to meet your needs. However, in some cases when none of them meets your needs, you can create your own custom exceptions.
Let's assume you want to create a `StudentNotFoundException` that contains a `StudentName` property.
To create custom exceptions, Follow these steps:

- Create a serializable class that inherits from `Exception`. The class name is preferred to end in "Exception".

```csharp
[Serializable]
public class StudentNotFoundException : Exception
{
    
}
```

- Add the default constructors.

```csharp
[Serializable]
public class StudentNotFoundException : Exception
{
    public StudentNotFoundException()
    {
    }

    public StudentNotFoundException(string message)
        : base(message)
    {
    }

    public StudentNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
```

- Add properties and/or more constructors depending on your needs.

```csharp
[Serializable]
public class StudentNotFoundException : Exception
{
    public string StudentName { get; }

    public StudentNotFoundException()
    {
    }

    public StudentNotFoundException(string message)
        : base(message)
    {
    }

    public StudentNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
	
    public StudentNotFoundException(string message, string studentName)
        : base(message)
    {
        StudentName = studentName;
    }
}
```

## Create localized exception messages
You have created our custom exception and you can throw it anywhere in code like the following:

```csharp
throw new StudentNotFoundException("The student cannot be found.", "John");
```

The previous line looks good, but its only problem is that `The student cannot be found.` is just a constant string, you want to have different messages depending on user culture.
[Satellite Assemblies](https://docs.microsoft.com/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps) is the good way to do that.

A satellite assembly is a `.dll` that contains resources for a specific language. When you ask for a specific resources at runtime, the CLR finds that resource depending on user culture. If no satellite assembly is found for that culture, the default resources file is used.


To start creating the localized exception messages:
- Create a new folder to hold the resource files, let's name the folder `Resources`.
- Add a new resource file to it. To do that in Visual Studio, Right click the folder in solution explorer -> Add -> New Item -> Choose `Resources File` -> Name it `ExceptionMessages.resx`. (This is the default resources file)
- Add a Name Value pair for your exception messages like the following image shows:

![image](https://user-images.githubusercontent.com/31348972/64120930-ca5a8400-cd9d-11e9-984a-789c5f582513.png)

- Add a new resource file for French. Name it `ExceptionMessages.fr-FR.resx`.
- Add a Name Value pair of the exception messages again but with French value:

![image](https://user-images.githubusercontent.com/31348972/64120995-ee1dca00-cd9d-11e9-9728-07b971bb6409.png)

- If you build the project and go `bin/Debug`, you will find a folder named `fr-FR` containing a `.dll` file, this is our satellite assembly.

- When you want to  throw the exception, you do the following:

```csharp
var resourceManager = new ResourceManager("FULLY_QIALIFIED_NAME_OF_RESOURCE_FILE", Assembly.GetExecutingAssembly());
throw new StudentNotFoundException(resourceManager.GetString("StudentNotFound"), "John")
```

> [!NOTE]
> If our project name is `TestProject` and our resource file is called `ExceptionMessages.resx` and is inside a folder called `Resources` in the project, the fully qualified name will be `TestProject.Resources.ExceptionMessages`.

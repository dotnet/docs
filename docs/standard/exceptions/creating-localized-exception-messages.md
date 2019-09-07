---
title: How to: create user-defined exceptions with localized exception messages
description: Learn how to create user-defined exceptions with localized exception messages
author: Youssef1313
ms.author: ronpet
ms.date: 09/02/2019
---
# How to: create user-defined exceptions with localized exception messages

## Create custom exceptions
.NET contains many different exceptions that you can use. However, in some cases when none of them meets your needs, you can create your own custom exceptions.
Let's assume you want to create a `StudentNotFoundException` that contains a `StudentName` property.
To create custom exceptions, Follow these steps:

- Create a serializable class that inherits from `Exception`. The class name should end in "Exception":

    ```csharp
    [Serializable]
    public class StudentNotFoundException : Exception
    {
    
    }
    ```

- Add the default constructors:

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

- Add properties and more constructors, depending on your needs:

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
You have created a custom exception, and you can throw it anywhere with code like the following:

```csharp
throw new StudentNotFoundException("The student cannot be found.", "John");
```

The problem with the previous line is that "The student cannot be found." is just a constant string. In a localized application, you want to have different messages depending on user culture.
[Satellite Assemblies](https://docs.microsoft.com/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps) are a good way to do that.

A satellite assembly is a .dll that contains resources for a specific language. When you ask for a specific resources at runtime, the CLR finds that resource depending on user culture. If no satellite assembly is found for that culture, the resources of the default culture are used.


To create the localized exception messages:
- Create a new folder named *Resources* to hold the resource files.
- Add a new resource file to it. To do that in Visual Studio, right-click the folder in **Solution Explorer**, and select **Add** -> **New Item** -> **Resources File**. Name the file *ExceptionMessages.resx*. This is the default resources file.
- Add a name/value pair for your exception message, like the following image shows:

![Add resources to the default culture](media/add-resources-to-default-culture.jpg)

- Add a new resource file for French. Name it *ExceptionMessages.fr-FR.resx*.
- Add a name/value pair for the exception message again, but with a French value:

![Add resources to the fr-FR culture](media/add-resources-to-fr-culture.jpg)

- If you build the project and go to the *bin/Debug* folder, you'll find a folder named *fr-FR* containing a .dll file; this is the satellite assembly.

- You throw the exception with code like the following:

    ```csharp
    var resourceManager = new ResourceManager("FULLY_QIALIFIED_NAME_OF_RESOURCE_FILE", Assembly.GetExecutingAssembly());
    throw new StudentNotFoundException(resourceManager.GetString("StudentNotFound"), "John");
    ```

> [!NOTE]
> If our project name is `TestProject` and our resource file is *ExceptionMessages.resx* and is in a folder named *Resources* in the project, the fully qualified name of the resource file is `TestProject.Resources.ExceptionMessages`.

# See Also

[]()
[]()
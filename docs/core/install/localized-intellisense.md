---
title: Install localized IntelliSense files
description: Learn how to set up your development machine to use localized IntelliSense files.
author: mairaw
ms.author: mairaw
ms.date: 12/12/2019
---
# How to install localized IntelliSense files for .NET Core projects

IntelliSense is a code-completion aid that is available in different integrated development environments (IDEs), such as Visual Studio. By default, when you're developing .NET Core projects, the SDK only includes the English version of the IntelliSense files. This article explains how to install the localized version of those files and modify the Visual Studio installation to use a different language.

## Prerequisites

- [.NET Core 3.0 SDK](https://dotnet.microsoft.com/download/dotnet-core) or later versions
- [Visual Studio 2019 16.3 or later versions](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019)

## Download and install the localized IntelliSense files

1. Go to the [Download IntelliSense files](https://dotnet.microsoft.com/download/dotnet-core) page.
2. Download the IntelliSense file for the language and version you'd like to use.
3. Extract the contents of the zip file.
4. Navigate to the .NET Core installation folder. By default, it's under *C:\Program Files\dotnet\packs*.

   - Choose which SDK you want to install the IntelliSense for and navigate to the associated path. You have the following options:

      | SDK type        | Path                               |
      | --------------- | ---------------------------------- |
      | .NET Core       | *Microsoft.NETCore.App.Ref*        |
      | Windows Desktop | *Microsoft.WindowsDesktop.App.Ref* |
      | .NET Standard   | *NETStandard.Library.Ref*          |
   
   - Navigate to the version you want to install the localized IntelliSense for. For example, *3.1.0*.
   - Open the *ref* folder.
   - Open the moniker folder. For example, *netcoreapp3.1*.

   So, the full path that you'd navigate to would look similar to *C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\3.1.0\ref\netcoreapp3.1*.

5. Create a subfolder inside the moniker folder you just opened. The name of the folder indicates which language you want to use. The following table specifies the different options:

| Language              | Folder name |
| --------------------- | ----------- |
| Chinese (simplified)  | *zh-hans*   |
| Chinese (traditional) | *zh-hant*   |
| French                | *fr*        |
| German                | *de*        |
| Italian               | *it*        |
| Japanese              | *ja*        |
| Korean                | *ko*        |
| Russian               | *ru*        |
| Spanish               | *es*        |

6. Copy all the *.xml* files you extracted on step 3 to this new folder. If you're copying this to the .NET Standard path, then you can just copy the *netstandard.xml* file.

## Modify Visual Studio language



## See also

- [IntelliSense in Visual Studio](/visualstudio/ide/using-intellisense)
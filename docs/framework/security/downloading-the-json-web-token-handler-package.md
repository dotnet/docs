---
title: "Downloading the JSON Web Token Handler Package"
ms.date: 10/10/2018
ms.assetid: d12b3f5b-f1f1-4a9d-a159-0c13e5976c90
---
# Download the JSON Web Token Handler Package

This topic discusses how to download and use the JSON Web Token Handler in your project.

The JSON Web Token Handler extension is available as a NuGet package, which adds the necessary assemblies and references to your project. If you do not already have NuGet installed, go to [nuget.org](https://nuget.org) to install it. You can see the versioning history for the extension by visiting its page on NuGet: [JSON Web Token Handler on NuGet](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt/)

## Use the Package Manager GUI

1. In Visual Studio, right-click your project in **Solution Explorer**, and then select **Manage NuGet Packages**.

2. In the **Manage NuGet Packages** window, click the search box and enter `JWT Token Handler` and press **Enter**.

3. From the results pane, click the **Install** button for the first result.

4. The package will begin downloading. Before it is added to your project, the License Acceptance dialog will appear. If you agree to the license terms, click **I Accept**.

5. The latest JSON Web Token Handler assemblies will be downloaded and added to your project.

## Use the Package Manager Console

1. In Visual Studio, click **Tools** > **NuGet Package Manager** > **Package Manager Console**.

2. The **Package Manager Console** appears. Enter the following text and press **Enter**:

    ```powershell
    Install-Package System.IdentityModel.Tokens.Jwt
    ```

3. The latest JSON Web Token Handler assemblies will be downloaded and added to your project.

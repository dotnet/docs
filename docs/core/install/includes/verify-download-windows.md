---
author: adegeo
ms.author: adegeo
ms.date: 11/14/2023
ms.topic: include
---

You can use **PowerShell** or **Command Prompt** to validate the checksum of the file you've downloaded. For example, the following command reports the checksum of the _dotnet-sdk-8.0.100-win-x64.exe_ file:

```cmd
> certutil -hashfile dotnet-sdk-8.0.100-win-x64.exe SHA512
SHA512 hash of dotnet-sdk-8.0.100-win-x64.exe:
248acec95b381e5302255310fb9396267fd74a4a2dc2c3a5989031969cb31f8270cbd14bda1bc0352ac90f8138bddad1a58e4af1e56cc4a1613b1cf2854b518e
CertUtil: -hashfile command completed successfully.
```

```powershell
> (Get-FileHash .\dotnet-sdk-8.0.100-win-x64.exe -Algorithm SHA512).Hash
248acec95b381e5302255310fb9396267fd74a4a2dc2c3a5989031969cb31f8270cbd14bda1bc0352ac90f8138bddad1a58e4af1e56cc4a1613b1cf2854b518e
```

Compare the checksum with the value provided by the download site.

### Use PowerShell and a checksum file to validate

The .NET release notes contain a link to a checksum file you can use to validate your downloaded file. The following steps describe how to download the checksum file and validate a .NET install binary:

01. The release notes page for .NET 8 on GitHub at <https://github.com/dotnet/core/tree/main/release-notes/8.0> contains a section named **Releases**. The table in that section links to the downloads and checksum files for each .NET 8 release:

    :::image type="content" source="../media/install-sdk/release-notes-root.png" alt-text="The github release notes version table for .NET":::

01. Select the link for the version of .NET that you downloaded. The previous section used .NET SDK 8.0.100, which is in the .NET 8.0.0 release.

    > [!TIP]
    > If you're not sure which .NET release contains your checksum file, explore the links until you find it.

01. In the release page, you can see the .NET Runtime and .NET SDK version, and a link to the checksum file:

    :::image type="content" source="../media/install-sdk/release-notes-version.png" alt-text="The download table with checksums for .NET":::

01. Copy the link to the checksum file.

01. Use the following script, but replace the link to download the appropriate checksum file:

    ```powershell
    Invoke-WebRequest https://builds.dotnet.microsoft.com/dotnet/checksums/8.0.0-sha.txt -OutFile 8.0.0-sha.txt
    ```

01. With both the checksum file and the .NET release file downloaded to the same directory, search the checksum file for the checksum of the .NET download:

    When validation passes, you see **True** printed:

    ```powershell
    > (Get-Content .\8.0.0-sha.txt | Select-String "dotnet-sdk-8.0.100-win-x64.exe").Line -like (Get-FileHash .\dotnet-sdk-8.0.100-win-x64.exe -Algorithm SHA512).Hash + "*"
    True
    ```

    If you see **False** printed, the file you downloaded isn't valid and shouldn't be used.

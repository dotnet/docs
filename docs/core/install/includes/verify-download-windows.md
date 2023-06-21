---
author: adegeo
ms.author: adegeo
ms.date: 06/21/2023
ms.topic: include
---

You can use **PowerShell** or **Command Prompt** to validate the checksum of the file you've downloaded. For example, the following command reports the checksum of the _dotnet-sdk-7.0.304-win-x64.exe_ file:

```cmd
> certutil -hashfile dotnet-sdk-7.0.304-win-x64.exe SHA512
SHA512 hash of dotnet-sdk-7.0.304-win-x64.exe:
648732c79f6276c37a92e211b4c5b6cf84a0a54637c0f85949ced96d31838b43a4dcae905ef70bafbc9edd3542400746fb1e00c4c84679713e97219493a45938
CertUtil: -hashfile command completed successfully.
```

```powershell
> (Get-FileHash .\dotnet-sdk-7.0.304-win-x64.exe -Algorithm SHA512).Hash
648732C79F6276C37A92E211B4C5B6CF84A0A54637C0F85949CED96D31838B43A4DCAE905EF70BAFBC9EDD3542400746FB1E00C4C84679713E97219493A45938
```

Compare the checksum with the value provided by the download site.

### Use PowerShell and a checksum file to validate

The .NET release notes contain a link to a checksum file you can use to validate your downloaded file. The following steps describe how to download the checksum file and validate a .NET install binary:

01. The release notes page for .NET 7.0 on GitHub at <https://github.com/dotnet/core/tree/main/release-notes/7.0> contains a section named **Releases**. The table in this section links to the downloads and checksum files for each .NET 7 release:

    :::image type="content" source="../media/install-sdk/release-notes-root.png" alt-text="The github release notes version table for .NET":::

01. Select the link to your version of .NET that you downloaded. The previous section used .NET SDK 7.0.304, which is in the .NET 7.0.7 release.

    > [!TIP]
    > If you're not sure which .NET release contains your checksum file, explore the links until you find it.

01. In the release page, you can see the .NET Runtime and .NET SDK version, and a link to the checksum file:

    :::image type="content" source="../media/install-sdk/release-notes-version.png" alt-text="The download table with checksums for .NET":::

01. Copy the link to the checksum file.

01. Use the following script, pasting in the link to download the appropriate checksum file:

    ```powershell
    Invoke-WebRequest https://dotnetcli.blob.core.windows.net/dotnet/checksums/7.0.7-sha.txt -OutFile 7.0.7-sha.txt
    ```

01. With both the checksum file and the .NET release file downloaded to the same directory, search the checksum file for the checksum of the .NET download:

    When validation passes, you see **True** printed:

    ```powershell
    > (Get-Content .\7.0.7-sha.txt | Select-String "dotnet-sdk-7.0.304-win-x64.exe").Line -like (Get-FileHash .\dotnet-sdk-7.0.304-win-x64.exe -Algorithm SHA512).Hash + "*"
    True
    ```

    If you see **False** printed, the file you downloaded isn't valid and shouldn't be used.

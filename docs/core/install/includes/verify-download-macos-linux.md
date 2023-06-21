---
author: adegeo
ms.author: adegeo
ms.date: 06/21/2023
ms.topic: include
---

Use the `sha512sum` command to print the checksum of the file you've downloaded. For example, the following command reports the checksum of the _dotnet-sdk-7.0.304-linux-x64.tar.gz_ file:

```bash
$ sha512sum dotnet-sdk-7.0.304-linux-x64.tar.gz
f4b7d0cde432bd37f445363b3937ad483e5006794886941e43124de051475925b3cd11313b73d2cae481ee9b8f131394df0873451f6088ffdbe73f150b1ed727  dotnet-sdk-7.0.304-linux-x64.tar.gz
```

Compare the checksum with the value provided by the download site.

> [!IMPORTANT]
> Even though a Linux file is shown in these examples, this information equally applies to macOS.

### Use a checksum file to validate

The .NET release notes contain a link to a checksum file you can use to validate your downloaded file. For example:

01. The release notes page for .NET 7.0 on GitHub at <https://github.com/dotnet/core/tree/main/release-notes/7.0> contains a section named **Relases**. The table in this section links to the downloads and checksum files for each .NET 7 release:

    :::image type="content" source="../media/install-sdk/release-notes-root.png" alt-text="The github release notes version table for .NET":::

01. Select the link to your version of .NET that you downloaded. The previous section used .NET SDK 7.0.304, which is in the .NET 7.0.7 release.

    > [!TIP]
    > If you're not sure which .NET release contains your checksum file, explore the links until you find it.

01. In the release page, you can see the .NET Runtime and .NET SDK version, and a link to the checksum file:

    :::image type="content" source="../media/install-sdk/release-notes-version.png" alt-text="The download table with checksums for .NET":::

01. Copy the link to the checksum file.

01. Use the following script, pasting in the link to download the appropriate checksum file:

    ```bash
    curl -O https://dotnetcli.blob.core.windows.net/dotnet/checksums/7.0.7-sha.txt
    ```

01. With both the checksum file and the .NET release file downloaded to the same directory, use the `sha512sum -c {file} --ignore-missing` command to validate the downloaded file.

    When validation passes, you see the file printed with the **OK** status:

    ```bash
    $ sha512sum -c 7.0.7-sha.txt --ignore-missing
    dotnet-sdk-7.0.304-linux-x64.tar.gz: OK
    ```

    If you see the file marked as **FAILED**, the file you downloaded isn't valid and shouldn't be used.

    ```bash
    $ sha512sum -c 7.0.7-sha.txt --ignore-missing
    dotnet-sdk-7.0.304-linux-x64.tar.gz: FAILED
    sha512sum: WARNING: 1 computed checksum did NOT match
    sha512sum: 7.0.7-sha.txt: no file was verified
    ```

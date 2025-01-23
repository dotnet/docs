---
author: adegeo
ms.author: adegeo
ms.date: 11/14/2023
ms.topic: include
ms.custom: linux-related-content
---

Use the `sha512sum` command to print the checksum of the file you've downloaded. For example, the following command reports the checksum of the _dotnet-sdk-8.0.100-linux-x64.tar.gz_ file:

```bash
$ sha512sum dotnet-sdk-8.0.100-linux-x64.tar.gz
13905ea20191e70baeba50b0e9bbe5f752a7c34587878ee104744f9fb453bfe439994d38969722bdae7f60ee047d75dda8636f3ab62659450e9cd4024f38b2a5  dotnet-sdk-8.0.100-linux-x64.tar.gz
```

Compare the checksum with the value provided by the download site.

> [!IMPORTANT]
> Even though a Linux file is shown in these examples, this information equally applies to macOS.

### Use a checksum file to validate

The .NET release notes contain a link to a checksum file you can use to validate your downloaded file. The following steps describe how to download the checksum file and validate a .NET install binary:

01. The release notes page for .NET 8 on GitHub at <https://github.com/dotnet/core/tree/main/release-notes/8.0#releases> contains a section named **Releases**. The table in that section links to the downloads and checksum files for each .NET 8 release:

    :::image type="content" source="../media/install-sdk/release-notes-root.png" alt-text="The github release notes version table for .NET":::

01. Select the link for the version of .NET that you downloaded.

    The previous section used .NET SDK 8.0.100, which is in the .NET 8.0.0 release.

01. In the release page, you can see the .NET Runtime and .NET SDK version, and a link to the checksum file:

    :::image type="content" source="../media/install-sdk/release-notes-version.png" alt-text="The download table with checksums for .NET":::

01. Right-click on the **Checksum** link, and copy the link to your clipboard.

01. Open a terminal.

01. Use `curl -O {link}` to download the checksum file.

    Replace the link in the following command with the link you copied.

    ```bash
    curl -O https://builds.dotnet.microsoft.com/dotnet/checksums/8.0.0-sha.txt
    ```

01. With both the checksum file and the .NET release file downloaded to the same directory, use the `sha512sum -c {file} --ignore-missing` command to validate the downloaded file.

    When validation passes, you see the file printed with the **OK** status:

    ```bash
    $ sha512sum -c 8.0.0-sha.txt --ignore-missing
    dotnet-sdk-8.0.100-linux-x64.tar.gz: OK
    ```

    If you see the file marked as **FAILED**, the file you downloaded isn't valid and shouldn't be used.

    ```bash
    $ sha512sum -c 8.0.0-sha.txt --ignore-missing
    dotnet-sdk-8.0.100-linux-x64.tar.gz: FAILED
    sha512sum: WARNING: 1 computed checksum did NOT match
    sha512sum: 8.0.0-sha.txt: no file was verified
    ```

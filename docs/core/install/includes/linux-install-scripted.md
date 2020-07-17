
The [dotnet-install scripts](../../tools/dotnet-install-script.md) are used for automation and non-admin installs of the **SDK** and **Runtime**. You can download the script from <https://dot.net/v1/dotnet-install.sh>.

The script defaults to installing the latest SDK [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) version, which is .NET Core 3.1. To install the current release, which may not be an (LTS) version, use the `-c Current` parameter.

```bash
./dotnet-install.sh -c Current
```

To install .NET Core Runtime instead of the SDK, use the `--runtime` parameter.

```bash
./dotnet-install.sh -c Current --runtime aspnetcore
```

You can install a specific version by altering the `-c` parameter to indicate the specific version. The following command installs .NET Core SDK 3.1.

```bash
./dotnet-install.sh -c 3.1
```

For more information, see [dotnet-install scripts reference](../../tools/dotnet-install-script.md).

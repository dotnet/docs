
[.NET Core is available from the Snap Store.](https://snapcraft.io/dotnet-sdk)

A snap is a bundle of an app and its dependencies that works without modification across many different Linux distributions. Snaps are discoverable and installable from the Snap Store. For more information about Snap, see [Getting started with Snap](https://snapcraft.io/docs/getting-started).

Only supported versions of .NET Core are available through Snap.

### Install the SDK

Snap packages for .NET Core SDK are all published under the same identifier: `dotnet-sdk`. A specific version of the SDK can be installed by specifying the channel. The SDK includes the coresponding runtime. The following table list the channels:

| .NET Core version | Snap package             |
|-------------------|--------------------------|
| 3.1 (LTS)         | `3.1` or `latest/stable` |
| 2.1 (LTS)         | `2.1`                    |
| .NET 5.0 preview  | `5.0/beta`               |

Use the `snap install` command to install a .NET Core SDK snap package. Use the `--channel` parameter to indicate which version to install. If this parameter is omitted, `latest/stable` is used. In this example, `3.1` is specified:

```bash
sudo snap install dotnet-sdk --classic --channel=3.1
```

Next, register the `dotnet` command for the system with the `snap alias` command:

```bash
sudo snap alias dotnet-sdk.dotnet dotnet
```

This command is formatted as: `sudo snap alias {package}.{command} {alias}`. You can choose any `{alias}` name you would like. For example, you could name the command after the specific version installed by snap: `sudo snap alias dotnet-sdk.dotnet dotnet31`. When you use the command `dotnet31`, you'll invoke this specific version of .NET. But this is incompatible with most tutorials and examples as they expect a `dotnet` command to be available.

### Install the runtime

Snap packages for .NET Core Runtime are each published under their own package identifier. The following table lists the package identifiers:

| .NET Core version | Snap package        |
|-------------------|---------------------|
| 3.1 (LTS)         | `dotnet-runtime-31` |
| 3.0               | `dotnet-runtime-30` |
| 2.2               | `dotnet-runtime-22` |
| 2.1 (LTS)         | `dotnet-runtime-21` |

Use the `snap install` command to install a .NET Core Runtime snap package. In this example, .NET Core 3.1 is installed:

```bash
sudo snap install dotnet-runtime-31 --classic
```

Next, register the `dotnet` command for the system with the `snap alias` command:

```bash
sudo snap alias dotnet-runtime-31.dotnet dotnet
```

This command is formatted as: `sudo snap alias {package}.{command} {alias}`. You can choose any `{alias}` name you would like. For example, you could name the command after the specific version installed by snap: `sudo snap alias dotnet-runtime-31.dotnet dotnet31`. When you use the command `dotnet31`, you'll invoke this specific version of .NET. But this is incompatible with most tutorials and examples as they expect a `dotnet` command to be available.

### SSL Certificate errors

When .NET is installed through Snap, it's possible that on some distros the .NET SSL certificates may not be found and you may receive an error similar to the following during `restore`:

```bash
Processing post-creation actions...
Running 'dotnet restore' on /home/myhome/test/test.csproj...
  Restoring packages for /home/myhome/test/test.csproj...
/snap/dotnet-sdk/27/sdk/2.2.103/NuGet.targets(114,5): error : Unable to load the service index for source https://api.nuget.org/v3/index.json. [/home/myhome/test/test.csproj]
/snap/dotnet-sdk/27/sdk/2.2.103/NuGet.targets(114,5): error :   The SSL connection could not be established, see inner exception. [/home/myhome/test/test.csproj]
/snap/dotnet-sdk/27/sdk/2.2.103/NuGet.targets(114,5): error :   The remote certificate is invalid according to the validation procedure. [/home/myhome/test/test.csproj]
```

To resolve this issue, set a few enviornment variables:

```bash
export SSL_CERT_FILE=[path-to-certificate-file]
export SSL_CERT_DIR=/dev/null
```

The certificate location will vary by distro. Here are the locations for the distros where we have experienced the issue.

* Fedora - `/etc/pki/ca-trust/extracted/pem/tls-ca-bundle.pem`
* OpenSUSE - `/etc/ssl/ca-bundle.pem`
* Solus - `/etc/ssl/certs/ca-certificates.crt`

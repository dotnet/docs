dotnet-install scripts reference
================================

## NAME
dotnet-install.ps1 | dotnet-install.sh - script used to install the CLI tools and shared runtime

## SYNOPSIS
dotnet-install.sh [--channel] [--version]
    [--install-dir] [--debug] [--no-path] 
    [--shared-runtime]

dotnet-install.ps1 [-Channel] [-Version]
    [-InstallDir] [-Debug] [-NoPath] 
    [-SharedRuntime]

## DESCRIPTION
The `dotnet-install` scripts are used to perform a non-admin install of the CLI toolchain and the shared runtime. You 
can download the scripts from our [GitHub repo](https://github.com/dotnet/cli/tree/rel/1.0.0/scripts/obtain). 

Their main use case is to help with automation scenarios and non-admin installations. There are two scripts, one for PowerShell 
that works on Windows and a bash script that works on Linux/OS X. They both have the same behavior. Bash script also 
"understands" PowerShell switches so you can use them across the board. 

Installation scripts will download the ZIP/tarball from the CLI build drops and will proceed to install it in either the 
default location or in a location specified by `--install-dir`. By default, the installation script 
will download the SDK and install it; if you want to get just the shared runtime, you can specify the `--shared-runtime`
argument. 

By default, the script will add the install location to the $PATH for the current session. This can be overridden if the 
`--no-path` argument is used. 

Before running the script, please install all the required [dependencies](https://github.com/dotnet/cli/tree/rel/1.0.0/Documentation/reqs.md).

You can install a specific version using the `--version` argument. The version needs to be specified as 3-part version 
(for example 1.0.0-13232). If omitted, it will default to the first global.json found in the hierarchy above the folder the script 
was invoked in that contains the `sdkVersion` property. If that is not present it will use Latest.

You can also use this script to get the SDK or shared runtime debug binaries with debug symbols by using the `--debug` 
argument. If you do not do this on first install and realize you do need debug symbols later on, you can re-run the 
script with this argument and the version of the bits you installed. 

## Options
Options are different between script implementations. 

### PowerShell
`-Channel [CHANNEL]`

Which channel (for example, "future", "preview", "production") to install from. Defaults to "Production".

`-Version [VERSION]`

Which version of CLI to install; you need to specify the version as 3-part version (i.e. 1.0.0-13232). If omitted, it will default to the first global.json that contains the sdkVersion property; if that is not present it will use Latest. 	

`-InstallDir [DIR]`

Path to install to. The directory is created if it doesn't exist. Defaults to `%LocalAppData%\.dotnet`.

`-Debug`

Whether to use larger packages that contain debugging symbols or not. Defaults to "false".	

`-NoPath`

Export the prefix/installdir to the path for the current session. This makes CLI tools available immediately after install. 
Defaults to "false", that is, the PATH is modified. 

`-SharedRuntime`

Install just the shared runtime bits, not the entire SDK. Defaults to "false".

### Bash
`--channel [CHANNEL]`

Which channel (for example "future", "preview", "production") to install from. Defaults to "Production".

`--version [VERSION]`

Which version of CLI to install; you need to specify the version as 3-part version (i.e. 1.0.0-13232). If omitted, it will default to the first global.json that contains the sdkVersion property; if that is not present it will use Latest. 	

`--install-dir [DIR]`

Path to where to install. The directory is created if it doesn't exist. Defaults to `$HOME/.dotnet`.

`--debug`

Whether to use the larger packages that contain debugging symbols or not. Defaults to "false". You can install 

`--no-path`

Export the prefix/installdir to the path for the current session. This makes CLI tools available immediately after install. 
Defaults to "false", that is, the PATH is modified. 

`--shared-runtime`

Installs just the shared runtime bits, not the entire SDK. Defaults to "false".

## EXAMPLES

Windows:

```
./dotnet-install.ps1 -Channel Future
```

OSX/Linux:

```
./dotnet-install.sh --channel Future
```

Install the latest preview to specified location

Windows:

```
./dotnet-install.ps1 -Channel preview -InstallDir C:\cli
```

OSX/Linux:

```
./dotnet-install.sh --channel preview --install-dir ~/cli
```


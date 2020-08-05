
<!-- Note, this content is copied in ../macos.md. Any fixes should be applied there too, though content may be different -->

As an alternative to the package managers, you can download and manually install the SDK and runtime. Manual install is usually performed as part of continuous integration testing or on an unsupported Linux distribution. For a developer or user, it's generally better to use a package manager.

If you install .NET Core SDK, you don't need to install the corresponding runtime. First, download a **binary** release for either the SDK or the runtime from one of the following sites:

- ✔️ [.NET 5.0 preview downloads](https://dotnet.microsoft.com/download/dotnet/5.0)
- ✔️ [.NET Core 3.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- ✔️ [.NET Core 2.1 downloads](https://dotnet.microsoft.com/download/dotnet-core/2.1)
- [All .NET Core downloads](https://dotnet.microsoft.com/download/dotnet-core)

Next, extract the downloaded file and use the `export` command to set variables used by .NET Core and then ensure .NET Core is in PATH.

To extract the runtime and make the .NET Core CLI commands available at the terminal, first download a .NET Core binary release. Then, open a terminal and run the following commands from the directory where the file was saved. The archive file name may be different depending on what you downloaded.

**Use the following command to extract the runtime**:

```bash
mkdir -p "$HOME/dotnet" && tar zxf aspnetcore-runtime-3.1.0-linux-x64.tar.gz -C "$HOME/dotnet"
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

**Use the following command to extract the SDK**:

```bash
mkdir -p "$HOME/dotnet" && tar zxf dotnet-sdk-3.1.301-linux-x64.tar.gz -C "$HOME/dotnet"
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet
```

> [!TIP]
> The preceding `export` commands only make the .NET Core CLI commands available for the terminal session in which it was run.
>
> You can edit your shell profile to permanently add the commands. There are a number of different shells available for Linux and each has a different profile. For example:
>
> - **Bash Shell**: *~/.bash_profile*, *~/.bashrc*
> - **Korn Shell**: *~/.kshrc* or *.profile*
> - **Z Shell**: *~/.zshrc* or *.zprofile*
>
> Edit the appropriate source file for your shell and add `:$HOME/dotnet` to the end of the existing `PATH` statement. If no `PATH` statement is included, add a new line with `export PATH=$PATH:$HOME/dotnet`.
>
> Also, add `export DOTNET_ROOT=$HOME/dotnet` to the end of the file.

This approach lets you install different versions into separate locations and choose explicitly which one to use by which application.


When you install with a package manager, these libraries are installed for you. But, if you manually install .NET Core or you publish a self-contained app, you'll need to make sure these libraries are installed:

- krb5-libs
- libicu
- openssl-libs
- zlib

If the target runtime environment's OpenSSL version is 1.1 or newer, you'll need to install **compat-openssl10**.

For more information about the dependencies, see [Self-contained Linux apps](https://github.com/dotnet/core/blob/main/Documentation/self-contained-linux-apps.md).

For .NET Core apps that use the *System.Drawing.Common* assembly, you'll also need the following dependency:

- [libgdiplus (version 6.0.1 or later)](https://www.mono-project.com/docs/gui/libgdiplus/)

  > [!WARNING]
  > You can install a recent version of *libgdiplus* by adding the Mono repository to your system. For more information, see <https://www.mono-project.com/download/stable/>.

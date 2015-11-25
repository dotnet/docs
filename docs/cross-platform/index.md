# Cross-Platform development in .NET

When it comes to cross-platform development in .NET, you have a few options depending on what you requirements are.

## Portable Class Libraries

If your code does not need to access platform-specific APIs (for example, it is entirely a math API), then Portable Class Libraries may be suitable for your use.  Note that you can not P/Invoke in Portable Class Libraries, and the APIs you depend on are strictly limited to the subset of all platforms that you support.

Portable class libraries can be created in Visual Studio.

NOTE: Some platforms (e.g. Linux) do not have strong support for Portable Class Libraries, and you may find that on some Linux distributions (especially those with an old version of Mono), that runtime errors may occur.

## .NET Core (for server applications)

If you are writing an entirely server-side application, .NET Core may be a suitable choice for your needs.  Keep in mind that as with Portable Class Libraries, P/Invoke support here is limited (you'll need to perform runtime checks to determine what platform the user is running on).

.NET Core projects are managed through DNX.

## Shared Code projects

If you are writing simple applications (i.e. those that do not have a large number of assemblies), then you may be able to use Shared Code projects in the latest version of Visual Studio.

Shared Code projects share a set of C# files between multiple on-disk projects.  This means that for each platform you want to target for an assembly, you will have an additional C# project on disk (e.g. if you wanted to target Windows, Linux and Mac OS, you would have 4 project files on disk).

Shared Code projects do allow you to access all available platform APIs by using `#ifdef` constructs.  They do not contain references, so you will need to manage platform-specific references in each of the platform-specific projects for each assembly.

## Protobuild

If your code needs access to platform-specific APIs, or you are targeting multiple desktop, mobile or console platforms, Protobuild may be ideal for you.

Protobuild is a cross-platform project generator, which produces C# projects and solution files depending on what platform you want to target.  Because Protobuild generates C# project files, you can access all APIs that are available on each platform, and P/Invoke native methods.

In constrast to Shared Code projects, Protobuild projects allow changing project references based on the platform as well.  In addition unlike Shared Code projects, Protobuild only has one project definition on disk per project, which reduces management overhead if you have more than a few assemblies or are targeting more than a few platforms.

[Protobuild](http://protobuild.org/) can be downloaded from their website; documentation on how to get started with Protobuild can be found at on the [Getting Started](https://protobuild.readthedocs.org/en/latest/getting_started.html) guide.


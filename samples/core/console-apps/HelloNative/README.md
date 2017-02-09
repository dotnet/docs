Hello Native Sample
================

This sample is part of the [step-by-step tutorial](https://docs.microsoft.com/dotnet/articles/core/tutorials/using-with-xplat-cli)
for creating .NET Core Console Applications. Please see that topic for detailed steps on the code
for this sample.

Key Features
------------

This is the basic Hello World sample for native output. It demonstrates how you build a native
application using .NET Core on your platform: Linux, Mac, or Windows.

Note that you can build a native images for any supported platform only from that platform. .NET Core
does not support cross-compiling for supported platform.

Build and Run
-------------

To build and run the sample, type the following three commands:

`dotnet restore`
`dotnet build`
`.\bin\Debug\netcoreapp1.0\win10-x64\HelloNative.exe`

`dotnet restore` installs all the dependencies for this sample into the current directory.
`dotnet build` creates the output assembly (or assemblies).
`.\bin\Debug\netcoreapp1.0\win10-x64\HelloNative.exe` runs the output executable. The example
shows the Windows path. Replace `win10-x64` with your platform's RID from the list of
[supported RIDs](../../../../docs/core/rid-catalog.md).

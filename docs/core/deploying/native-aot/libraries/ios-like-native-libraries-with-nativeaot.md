---
title: Building native libraries for iOS-like platforms
description: How to build and consume native libraries with Native AOT for iOS-like platforms
author: ivanpovazan
ms.author: ivanpovazan
ms.date: 11/11/2024
---

# Building native libraries for iOS-like platforms

Starting from .NET 9, Native AOT supports publishing .NET class libraries that don't depend on iOS workloads for iOS-like platforms.
This enables users to create self-contained native libraries that can be consumed from iOS, Mac Catalyst and tvOS applications.

> [!IMPORTANT]
> This approach does not come with the built-in Objective-C interoperability support and additional code adaptations may be required (like: marshalling reference type arguments) to achieve interoperability.

## Building shared libraries

This section describes steps to create a simple .NET Class Library project with NativeAOT support.

1. Download .NET 9 SDK
2. Create a class library project

    ```bash
    dotnet new classlib -n "MyNativeAOTLibrary"
    ```

3. Add the following properties into the project file `MyNativeAOTLibrary.csproj`

    ```xml
    <PublishAot>true</PublishAot>
    <PublishAotUsingRuntimePack>true</PublishAotUsingRuntimePack>
    ```

4. Edit the `MyNativeAOTLibrary/Class1.cs` source code to expose a managed method to the native world as `aotsample_add`. For example:

    ```cs
    using System.Runtime.InteropServices;
    namespace NaotLib;

    public class Class1
    {
        [UnmanagedCallersOnly(EntryPoint = "aotsample_add")]
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
    ```

### Building iOS shared libraries

This section covers building shared libraries for iOS physical devices (RID: `ios-arm64`).
Targeting iOS simulators (RIDs: `iossimulator-arm64`, `iossimulator-x64`) is almost identical and is not covered in this guide.

1. Publish the class library and target desired iOS platform

    ```bash
    dotnet publish -r ios-arm64 MyNativeAOTLibrary/MyNativeAOTLibrary.csproj
    ```

2. Shared library `MyNativeAOTLibrary.dylib` and debug symbols `MyNativeAOTLibrary.dylib.dSYM` will be located at: `MyNativeAOTLibrary/bin/Release/net9.0/ios-arm64/publish/`

### Building MacCatalyst shared libraries

This section covers building shared libraries for MacCatalyst (RIDs: `maccatalyst-arm64`, `maccatalyst-x64`).

1. Publish the class library and target MacCatalyst for `Arm64` architecture

    ```bash
    dotnet publish -r maccatalyst-arm64 MyNativeAOTLibrary/MyNativeAOTLibrary.csproj
    ```

2. (and/or) Publish the class library and target MacCatalyst for `x64` architecture

    ```bash
    dotnet publish -r maccatalyst-x64 MyNativeAOTLibrary/MyNativeAOTLibrary.csproj
    ```

3. Previous steps will produce two pairs of files: a shared library `MyNativeAOTLibrary.dylib` and its debug symbols `MyNativeAOTLibrary.dylib.dSYM` for each of the two architectures, which will be located in their respective publish folders: `MyNativeAOTLibrary/bin/Release/net9.0/<rid>/publish/`

> [!NOTE]
> Both step 1. and step 2. are required if a universal MacCatalyst framework is being created (more info available [below](#packaging-the-shared-library-into-a-custom-maccatalyst-universal-framework))

## Creating and consuming a custom framework (optional)

Apple imposes a requirement that shared libraries (.dylibs) need to be packaged into frameworks in order to be consumed from applications.

This section describes all required steps to achieve this and a simple scenario of a iOS/MacCatalyst application consuming a shared NativeAOT library/framework.

> [!NOTE]
> The described steps are just for demonstration purposes. The actual requirements may differ depending on the exact use case.

### Packaging the shared library into custom iOS framework

1. Create a framework folder

    ```bash
    mkdir MyNativeAOTLibrary.framework
    ```

2. Adjust load commands:

    - `LC_RPATH` load command

        ```bash
        install_name_tool -rpath @executable_path @executable_path/Frameworks MyNativeAOTLibrary/bin/Release/net9.0/ios-arm64/publish/MyNativeAOTLibrary.dylib
        ```

    - `LC_ID_DYLIB` load command

        ```bash
        install_name_tool -id @rpath/MyNativeAOTLibrary.framework/MyNativeAOTLibrary MyNativeAOTLibrary/bin/Release/net9.0/ios-arm64/publish/MyNativeAOTLibrary.dylib
        ```

3. Manually package the binary into a universal file

    ```bash
    lipo -create MyNativeAOTLibrary/bin/Release/net9.0/ios-arm64/publish/MyNativeAOTLibrary.dylib -output MyNativeAOTLibrary.framework/MyNativeAOTLibrary
    ```

4. Add a property list file to your framework:

    - Create a `Info.plist` file

    ```bash
    touch MyNativeAOTLibrary.framework/Info.plist
    ```

    - Add the contents from the [appendix](#appendix-infoplist-contents) into the created `Info.plist` file

After the final step the framework structure should look like this:

```
MyNativeAOTLibrary.framework
    |_ MyNativeAOTLibrary
    |_ Info.plist
```

### Packaging the shared library into a custom MacCatalyst universal framework

Universal frameworks require binaries for both `Arm64` and `x64` architecture.
For this reason, it is required to publish native libraries targeting both RIDs: `maccatalyst-arm64` and `maccatalyst-x64` beforehand.

1. Create a framework folder structure

    ```bash
    mkdir -p MyNativeAOTLibrary.framework/Versions/A/Resources
    ln -sfh Versions/Current/MyNativeAOTLibrary MyNativeAOTLibrary.framework/MyNativeAOTLibrary
    ln -sfh Versions/Current/Resources MyNativeAOTLibrary.framework/Resources
    ln -sfh A MyNativeAOTLibrary.framework/Versions/Current
    ```

2. Adjust load commands:

    - `LC_RPATH` load command

        ```bash
        install_name_tool -rpath @executable_path @executable_path/../Frameworks MyNativeAOTLibrary/bin/Release/net9.0/maccatalyst-arm64/publish/MyNativeAOTLibrary.dylib
        install_name_tool -rpath @executable_path @executable_path/../Frameworks MyNativeAOTLibrary/bin/Release/net9.0/maccatalyst-x64/publish/MyNativeAOTLibrary.dylib
        ```

    - `LC_ID_DYLIB` load command

        ```bash
        install_name_tool -id @rpath/MyNativeAOTLibrary.framework/Versions/A/MyNativeAOTLibrary MyNativeAOTLibrary/bin/Release/net9.0/maccatalyst-arm64/publish/MyNativeAOTLibrary.dylib
        install_name_tool -id @rpath/MyNativeAOTLibrary.framework/Versions/A/MyNativeAOTLibrary MyNativeAOTLibrary/bin/Release/net9.0/maccatalyst-x64/publish/MyNativeAOTLibrary.dylib
        ```

3. Manually package the binary into a universal file

    ```bash
    lipo -create MyNativeAOTLibrary/bin/Release/net9.0/maccatalyst-arm64/publish/MyNativeAOTLibrary.dylib MyNativeAOTLibrary/bin/Release/net9.0/maccatalyst-x64/publish/MyNativeAOTLibrary.dylib -output MyNativeAOTLibrary.framework/Versions/A/MyNativeAOTLibrary
    ```

4. Add a property list file to your framework:

    - Create a `Info.plist` file

    ```bash
    touch MyNativeAOTLibrary.framework/Versions/A/Resources/Info.plist
    ```

    - Add the contents from the [appendix](#appendix-infoplist-contents) into the created `Info.plist` file

After the final step the framework structure should look like this:

```
MyNativeAOTLibrary.framework
    |_ MyNativeAOTLibrary -> Versions/Current/MyNativeAOTLibrary
    |_ Resources -> Versions/Current/Resources
    |_ Versions
        |_ A
        |   |_ Resources
        |   |   |_ Info.plist
        |   |_ MyNativeAOTLibrary
        |_ Current -> A
```

### Consuming custom frameworks

1. Open `Xcode` (in this example `Xcode 16.0` is used)
2. Create a new `App` project
3. Choose the name for your app (e.g., `MyiOSApp`) and choose Objective-C as the source language
4. Add a reference to the `MyNativeAOTLibrary` framework
    - In the `MyiOSApp` targets `General` tab, under `Frameworks, Libraries and Embedded Content` click the `+` sign to add `MyNativeAOTLibrary` as the referenced framework
    - In the dialog choose: `Add Other` -> `Add Files` and then browse to the location of `MyNativeAOTLibrary.framework` and select it
    - Once selected, set `Embed and Sign` option for `MyNativeAOTLibrary` framework

    ![Drop](./xcode-add-framework-reference.png)
5. Add `MyNativeAOTLibrary.framework` location to the list of `Framework Search Paths` in the `Build Settings` tab

    ![Drop](./xcode-add-framework-search-path.png)
6. Edit the `main.m` by calling the exposed managed method `aotsample_add` and printing the result

    ```objc
        extern int aotsample_add(int a, int b);
        int main(int argc, char * argv[]) {
            ...
            NSLog(@"2 + 5 = %d", aotsample_add(2, 5));
            ...
        }
    ```

7. Select your physical iOS device and build/run the app
8. Inspect the logs after the app has successfully launched, the app should print out: `2 + 5 = 7`

> [!NOTE]
> For MacCatalyst, the above-described steps are identical apart from step 7, where the Run Destination needs to be set as: `Mac (Mac Catalyst)`

## Building static libraries with NativeAOT for iOS-like platforms

As described in [building native libraries overview](./index.md#building-native-libraries), it is preferred to build shared libraries, over static ones, due to several limitations.

However, if desired, building static libraries can be accomplished by following the steps for building a shared one, with an additional property to be included in the project file:

```xml
<NativeLib>Static</NativeLib>
```

After the project has been published, the static library `MyNativeAOTLibrary.a` can be found at: `MyNativeAOTLibrary/bin/Release/net9.0/<rid>/publish`.

Consuming the static library and configuring the consumer project are not covered in this document.

## Appendix Info.plist contents

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>CFBundleName</key>
    <string>MyNativeAOTLibrary</string>
    <key>CFBundleIdentifier</key>
    <string>com.companyname.MyNativeAOTLibrary</string>
    <key>CFBundleVersion</key>
    <string>1.0</string>
    <key>CFBundleExecutable</key>
    <string>MyNativeAOTLibrary</string>
    <key>CFBundlePackageType</key>
    <string>FMWK</string>
</dict>
</plist>
```

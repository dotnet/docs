---
title: ".NET Native General Troubleshooting"
ms.date: "03/30/2017"
ms.assetid: ee8c5e17-35ea-48a1-8767-83298caac1e8
---
# .NET Native General Troubleshooting

This topic describes how to troubleshoot potential issues that you might encounter when developing apps with .NET Native.

- **Issue:** Your build output window isn't properly updated.

  **Resolution:** The build output window isn't updated until the build completes. Build times may be up to several minutes, so you might experience a delay in seeing the updates.

- **Issue:** Your app’s retail build time for ARM has increased.

  **Resolution:** When you deploy an app to your ARM device, the .NET Native infrastructure is invoked. This compilation performs a large number of optimizations while ensuring that non-static semantics such as reflection continue to work. In addition, the portion of the .NET Framework that the app uses is statically linked in for optimal performance and has to be compiled into native code as well. This is why compilation takes longer.

  However, compilation times are still within a minute of standard compilation for most apps on a standard development machine.  Typically, just generating native images for the .NET Framework on a standard development machine takes several minutes.  Even with all the optimizations to improve the generated code and with including the .NET Framework, app build times are typically a minute or two.

  We are continuing to work on improving compilation performance by investigating multi-threaded compilation and other optimizations.

- **Issue:** You don’t know if your app was compiled using .NET Native.

  **Resolution:** If the .NET Native compiler is invoked, you'll notice longer build times, and Task Manager will show various .NET Native component processes such as ILC.exe and nutc_driver.exe.

  After you successfully build your project with .NET Native, you'll find the output under obj\\*config*\ *arch*\\*projectname*.ilc\out.  The final native package contents can be found under bin\\*arch*\\*config*\AppX. The final native package contents are under \bin\\*arch*\\*config*\AppX if you have deployed the app.

- **Issue:** Your .NET Native-compiled app is throwing runtime exceptions (typically [MissingMetadataException](missingmetadataexception-class-net-native.md) or [MissingRuntimeArtifactException](missingruntimeartifactexception-class-net-native.md) exceptions) that it did not throw when compiled without .NET Native.

  **Resolution:** The exceptions are thrown because .NET Native did not provide either the metadata or the implementation code that is otherwise available through reflection. (For more information, see [.NET Native and Compilation](net-native-and-compilation.md).) To eliminate the exception, you have to add an entry to your [runtime directives (rd.xml) file](runtime-directives-rd-xml-configuration-file-reference.md) so that the .NET Native tool chain can make the metadata or implementation code available at runtime. Two troubleshooters are available that will generate the necessary entry to add to your runtime directives file:

  - The [MissingMetadataException troubleshooter](https://dotnet.github.io/native/troubleshooter/type.html) for types.

  - The [MissingMetadataException troubleshooter](https://dotnet.github.io/native/troubleshooter/method.html) for methods.

  For more information, see [Reflection and .NET Native](reflection-and-net-native.md).

## See also

- [Migrating Your Windows Store App to .NET Native](migrating-your-windows-store-app-to-net-native.md)

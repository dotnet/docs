---
title: System.AppContext class
description: Learn about the System.AppContext class through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.AppContext class

[!INCLUDE [context](includes/context.md)]

The <xref:System.AppContext> class enables library writers to provide a uniform opt-out mechanism for new functionality for their users. It establishes a loosely coupled contract between components in order to communicate an opt-out request. This capability is typically important when a change is made to existing functionality. Conversely, there is already an implicit opt-in for new functionality.

## AppContext for library developers

Libraries use the <xref:System.AppContext> class to define and expose compatibility switches, while library users can set those switches to affect the library behavior. By default, libraries provide the new functionality, and they only alter it (that is, they provide the previous functionality) if the switch is set. This allows libraries to provide new behavior for an existing API while continuing to support callers who depend on the previous behavior.

### Define the switch name

The most common way to allow consumers of your library to opt out of a change of behavior is to define a named switch. Its `value` element is a name/value pair that consists of the name of a switch and its <xref:System.Boolean> value. By default, the switch is always implicitly `false`, which provides the new behavior (and makes the new behavior opt-in by default). Setting the switch to `true` enables it, which provides the legacy behavior. Explicitly setting the switch to `false` also provides the new behavior.

It's beneficial to use a consistent format for switch names, since they're a formal contract exposed by a library. The following are two obvious formats:

- *Switch*.*namespace*.*switchname*
- *Switch*.*library*.*switchname*

Once you define and document the switch, callers can use it by calling the <xref:System.AppContext.SetSwitch%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> method programmatically. .NET Framework apps can also use the switch by adding an [\<AppContextSwitchOverrides>](../../framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element to their application configuration file or by using the registry. For more information about how callers use and set the value of <xref:System.AppContext> configuration switches, see the [AppContext for library consumers](#appcontext-for-library-consumers) section.

In .NET Framework, when the common language runtime runs an application, it automatically reads the registry's compatibility settings and loads the application configuration file to populate the application's <xref:System.AppContext> instance. Because the <xref:System.AppContext> instance is populated either programmatically by the caller or by the runtime, .NET Framework apps don't have to take any action, such as calling the <xref:System.AppContext.SetSwitch%2A> method, to configure the <xref:System.AppContext> instance.

### Check the setting

You can check if a consumer has declared the value of the switch and act appropriately by calling the <xref:System.AppContext.TryGetSwitch%2A?displayProperty=nameWithType> method. The method returns `true` if the `switchName` argument is found, and its `isEnabled` argument indicates the value of the switch. Otherwise, the method returns `false`.

### Example

The following example illustrates the use of the <xref:System.AppContext> class to allow the customer to choose the original behavior of a library method. The following is version 1.0 of a library named `StringLibrary`. It defines a `SubstringStartsAt` method that performs an ordinal comparison to determine the starting index of a substring within a larger string.

:::code language="csharp" source="./snippets/System/AppContext/Overview/csharp/V1/Example4.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/AppContext/Overview/fsharp/Example4.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/AppContext/Overview/vb/V1/Example4.vb" id="Snippet4":::

The following example then uses the library to find the starting index of the substring "archæ" in "The archaeologist". Because the method performs an ordinal comparison, the substring cannot be found.

:::code language="csharp" source="./snippets/System/AppContext/Overview/csharp/V1/Example4.cs" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/AppContext/Overview/fsharp/Example4.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/AppContext/Overview/vb/V1/Example4.vb" id="Snippet5":::

Version 2.0 of the library, however, changes the `SubstringStartsAt` method to use culture-sensitive comparison.

:::code language="csharp" source="./snippets/System/AppContext/Overview/csharp/V2/Example6.cs" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/AppContext/Overview/fsharp/Example6.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/AppContext/Overview/vb/V2/Example6.vb" id="Snippet6":::

When the app is recompiled to run against the new version of the library, it now reports that the substring "archæ" is found at index 4 in "The archaeologist".

:::code language="csharp" source="./snippets/System/AppContext/Overview/csharp/V2/Example6.cs" id="Snippet7":::
:::code language="fsharp" source="./snippets/System/AppContext/Overview/fsharp/Example6.fs" id="Snippet7":::
:::code language="vb" source="./snippets/System/AppContext/Overview/vb/V2/Example6.vb" id="Snippet7":::

This change can be prevented from breaking the applications that depend on the original behavior by defining a switch. In this case, the switch is named `StringLibrary.DoNotUseCultureSensitiveComparison`. Its default value, `false`, indicates that the library should perform its version 2.0 culture-sensitive comparison. `true` indicates that the library should perform its version 1.0 ordinal comparison. A slight modification of the previous code allows the library consumer to set the switch to determine the kind of comparison the method performs.

:::code language="csharp" source="./snippets/System/AppContext/Overview/csharp/V3/Example8.cs" id="Snippet8":::
:::code language="fsharp" source="./snippets/System/AppContext/Overview/fsharp/Example8.fs" id="Snippet8":::
:::code language="vb" source="./snippets/System/AppContext/Overview/vb/V3/Example8.vb" id="Snippet8":::

A .NET Framework application can then use the following configuration file to restore the version 1.0 behavior.

```xml
<configuration>
   <runtime>
      <AppContextSwitchOverrides value="StringLibrary.DoNotUseCultureSensitiveComparison=true" />
   </runtime>
</configuration>
```

When the application is run with the configuration file present, it produces the following output:

```output
'archæ' not found in 'The archaeologist'
```

## AppContext for library consumers

If you're the consumer of a library, the <xref:System.AppContext> class allows you to take advantage of a library or library method's opt-out mechanism for new functionality. Individual methods of the class library that you are calling define particular switches that enable or disable a new behavior. The value of the switch is a Boolean. If it is `false`, which is typically the default value, the new behavior is enabled; if it is `true`, the new behavior is disabled, and the member behaves as it did previously.

You can set the value of a switch by calling the <xref:System.AppContext.SetSwitch%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> method in your code. The `switchName` argument defines the switch name, and the `isEnabled` property defines the value of the switch. Because <xref:System.AppContext> is a static class, it is available on a per-application domain basis. Calling the <xref:System.AppContext.SetSwitch%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> has application scope; that is, it affects only the application.

.NET Framework apps have additional ways to set the value of a switch:

- By adding an `<AppContextSwitchOverrides>` element to the [\<runtime>](../../framework/configure-apps/file-schema/runtime/runtime-element.md) section of the app.config file. The switch has a single attribute, `value`, whose value is a string that represents a key/value pair containing both the switch name and its value.

  To define multiple switches, separate each switch's key/value pair in the [\<AppContextSwitchOverrides>](../../framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) element's `value` attribute with a semicolon. In that case, the `<AppContextSwitchOverrides>` element has the following format:

  ```xml
  <AppContextSwitchOverrides value="switchName1=value1;switchName2=value2" />
  ```

  Using the `<AppContextSwitchOverrides>` element to define a configuration setting has application scope; that is, it affects only the application.

  > [!NOTE]
  > For information on the switches defined by .NET Framework, see [\<AppContextSwitchOverrides> element](../../framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md).

- By adding an entry to the registry. Add a new string value to the **HKLM\SOFTWARE\Microsoft\\.NETFramework\AppContext** subkey. Set the name of the entry to the name of the switch. Set its value to one of the following options: `True`, `true`, `False`, or `false`. If the runtime encounters any other value, it ignores the switch.

  On a 64-bit operating system, you must also add the same entry to the **HKLM\SOFTWARE\Wow6432Node\Microsoft\\.NETFramework\AppContext** subkey.

  Using the registry to define an <xref:System.AppContext> switch has machine scope; that is, it affects every application running on the machine.

For ASP.NET and ASP.NET Core applications, you set a switch by adding an [\<Add>](../../framework/configure-apps/file-schema/appsettings/add-element-for-appsettings.md) element to the [\<appSettings>](../../framework/configure-apps/file-schema/appsettings/index.md) section of the web.config file. For example:

```xml
<appSettings>
   <add key="AppContext.SetSwitch:switchName1" value="switchValue1" />
   <add key="AppContext.SetSwitch:switchName2" value="switchValue2" />
</appSettings>
```

If you set the same switch in more than one way, the order of precedence for determining which setting overrides the others is:

1. The programmatic setting.
2. The setting in the app.config file (for .NET Framework apps) or the web.config file (for ASP.NET Core apps).
3. The registry setting (for .NET Framework apps only).

## See also

- [AppContext switch](../../framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md)

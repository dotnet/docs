### MVC: JsonResult moved to Microsoft.AspNetCore.Mvc.Core

`JsonResult` has moved to the `Microsoft.AspNetCore.Mvc.Core` assembly. This type used to be defined in [Microsoft.AspNetCore.Mvc.Formatters.Json](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Formatters.Json). An assembly-level [[TypeForwardedTo]](xref:System.Runtime.CompilerServices.TypeForwardedToAttribute) attribute was added to `Microsoft.AspNetCore.Mvc.Formatters.Json` to address this issue for the majority of users. Apps that use third-party libraries may encounter issues.

#### Version introduced

3.0 Preview 6

#### Old behavior

An app using a 2.2-based library builds successfully.

#### New behavior

An app using a 2.2-based library fails compilation. An error containing a variation of the following text is provided:

```
The type 'JsonResult' exists in both 'Microsoft.AspNetCore.Mvc.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60' and 'Microsoft.AspNetCore.Mvc.Formatters.Json, Version=2.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60'
```

For an example of such an issue, see [dotnet/aspnetcore#7220](https://github.com/dotnet/aspnetcore/issues/7220).

#### Reason for change

Platform-level changes to the composition of ASP.NET Core as described at [aspnet/Announcements#325](https://github.com/aspnet/Announcements/issues/325).

#### Recommended action

Libraries compiled against the 2.2 version of `Microsoft.AspNetCore.Mvc.Formatters.Json` may need to recompile to address the problem for all consumers. If affected, contact the library author. Request recompilation of the library to target ASP.NET Core 3.0.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Mvc.JsonResult?displayProperty=nameWithType>

<!-- 

#### Affected APIs

`T:Microsoft.AspNetCore.Mvc.JsonResult`

-->

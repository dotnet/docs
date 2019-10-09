### Make "pubternal" types in MVC internal

In ASP.NET Core, "pubternal" types are declared as `public` but reside in a `.Internal`-suffixed namespace. While these types are `public`, they have no support policy and are subject to breaking changes. Unfortunately, accidental use of these types has been common, resulting in breaking changes to these projects and limiting our ability to maintain the framework.

In ASP.NET Core 3.0, we're updating all "pubternal" types in MVC to either be `public` in a supported namespace, or `internal` as appropriate.

#### Version introduced

3.0

#### Old behavior

Some types in MVC were `public` but in a `.Internal` namespace. These types had no support policy and were subject to breaking changes.

#### New behavior

All such types are updated either to be `public` in a supported namespace, or marked as `internal`.

#### Reason for change

Accidental use of the "pubternal" types has been common, resulting in breaking changes to these projects and limiting our ability to maintain the framework.

#### Recommended action

If you're using types that have become truly `public` and have been moved into a new, supported namespace, update your references to match the new namespaces.

If you're using types that have become marked as `internal`, you'll need to find an alternative. The previously "pubternal" types were never supported for public use. If there are specific types in these namespaces that are critical to your apps, file an issue at https://github.com/aspnet/AspNetCore. Considerations may be made for making the requested types `public`.

#### Category

ASP.NET Core

#### Affected APIs

This change includes types in the following namespaces:

- Microsoft.AspNetCore.Mvc.Formatters.Xml.Internal
- Microsoft.AspNetCore.Mvc.Cors.Internal
- Microsoft.AspNetCore.Mvc.ViewFeatures.Internal
- Microsoft.AspNetCore.Mvc.Formatters.Json.Internal
- Microsoft.AspNetCore.Mvc.RazorPages.Internal
- Microsoft.AspNetCore.Mvc.DataAnnotations.Internal
- Microsoft.AspNetCore.Mvc.TagHelpers.Internal
- Microsoft.AspNetCore.Mvc.Internal
- Microsoft.AspNetCore.Mvc.Razor.Internal
- Microsoft.AspNetCore.Mvc.Formatters.Internal
- Microsoft.AspNetCore.Mvc.Core.Internal
- Microsoft.AspNetCore.Mvc.ModelBinding.Internal

***

### Microsoft.AspNetCore.SpaServices and NodeServices no longer fallback to console logger by default

`Microsoft.AspNetCore.SpaServices` and `Microsoft.AspNetCore.NodeServices` won't display console logs unless logging is configured.

#### Version introduced

3.0

#### Old behavior

`Microsoft.AspNetCore.SpaServices` and `Microsoft.AspNetCore.NodeServices` used to automatically create a console logger when logging isn't configured. 

#### New behavior

`Microsoft.AspNetCore.SpaServices` and `Microsoft.AspNetCore.NodeServices` won't display console logs unless logging is configured.

#### Reason for change

There's a need to align with how other ASP.NET Core packages implement logging.

#### Recommended action

If the old behavior is required, to configure console logging, add `services.AddLogging(builder => builder.AddConsole())` to your `Setup.ConfigureServices` method.

#### Category

ASP.NET Core

#### Affected APIs

Not detectable via API analysis

### HTTP: Some cookie SameSite defaults changed to None

`SameSite` is an option for cookies that can help mitigate some Cross-Site Request Forgery (CSRF) attacks. When this option was initially introduced, inconsistent defaults were used across various ASP.NET Core APIs. The inconsistency has led to confusing results. As of ASP.NET Core 3.0, these defaults are better aligned. This is an opt-in feature on a per-component basis.

#### Version introduced

3.0

#### Old behavior

APIs defaulted to `SameSiteMode.Lax`.

#### New behavior

APIs default to `SameSiteMode.None`.

#### Reason for change

The default value was changed to make `SameSite` an opt-in feature.

#### Recommended action

Each component that emits cookies needs to decide if `SameSite` is appropriate for its scenarios. Review your usage of the affected APIs and reconfigure `SameSite` as needed.

#### Category

ASP.NET Core

#### Affected APIs

- <xref:Microsoft.AspNetCore.Http.IResponseCookies.Append(System.String,System.String,Microsoft.AspNetCore.Http.CookieOptions)?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.Builder.CookiePolicyOptions.MinimumSameSitePolicy%2A?displayProperty=nameWithType>

<!--

#### Affected APIs

- `M:Microsoft.AspNetCore.Http.IResponseCookies.Append(System.String,System.String,Microsoft.AspNetCore.Http.CookieOptions)`
- `Overload:Microsoft.AspNetCore.Builder.CookiePolicyOptions.MinimumSameSitePolicy`

-->
 
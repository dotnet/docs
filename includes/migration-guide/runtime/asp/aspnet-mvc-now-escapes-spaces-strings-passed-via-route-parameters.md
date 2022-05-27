### ASP.NET MVC now escapes spaces in strings passed in via route parameters

#### Details

In order to conform to RFC 2396, spaces in route paths are now escaped when populating action parameters from a route. So, whereas  `/controller/action/some data` would previously match the route `/controller/action/{data}` and provide `some data` as the data parameter, it will now provide `some%20data` instead.

#### Suggestion

Code should be updated to unescape string parameters from a route. If the original URI is needed, it can be accessed with the <xref:System.Net.HttpWebRequest.RequestUri>.OriginalString API.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.5.2|
|Type|Runtime|

#### Affected APIs

- <xref:System.Web.Mvc.RouteAttribute.%23ctor(System.String)>

<!--

#### Affected APIs

- `M:System.Web.Mvc.RouteAttribute.#ctor(System.String)`

-->

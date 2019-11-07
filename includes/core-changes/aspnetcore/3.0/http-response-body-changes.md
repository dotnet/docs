### HTTP: Response body infrastructure changes

The infrastructure backing an HTTP response body has changed. If you're using `HttpResponse` directly, you shouldn't need to make any code changes. Read further if you're wrapping or replacing `HttpResponse.Body` or accessing `HttpContext.Features`.

#### Version introduced

3.0

#### Old behavior

There were three APIs associated with the HTTP response body:

- `IHttpResponseFeature.Body`
- `IHttpSendFileFeature.SendFileAsync`
- `IHttpBufferingFeature.DisableResponseBuffering`

#### New behavior

If you replace `HttpResponse.Body`, it replaces the entire `IHttpResponseBodyFeature` with a wrapper around your given stream using `StreamResponseBodyFeature` to provide default implementations for all of the expected APIs. Setting back the original stream reverts this change.

#### Reason for change

The motivation is to combine the response body APIs into a single new feature interface.

#### Recommended action

Use `IHttpResponseBodyFeature` where you previously were using `IHttpResponseFeature.Body`,
`IHttpSendFileFeature`, or `IHttpBufferingFeature`.

#### Category

ASP.NET Core

#### Affected APIs

- <xref:Microsoft.AspNetCore.Http.Features.IHttpBufferingFeature?displayProperty=nameWithType>
- <xref:Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Body?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature?displayProperty=nameWithType>

<!-- 

#### Affected APIs

- `T:Microsoft.AspNetCore.Http.Features.IHttpBufferingFeature`
- `P:Microsoft.AspNetCore.Http.Features.IHttpResponseFeature.Body`
- `T:Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature`

-->

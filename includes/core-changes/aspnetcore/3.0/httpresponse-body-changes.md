### HttpResponse body infrastructure changes

The infrastructure backing an HTTP response body has changed. If you're using `HttpResponse` directly, you shouldn't need to make any code changes. Read further if you're wrapping or replacing `HttpResponse.Body` or accessing `HttpContext.Features`.

#### Version introduced

3.0

#### Old behavior

There were three APIs associated with the response body:

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

- [IHttpResponseFeature.Body](/dotnet/api/microsoft.aspnetcore.http.features.ihttpresponsefeature.body?view=aspnetcore-2.2#Microsoft_AspNetCore_Http_Features_IHttpResponseFeature_Body)
- [IHttpSendFileFeature](/dotnet/api/microsoft.aspnetcore.http.features.ihttpsendfilefeature?view=aspnetcore-2.2)
- [IHttpBufferingFeature](/dotnet/api/microsoft.aspnetcore.http.features.ihttpbufferingfeature?view=aspnetcore-2.2)

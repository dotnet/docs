### Kestrel request trailer headers moved to new collection

In prior versions, Kestrel added HTTP/1.1 chunked trailer headers into the request headers collection when the request body was read to the end. This behavior caused concerns about ambiguity between headers and trailers. The decision was made to move the trailers to a new collection.

HTTP/2 request trailers were unavailable in ASP.NET Core 2.2, but are now also available in this new collection in ASP.NET Core 3.0.

New request extension methods have been added to access these trailers.

HTTP/1.1 trailers are available once the entire request body has been read.

HTTP/2 trailers are available once they're received from the client. The client won't send the trailers until the entire request body has been at least buffered by the server. You may need to read the request body to free up buffer space. Trailers are always available if you read the request body to the end. The trailers mark the end of the body.

#### Version introduced

3.0

#### Old behavior

Request trailer headers would be added to the `HttpRequest.Headers` collection.

#### New behavior

Request trailer headers **aren't present** in the `HttpRequest.Headers` collection. Use the following extension methods on `HttpRequest` to access them:

- `GetDeclaredTrailers()` - Gets the request "Trailer" header that lists which trailers to expect after the body.
- `SupportsTrailers()` - Indicates if the request supports receiving trailer headers.
- `CheckTrailersAvailable()` - Determines if the request supports trailers and if they're available for reading.
- `GetTrailer(string trailerName)` - Gets the requested trailing header from the response.

#### Reason for change

Trailers are a key feature in scenarios like gRPC. Merging the trailers in to request headers was confusing to users.

#### Recommended action

Use the trailer-related extension methods on `HttpRequest` to access trailers.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Http.HttpRequest.Headers?displayProperty=nameWithType>

<!--

#### Affected APIs

`P:Microsoft.AspNetCore.Http.HttpRequest.Headers`

-->

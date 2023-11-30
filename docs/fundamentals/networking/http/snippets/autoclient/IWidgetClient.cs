using Microsoft.Extensions.Http.AutoClient;

[AutoClient(
    httpClientName: "GeneratedClient",
    customDependencyName: "Widget Service")]
public interface IWidgetClient
{
}

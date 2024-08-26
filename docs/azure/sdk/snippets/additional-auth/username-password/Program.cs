using Azure.Identity;
using Azure.Storage.Blobs;

var clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
var username = Environment.GetEnvironmentVariable("AZURE_USERNAME");
var password = Environment.GetEnvironmentVariable("AZURE_PASSWORD");

var client = new BlobServiceClient(
    new Uri("https://<storage-account-name>.blob.core.windows.net"),
    new UsernamePasswordCredential(username, password, tenantId, clientId));

foreach (var blobItem in client.GetBlobContainers())
{
    Console.WriteLine(blobItem.Name);
}
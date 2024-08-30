using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

string clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID")!;
string tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID")!;
string username = Environment.GetEnvironmentVariable("AZURE_USERNAME")!;
string password = Environment.GetEnvironmentVariable("AZURE_PASSWORD")!;

BlobServiceClient client = new(
    new Uri("https://<storage-account-name>.blob.core.windows.net"),
    new UsernamePasswordCredential(username, password, tenantId, clientId));

foreach (BlobContainerItem blobItem in client.GetBlobContainers())
{
    Console.WriteLine(blobItem.Name);
}

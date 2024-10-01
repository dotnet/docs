using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Storage.Blobs;

namespace InteractiveBrokeredAuthSample
{
    public partial class InteractiveBrokeredAuth : Form
    {
        public InteractiveBrokeredAuth()
        {
            InitializeComponent();
        }

        private void testInteractiveBrokeredAuth_Click(object sender, EventArgs e)
        {
            // Get the handle of the current window
            IntPtr windowHandle = this.Handle;

            var credential = new InteractiveBrowserCredential(
                new InteractiveBrowserCredentialBrokerOptions(windowHandle));

            // To authenticate and authorize with an Entra ID app registration, substitute the
            // <app_id> and <tenant_id> placeholders with the values for your app and tenant.
            // var credential = new InteractiveBrowserCredential(
            //    new InteractiveBrowserCredentialBrokerOptions(windowHandle)
            //        { 
            //            TenantId = "your-tenant-id",
            //            ClientId = "your-client-id"
            //        }
            // );

            var client = new BlobServiceClient(
                new Uri("https://<storage-account-name>.blob.core.windows.net/"),
                credential
            );

            // Prompt for credentials appears on first use of the client
            foreach (var container in client.GetBlobContainers())
            {
                Console.WriteLine(container.Name);
            }
        }
    }
}

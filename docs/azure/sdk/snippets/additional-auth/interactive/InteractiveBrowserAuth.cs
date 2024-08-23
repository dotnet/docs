using Azure.Identity;
using Azure.Storage.Blobs;

namespace InteractiveBrokeredAuthSample
{
    public partial class InteractiveBrowserAuth : Form
    {
        public InteractiveBrowserAuth()
        {
            InitializeComponent();
        }

        private void testInteractiveBrowserAuth_Click(object sender, EventArgs e)
        {
            var client = new BlobServiceClient(
                new Uri("https://<storage-account-name>.blob.core.windows.net"),
                new InteractiveBrowserCredential());

            foreach (var blobItem in client.GetBlobContainers())
            {
                Console.WriteLine(blobItem.Name);
            }
        }
    }
}

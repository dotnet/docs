using System.Windows;
using System.Windows.Interop;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;

namespace PublicClientAppAuthBestPractices;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    #region snippet_credential_reuse_nonAspNetCore
    private void testBrokeredAuth_Click(object sender, RoutedEventArgs e)
    {
        IntPtr windowHandle = new WindowInteropHelper(this).Handle;
        InteractiveBrowserCredential credential = new(
            new InteractiveBrowserCredentialBrokerOptions(windowHandle)
            {
                UseDefaultBrokerAccount = true,
            });

        BlobServiceClient blobServiceClient = new(
            new Uri("<blob-storage-url>"),
            credential);

        SecretClient secretClient = new(
            new Uri("<key-vault-url>"),
            credential);
    }
    #endregion snippet_credential_reuse_nonAspNetCore
}

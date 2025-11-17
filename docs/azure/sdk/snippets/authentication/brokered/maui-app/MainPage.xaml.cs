using Azure;
using Azure.Identity;
using Azure.Identity.Broker;
using Azure.Security.KeyVault.Secrets;
using System.Diagnostics;

#if MACCATALYST
using Foundation;
using UIKit;
#endif

namespace SecretVaultApp;

public partial class MainPage : ContentPage
{
    private const string KeyVaultUrl = "https://<your-key-vault-name>.vault.azure.net/";
    private const string SecretName = "MySecret";

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnRetrieveSecretClicked(object? sender, EventArgs e)
    {
        // Show loading indicator and hide previous results
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;
        ResultLabel.IsVisible = false;
        ErrorLabel.IsVisible = false;
        RetrieveSecretBtn.IsEnabled = false;

        try
        {
#if WINDOWS
            #region snippet_brokered_windows
            // Get the parent window handle for MAUI on Windows
            Microsoft.Maui.Controls.Window? parentWindow = this.GetParentWindow();
            Microsoft.UI.Xaml.Window? windowHandle = parentWindow?.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
            IntPtr hwnd = windowHandle != null ? WinRT.Interop.WindowNative.GetWindowHandle(windowHandle) : IntPtr.Zero;

            // Configure InteractiveBrowserCredentialBrokerOptions with parent window reference
            InteractiveBrowserCredentialBrokerOptions options = new(hwnd)
            {
                UseDefaultBrokerAccount = true,
            };

            // Create credential that will use WAM broker on Windows
            InteractiveBrowserCredential credential = new(options);

            SecretClient client = new(new Uri(KeyVaultUrl), credential);
            KeyVaultSecret secret = await client.GetSecretAsync(SecretName);
            #endregion
#elif MACCATALYST
            #region snippet_brokered_macos
            // Get the parent window handle for MAUI on Mac Catalyst
            Microsoft.Maui.Controls.Window? parentWindow = this.GetParentWindow();
            UIWindow? uiWindow = parentWindow?.Handler?.PlatformView as UIWindow;
            IntPtr hwnd = uiWindow != null ? uiWindow.Handle : IntPtr.Zero;

            // Configure InteractiveBrowserCredentialBrokerOptions with parent window reference
            InteractiveBrowserCredentialBrokerOptions options = new(hwnd)
            {
                UseDefaultBrokerAccount = true,
            };

            // Create credential that will use the broker on macOS
            InteractiveBrowserCredential credential = new(options);

            SecretClient client = new(new Uri(KeyVaultUrl), credential);
            KeyVaultSecret secret = await client.GetSecretAsync(SecretName);
            #endregion
#else
            // For non-Windows and non-macOS platforms, use standard interactive browser credential
            InteractiveBrowserCredential credential = new();

            SecretClient client = new(new Uri(KeyVaultUrl), credential);
            KeyVaultSecret secret = await client.GetSecretAsync(SecretName);
#endif

            // Display the secret value (in production, be careful about displaying secrets)
            ResultLabel.Text = $"✅ Secret '{SecretName}' retrieved successfully!\n" +
                              $"🔑 Value: {secret.Value}\n" +
                              $"📅 Created: {secret.Properties.CreatedOn:yyyy-MM-dd HH:mm:ss}";
            ResultLabel.IsVisible = true;

            Debug.WriteLine($"Successfully retrieved secret: {SecretName}");
        }
        catch (RequestFailedException ex)
        {
            string errorMessage = ex.Status switch
            {
                401 => "❌ Authentication failed. Please ensure you're signed in to Azure and have the correct permissions.",
                403 => "🚫 Access denied. Please check your Azure Key Vault access policies.",
                404 => $"🔍 Secret '{SecretName}' not found in the Key Vault. Please verify the secret name and Key Vault URL.",
                _ => $"⚠️ Azure Key Vault error ({ex.Status}): {ex.Message}"
            };

            ErrorLabel.Text = errorMessage;
            ErrorLabel.IsVisible = true;
            Debug.WriteLine($"RequestFailedException: Status={ex.Status}, Message={ex.Message}");
        }
        catch (AuthenticationFailedException ex)
        {
            ErrorLabel.Text = $"🔐 Authentication failed: {ex.Message}\n\nPlease ensure you're signed in to Azure and try again.";
            ErrorLabel.IsVisible = true;
            Debug.WriteLine($"AuthenticationFailedException: {ex.Message}");
        }
        catch (UriFormatException)
        {
            ErrorLabel.Text = "🌐 Invalid Key Vault URL. Please update the KeyVaultUrl in the code with your actual Key Vault URL.";
            ErrorLabel.IsVisible = true;
            Debug.WriteLine("Invalid KeyVaultUrl format");
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = $"💥 An unexpected error occurred: {ex.Message}";
            ErrorLabel.IsVisible = true;
            Debug.WriteLine($"Unexpected Exception: {ex.GetType().Name} - {ex.Message}");
        }
        finally
        {
            // Hide loading indicator and re-enable button
            LoadingIndicator.IsVisible = false;
            LoadingIndicator.IsRunning = false;
            RetrieveSecretBtn.IsEnabled = true;
        }
    }
}

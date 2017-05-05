// <snippetClientCredentials>   
using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Security;
using NorthwindClient.Northwind;
using System.Data.Services.Client;

namespace NorthwindClient
{
    public partial class ClientCredentials : Window
    {
        // Create the binding collections and the data service context.
        private DataServiceCollection<Customer> binding;
        NorthwindEntities context;
        CollectionViewSource customerAddressViewSource;

        // Instantiate the service URI and credentials.
        Uri serviceUri = new Uri("http://localhost:12345/Northwind.svc/");
        NetworkCredential credentials = new NetworkCredential();

        public ClientCredentials()
        {
            InitializeComponent();
        }

        private void ClientCredentials_Loaded(object sender, RoutedEventArgs e)
        {
            string userName = string.Empty;
            string domain = string.Empty;
            SecureString password = new SecureString();

            // Get credentials for authentication.
            LoginWindow login = new LoginWindow();
            login.ShowDialog();

            if (login.DialogResult == true 
                && login.userNameBox.Text != string.Empty
                && login.passwordBox.SecurePassword.Length != 0)
            { 
                // Instantiate the context.
                context =
                    new NorthwindEntities(serviceUri);

                // Get the user name and domain from the login.
                string[] qualifiedUserName = login.userNameBox.Text.Split(new char[] { '\\' });
                if (qualifiedUserName.Length == 2)
                {
                    domain = qualifiedUserName[0];
                    userName = qualifiedUserName[1];
                }
                else
                {
                    userName = login.userNameBox.Text;
                }
                password = login.passwordBox.SecurePassword;

                // Set the client authentication credentials.
                context.Credentials =
                    new NetworkCredential(userName, password, domain);


                // Define an anonymous LINQ query that returns a collection of Customer types.
                var query = from c in context.Customers
                            where c.Country == "Germany"
                            select c;

                try
                {
                    // Instantiate the binding collection, which executes the query.
                    binding = new DataServiceCollection<Customer>(query);

                    while (binding.Continuation != null)
                    {
                        // Continue to execute the query until all pages are loaded.
                        binding.Load(context.Execute<Customer>(binding.Continuation.NextLinkUri));
                    }

                    // Assign the binding collection to the CollectionViewSource.
                    customerAddressViewSource =
                        (CollectionViewSource)this.Resources["customerViewSource"];
                    customerAddressViewSource.Source = binding;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (login.DialogResult == false)
            {
                MessageBox.Show("Login cancelled.");
            }
        }
    }
}
// </snippetClientCredentials>
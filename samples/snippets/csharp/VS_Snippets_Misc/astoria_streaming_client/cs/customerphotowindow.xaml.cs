using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NorthwindStreamingClient.Northwind;
using System.Data.Services.Client;
using System.IO;

namespace NorthwindStreamingClient
{
    /// <summary>
    /// Interaction logic for CustomerPhotoWindow.xaml
    /// </summary>
    public partial class CustomerPhotoWindow : Window
    {
        private NorthwindEntities context;
        private DataServiceCollection<Employees> trackedEmployees;
        private Employees currentEmployee;

        // Ideally, the service URI should be stored in the settings file.
        private Uri svcUri =
            new Uri("http://" + Environment.MachineName +
                "/NorthwindStreaming/NorthwindStreaming.svc");

        public CustomerPhotoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Instantiate the data service context.
            context = new NorthwindEntities(svcUri);

            try
            {
                // Create a new collection for binding based on the LINQ query.
                trackedEmployees = new DataServiceCollection<Employees>(context.Employees);

                // Load all pages of the response at once.
                while (trackedEmployees.Continuation != null)
                {
                    trackedEmployees.Load(
                        context.Execute<Employees>(trackedEmployees.Continuation.NextLinkUri));
                }

                // Bind the root StackPanel element to the collection;
                // related object binding paths are defined in the XAML.
                LayoutRoot.DataContext = trackedEmployees;

                if (trackedEmployees.Count == 0)
                {
                    MessageBox.Show("Data could not be returned from the data service.");
                }

                // Select the first employee in the collection.
                employeesComboBox.SelectedIndex = 0;
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void employeesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the currently selected employee.
            currentEmployee =
                (Employees)this.employeesComboBox.SelectedItem;

            try
            {
                //<snippetGetReadStreamClient>
                // Get the read stream for the Media Resource of the currently selected
                // entity (Media Link Entry).
                using (DataServiceStreamResponse response =
                    context.GetReadStream(currentEmployee, "image/bmp"))
                {
                    // Use the returned binary stream to create a bitmap image that is
                    // the source of the image control.
                    employeeImage.Source = CreateBitmapFromStream(response.Stream);
                }
                //</snippetGetReadStreamClient>

                //<snippetGetReadStreamClientUri>
                // Get the read stream URI for the Media Resource of the currently selected
                // entity (Media Link Entry), and use it to create a bitmap image that is
                // the source of the image control.
                employeeImage.Source = new BitmapImage(context.GetReadStreamUri(currentEmployee));
                //</snippetGetReadStreamClientUri>
            }
            catch (DataServiceRequestException ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void setImage_Click(object sender, RoutedEventArgs e)
        {
            // Create a dialog to select the bitmap to stream to the data service.
            Microsoft.Win32.OpenFileDialog openImage = new Microsoft.Win32.OpenFileDialog();
            openImage.FileName = "image";
            openImage.DefaultExt = ".bmp";
            openImage.Filter = "Bitmap images (.bmp)|*.bmp";
            openImage.Title = "Select the image file to upload...";

            try
            {
                if (openImage.ShowDialog(this) == true)
                {
                    //<snippetSetSaveStreamClient>
                    // Use the FileStream to open an existing image file.
                    FileStream imageStream =
                        new FileStream(openImage.FileName, FileMode.Open);

                    // Set the file stream as the source of binary stream
                    // to send to the data service. Allow the context to
                    // close the filestream.
                    context.SetSaveStream(currentEmployee,
                        imageStream, true, "image/bmp",
                        string.Empty);

                    // Upload the binary stream to the data service.
                    context.SaveChanges();
                    //</snippetSetSaveStreamClient>

                    imageStream =
                        new FileStream(openImage.FileName, FileMode.Open);

                    employeeImage.Source = CreateBitmapFromStream(imageStream);
                }
            }
            catch (DataServiceRequestException ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private BitmapImage CreateBitmapFromStream(Stream stream)
        {
            try
            {
                // Create a new bitmap image using the memory stream.
                BitmapImage imageFromStream = new BitmapImage();
                imageFromStream.BeginInit();
                imageFromStream.StreamSource = stream;
                imageFromStream.CacheOption = BitmapCacheOption.OnLoad;
                imageFromStream.EndInit();

                // Return the bitmap.
                return imageFromStream;
            }
            catch (Exception)
            {
                MessageBox.Show("The file cannot be read; "
                + "make sure that it is a valid .bmp file.");
                return null;
            }
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

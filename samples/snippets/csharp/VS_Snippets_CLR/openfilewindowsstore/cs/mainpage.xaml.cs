//<snippetCode>
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using System.Text;
using Windows.Storage.Pickers;
using Windows.UI.Popups; 

namespace OpenFileWindowsStore
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Create a file picker to open a file. Most file access in Windows Store Apps
        // requires the use of a file picker for security purposes.
        FileOpenPicker picker = new FileOpenPicker();
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
         
           // Set properties on the file picker such as start location and the type 
            // of files to display.
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add(".txt");

            // Show picker enabling user to pick one file.
            StorageFile result = await picker.PickSingleFileAsync();

            if (result != null)
            {
                try
                {
                    // Use FileIO to replace the content of the text file
                    await FileIO.WriteTextAsync(result, UserInputTextBox.Text);

                    // Display a success message
                    StatusTextBox.Text = "Status: File saved successfully";
                }
                catch (Exception ex)
                {
                    // Display an error message
                    StatusTextBox.Text = "Status: error saving the file - " + ex.Message;
                }
            }
            else
                StatusTextBox.Text = "Status: User cancelled save operation";
        }
    }
}
//</snippetCode>
 



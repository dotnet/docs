//*********************************************************
//
//    Copyright (c) Microsoft. All rights reserved.
//    This code is licensed under the Microsoft Public License.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************
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

using PhotoData;
using System.Data.Services.Client;
using System.IO;
using System.Xml.Linq;

namespace PhotoStreamingClient
{
    /// <summary>
    /// Interaction logic for PhotoWindow.xaml
    /// </summary>
    public partial class PhotoWindow : Window
    {
        private PhotoDataContainer context;
        private DataServiceCollection<PhotoInfo> trackedPhotos;
        private PhotoInfo currentPhoto;

        // Get the service URI from the settings file.
        private Uri svcUri =
            new Uri(Properties.Settings.Default.svcUri);

        public PhotoWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Instantiate the data service context.
            context = new PhotoDataContainer(svcUri);

            // Call the method to get photos from the data service.
            GetPhotosFromService(MergeOption.AppendOnly);
        }

        private void GetPhotosFromService(MergeOption mergeOption)
        {
            // Set the merge option.
            context.MergeOption = mergeOption;

            try
            {
                // Define a query that returns a feed with all PhotoInfo objects.
                var query = context.PhotoInfo;

                // Create a new collection for binding based on the executed query.
                trackedPhotos = new DataServiceCollection<PhotoInfo>(query);

                // Load all pages of the response into the binding collection.
                while (trackedPhotos.Continuation != null)
                {
                    trackedPhotos.Load(
                        context.Execute<PhotoInfo>(trackedPhotos.Continuation.NextLinkUri));
                }

                // Bind the root StackPanel element to the collection;
                // related object binding paths are defined in the XAML.
                LayoutRoot.DataContext = trackedPhotos;

                if (trackedPhotos.Count == 0)
                {
                    MessageBox.Show("Data could not be returned from the data service.");
                }

                // Select the first photo in the collection.
                photoComboBox.SelectedIndex = 0;

                // Enable the buttons.
                photoDetails.IsEnabled = true;
                addPhoto.IsEnabled = true;
                deletePhoto.IsEnabled = true;
            }
            catch (DataServiceQueryException ex)
            {
                string errorMessage = string.Empty;

                // Get the response from the request.
                QueryOperationResponse response = ex.Response;

                // If we have a 404, the URI may be incorrect.
                if (response.StatusCode == 404)
                {
                    errorMessage = string.Format("Make sure that the service URI '{0}' is correct.",
                        svcUri.ToString());
                }
                else
                {
                    // Get the error message from the response.
                    errorMessage = response.Error.Message;
                }

                // Display the message.
                MessageBox.Show(errorMessage,
                    string.Format("Error Status Code: {0}", response.StatusCode));
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Reset the merge option to the default.
                context.MergeOption = MergeOption.AppendOnly;
            }
        }
        private void photoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getCurrentPhoto();
        }

        private void getCurrentPhoto()
        {
            // Get the currently selected photo.
            currentPhoto =
                (PhotoInfo)this.photoComboBox.SelectedItem;

            // Get the image for the selected PhotoData not an added one.
            if (currentPhoto != null && currentPhoto.PhotoId != 0)
            {
                try
                {
                    //<snippetGetReadStreamUri>
                    // Use the ReadStreamUri of the Media Resource for selected PhotoInfo object
                    // as the URI source of a new bitmap image.
                    photoImage.Source = new BitmapImage(context.GetReadStreamUri(currentPhoto));
                    //</snippetGetReadStreamUri>
                }
                catch (DataServiceClientException ex)
                {
                    XElement error = XElement.Parse(ex.Message);

                    // Display the error messages.
                    MessageBox.Show(error.Value,
                        string.Format("Error Status Code: {0}", ex.StatusCode));
                }
            }
        }

        private void addPhoto_Click(object sender, RoutedEventArgs e)
        {
            // Create a new PhotoInfo object.
            PhotoInfo newPhotoEntity = new PhotoInfo();

            // Ceate an new PhotoDetailsWindow instance with the current 
            // context and the new photo entity.
            PhotoDetailsWindow addPhotoWindow =
                new PhotoDetailsWindow(newPhotoEntity, context);

            addPhotoWindow.Title = "Select a new photo to upload...";

            // We need to have the new entity tracked to be able to 
            // call DataServiceContext.SetSaveStream.
            trackedPhotos.Add(newPhotoEntity);

            // If we successfully created the new image, then display it.
            if (addPhotoWindow.ShowDialog() == true)
            {
                // Set the index to the new photo.
                photoComboBox.SelectedItem = newPhotoEntity;
            }
            else
            {
                // Remove the new entity since the add operation failed.
                trackedPhotos.Remove(newPhotoEntity);
            }
        }

        private void photoDetails_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected photo.
            currentPhoto = photoComboBox.SelectedItem as PhotoInfo;

            // Create an instance of the photo details window.
            PhotoDetailsWindow photoDetailsWindow =
                new PhotoDetailsWindow(currentPhoto, context);

            photoDetailsWindow.Title =
                string.Format("Details {0}:", currentPhoto.FileName);

            // Display the dialog.
            if (photoDetailsWindow.ShowDialog() == true)
            {
                // Request the image file again in case it was changed.
                // We might have also used a client-side copy of the image to avoid
                // this GET request to the data service.
                getCurrentPhoto();
            }
        }

        private void deletePhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the currently selected photo.
                PhotoInfo currentPhoto = (PhotoInfo)photoComboBox.SelectedItem;

                if (MessageBox.Show("Are you sure you want to delete this photo from the service?"
                    , "Delete Photo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    int currentIndex = photoComboBox.SelectedIndex;

                    // Delete the currently selected photo entity from the binding collection.
                    trackedPhotos.Remove(currentPhoto);

                    // Send the DELETE request to the data service.
                    context.SaveChanges();

                    // Move the index to the previous photo.
                    photoComboBox.SelectedIndex = currentIndex == 0 ? 0 : currentIndex - 1;
                }
            }
            catch (DataServiceRequestException)
            {
                // The delete failed; we should ask the user to refresh images from the data service.
                if (MessageBox.Show("The image may have already been deleted.\n" +
                    "Refresh images from the data service?", "Error on Delete",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // Refresh images from the data service using overwrite changes.
                    GetPhotosFromService(MergeOption.OverwriteChanges);
                }
                else
                {
                    // Warn the user about possible other errors.
                    MessageBox.Show("If other errors occur, click Refresh Photos.");
                }
            }
        }

        private void refreshPhotosButton_Click(object sender, RoutedEventArgs e)
        {
            // Refresh the list of photos from the data service.
            GetPhotosFromService(MergeOption.OverwriteChanges);
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

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
using System.Windows.Shapes;

using PhotoData;
using System.Data.Services.Client;
using System.IO;

namespace PhotoStreamingClient
{
    /// <summary>
    /// Interaction logic for PhotoDetailsWindow.xaml
    /// </summary>
    public partial class PhotoDetailsWindow : Window
    {
        private PhotoInfo photoEntity;
        private DataServiceContext context;
        private FileStream imageStream;
        private MergeOption cachedMergeOption;

        public PhotoDetailsWindow(PhotoInfo photo, DataServiceContext context)
        {
            InitializeComponent();

            this.photoEntity = photo;
            this.context = context;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Display the OpenImage dialog if we are adding a new photo.
            if (photoEntity.PhotoId == 0)
            {
                if (!SelectPhotoToSend())
                {
                    // Close the add photo window if a photo cannot be selected.
                    this.Close();
                }
            }

            // Set the binding source of the root WPF object to the new entity.
            LayoutRoot.DataContext = photoEntity;
        }

        private void setPhoto_Click(object sender, RoutedEventArgs e)
        {
            // Select a photo from the local computer.
            SelectPhotoToSend();
        }

        private bool SelectPhotoToSend()
        {
            // Create a dialog to select the image file to stream to the data service.
            Microsoft.Win32.OpenFileDialog openImage = new Microsoft.Win32.OpenFileDialog();
            openImage.FileName = "image";
            openImage.DefaultExt = ".*";
            openImage.Filter = "Images File|*.jpg;*.png;*.gif;*.bmp";
            openImage.Title = "Select the image file to upload...";
            openImage.Multiselect = false;
            openImage.CheckFileExists = true;

            // Reset the image stream.
            imageStream = null;

            try
            {
                if (openImage.ShowDialog(this) == true)
                {
                    if (photoEntity.PhotoId == 0)
                    {
                        // Set the image name from the selected file.
                        photoEntity.FileName = openImage.SafeFileName;

                        photoEntity.DateAdded = DateTime.Today;

                        // Set the content type and the file name for the slug header.
                        photoEntity.ContentType =
                            GetContentTypeFromFileName(photoEntity.FileName);
                    }

                    photoEntity.DateModified = DateTime.Today;

                    // Use a FileStream to open the existing image file.
                    imageStream = new FileStream(openImage.FileName, FileMode.Open);

                    photoEntity.FileSize = (int)imageStream.Length;

                    // Create a new image using the memory stream.
                    BitmapImage imageFromStream = new BitmapImage();
                    imageFromStream.BeginInit();
                    imageFromStream.StreamSource = imageStream;
                    imageFromStream.CacheOption = BitmapCacheOption.OnLoad;
                    imageFromStream.EndInit();

                    // Set the height and width of the image.
                    photoEntity.Dimensions.Height = (short?)imageFromStream.PixelHeight;
                    photoEntity.Dimensions.Width = (short?)imageFromStream.PixelWidth;

                    // Reset to the beginning of the stream before we pass it to the service.
                    imageStream.Position = 0;

                    //<snippetSetSaveStream>
                    // Set the file stream as the source of binary stream
                    // to send to the data service. The Slug header is the file name and
                    // the content type is determined from the file extension.
                    // A value of 'true' means that the stream is closed by the client when
                    // the upload is complete.
                    context.SetSaveStream(photoEntity, imageStream, true,
                        photoEntity.ContentType, photoEntity.FileName);
                    //</snippetSetSaveStream>

                    return true;
                }
                else
                {
                    MessageBox.Show("The selected file could not be opened.");
                    return false;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    string.Format("The selected image file could not be opened. {0}",
                    ex.Message), "Operation Failed");

                return false;
            }
        }
        private void savePhotoDetails_Click(object sender, RoutedEventArgs e)
        {
            EntityDescriptor entity = null;

            try
            {
                if (string.IsNullOrEmpty(photoEntity.FileName))
                {
                    MessageBox.Show("You must first select an image file to upload.");
                    return;
                }

                // Send the update (POST or MERGE) request to the data service and
                // capture the added or updated entity in the response.
                ChangeOperationResponse response =
                    context.SaveChanges().FirstOrDefault() as ChangeOperationResponse;

                // When we issue a POST request, the photo ID and edit-media link are not updated
                // on the client (a bug), so we need to get the server values.
                if (photoEntity.PhotoId == 0)
                {
                    if (response != null)
                    {
                        entity = response.Descriptor as EntityDescriptor;
                    }

                    // Verify that the entity was created correctly.
                    if (entity != null && entity.EditLink != null)
                    {
                        // Cache the current merge option (we reset to the cached
                        // value in the finally block).
                        cachedMergeOption = context.MergeOption;

                        // Set the merge option so that server changes win.
                        context.MergeOption = MergeOption.OverwriteChanges;

                        // Get the updated entity from the service.
                        // Note: we need Count() just to execute the query.
                        context.Execute<PhotoInfo>(entity.EditLink).Count();
                    }
                }

                this.DialogResult = true;
                this.Close();
            }
            catch (DataServiceRequestException ex)
            {
                // Get the change operation result.
                ChangeOperationResponse response =
                    ex.Response.FirstOrDefault() as ChangeOperationResponse;

                string errorMessage = string.Empty;

                // Check for a resource not found error.
                if (response != null && response.StatusCode == 404)
                {
                    // Tell the user to refresh the photos from the data service.
                    errorMessage = "The selected image may have been removed from the data service.\n"
                    + "Click the Refresh Photos button to refresh photos from the service.";
                }
                else
                {
                    // Just provide the general error message.
                    errorMessage = string.Format("The photo data could not be updated or saved. {0}",
                        ex.Message);
                }

                // Show the messsage box.
                MessageBox.Show(errorMessage, "Operation Failed");

                // Return false since we could not add or update the photo.
                this.DialogResult = false;
                return;
            }
            finally
            {
                // Reset to the cached merge option.
                context.MergeOption = cachedMergeOption;
            }
        }
        private static string GetContentTypeFromFileName(string fileName)
        {
            // Get the file extension from the FileName property.
            string[] splitFileName = fileName.Split(new Char[] { '.' });

            // Return the Content-Type value based on the file extension.
            switch (splitFileName[splitFileName.Length - 1])
            {
                case "jpeg":
                    return "image/jpeg";
                case "jpg":
                    return "image/jpeg";
                case "gif":
                    return "image/gif";
                case "png":
                    return "image/png";
                case "tiff":
                    return "image/tiff";
                case "bmp":
                    return "image/bmp";
                default:
                    return "application/octet-stream";
            }
        }

        private void cancelDetails_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("If you cancel without saving you will lose any changes.", "Close this dialog?",
                 MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                this.DialogResult = false;
                this.Close();
            }
        }
    }
}
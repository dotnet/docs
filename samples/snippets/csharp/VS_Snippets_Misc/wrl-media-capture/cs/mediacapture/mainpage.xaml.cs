// <snippet8>
using System;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace MediaCapture
{
    public sealed partial class MainPage : Page
    {
        // Captures photos from the webcam.
        private Windows.Media.Capture.MediaCapture mediaCapture;

        // Used to display status messages.
        private Brush statusBrush = new SolidColorBrush(Colors.Green);
        // Used to display error messages.
        private Brush exceptionBrush = new SolidColorBrush(Colors.Red);

        public MainPage()
        {
            this.InitializeComponent();
        }

        // Shows a status message.
        private void ShowStatusMessage(string text)
        {
            StatusBlock.Foreground = statusBrush;
            StatusBlock.Text = text;
        }

        // Shows an error message.
        private void ShowExceptionMessage(Exception ex)
        {
            StatusBlock.Foreground = exceptionBrush;
            StatusBlock.Text = ex.Message;
        }

        // Click event handler for the "Start Device" button.
        private async void StartDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StartDevice.IsEnabled = false;

                // Enumerate webcams.
                ShowStatusMessage("Enumerating webcams...");
                var devInfoCollection = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
                if (devInfoCollection.Count == 0)
                {
                    ShowStatusMessage("No webcams found");
                    return;
                }

                // Initialize the MediaCapture object, choosing the first found webcam.
                mediaCapture = new Windows.Media.Capture.MediaCapture();
                var settings = new Windows.Media.Capture.MediaCaptureInitializationSettings();
                settings.VideoDeviceId = devInfoCollection[0].Id;
                await mediaCapture.InitializeAsync(settings);

                // We can now take photos and enable the grayscale effect.
                TakePhoto.IsEnabled = true;
                AddRemoveEffect.IsEnabled = true;

                ShowStatusMessage("Device initialized successfully");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        // Takes a photo from the webcam and displays it.
        private async void TakePhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShowStatusMessage("Taking photo...");
                TakePhoto.IsEnabled = false;

                // Capture the photo to an in-memory stream.
                var photoStream = new InMemoryRandomAccessStream();
                await mediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), photoStream);
                ShowStatusMessage("Create photo file successful");

                // Display the photo.
                var bmpimg = new BitmapImage();
                photoStream.Seek(0);
                await bmpimg.SetSourceAsync(photoStream);
                CapturedImage.Source = bmpimg;

                TakePhoto.IsEnabled = true;
                ShowStatusMessage("Photo taken");
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
                TakePhoto.IsEnabled = true;
            }
        }

        // Enables the grayscale effect.
        private async void AddRemoveEffect_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                AddRemoveEffect.IsEnabled = false;
                await mediaCapture.AddEffectAsync(MediaStreamType.Photo, "GrayscaleTransform.GrayscaleEffect", null);
                ShowStatusMessage("Add effect to video preview successful");
                AddRemoveEffect.IsEnabled = true;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        // Removes the grayscale effect.
        private async void AddRemoveEffect_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                AddRemoveEffect.IsEnabled = false;
                await mediaCapture.ClearEffectsAsync(Windows.Media.Capture.MediaStreamType.Photo);
                ShowStatusMessage("Remove effect from preview successful");
                AddRemoveEffect.IsEnabled = true;
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
    }
}
// </snippet8>
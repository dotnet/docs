//<SnippetThreadingWeatherCodeBehind>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace SDKSamples
{
    public partial class Window1 : Window
    {
        // Delegates to be used in placking jobs onto the Dispatcher.
        private delegate void NoArgDelegate();
        //<SnippetThreadingWeatherDelegates>
        private delegate void OneArgDelegate(String arg);
        //</SnippetThreadingWeatherDelegates>

        // Storyboards for the animations.
        private Storyboard showClockFaceStoryboard;
        private Storyboard hideClockFaceStoryboard;
        private Storyboard showWeatherImageStoryboard;
        private Storyboard hideWeatherImageStoryboard;

        public Window1(): base()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load the storyboard resources.
            showClockFaceStoryboard =
                (Storyboard)this.Resources["ShowClockFaceStoryboard"];
            hideClockFaceStoryboard =
                (Storyboard)this.Resources["HideClockFaceStoryboard"];
            showWeatherImageStoryboard =
                (Storyboard)this.Resources["ShowWeatherImageStoryboard"];
            hideWeatherImageStoryboard =
                (Storyboard)this.Resources["HideWeatherImageStoryboard"];
        }

        //<SnippetThreadingWeatherButtonHandler>
        private void ForecastButtonHandler(object sender, RoutedEventArgs e)
        {
            // Change the status image and start the rotation animation.
            fetchButton.IsEnabled = false;
            fetchButton.Content = "Contacting Server";
            weatherText.Text = "";
            hideWeatherImageStoryboard.Begin(this);

            // Start fetching the weather forecast asynchronously.
            NoArgDelegate fetcher = new NoArgDelegate(
                this.FetchWeatherFromServer);

            fetcher.BeginInvoke(null, null);
        }
        //</SnippetThreadingWeatherButtonHandler>

        //<SnippetThreadingWeatherFetchWeather>
        private void FetchWeatherFromServer()
        {
            // Simulate the delay from network access.
            Thread.Sleep(4000);

            // Tried and true method for weather forecasting - random numbers.
            Random rand = new Random();
            String weather;

            if (rand.Next(2) == 0)
            {
                weather = "rainy";
            }
            else
            {
                weather = "sunny";
            }

            //<SnippetThreadingWeatherDispatcherOneArge>
            // Schedule the update function in the UI thread.
            tomorrowsWeather.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Normal,
                new OneArgDelegate(UpdateUserInterface),
                weather);
            //</SnippetThreadingWeatherDispatcherOneArge>
        }
        //</SnippetThreadingWeatherFetchWeather>

        //<SnippetThreadingWeatherUpdateUI>
        private void UpdateUserInterface(String weather)
        {
            //Set the weather image
            if (weather == "sunny")
            {
                weatherIndicatorImage.Source = (ImageSource)this.Resources[
                    "SunnyImageSource"];
            }
            else if (weather == "rainy")
            {
                weatherIndicatorImage.Source = (ImageSource)this.Resources[
                    "RainingImageSource"];
            }

            //Stop clock animation
            showClockFaceStoryboard.Stop(this);
            hideClockFaceStoryboard.Begin(this);

            //Update UI text
            fetchButton.IsEnabled = true;
            fetchButton.Content = "Fetch Forecast";
            weatherText.Text = weather;
        }
        //</SnippetThreadingWeatherUpdateUI>

        private void HideClockFaceStoryboard_Completed(object sender,
            EventArgs args)
        {
            showWeatherImageStoryboard.Begin(this);
        }

        private void HideWeatherImageStoryboard_Completed(object sender,
            EventArgs args)
        {
            showClockFaceStoryboard.Begin(this, true);
        }
    }
}
//</SnippetThreadingWeatherCodeBehind>

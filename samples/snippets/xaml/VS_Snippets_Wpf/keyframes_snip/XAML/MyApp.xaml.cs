using System;
using System.Windows;
using System.Windows.Media;

namespace Microsoft.Samples.KeyFrameExamples
{
    /// <summary>
    /// Interaction logic for Application.xaml
    /// </summary>

    public partial class MyApp : Application
    {
        void AppStartingUp(object sender, StartupEventArgs e)
        {

            SampleViewer mainWindow = new SampleViewer();
            mainWindow.Show();
        }
    }
}
using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using System.Xml;

namespace Microsoft.Samples.Graphics
{

    public partial class app : Application
    {

        private void myAppStartingUp(object sender, StartupEventArgs args)
        {
            Window mySampleWindow = new SampleViewer();
            mySampleWindow.Show();
        }
    }
}

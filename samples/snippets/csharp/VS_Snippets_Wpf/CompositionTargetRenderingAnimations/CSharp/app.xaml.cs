using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.IO;

namespace Microsoft.Samples.PerFrameAnimations
{

    // Displays the sample.
    public partial class app : Application
    {

        public app()
        {
            
        }


        protected override void OnStartup(StartupEventArgs e)
        {
           
            Window w = new Window();
            w.Content = new SampleViewer();
            w.Show();
            
            base.OnStartup(e);
        }




    }

}
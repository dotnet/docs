using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPCrossThreadSolutionCS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void threadExampleBtn_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = String.Empty;

            textBox1.Text = "Simulating work on UI thread.\n";
            DoSomeWork(20);
            textBox1.Text += "Work completed...\n";

            textBox1.Text += "Simulating work on non-UI thread.\n";
            await Task.Run(() => DoSomeWork(1000));
            textBox1.Text += "Work completed..\n";
        }

        // <Snippet4>
        private async void DoSomeWork(int milliseconds)
        {
            // Simulate work.
            await Task.Delay(milliseconds);

            // Report completion.
            bool uiAccess = textBox1.Dispatcher.HasThreadAccess;
            String msg = String.Format("Some work completed in {0} ms. on {1}UI thread\n",
                                       milliseconds, uiAccess ? String.Empty : "non-");
            if (uiAccess)
                textBox1.Text += msg;
            else
                await textBox1.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { textBox1.Text += msg; });
        }
        // </Snippet4>
    }
}

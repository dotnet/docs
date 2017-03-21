using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Timers;
using System.Security.Permissions;


namespace DispatcherSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        int count = 0;
        int ticks = 0;
        DispatcherFrame frame;

        System.Timers.Timer timer = new System.Timers.Timer();
        public Window1()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            txtDisplay.TextWrapping = TextWrapping.Wrap;
            timer.Interval = 1000;
            timer.Elapsed +=new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
          //  timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ticks++;
            //txtDisplay.Text += " $tick$ ";
            txtDisplay.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new DispatcherOperationCallback(tickers), null);

            if (ticks > 20)
            {
                frame.Continue = false;
                timer.Enabled = false;
            }
        }

        public object tickers(object o)
        {
            txtDisplay.Text += " $tick$ " ;
            return null;
        }

        private void btn4(object sender, RoutedEventArgs e)
        {
         //   Window dialog = new Window();
          ///  dialog.ShowDialog();


        }

        //<SnippetDispatcherDispatcherFrameDoEvents>
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }

        public object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;
           
            return null;
        }
        //</SnippetDispatcherDispatcherFrameDoEvents>

        private void DisableProcessing(object sender, RoutedEventArgs e)
        {
            //<SnippetDispatcherDisableProcessing>
            // The Dispose() method is called at the end of the using statement.
            // Calling Dispose on the DispatcherProcessingDisabled structure, 
            // which is returned from the call to DisableProcessing, will
            // re-enalbe Dispatcher processing.
            using (Dispatcher.DisableProcessing())
            {
                // Do work while the dispatcher processing is disabled.
                Thread.Sleep(2000);
            }
            //</SnippetDispatcherDisableProcessing>
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            lblDisplay.Content = "Executing";
            DoEvents();
            Thread.Sleep(2000);

            lblDisplay.Content = "Finished";
        }

        private void btn3(object sender, RoutedEventArgs e)
        {
            lblDisplay.Content = "Stage_1";

            for (int x = 0; x < 100; x++)
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new DispatcherOperationCallback(DoWork), x);
            }
            DoEvents();
            Thread.Sleep(2000);

            lblDisplay.Content += "  Statge_2"; 
        }

        public object DoWork(object para)
        {
            if ((int)para % 10 == 0)
            {
                txtDisplay.Text += "\n";
            }
            txtDisplay.Text += ((int)para).ToString();

            return null;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void DoEvents2()
        {
            DispatcherFrame frame = new DispatcherFrame();

            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Send,
                new DispatcherOperationCallback(ExitFrames), frame);

            Dispatcher.PushFrame(frame);
        }





        public void UpdateLabel()
        {
          //  DoEvents2();
            txtDisplay.Text += " *** ";
        }

        public object ExitFrames(object f)
        {
            count++;

            DispatcherFrame frame = f as DispatcherFrame;


            Thread.Sleep(2000);
            if (count < 5)
            {
                UpdateLabel();
            }
            else
            {
               // frame.Continue = false;
            }



            return null;
        }
    }
}
// <snippet100>
// MainWindow.xaml.cs
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace Shell_TaskbarItemSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            // Set up the BackgroundWorker.
            this._backgroundWorker.WorkerReportsProgress = true;
            this._backgroundWorker.WorkerSupportsCancellation = true;
            this._backgroundWorker.DoWork += new DoWorkEventHandler(bw_DoWork);
            this._backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            this._backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void StartCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
        
        // <snippet110>
        private void StartCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (this._backgroundWorker.IsBusy == false)
            {
                this._backgroundWorker.RunWorkerAsync();
                // When the task is started, change the ProgressState and Overlay
                // of the taskbar item to indicate an active task.
                this.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.Normal;
                this.taskBarItemInfo1.Overlay = (DrawingImage)this.FindResource("PlayImage");
            }
            e.Handled = true;
        }
        // </snippet110>

        private void StopCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this._backgroundWorker.WorkerSupportsCancellation;
            e.Handled = true;
        }

        private void StopCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this._backgroundWorker.CancelAsync();
            e.Handled = true;
        }

        // <snippet120>
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // When the task ends, change the ProgressState and Overlay
            // of the taskbar item to indicate a stopped task.
            if (e.Cancelled == true)
            {
                // The task was stopped by the user. Show the progress indicator
                // in the paused state.
                this.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.Paused;
            }
            else if (e.Error != null)
            {
                // The task ended with an error. Show the progress indicator
                // in the error state.
                this.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.Error;
            }
            else
            {
                // The task completed normally. Remove the progress indicator.
                this.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.None;
            }
            // In all cases, show the 'Stopped' overlay.
            // <snippet121>
            this.taskBarItemInfo1.Overlay = (DrawingImage)this.FindResource("StopImage");
            // </snippet121>
        }
        // </snippet120>

        // <snippet130>
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbCount.Text = e.ProgressPercentage.ToString();
            // Update the value of the task bar progress indicator.
            this.taskBarItemInfo1.ProgressValue = (double)e.ProgressPercentage / 100;
        }
        // </snippet130>

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {        
            BackgroundWorker _worker = sender as BackgroundWorker;
            if (_worker != null)
            {
                for (int i = 1; i <= 100; i++)
                {
                    if (_worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(25);
                        _worker.ReportProgress(i);
                    }
                }
            }
        }
    
    }   
}
// </snippet100>

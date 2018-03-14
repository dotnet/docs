using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;



namespace SDKSamples
{
    public partial class Window1 : Window
    {   
        // Delegate used to push a worker itme onto the Dispatcher.
        private delegate void UpdateUIDelegate(Button button);

        public Window1()
        {
            InitializeComponent();

            // Get the ID of the UI thread for display purposes.
            _uiThreadID = this.Dispatcher.Thread.ManagedThreadId;
            lblUIThreadID.Content = _uiThreadID;
        }

        //<SnippetDispatcherAccessCheckAccess>
        // Uses the Dispatcher.CheckAccess method to determine if 
        // the calling thread has access to the thread the UI object is on.
        private void TryToUpdateButtonCheckAccess(object uiObject)
        {
            Button theButton = uiObject as Button;

            if (theButton != null)
            {
                // Checking if this thread has access to the object.
                if (theButton.Dispatcher.CheckAccess())
                {
                    // This thread has access so it can update the UI thread.
                    UpdateButtonUI(theButton);
                }
                else
                {
                    // This thread does not have access to the UI thread.
                    // Place the update method on the Dispatcher of the UI thread.
                    theButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        new UpdateUIDelegate(UpdateButtonUI), theButton);
                }
            }
        }
        //</SnippetDispatcherAccessCheckAccess>

        //<SnippetDispatcherAccessVerifyAccess>
        // Uses the Dispatcher.VerifyAccess method to determine if 
        // the calling thread has access to the thread the UI object is on.
        private void TryToUpdateButtonVerifyAccess(object uiObject)
        {
            Button theButton = uiObject as Button;

            if (theButton != null)
            {
                try
                {   
                    // Check if this thread has access to this object.
                    theButton.Dispatcher.VerifyAccess();

                    // The thread has access to the object, so update the UI.
                    UpdateButtonUI(theButton);
                }

                // Cannot access objects on the thread.
                catch (InvalidOperationException e)
                {
                    // Exception Error Message.
                    MessageBox.Show("Exception ToString: \n\n" + e.ToString(), 
                        "Execption Caught! Thrown During AccessVerify().");

                    MessageBox.Show("Pushing job onto UI Thread Dispatcher");

                    // Placing job onto the Dispatcher of the UI Thread.
                    theButton.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        new UpdateUIDelegate(UpdateButtonUI), theButton);
                }
            }
        }
        //</SnippetDispatcherAccessVerifyAccess>


        private void threadStartingCheckAccess()
        {
            // Try to update a Button created on the UI thread.
            TryToUpdateButtonCheckAccess(ButtonOnUIThread);   
        }

        private void threadStartingVerifyAccess()
        {
            // Try to update a Button created on the UI thread.
            TryToUpdateButtonVerifyAccess(ButtonOnUIThread);
        }

        private void CreateThread(object sender, RoutedEventArgs e)
        {
            ThreadStart threadStartingPoint;

            // Determine which ThreadStart to use.
            if (rbCheckAccess.IsChecked == true)
            {
                threadStartingPoint = new ThreadStart(threadStartingCheckAccess);
            }
            else
            {
                threadStartingPoint = new ThreadStart(threadStartingVerifyAccess);
            }

            // Create and start a new thread.
            Thread backgroundThread = new Thread(threadStartingPoint);
            backgroundThread.SetApartmentState(ApartmentState.STA);
            backgroundThread.Start();

            // Update thread information for display purposes.
            _backgroundThreadID = backgroundThread.ManagedThreadId;
            lblBackgroundThreadID.Content = _backgroundThreadID.ToString();
        }


        private void UpdateButtonUI(Button theButton)
        {
            // Update the Button content with the current time.
            theButton.Content = DateTime.Now.TimeOfDay;
        }

        private int _uiThreadID;
        private int _backgroundThreadID;
    }
}
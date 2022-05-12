// <snippet10>
// <snippet11>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
// </snippet11>

namespace AsyncPattern
{
    // This form tests the PrimeNumberCalculator component.
    public class PrimeNumberCalculatorMain : System.Windows.Forms.Form
	{
        /////////////////////////////////////////////////////////////
		// Private fields
        //
        #region Private fields

        private PrimeNumberCalculator primeNumberCalculator1;
        private System.Windows.Forms.GroupBox taskGroupBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader taskIdColHeader;
        private System.Windows.Forms.ColumnHeader progressColHeader;
        private System.Windows.Forms.ColumnHeader currentColHeader;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button startAsyncButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColumnHeader testNumberColHeader;
        private System.Windows.Forms.ColumnHeader resultColHeader;
        private System.Windows.Forms.ColumnHeader firstDivisorColHeader;
        private System.ComponentModel.IContainer components;
        private int progressCounter;
        private int progressInterval = 100;

        #endregion // Private fields

        /////////////////////////////////////////////////////////////
        // Construction and destruction
        //
        #region Private fields
		public PrimeNumberCalculatorMain ()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            // Hook up event handlers.
            this.primeNumberCalculator1.CalculatePrimeCompleted +=
                new CalculatePrimeCompletedEventHandler(
                primeNumberCalculator1_CalculatePrimeCompleted);

            this.primeNumberCalculator1.ProgressChanged +=
                new ProgressChangedEventHandler(
                primeNumberCalculator1_ProgressChanged);

            this.listView1.SelectedIndexChanged +=
                new EventHandler(listView1_SelectedIndexChanged);
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        #endregion // Construction and destruction

        /////////////////////////////////////////////////////////////
        //
        #region Implementation

        // This event handler selects a number randomly to test
        // for primality. It then starts the asynchronous
        // calculation by calling the PrimeNumberCalculator
        // component's CalculatePrimeAsync method.
        private void startAsyncButton_Click (
            System.Object sender, System.EventArgs e)
        {
            // Randomly choose test numbers
            // up to 200,000 for primality.
            Random rand = new Random();
            int testNumber = rand.Next(200000);

            // Task IDs are Guids.
            Guid taskId = Guid.NewGuid();
            this.AddListViewItem(taskId, testNumber);

            // Start the asynchronous task.
            this.primeNumberCalculator1.CalculatePrimeAsync(
                testNumber,
                taskId);
        }

        private void listView1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            this.cancelButton.Enabled = CanCancel();
        }

        // This event handler cancels all pending tasks that are
        // selected in the ListView control.
        private void cancelButton_Click(
            System.Object sender,
            System.EventArgs e)
        {
            Guid taskId = Guid.Empty;

            // Cancel all selected tasks.
            foreach(ListViewItem lvi in this.listView1.SelectedItems)
            {
                // Tasks that have been completed or canceled have
                // their corresponding ListViewItem.Tag property
                // set to null.
                if (lvi.Tag != null)
                {
                    taskId = (Guid)lvi.Tag;
                    this.primeNumberCalculator1.CancelAsync(taskId);
                    lvi.Selected = false;
                }
            }

            cancelButton.Enabled = false;
        }

        // <snippet40>
        // This event handler updates the ListView control when the
        // PrimeNumberCalculator raises the ProgressChanged event.
        //
        // On fast computers, the PrimeNumberCalculator can raise many
        // successive ProgressChanged events, so the user interface
        // may be flooded with messages. To prevent the user interface
        // from hanging, progress is only reported at intervals.
        private void primeNumberCalculator1_ProgressChanged(
            ProgressChangedEventArgs e)
        {
            if (this.progressCounter++ % this.progressInterval == 0)
            {
                Guid taskId = (Guid)e.UserState;

                if (e is CalculatePrimeProgressChangedEventArgs)
                {
                    CalculatePrimeProgressChangedEventArgs cppcea =
                        e as CalculatePrimeProgressChangedEventArgs;

                    this.UpdateListViewItem(
                        taskId,
                        cppcea.ProgressPercentage,
                        cppcea.LatestPrimeNumber);
                }
                else
                {
                    this.UpdateListViewItem(
                        taskId,
                        e.ProgressPercentage);
                }
            }
            else if (this.progressCounter > this.progressInterval)
            {
                this.progressCounter = 0;
            }
        }
        // </snippet40>

        // <snippet12>
        // This event handler updates the ListView control when the
        // PrimeNumberCalculator raises the CalculatePrimeCompleted
        // event. The ListView item is updated with the appropriate
        // outcome of the calculation: Canceled, Error, or result.
        private void primeNumberCalculator1_CalculatePrimeCompleted(
            object sender,
            CalculatePrimeCompletedEventArgs e)
        {
            Guid taskId = (Guid)e.UserState;

            if (e.Cancelled)
            {
                string result = "Canceled";

                ListViewItem lvi = UpdateListViewItem(taskId, result);

                if (lvi != null)
                {
                    lvi.BackColor = Color.Pink;
                    lvi.Tag = null;
                }
            }
            else if (e.Error != null)
            {
                string result = "Error";

                ListViewItem lvi = UpdateListViewItem(taskId, result);

                if (lvi != null)
                {
                    lvi.BackColor = Color.Red;
                    lvi.ForeColor = Color.White;
                    lvi.Tag = null;
                }
            }
            else
            {
                bool result = e.IsPrime;

                ListViewItem lvi = UpdateListViewItem(
                    taskId,
                    result,
                    e.FirstDivisor);

                if (lvi != null)
                {
                    lvi.BackColor = Color.LightGray;
                    lvi.Tag = null;
                }
            }
        }
        // </snippet12>

        #endregion // Implementation

        /////////////////////////////////////////////////////////////
        //
        #region Private Methods

        private ListViewItem AddListViewItem(
            Guid guid,
            int testNumber )
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = testNumber.ToString(
                CultureInfo.CurrentCulture.NumberFormat);

            lvi.SubItems.Add("Not Started");
            lvi.SubItems.Add("1");
            lvi.SubItems.Add(guid.ToString());
            lvi.SubItems.Add("---");
            lvi.SubItems.Add("---");
            lvi.Tag = guid;

            this.listView1.Items.Add( lvi );

            return lvi;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            int percentComplete,
            int current )
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[1].Text =
                            percentComplete.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lvi.SubItems[2].Text =
                            current.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            int percentComplete,
            int current,
            bool result,
            int firstDivisor )
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if ((Guid)lvi.Tag == guid)
                {
                    lvi.SubItems[1].Text =
                        percentComplete.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lvi.SubItems[2].Text =
                        current.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);
                    lvi.SubItems[4].Text =
                        result ? "Prime" : "Composite";
                    lvi.SubItems[5].Text =
                        firstDivisor.ToString(
                        CultureInfo.CurrentCulture.NumberFormat);

                    lviRet = lvi;

                    break;
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            int percentComplete )
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[1].Text =
                            percentComplete.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            bool result,
            int firstDivisor )
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[4].Text =
                            result ? "Prime" : "Composite";
                        lvi.SubItems[5].Text =
                            firstDivisor.ToString(
                            CultureInfo.CurrentCulture.NumberFormat);
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private ListViewItem UpdateListViewItem(
            Guid guid,
            string result)
        {
            ListViewItem lviRet = null;

            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Tag != null)
                {
                    if ((Guid)lvi.Tag == guid)
                    {
                        lvi.SubItems[4].Text = result;
                        lviRet = lvi;
                        break;
                    }
                }
            }

            return lviRet;
        }

        private bool CanCancel()
        {
            bool oneIsActive = false;

            foreach(ListViewItem lvi in this.listView1.SelectedItems)
            {
                if (lvi.Tag != null)
                {
                    oneIsActive = true;
                    break;
                }
            }

            return( oneIsActive == true );
        }

        #endregion

		#region Windows Form Designer generated code
		
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.taskGroupBox = new System.Windows.Forms.GroupBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.startAsyncButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.testNumberColHeader = new System.Windows.Forms.ColumnHeader();
            this.progressColHeader = new System.Windows.Forms.ColumnHeader();
            this.currentColHeader = new System.Windows.Forms.ColumnHeader();
            this.taskIdColHeader = new System.Windows.Forms.ColumnHeader();
            this.resultColHeader = new System.Windows.Forms.ColumnHeader();
            this.firstDivisorColHeader = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.primeNumberCalculator1 = new AsyncPattern.PrimeNumberCalculator(this.components);
            this.taskGroupBox.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // taskGroupBox
            //
            this.taskGroupBox.Controls.Add(this.buttonPanel);
            this.taskGroupBox.Controls.Add(this.listView1);
            this.taskGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskGroupBox.Location = new System.Drawing.Point(0, 0);
            this.taskGroupBox.Name = "taskGroupBox";
            this.taskGroupBox.Size = new System.Drawing.Size(608, 254);
            this.taskGroupBox.TabIndex = 1;
            this.taskGroupBox.TabStop = false;
            this.taskGroupBox.Text = "Tasks";
            //
            // buttonPanel
            //
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.startAsyncButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(3, 176);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(602, 75);
            this.buttonPanel.TabIndex = 1;
            //
            // cancelButton
            //
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(128, 24);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            //
            // startAsyncButton
            //
            this.startAsyncButton.Location = new System.Drawing.Point(24, 24);
            this.startAsyncButton.Name = "startAsyncButton";
            this.startAsyncButton.Size = new System.Drawing.Size(88, 23);
            this.startAsyncButton.TabIndex = 0;
            this.startAsyncButton.Text = "Start New Task";
            this.startAsyncButton.Click += new System.EventHandler(this.startAsyncButton_Click);
            //
            // listView1
            //
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.testNumberColHeader,
                this.progressColHeader,
                this.currentColHeader,
                this.taskIdColHeader,
                this.resultColHeader,
                this.firstDivisorColHeader});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(602, 160);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            //
            // testNumberColHeader
            //
            this.testNumberColHeader.Text = "Test Number";
            this.testNumberColHeader.Width = 80;
            //
            // progressColHeader
            //
            this.progressColHeader.Text = "Progress";
            //
            // currentColHeader
            //
            this.currentColHeader.Text = "Current";
            //
            // taskIdColHeader
            //
            this.taskIdColHeader.Text = "Task ID";
            this.taskIdColHeader.Width = 200;
            //
            // resultColHeader
            //
            this.resultColHeader.Text = "Result";
            this.resultColHeader.Width = 80;
            //
            // firstDivisorColHeader
            //
            this.firstDivisorColHeader.Text = "First Divisor";
            this.firstDivisorColHeader.Width = 80;
            //
            // panel2
            //
            this.panel2.Location = new System.Drawing.Point(200, 128);
            this.panel2.Name = "panel2";
            this.panel2.TabIndex = 2;
            //
            // PrimeNumberCalculatorMain
            //
            this.ClientSize = new System.Drawing.Size(608, 254);
            this.Controls.Add(this.taskGroupBox);
            this.Name = "PrimeNumberCalculatorMain";
            this.Text = "Prime Number Calculator";
            this.taskGroupBox.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
		#endregion

    }

    // <snippet30>

    /////////////////////////////////////////////////////////////
    #region PrimeNumberCalculator Implementation

    // <snippet7>
    public delegate void ProgressChangedEventHandler(
        ProgressChangedEventArgs e);

    public delegate void CalculatePrimeCompletedEventHandler(
        object sender,
        CalculatePrimeCompletedEventArgs e);
    // </snippet7>

    // This class implements the Event-based Asynchronous Pattern.
    // It asynchronously computes whether a number is prime or
    // composite (not prime).
    public class PrimeNumberCalculator : Component
    {
        // <snippet22>
        private delegate void WorkerEventHandler(
            int numberToCheck,
            AsyncOperation asyncOp);
        // </snippet22>

        // <snippet9>
        private SendOrPostCallback onProgressReportDelegate;
        private SendOrPostCallback onCompletedDelegate;
        // </snippet9>

        // <snippet23>
        private HybridDictionary userStateToLifetime =
            new HybridDictionary();
        // </snippet23>

        private System.ComponentModel.Container components = null;

        /////////////////////////////////////////////////////////////
        #region Public events

        // <snippet8>
        public event ProgressChangedEventHandler ProgressChanged;
        public event CalculatePrimeCompletedEventHandler CalculatePrimeCompleted;
        // </snippet8>

        #endregion

        /////////////////////////////////////////////////////////////
        #region Construction and destruction

        public PrimeNumberCalculator(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            InitializeDelegates();
        }

        // <snippet21>
        public PrimeNumberCalculator()
        {
            InitializeComponent();

            InitializeDelegates();
        }
        // </snippet21>

        // <snippet20>
        protected virtual void InitializeDelegates()
        {
            onProgressReportDelegate =
                new SendOrPostCallback(ReportProgress);
            onCompletedDelegate =
                new SendOrPostCallback(CalculateCompleted);
        }
        // </snippet20>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion // Construction and destruction

        /////////////////////////////////////////////////////////////
        ///
        #region Implementation

        // <snippet3>
        // This method starts an asynchronous calculation.
        // First, it checks the supplied task ID for uniqueness.
        // If taskId is unique, it creates a new WorkerEventHandler
        // and calls its BeginInvoke method to start the calculation.
        public virtual void CalculatePrimeAsync(
            int numberToTest,
            object taskId)
        {
            // Create an AsyncOperation for taskId.
            AsyncOperation asyncOp =
                AsyncOperationManager.CreateOperation(taskId);

            // Multiple threads will access the task dictionary,
            // so it must be locked to serialize access.
            lock (userStateToLifetime.SyncRoot)
            {
                if (userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException(
                        "Task ID parameter must be unique",
                        "taskId");
                }

                userStateToLifetime[taskId] = asyncOp;
            }

            // Start the asynchronous operation.
            WorkerEventHandler workerDelegate = new WorkerEventHandler(CalculateWorker);
            workerDelegate.BeginInvoke(
                numberToTest,
                asyncOp,
                null,
                null);
        }
        // </snippet3>

        // <snippet32>
        // Utility method for determining if a
        // task has been canceled.
        private bool TaskCanceled(object taskId)
        {
            return( userStateToLifetime[taskId] == null );
        }
        // </snippet32>

        // <snippet4>
        // This method cancels a pending asynchronous operation.
        public void CancelAsync(object taskId)
        {
            AsyncOperation asyncOp = userStateToLifetime[taskId] as AsyncOperation;
            if (asyncOp != null)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(taskId);
                }
            }
        }
        // </snippet4>

        // <snippet27>
        // This method performs the actual prime number computation.
        // It is executed on the worker thread.
        private void CalculateWorker(
            int numberToTest,
            AsyncOperation asyncOp)
        {
            bool isPrime = false;
            int firstDivisor = 1;
            Exception e = null;

            // Check that the task is still active.
            // The operation may have been canceled before
            // the thread was scheduled.
            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    // Find all the prime numbers up to
                    // the square root of numberToTest.
                    ArrayList primes = BuildPrimeNumberList(
                        numberToTest,
                        asyncOp);

                    // Now we have a list of primes less than
                    // numberToTest.
                    isPrime = IsPrime(
                        primes,
                        numberToTest,
                        out firstDivisor);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            //CalculatePrimeState calcState = new CalculatePrimeState(
            //        numberToTest,
            //        firstDivisor,
            //        isPrime,
            //        e,
            //        TaskCanceled(asyncOp.UserSuppliedState),
            //        asyncOp);

            //this.CompletionMethod(calcState);

            this.CompletionMethod(
                numberToTest,
                firstDivisor,
                isPrime,
                e,
                TaskCanceled(asyncOp.UserSuppliedState),
                asyncOp);

            //completionMethodDelegate(calcState);
        }
        // </snippet27>

        // <snippet5>
        // This method computes the list of prime numbers used by the
        // IsPrime method.
        private ArrayList BuildPrimeNumberList(
            int numberToTest,
            AsyncOperation asyncOp)
        {
            ProgressChangedEventArgs e = null;
            ArrayList primes = new ArrayList();
            int firstDivisor;
            int n = 5;

            // Add the first prime numbers.
            primes.Add(2);
            primes.Add(3);

            // Do the work.
            while (n < numberToTest &&
                   !TaskCanceled( asyncOp.UserSuppliedState ) )
            {
                if (IsPrime(primes, n, out firstDivisor))
                {
                    // Report to the client that a prime was found.
                    e = new CalculatePrimeProgressChangedEventArgs(
                        n,
                        (int)((float)n / (float)numberToTest * 100),
                        asyncOp.UserSuppliedState);

                    asyncOp.Post(this.onProgressReportDelegate, e);

                    primes.Add(n);

                    // Yield the rest of this time slice.
                    Thread.Sleep(0);
                }

                // Skip even numbers.
                n += 2;
            }

            return primes;
        }
        // </snippet5>

        // <snippet28>
        // This method tests n for primality against the list of
        // prime numbers contained in the primes parameter.
        private bool IsPrime(
            ArrayList primes,
            int n,
            out int firstDivisor)
        {
            bool foundDivisor = false;
            bool exceedsSquareRoot = false;

            int i = 0;
            int divisor = 0;
            firstDivisor = 1;

            // Stop the search if:
            // there are no more primes in the list,
            // there is a divisor of n in the list, or
            // there is a prime that is larger than
            // the square root of n.
            while (
                (i < primes.Count) &&
                !foundDivisor &&
                !exceedsSquareRoot)
            {
                // The divisor variable will be the smallest
                // prime number not yet tried.
                divisor = (int)primes[i++];

                // Determine whether the divisor is greater
                // than the square root of n.
                if (divisor * divisor > n)
                {
                    exceedsSquareRoot = true;
                }
                // Determine whether the divisor is a factor of n.
                else if (n % divisor == 0)
                {
                    firstDivisor = divisor;
                    foundDivisor = true;
                }
            }

            return !foundDivisor;
        }
        // </snippet28>

        // <snippet24>
        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void CalculateCompleted(object operationState)
        {
            CalculatePrimeCompletedEventArgs e =
                operationState as CalculatePrimeCompletedEventArgs;

            OnCalculatePrimeCompleted(e);
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void ReportProgress(object state)
        {
            ProgressChangedEventArgs e =
                state as ProgressChangedEventArgs;

            OnProgressChanged(e);
        }

        protected void OnCalculatePrimeCompleted(
            CalculatePrimeCompletedEventArgs e)
        {
            if (CalculatePrimeCompleted != null)
            {
                CalculatePrimeCompleted(this, e);
            }
        }

        protected void OnProgressChanged(ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(e);
            }
        }
        // </snippet24>

        // <snippet26>
        // This is the method that the underlying, free-threaded
        // asynchronous behavior will invoke.  This will happen on
        // an arbitrary thread.
        private void CompletionMethod(
            int numberToTest,
            int firstDivisor,
            bool isPrime,
            Exception exception,
            bool canceled,
            AsyncOperation asyncOp )

        {
            // If the task was not previously canceled,
            // remove the task from the lifetime collection.
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            // Package the results of the operation in a
            // CalculatePrimeCompletedEventArgs.
            CalculatePrimeCompletedEventArgs e =
                new CalculatePrimeCompletedEventArgs(
                numberToTest,
                firstDivisor,
                isPrime,
                exception,
                canceled,
                asyncOp.UserSuppliedState);

            // End the task. The asyncOp object is responsible
            // for marshaling the call.
            asyncOp.PostOperationCompleted(onCompletedDelegate, e);

            // Note that after the call to OperationCompleted,
            // asyncOp is no longer usable, and any attempt to use it
            // will cause an exception to be thrown.
        }
        // </snippet26>

        #endregion

        /////////////////////////////////////////////////////////////
        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

    }

    // <snippet29>
    public class CalculatePrimeProgressChangedEventArgs :
            ProgressChangedEventArgs
    {
        private int latestPrimeNumberValue = 1;

        public CalculatePrimeProgressChangedEventArgs(
            int latestPrime,
            int progressPercentage,
            object userToken) : base( progressPercentage, userToken )
        {
            this.latestPrimeNumberValue = latestPrime;
        }

        public int LatestPrimeNumber
        {
            get
            {
                return latestPrimeNumberValue;
            }
        }
    }
    // </snippet29>

    // <snippet6>
    public class CalculatePrimeCompletedEventArgs :
        AsyncCompletedEventArgs
    {
        private int numberToTestValue = 0;
        private int firstDivisorValue = 1;
        private bool isPrimeValue;

        public CalculatePrimeCompletedEventArgs(
            int numberToTest,
            int firstDivisor,
            bool isPrime,
            Exception e,
            bool canceled,
            object state) : base(e, canceled, state)
        {
            this.numberToTestValue = numberToTest;
            this.firstDivisorValue = firstDivisor;
            this.isPrimeValue = isPrime;
        }

        public int NumberToTest
        {
            get
            {
                // Raise an exception if the operation failed or
                // was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the
                // property value.
                return numberToTestValue;
            }
        }

        public int FirstDivisor
        {
            get
            {
                // Raise an exception if the operation failed or
                // was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the
                // property value.
                return firstDivisorValue;
            }
        }

        public bool IsPrime
        {
            get
            {
                // Raise an exception if the operation failed or
                // was canceled.
                RaiseExceptionIfNecessary();

                // If the operation was successful, return the
                // property value.
                return isPrimeValue;
            }
        }
    }

    // </snippet6>

    #endregion

    // </snippet30>
}
// </snippet10>

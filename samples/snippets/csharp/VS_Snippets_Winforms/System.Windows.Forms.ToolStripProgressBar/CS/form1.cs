// <Snippet1>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

class FibonacciNumber : Form
{
	[STAThread]
	static void Main()
	{
		Application.EnableVisualStyles();
		Application.Run(new FibonacciNumber());
	}

	private StatusStrip progressStatusStrip;
	private ToolStripProgressBar toolStripProgressBar;
	private NumericUpDown requestedCountControl;
	private Button goButton;
	private TextBox outputTextBox;
	private BackgroundWorker backgroundWorker;
	private ToolStripStatusLabel toolStripStatusLabel;
	private int requestedCount;

	public FibonacciNumber()
	{
		Text = "Fibonacci";
		
		// Prepare the StatusStrip.
		progressStatusStrip = new StatusStrip();
		toolStripProgressBar = new ToolStripProgressBar();
		toolStripProgressBar.Enabled = false;
		toolStripStatusLabel = new ToolStripStatusLabel();
		progressStatusStrip.Items.Add(toolStripProgressBar);
		progressStatusStrip.Items.Add(toolStripStatusLabel);

		FlowLayoutPanel flp = new FlowLayoutPanel();
		flp.Dock = DockStyle.Top;

		Label beforeLabel = new Label();
		beforeLabel.Text = "Calculate the first ";
		beforeLabel.AutoSize = true;
		flp.Controls.Add(beforeLabel);
                // <Snippet2>
		requestedCountControl = new NumericUpDown();
		requestedCountControl.Maximum = 1000;
		requestedCountControl.Minimum = 1;
		requestedCountControl.Value = 100;
		flp.Controls.Add(requestedCountControl);
                // </Snippet2>
		Label afterLabel = new Label();
		afterLabel.Text = "Numbers in the Fibonacci sequence.";
		afterLabel.AutoSize = true;
		flp.Controls.Add(afterLabel);
		
		goButton = new Button();
		goButton.Text = "&Go";
		goButton.Click += new System.EventHandler(button1_Click);
		flp.Controls.Add(goButton);

		outputTextBox = new TextBox();
		outputTextBox.Multiline = true;
		outputTextBox.ReadOnly = true;
		outputTextBox.ScrollBars = ScrollBars.Vertical;
		outputTextBox.Dock = DockStyle.Fill;

		Controls.Add(outputTextBox);
		Controls.Add(progressStatusStrip);
		Controls.Add(flp);

		backgroundWorker = new BackgroundWorker();
		backgroundWorker.WorkerReportsProgress = true;
		backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
		backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		
	}

    // <snippet10>
	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		// This method will run on a thread other than the UI thread.
		// Be sure not to manipulate any Windows Forms controls created
		// on the UI thread from this method.
		backgroundWorker.ReportProgress(0, "Working...");
		Decimal lastlast = 0;
		Decimal last = 1;
		Decimal current;
		if (requestedCount >= 1)
		{ AppendNumber(0); }
		if (requestedCount >= 2)
		{ AppendNumber(1); }
		for (int i = 2; i < requestedCount; ++i)
		{
			// Calculate the number.
			checked { current = lastlast + last; }
			// Introduce some delay to simulate a more complicated calculation.
			System.Threading.Thread.Sleep(100);
			AppendNumber(current);
			backgroundWorker.ReportProgress((100 * i) / requestedCount, "Working...");
			// Get ready for the next iteration.
			lastlast = last;
			last = current;
		}


		backgroundWorker.ReportProgress(100, "Complete!");
	}
    // </snippet10>

	private delegate void AppendNumberDelegate(Decimal number);
        // <Snippet3>
	private void AppendNumber(Decimal number)
	{
		if (outputTextBox.InvokeRequired)
		{ outputTextBox.Invoke(new AppendNumberDelegate(AppendNumber), number); }
		else
		{ outputTextBox.AppendText(number.ToString("N0") + Environment.NewLine); }
	}
        // </Snippet3>
	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		toolStripProgressBar.Value = e.ProgressPercentage;
		toolStripStatusLabel.Text = e.UserState as String;
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		if (e.Error is OverflowException)
		{ outputTextBox.AppendText(Environment.NewLine + "**OVERFLOW ERROR, number is too large to be represented by the decimal data type**"); }
		toolStripProgressBar.Enabled = false;
		requestedCountControl.Enabled = true;
		goButton.Enabled = true;

	}

	private void button1_Click(object sender, EventArgs e)
	{
		goButton.Enabled = false;
		toolStripProgressBar.Enabled = true;
		requestedCount = (int)requestedCountControl.Value;
		requestedCountControl.Enabled = false;
		outputTextBox.Clear();
		backgroundWorker.RunWorkerAsync();
	}
}
// </Snippet1>
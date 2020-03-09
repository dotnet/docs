using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class BackgroundWorkerForm : Form
{
    private BackgroundWorker backgroundWorker1;
    private Button button1;
    private TextBox textBox1;

    [STAThread]
    static void Main()
    {
        Application.SetCompatibleTextRenderingDefault(false);
        Application.EnableVisualStyles();
        Application.Run(new BackgroundWorkerForm());
    }
    public BackgroundWorkerForm()
    {
        backgroundWorker1 = new BackgroundWorker();
        backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
        backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
        button1 = new Button
        {
            Location = new Point(15, 55),
            Size = new Size(240, 20),
            Text = "Set text safely with BackgroundWorker"
        };
        button1.Click += new EventHandler(Button1_Click);
        textBox1 = new TextBox
        {
            Location = new Point(15, 15),
            Size = new Size(240, 20)
        };
        Controls.Add(button1);
        Controls.Add(textBox1);
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }

    private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        // Sleep 2 seconds to emulate getting data.
        Thread.Sleep(2000);
        e.Result = "This text was set safely by BackgroundWorker.";
    }

    private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        textBox1.Text = e.Result.ToString();
    }
}

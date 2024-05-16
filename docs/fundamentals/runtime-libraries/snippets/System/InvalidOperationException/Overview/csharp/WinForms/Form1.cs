using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCrossThreadCS
{
    public partial class Form1 : Form
    {
        public static void Main() { }

        public Form1()
        {
            InitializeComponent();
        }

        // <Snippet2>
        List<String> lines = new List<String>();

        private async void threadExampleBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            lines.Clear();

            lines.Add("Simulating work on UI thread.");
            textBox1.Lines = lines.ToArray();
            DoSomeWork(20);

            lines.Add("Simulating work on non-UI thread.");
            textBox1.Lines = lines.ToArray();
            await Task.Run(() => DoSomeWork(1000));

            lines.Add("ThreadsExampleBtn_Click completes. ");
            textBox1.Lines = lines.ToArray();
        }

        private async void DoSomeWork(int milliseconds)
        {
            // simulate work
            await Task.Delay(milliseconds);

            // report completion
            lines.Add(String.Format("Some work completed in {0} ms on UI thread.", milliseconds));
            textBox1.Lines = lines.ToArray();
        }
        // </Snippet2>
    }
}

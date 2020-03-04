using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCrossThreadSolutionCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

        // <Snippet5>
        private async void DoSomeWork(int milliseconds)
        {
            // simulate work
            await Task.Delay(milliseconds);

            // Report completion.
            bool uiMarshal = textBox1.InvokeRequired;
            String msg = String.Format("Some work completed in {0} ms. on {1}UI thread\n",
                                       milliseconds, uiMarshal ? String.Empty : "non-");
            lines.Add(msg);

            if (uiMarshal) {
                textBox1.Invoke(new Action(() => { textBox1.Lines = lines.ToArray(); }));
            }
            else {
                textBox1.Lines = lines.ToArray();
            }
        }
        // </Snippet5>
    }
}

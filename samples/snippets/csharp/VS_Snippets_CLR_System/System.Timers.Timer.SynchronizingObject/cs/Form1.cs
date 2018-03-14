


namespace SynchronizingObjectCS1
{
    // <Snippet1>
    using System;
    using System.IO;
    using  Timers = System.Timers;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        Timers.Timer timer = null;
        StreamWriter sw = null;
        bool hasChanged = false;
        bool dialogIsOpen = false;
        int elapsedMinutes = 0;
        // Cache the text box cache internally without saving it.
        String txt = "";

        public Form1()
        {
            InitializeComponent();

            this.Text = "Quick Text Editor";
            button1.Text = "Save";
            textBox1.Multiline = true;

            // Configure the SaveFile dialog
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            // Create a timer with a 1-minute interval
            timer = new Timers.Timer(60000);
            // Define the event handler
            timer.Elapsed += this.PromptForSave;
            // Synchronize the timer with the text box
            timer.SynchronizingObject = this;
            // Start the timer
            timer.AutoReset = true;
        }

        private void PromptForSave(Object source, Timers.ElapsedEventArgs e)
        {
            if (hasChanged & (!dialogIsOpen)) {
                elapsedMinutes++;
                dialogIsOpen = true;
                if (MessageBox.Show(String.Format("{0} minutes have elapsed since the text was saved. Save it now? ",
                    elapsedMinutes), "Save Text",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    button1_Click(this, EventArgs.Empty);
                    dialogIsOpen = false;
                }
            }
        }

        private void button1_Click(Object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(saveFileDialog1.FileName)) {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    sw = new StreamWriter(saveFileDialog1.FileName, false);
            }
            txt = textBox1.Text;
            hasChanged = false;
            timer.Stop();
        }

        private void form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (sw != null) {
                sw.Write(txt);
                sw.Close();
            }
        }

        private void textBox1_TextChanged(Object sender, EventArgs e)
        {
            hasChanged = true;
            timer.Start();
        }

    }
    // </Snippet1>
}

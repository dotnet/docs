using System;
using System.Drawing;
using System.Windows.Forms;

namespace _831524_CS_TextBox.AutoCompleteCustomSourceProperty
{
    public class Form1 : Form
    {
        public Form1()
        {
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        //<snippet10>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the list to use as the custom source. 
            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
                            {
                                "January",
                                "February",
                                "March",
                                "April",
                                "May",
                                "June",
                                "July",
                                "August",
                                "September",
                                "October",
                                "November",
                                "December"
                            });

            // Create and initialize the text box.
            var textBox = new TextBox
                          {
                              AutoCompleteCustomSource = source,
                              AutoCompleteMode = 
                                  AutoCompleteMode.SuggestAppend,
                              AutoCompleteSource =
                                  AutoCompleteSource.CustomSource,
                              Location = new Point(20, 20),
                              Width = ClientRectangle.Width - 40,
                              Visible = true
                          };

            // Add the text box to the form.
            Controls.Add(textBox);
        }
        //</snippet10>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

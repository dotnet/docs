using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace AutoSizeProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Label urlLabel;
        private TextBox urlTextBox;
        private Button urlButton;
        private FlowLayoutPanel flowPanel;

        //<SNIPPET1>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = "URL Opener";

            flowPanel = new FlowLayoutPanel();
            flowPanel.AutoSize = true;
            flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Controls.Add(flowPanel);

            urlLabel = new Label();
            urlLabel.Name = "urlLabel";
            urlLabel.Text = "URL:";
            urlLabel.Width = 50;
            urlLabel.TextAlign = ContentAlignment.MiddleCenter;
            flowPanel.Controls.Add(urlLabel);

            urlTextBox = new TextBox();
            urlTextBox.Name = "urlTextBox";
            urlTextBox.Width = 250;
            flowPanel.Controls.Add(urlTextBox);

            urlButton = new Button();
            urlButton.Name = "urlButton";
            urlButton.Text = "Open URL in Browser";
            urlButton.Click += new EventHandler(urlButton_Click);
            flowPanel.Controls.Add(urlButton);
        }

        void urlButton_Click(object sender, EventArgs e)
        {
            try
            {
                Uri newUri = new Uri(urlTextBox.Text);
            }
            catch (UriFormatException uriEx)
            {
                MessageBox.Show("Sorry, your URL is malformed. Try again. Error: " + uriEx.Message);
                urlTextBox.ForeColor = Color.Red;
                return;
            }
            
            // Valid URI. Reset any previous error color, and launch the URL in the 
            // default browser.
            // NOTE: Depending on the user's settings, this method of starting the
            // browser may use an existing window in an existing Web browser process.
            // To get around this, start up a specific browser instance instead using one of
            // the overloads for Process.Start. You can examine the registry to find the
            // current default browser and launch that, or hard-code a specific browser.
            urlTextBox.ForeColor = Color.Black;
            Process.Start(urlTextBox.Text);
        }
        //</SNIPPET1>
    }
}
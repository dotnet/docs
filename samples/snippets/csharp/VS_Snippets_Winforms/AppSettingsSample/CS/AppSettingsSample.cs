//AppSettingsSample C# sample, flattened to one file for Parsnip.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;


namespace AppSettingsSample
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			//Application.EnableRTLMirroring();
			Application.Run(new Form1());
		}
	}


	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.btnBackColor = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.tbStatus = new System.Windows.Forms.TextBox();
			this.btnReload = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnBackColor
			// 
			this.btnBackColor.Location = new System.Drawing.Point(26, 24);
			this.btnBackColor.Name = "btnBackColor";
			this.btnBackColor.Size = new System.Drawing.Size(159, 23);
			this.btnBackColor.TabIndex = 0;
			this.btnBackColor.Text = "Change Background Color";
			this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(26, 90);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(159, 23);
			this.btnReset.TabIndex = 1;
			this.btnReset.Text = "Reset to Defaults";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// tbStatus
			// 
			this.tbStatus.Location = new System.Drawing.Point(26, 123);
			this.tbStatus.Name = "tbStatus";
			this.tbStatus.Size = new System.Drawing.Size(159, 20);
			this.tbStatus.TabIndex = 2;
			// 
			// btnReload
			// 
			this.btnReload.Location = new System.Drawing.Point(26, 57);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(159, 23);
			this.btnReload.TabIndex = 3;
			this.btnReload.Text = "Reload from Storage";
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(217, 166);
			this.Controls.Add(this.btnReload);
			this.Controls.Add(this.tbStatus);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnBackColor);
			this.Name = "Form1";
			this.Text = "App Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        //<SNIPPET20>
        private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btnReload;
        //</SNIPPET20>

	}


    //<SNIPPET1>
    partial class Form1 : Form
    {
        private FormSettings frmSettings1 = new FormSettings();

        public Form1()
        {
            InitializeComponent();
        }

        //<SNIPPET2>
        private void Form1_Load(object sender, EventArgs e)
        {
            //<SNIPPET11>
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            //Associate settings property event handlers.
            frmSettings1.SettingChanging += new SettingChangingEventHandler(
                                                frmSettings1_SettingChanging);
            frmSettings1.SettingsSaving += new SettingsSavingEventHandler(
                                                frmSettings1_SettingsSaving);
            //</SNIPPET11>

            //<SNIPPET12>
            //Data bind settings properties with straightforward associations.
            Binding bndBackColor = new Binding("BackColor", frmSettings1, 
                "FormBackColor", true, DataSourceUpdateMode.OnPropertyChanged);
            this.DataBindings.Add(bndBackColor);
            Binding bndLocation = new Binding("Location", frmSettings1, 
                "FormLocation", true, DataSourceUpdateMode.OnPropertyChanged);
            this.DataBindings.Add(bndLocation);

            // Assign Size property, since databinding to Size doesn't work well.
             this.Size = frmSettings1.FormSize;

            //For more complex associations, manually assign associations.
            String savedText = frmSettings1.FormText;
            //Since there is no default value for FormText.
            if (savedText != null)
                this.Text = savedText;
            //</SNIPPET12>
        }
        //</SNIPPET2>

        //<SNIPPET3>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Synchronize manual associations first.
            frmSettings1.FormText = this.Text + '.';
            frmSettings1.FormSize = this.Size;
            frmSettings1.Save();
        }
        //</SNIPPET3>

        //<SNIPPET4>
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                Color c = colorDialog1.Color;
                this.BackColor = c;
            }
        }
        //</SNIPPET4>

        //<SNIPPET5>
        private void btnReset_Click(object sender, EventArgs e)
        {
            frmSettings1.Reset();
            this.BackColor = SystemColors.Control;
        }
        //</SNIPPET5>

        //<SNIPPET6>
        private void btnReload_Click(object sender, EventArgs e)
        {
            frmSettings1.Reload();
        }
        //</SNIPPET6>

        //<SNIPPET7>
        void frmSettings1_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            tbStatus.Text = e.SettingName + ": " + e.NewValue;
        }
        //</SNIPPET7>

        //<SNIPPET8>
        void frmSettings1_SettingsSaving(object sender, CancelEventArgs e)
        {
            //Should check for settings changes first.
            DialogResult dr = MessageBox.Show(
                            "Save current values for application settings?",
                            "Save Settings", MessageBoxButtons.YesNo);
            if (DialogResult.No == dr)
            {
                e.Cancel = true;
            }
        }
        //</SNIPPET8>

    }

    //<SNIPPET9>
    //Application settings wrapper class
    sealed class FormSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        public String FormText
        {
            get { return (String)this["FormText"]; }
            set { this["FormText"] = value; }
        }

        //<SNIPPET10>
        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0, 0")]
        public Point FormLocation
        {
            get { return (Point)(this["FormLocation"]); }
            set { this["FormLocation"] = value; }
        }
        //</SNIPPET10>

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("225, 200")]
        public Size FormSize
        {
            get { return (Size)this["FormSize"]; }
            set { this["FormSize"] = value; }
        }


        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("LightGray")]
        public Color FormBackColor
        {
            get { return (Color)this["FormBackColor"]; }
            set { this["FormBackColor"] = value; }
        }

    }
    //</SNIPPET9>
 
    //</SNIPPET1>
}

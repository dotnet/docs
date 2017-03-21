    partial class Form1 : Form
    {
        private FormSettings frmSettings1 = new FormSettings();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

            //Associate settings property event handlers.
            frmSettings1.SettingChanging += new SettingChangingEventHandler(
                                                frmSettings1_SettingChanging);
            frmSettings1.SettingsSaving += new SettingsSavingEventHandler(
                                                frmSettings1_SettingsSaving);

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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Synchronize manual associations first.
            frmSettings1.FormText = this.Text + '.';
            frmSettings1.FormSize = this.Size;
            frmSettings1.Save();
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorDialog1.ShowDialog())
            {
                Color c = colorDialog1.Color;
                this.BackColor = c;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            frmSettings1.Reset();
            this.BackColor = SystemColors.Control;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            frmSettings1.Reload();
        }

        void frmSettings1_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            tbStatus.Text = e.SettingName + ": " + e.NewValue;
        }

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

    }

    //Application settings wrapper class
    sealed class FormSettings : ApplicationSettingsBase
    {
        [UserScopedSettingAttribute()]
        public String FormText
        {
            get { return (String)this["FormText"]; }
            set { this["FormText"] = value; }
        }

        [UserScopedSettingAttribute()]
        [DefaultSettingValueAttribute("0, 0")]
        public Point FormLocation
        {
            get { return (Point)(this["FormLocation"]); }
            set { this["FormLocation"] = value; }
        }

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
 
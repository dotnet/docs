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
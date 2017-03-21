        void frmSettings1_SettingChanging(object sender, SettingChangingEventArgs e)
        {
            tbStatus.Text = e.SettingName + ": " + e.NewValue;
        }
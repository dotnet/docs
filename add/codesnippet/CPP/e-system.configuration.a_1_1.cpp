    private:
        void FormSettings_SettingsSaving(Object^ sender,
            CancelEventArgs^ e)
        {
            //Should check for settings changes first.
            ::DialogResult^ dialogResult = MessageBox::Show(
                "Save current values for application settings?",
                "Save Settings", MessageBoxButtons::YesNo);
            if (::DialogResult::No == dialogResult)
            {
                e->Cancel = true;
            }
        }
    private:
        void FormSettings_SettingChanging(Object^ sender,
            SettingChangingEventArgs^ e)
        {
            statusDisplay->Text = e->SettingName + ": " + e->NewValue;
        }
    private:
        void AppSettingsForm_FormClosing(Object^ sender,
            FormClosingEventArgs^ e)
        {
            //Synchronize manual associations first.
            formSettings->FormText = this->Text + '.';
            formSettings->Save();
        }
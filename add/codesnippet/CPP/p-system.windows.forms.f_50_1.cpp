private:
    void wrapContentsCheckBox_CheckedChanged(
        System::Object^ sender, System::EventArgs^ e)
    {
        this->flowLayoutPanel1->WrapContents =
            this->wrapContentsCheckBox->Checked;
    }
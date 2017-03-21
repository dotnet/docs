    private:
        void ResetButton_Click(Object^ sender, EventArgs^ e)
        {
            formSettings->Reset();
            this->BackColor = SystemColors::Control;
        }
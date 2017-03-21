
    private:
        void Button2_Click(System::Object^ sender,
            System::EventArgs^ e)
        {
            Button2->Font = gcnew System::Drawing::Font
                (FontFamily::GenericMonospace, 12.0F,
                FontStyle::Italic, GraphicsUnit::Pixel);
        }
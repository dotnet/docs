    private:
        void ComboBox1_SelectedIndexChanged(System::Object^ sender,
            System::EventArgs^ e)
        {

            // Cast the sender object back to a ComboBox.
            ComboBox^ ComboBox1 = (ComboBox^) sender;

            // Retrieve the selected item.
            String^ selectedString = (String^) ComboBox1->SelectedItem;

            // Convert it to lowercase.
            selectedString = selectedString->ToLower();

            // Declare the current size.
            float currentSize;

            // If Bigger is selected, get the current size from the 
            // Size property and increase it. Reset the font to the
            //  new size, using the current unit.
            if (selectedString == "bigger")
            {
                currentSize = Label1->Font->Size;
                currentSize += 2.0F;
                Label1->Font =gcnew System::Drawing::Font(Label1->Font->Name, 
                    currentSize, Label1->Font->Style, Label1->Font->Unit);

            }
            // If Smaller is selected, get the current size, in
            // points, and decrease it by 2.  Reset the font with
            // the new size in points.
            if (selectedString == "smaller")
            {
                currentSize = Label1->Font->Size;
                currentSize -= 2.0F;
                Label1->Font = gcnew System::Drawing::Font(Label1->Font->Name, 
                    currentSize, Label1->Font->Style);

            }
        }
        // Declare the drop-down button and the items it will contain.
        ToolStripDropDownButton^ dropDownButton1;
        ToolStripDropDown^ dropDown;
        ToolStripButton^ buttonRed;
        ToolStripButton^ buttonBlue;
        ToolStripButton^ buttonYellow;

        void InitializeDropDownButton()
        {
            dropDownButton1 = gcnew ToolStripDropDownButton;
            dropDown = gcnew ToolStripDropDown;
            dropDownButton1->Text = "A";

            // Set the drop-down on the DropDownButton.
            dropDownButton1->DropDown = dropDown;

            // Declare three buttons, set their forecolor and text, 
            // and add the buttons to the drop-down.
            buttonRed = gcnew ToolStripButton;
            buttonRed->ForeColor = Color::Red;
            buttonRed->Text = "A";
            buttonBlue = gcnew ToolStripButton;
            buttonBlue->ForeColor = Color::Blue;
            buttonBlue->Text = "A";
            buttonYellow = gcnew ToolStripButton;
            buttonYellow->ForeColor = Color::Yellow;
            buttonYellow->Text = "A";
            buttonBlue->Click += gcnew EventHandler(this, 
                &Form1::colorButtonsClick);
            buttonRed->Click += gcnew EventHandler(this, 
                &Form1::colorButtonsClick);
            buttonYellow->Click += gcnew EventHandler(this, 
                &Form1::colorButtonsClick);
            array<ToolStripItem^>^ ToolStrips = 
                {buttonRed,buttonBlue,buttonYellow};
            dropDown->Items->AddRange(ToolStrips);
            toolStrip1->Items->Add(dropDownButton1);
        }


        // Handle the buttons' click event by setting the forecolor 
        // of the form to the forecolor of the button that is clicked.
        void colorButtonsClick(Object^ sender, EventArgs^ e)
        {
            ToolStripButton^ senderButton = (ToolStripButton^) sender;
            this->ForeColor = senderButton->ForeColor;
        }


        //  internal:

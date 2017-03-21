        ToolStripButton^ boldButton;

        void InitializeBoldButton()
        {
            boldButton = gcnew ToolStripButton;
            boldButton->Text = "B";
            boldButton->CheckOnClick = true;
            boldButton->CheckedChanged  += gcnew EventHandler(this, 
                &Form1::boldButtonCheckedChanged);
            toolStrip1->Items->Add(boldButton);
        }

        void boldButtonCheckedChanged(Object^ sender, EventArgs^ e)
        {
            if (boldButton->Checked)
            { 
                this->Font= gcnew System::Drawing::Font(this->Font, 
                    FontStyle::Bold);
            }
            else
            { 
                this->Font = gcnew System::Drawing::Font(this->Font, 
                    FontStyle::Regular);
            }
        }


        //   internal:

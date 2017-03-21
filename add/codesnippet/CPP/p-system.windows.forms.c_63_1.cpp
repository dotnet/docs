         System::Windows::Forms::ColorDialog^ MyDialog = gcnew ColorDialog;

         // Allows the user to select or edit a custom color.
         MyDialog->AllowFullOpen = true;

         // Assigns an array of custom colors to the CustomColors property
         array<int>^temp0 = {6916092,15195440,16107657,1836924,3758726,12566463,7526079,7405793,6945974,241502,2296476,5130294,3102017,7324121,14993507,11730944};
         MyDialog->CustomColors = temp0;

         // Allows the user to get help. (The default is false.)
         MyDialog->ShowHelp = true;

         // Sets the initial color select to the current text color,
         // so that if the user cancels out, the original color is restored.
         MyDialog->Color = this->BackColor;
         MyDialog->ShowDialog();
         this->BackColor = MyDialog->Color;
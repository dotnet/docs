        private void CharacterRangeEquality1()
        {

            // Declare the string to draw.
            string message = "Strings or strings; that is the question.";

            // Compare the ranges for equality. The should not be equal.
            CharacterRange range1 = 
                new CharacterRange(message.IndexOf("Strings"), "Strings".Length);
            CharacterRange range2 = 
                new CharacterRange(message.IndexOf("strings"), "strings".Length);

            if (range1 == range2)
                MessageBox.Show("The ranges are equal.");
            else
                MessageBox.Show("The ranges are not equal.");
    
        }
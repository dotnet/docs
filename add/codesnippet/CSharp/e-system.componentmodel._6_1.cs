        // Create a new part from the text in the two text boxes.
        void listOfParts_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Part(textBox1.Text, int.Parse(textBox2.Text));
            
        }
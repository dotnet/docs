        static void DisplayInWord()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            // docs is a collection of all the Document objects currently 
            // open in Word.
            Word.Documents docs = wordApp.Documents;

            // Add a document to the collection and name it doc. 
            Word.Document doc = docs.Add();
        }
        static void CreateIconInWordDoc()
        {
            var wordApp = new Word.Application();
            wordApp.Visible = true;

            // The Add method has four reference parameters, all of which are 
            // optional. Visual C# allows you to omit arguments for them if
            // the default values are what you want.
            wordApp.Documents.Add();

            // PasteSpecial has seven reference parameters, all of which are 
            // optional. This example uses named arguments to specify values 
            // for two of the parameters. Although these are reference 
            // parameters, you do not need to use the ref keyword, or to create 
            // variables to send in as arguments. You can send the values directly.
            wordApp.Selection.PasteSpecial( Link: true, DisplayAsIcon: true);
        }
            var wordApp = new Word.Application();
            wordApp.Visible = true;
            wordApp.Documents.Add();
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
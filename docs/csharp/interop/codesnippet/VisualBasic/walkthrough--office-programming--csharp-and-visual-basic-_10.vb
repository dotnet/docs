        Dim wordApp As New Word.Application
        wordApp.Visible = True
        wordApp.Documents.Add()
        wordApp.Selection.PasteSpecial(Link:=True, DisplayAsIcon:=True)
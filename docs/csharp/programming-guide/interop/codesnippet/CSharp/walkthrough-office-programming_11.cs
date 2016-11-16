            // Call to PasteSpecial in Visual C# 2008.
            object iconIndex = Type.Missing;
            object link = true;
            object placement = Type.Missing;
            object displayAsIcon = true;
            object dataType = Type.Missing;
            object iconFileName = Type.Missing;
            object iconLabel = Type.Missing;
            wordApp.Selection.PasteSpecial(ref iconIndex,
                                           ref link,
                                           ref placement,
                                           ref displayAsIcon,
                                           ref dataType,
                                           ref iconFileName,
                                           ref iconLabel);

            // Call to PasteSpecial in Visual C# 2010.
            wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
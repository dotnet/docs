            // In Visual C# 2008, you cannot access the Range, Offset, and Value
            // properties directly.
            excelApp.get_Range("A1").Value2 = "ID";
            excelApp.ActiveCell.get_Offset(1, 0).Select();
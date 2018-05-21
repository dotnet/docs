            // Visual C# 2010 provides indexed properties for COM programming.
            excelApp.Range["A1"].Value = "ID";
            excelApp.ActiveCell.Offset[1, 0].Select();
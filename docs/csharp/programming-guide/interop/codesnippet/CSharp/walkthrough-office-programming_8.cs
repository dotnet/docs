            // Casting is required in Visual C# 2008.
            ((Excel.Range)excelApp.Columns[1]).AutoFit();

            // Casting is not required in Visual C# 2010.
            excelApp.Columns[1].AutoFit();